using MineSweeper.AppConstants;
using MineSweeper.Helper;

namespace MineSweeper.Validator
{
    public class InputValidator : IInputValidator
    {
        //private const string PositiveInteger = "^[1-9][0-9]*$";

        public FunctionResult<int> ValidateGridSize(string input)
        {
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

        public FunctionResult<int> ValidateNumberOfMines(string input, int gridSize)
        {
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

        public FunctionResult<MineSquare> ValidateSquareSelection(string input, int gridSize)
        {
            if(string.IsNullOrEmpty(input) || input.Length != 2)
            {
                return FunctionResult<MineSquare>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            var val1 = Convert.ToInt32(input[0]);
            var asciiMinValue = Convert.ToInt32(MineSweeperConstants.CharacterA);
            var asciiMaxValue = asciiMinValue + gridSize-1;

            if (val1 < asciiMinValue || val1 > asciiMaxValue)
            {
                return FunctionResult<MineSquare>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            var isInteger = char.IsDigit(input[1]);
            if (!isInteger)
            {
                return FunctionResult<MineSquare>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            var val2 = int.Parse(input[1].ToString());
            if (val2 < 1 || val2 > gridSize)
            {
                return FunctionResult<MineSquare>.Fail(new FunctionError { Message = ErrorMessageConstants.IncorrectInput });
            }

            return FunctionResult<MineSquare>.Success(new MineSquare(val1, val2));
        }
    }
}
