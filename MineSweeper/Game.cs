using MineSweeper.AppConstants;
using MineSweeper.Commands;
using MineSweeper.Operations;

namespace MineSweeper
{
    public class Game
    {
        private readonly IUserCommand _userCommand;
        private readonly IInputOutput _inputOutput;
        private readonly MineField _mineField;

        public Game(IUserCommand userCommand, IInputOutput inputOutput, MineField mineField) 
        {
            _userCommand = userCommand;
            _inputOutput = inputOutput;
            _mineField = mineField;
        }

        public void Run()
        {
            _inputOutput.Display(MineSweeperConstants.WelcomeMessage);
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

            SelectSquareAndRevealMineField();
        }

        public void SelectSquareAndRevealMineField()
        {
            while (true)
            {
                var mineSquare = SelectSquare();
                if (mineSquare.IsMine)
                {
                    _userCommand.PromptPlayAgain(false);
                    break;
                }

                RevealUpdateAndDisplayMinField(mineSquare);

                var allRevealed = _mineField.CheckAllMinesRevealed();
                if (allRevealed)
                {
                    _userCommand.PromptPlayAgain(true);
                    break;
                }
            }
        }

        public MineSquare SelectSquare()
        {
            var squarePosition = _userCommand.PromptSquareSelection(_mineField.GridSize);
            return _mineField.GetSquareByPosition(squarePosition.Item1, squarePosition.Item2);
        }

        public void RevealUpdateAndDisplayMinField(MineSquare mineSquare)
        {
            var adjacentMines = _mineField.RevealSquare(mineSquare);
            _mineField.UpdateMineField(mineSquare);

            _userCommand.DisplayAdjacentMinesAndMineField(_mineField, adjacentMines);
        }
    }
}
