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
    }
}
