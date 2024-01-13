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
                return FunctionResult<int>.Fail(new FunctionError { Message = ErrorMessageConstants.NotAPositiveInteger });
            }

            return FunctionResult<int>.Success(int.Parse(input));
        }
    }
}
