using MineSweeper.Commands;

namespace MineSweeper
{
    public class Game
    {
        private readonly IUserCommand _userCommand;
        private readonly MineField _mineField;

        public Game(IUserCommand userCommand, MineField mineField) 
        {
            _userCommand = userCommand;
            _mineField = mineField;
        }

        public void Run()
        {
            while (true)
            {
                PlayGame();
            }
        }

        public void PlayGame()
        {
            var gridSize = _userCommand.PromptGridSize();
            var numberOfMines = _userCommand.PromptNumberOfMines(gridSize);

            _mineField.Initialize(gridSize, numberOfMines);
            _userCommand.DisplayMineField(_mineField);

            while (true)
            {
                var squarePosition = _userCommand.PromptSquareSelection(gridSize);
                var mineSquare = _mineField.GetSquareByPosition(squarePosition.Item1, squarePosition.Item2);

                if (mineSquare.IsMine)
                {
                    _userCommand.PromptPlayAgain(false);
                    break;
                }

                var adjacentMines = _mineField.RevealSquare(squarePosition.Item1, squarePosition.Item2);
                _mineField.UpdateMineField(mineSquare);

                _userCommand.DisplayAdjacentMinesAndMineField(_mineField, adjacentMines);

                var allRevealed = _mineField.CheckAllMinesRevealed();
                if (allRevealed)
                {
                    _userCommand.PromptPlayAgain(true);
                    break;
                }
            }

        }
    }
}
