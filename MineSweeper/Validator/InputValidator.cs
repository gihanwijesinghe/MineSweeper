using MineSweeper.AppConstants;
using MineSweeper.Helper.FunctionsHelper;

namespace MineSweeper.Validator
{
    public class InputValidator : IInputValidator
    {
        //private const string PositiveInteger = "^[1-9][0-9]*$";
        private FunctionResult<bool> ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return FunctionResult<bool>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            return FunctionResult<bool>.Success(true);
        }

        public FunctionResult<int> ValidateAndGetGridSize(string input)
        {
            var res = ValidateInput(input);
            if(!res.IsSuccess)
            {
                return FunctionResult<int>.Fail(res.Errors.ToList());
            }

            var isInteger = input.All(char.IsDigit);
            if (!isInteger)
            {
                return FunctionResult<int>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            var val = int.Parse(input);
            if (val < 2)
            {
                return FunctionResult<int>.Fail(new FunctionError { Message = ErrorMessageConstants.LessThanMinimumGridSize });
            }
            if (val > 10)
            {
                return FunctionResult<int>.Fail(new FunctionError { Message = ErrorMessageConstants.MoreThanMaximumGridSize });
            }

            return FunctionResult<int>.Success(int.Parse(input));
        }

        public FunctionResult<int> ValidateAndGetNumberOfMines(string input, int gridSize)
        {
            var res = ValidateInput(input);
            if (!res.IsSuccess)
            {
                return FunctionResult<int>.Fail(res.Errors.ToList());
            }

            var isInteger = input.All(char.IsDigit);
            if (!isInteger)
            {
                return FunctionResult<int>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            var val = int.Parse(input);

            if(val == 0)
            {
                return FunctionResult<int>.Fail(new FunctionError { Message = ErrorMessageConstants.ShouldHaveAtleastOneMine });
            }

            if(val*100/(gridSize*gridSize) > MineSweeperConstants.MinesToSquaresMaxPercentage)
            {
                return FunctionResult<int>.Fail(new FunctionError { Message = ErrorMessageConstants.MaximumMinesError });
            }

            return FunctionResult<int>.Success(int.Parse(input));
        }

        public FunctionResult<(int, int)> ValidateAndGetSquarePositions(string input, int gridSize)
        {
            var res = ValidateInput(input);
            if (!res.IsSuccess)
            {
                return FunctionResult<(int, int)>.Fail(res.Errors.ToList());
            }

            if (string.IsNullOrEmpty(input) || input.Length != 2)
            {
                return FunctionResult<(int, int)>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            var val1 = Convert.ToInt32(input[0]);
            var asciiMinValue = Convert.ToInt32(MineSweeperConstants.CharacterA);
            var asciiMaxValue = asciiMinValue + gridSize-1;

            if (val1 < asciiMinValue || val1 > asciiMaxValue)
            {
                return FunctionResult<(int, int)>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            var isInteger = char.IsDigit(input[1]);
            if (!isInteger)
            {
                return FunctionResult<(int, int)>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            var val2 = int.Parse(input[1].ToString());
            if (val2 < 1 || val2 > gridSize)
            {
                return FunctionResult<(int, int)>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            return FunctionResult<(int, int)>.Success((val1 - asciiMinValue, val2-1));
        }
    }
}
