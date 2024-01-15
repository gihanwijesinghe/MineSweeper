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
        public readonly MineGame MineGame;

        public GameGenerator(IUserCommand userCommand, IInputOutput inputOutput, MineFieldGenerator mineFieldGenerator) 
        {
            _userCommand = userCommand;
            _inputOutput = inputOutput;
            _mineFieldGenerator = mineFieldGenerator;
            MineGame = new MineGame();
        }

        public void Run()
        {
            _inputOutput.Display(MineSweeperConstants.WelcomeMessage);

            MineGame.State = GameState.Running;
            while (MineGame.State == GameState.Running)
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
                    PlayAgain(GameResult.Lose);
                    break;
                }

                RevealUpdateAndDisplayMinField(mineSquare);

                var allRevealed = _mineFieldGenerator.CheckAllMinesRevealed();
                if (allRevealed)
                {
                    PlayAgain(GameResult.Win);
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

        public void PlayAgain(GameResult gameResult)
        {
            MineGame.CurrentResult = gameResult;
            var playAgain = true;

            switch (gameResult)
            {
                case GameResult.Win:
                    playAgain = _userCommand.PromptPlayAgain(true, true);
                    break;
                case GameResult.Lose:
                    playAgain = _userCommand.PromptPlayAgain(false, true);
                    break;
                default: break;
            }
            if (!playAgain)
            {
                MineGame.State = GameState.Stop;
            }
        }
    }
}
