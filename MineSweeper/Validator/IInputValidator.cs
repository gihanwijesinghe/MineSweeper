using MineSweeper.Helper;

namespace MineSweeper.Validator
{
    public interface IInputValidator
    {
        FunctionResult<int> ValidateGridSize(string input);
        FunctionResult<int> ValidateNumberOfMines(string input, int gridSize);
    }
}
