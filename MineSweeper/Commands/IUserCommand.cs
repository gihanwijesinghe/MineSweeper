namespace MineSweeper.Commands
{
    public interface IUserCommand
    {
        int PromptGridSize();
        int PromptNumberOfMines(int gridSize);
        (int, int) PromptSquareSelection(int gridSize);
        void PromptPlayAgain(bool won);
        void DisplayMineField(MineField mineField);
        void DisplayMineFieldWithVals(MineField mineField);
    }
}
