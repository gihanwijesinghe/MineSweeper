using MineSweeper.Commands;
using MineSweeper.Models;

namespace MineSweeperTests
{
    public class MockUserCommand : IUserCommand
    {
        public void DisplayAdjacentMinesAndMineField(MineField mineField, int adjacentMines)
        {
            
        }

        public void DisplayMineField(MineField mineField)
        {
            
        }

        public void DisplayMineFieldWithVals(MineField mineField)
        {
            
        }

        public int PromptGridSize()
        {
            return 3;
        }

        public int PromptNumberOfMines(int gridSize)
        {
            return gridSize;
        }

        public bool PromptPlayAgain(bool won, bool playAgain)
        {
            return false;
        }

        public (int, int) PromptSquareSelection(int gridSize)
        {
            return (0, 0);
        }
    }
}
