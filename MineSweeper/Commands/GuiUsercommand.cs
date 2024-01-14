using MineSweeper.Models;

namespace MineSweeper.Commands
{
    //TODO: Implement functionality for GUI user interface commands accordingly
    public class GuiUsercommand : IUserCommand
    {
        public void DisplayAdjacentMinesAndMineField(MineField mineField, int adjacentMines)
        {
            throw new NotImplementedException();
        }

        public void DisplayMineField(MineField mineField)
        {
            throw new NotImplementedException();
        }

        public void DisplayMineFieldWithVals(MineField mineField)
        {
            throw new NotImplementedException();
        }

        public int PromptGridSize()
        {
            throw new NotImplementedException();
        }

        public int PromptNumberOfMines(int gridSize)
        {
            throw new NotImplementedException();
        }

        public void PromptPlayAgain(bool won)
        {
            throw new NotImplementedException();
        }

        public (int, int) PromptSquareSelection(int gridSize)
        {
            throw new NotImplementedException();
        }
    }
}
