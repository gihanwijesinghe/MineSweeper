using MineSweeper.AppConstants;
using MineSweeper.Commands;
using MineSweeper.Models;
using MineSweeper.Operations;

namespace MineSweeper
{
    public class GameGenerator
    {
        private readonly IUserCommand _userCommand;
        private readonly IInputOutput _inputOutput;
        private readonly MineFieldGenerator _mineFieldGenerator;

        public GameGenerator(IUserCommand userCommand, IInputOutput inputOutput, MineFieldGenerator mineFieldGenerator) 
        {
            _userCommand = userCommand;
            _inputOutput = inputOutput;
            _mineFieldGenerator = mineFieldGenerator;
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

            _mineFieldGenerator.Initialize(gridSize, numberOfMines);
            _userCommand.DisplayMineField(_mineFieldGenerator.MineField);

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

                var allRevealed = _mineFieldGenerator.CheckAllMinesRevealed();
                if (allRevealed)
                {
                    _userCommand.PromptPlayAgain(true);
                    break;
                }
            }
        }

        public MineSquare SelectSquare()
        {
            var _mineField = _mineFieldGenerator.MineField;
            var squarePosition = _userCommand.PromptSquareSelection(_mineField.GridSize);
            return _mineFieldGenerator.GetSquareByPosition(squarePosition.Item1, squarePosition.Item2);
        }

        public void RevealUpdateAndDisplayMinField(MineSquare mineSquare)
        {
            var adjacentMines = _mineFieldGenerator.RevealSquare(mineSquare);
            _mineFieldGenerator.UpdateMineField(mineSquare);

            var _mineField = _mineFieldGenerator.MineField;
            _userCommand.DisplayAdjacentMinesAndMineField(_mineField, adjacentMines);
        }
    }
}
