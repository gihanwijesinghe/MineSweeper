using MineSweeper.Models;

namespace MineSweeper.Commands
{
    public interface IUserCommand
    {
        int PromptGridSize();
        int PromptNumberOfMines(int gridSize);
        (int, int) PromptSquareSelection(int gridSize);
        bool PromptPlayAgain(bool won, bool playAgain);
        void DisplayMineField(MineField mineField);
        void DisplayAdjacentMinesAndMineField(MineField mineField, int adjacentMines);
        void DisplayMineFieldWithVals(MineField mineField);
    }
}
