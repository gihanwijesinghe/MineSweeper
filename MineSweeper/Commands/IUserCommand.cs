namespace MineSweeper.Commands
{
    public interface IUserCommand
    {
        int PromptGridSize();
        int PromptNumberOfMines(int gridSize);
        (int, int) PromptSquareSelection(int gridSize);
        void DisplayMineField(MineField mineField);
        void DisplayMineFieldWithVals(MineField mineField);
    }
}
