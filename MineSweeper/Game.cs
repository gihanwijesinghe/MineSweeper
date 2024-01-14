using MineSweeper.AppConstants;
using MineSweeper.Commands;

namespace MineSweeper
{
    public class Game
    {
        private readonly IInputOutput _inputOutput;
        private readonly IUserCommand _userCommand;
        private readonly MineField _mineField;

        public Game(IInputOutput inputOutput, IUserCommand userCommand) 
        { 
            _inputOutput= inputOutput;
            _userCommand = userCommand;
            _mineField = new MineField();
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
            //_userCommand.DisplayMineFieldWithVals(_mineField);

            while (true)
            {
                var squarePosition = _userCommand.PromptSquareSelection(gridSize);
                var mineSquare = _mineField.GetSquareByPosition(squarePosition.Item1, squarePosition.Item2);

                if (mineSquare.IsMine)
                {
                    _userCommand.PromptPlayAgain(false);
                    break;
                }

                var adjucentMines = _mineField.RevealSquare(squarePosition.Item1, squarePosition.Item2);
                _inputOutput.Display($"This square contains {adjucentMines} adjacent mines.");
                _mineField.UpdateMineField(mineSquare);
                _inputOutput.Display(ConsoleCommandConstants.HereIsUpdatedMinField);
                //_userCommand.DisplayMineFieldWithVals(_mineField);
                _userCommand.DisplayMineField(_mineField);

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
