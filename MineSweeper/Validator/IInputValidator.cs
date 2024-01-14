using MineSweeper.Helper.FunctionsHelper;

namespace MineSweeper.Validator
{
    public interface IInputValidator
    {
        FunctionResult<int> ValidateAndGetGridSize(string input);
        FunctionResult<int> ValidateAndGetNumberOfMines(string input, int gridSize);
        FunctionResult<(int, int)> ValidateAndGetSquarePositions(string input, int gridSize);
    }
}
