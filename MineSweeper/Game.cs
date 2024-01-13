using MineSweeper.AppConstants;
using MineSweeper.Command;
using MineSweeper.Validator;
using System.Text;

namespace MineSweeper
{
    public class Game
    {
        private readonly IInputOutputCommand _inputOutputCommand;
        private readonly IInputValidator _inputValidator;
        private readonly MineField _mineField;

        public Game(IInputOutputCommand inputOutputCommand, IInputValidator inputValidator) 
        { 
            _inputOutputCommand = inputOutputCommand;
            _inputValidator = inputValidator;
            _mineField = new MineField();
        }

        public void Run()
        {
            var gridSize = PromptGridSize();
            var numberOfMines = PromptNumberOfMines(gridSize);

            _mineField.Initialize(gridSize, numberOfMines);
            DisplayMineField();

            PlayGame();
        }

        public int PromptGridSize()
        {
            var gridSize = _inputOutputCommand.PromptUser(ConsoleCommandConstants.EnterGridSize);

            var res = _inputValidator.ValidateGridSize(gridSize);

            if (!res.IsSuccess)
            {
                _inputOutputCommand.DisplayError(res.Errors);
                return PromptGridSize();
            }

            return res.Result;
        }

        public int PromptNumberOfMines(int gridSize)
        {
            var numberOfMines = _inputOutputCommand.PromptUser(ConsoleCommandConstants.EnterNumberOfMines);

            var res = _inputValidator.ValidateNumberOfMines(numberOfMines, gridSize);

            if (!res.IsSuccess)
            {
                _inputOutputCommand.DisplayError(res.Errors);
                return PromptNumberOfMines(gridSize);
            }

            return res.Result;
        }

        public void PlayGame()
        {
            var selectedSquare = PromptSquareSelection();
        }

        public MineSquare PromptSquareSelection()
        {
            var input = _inputOutputCommand.PromptUser(ConsoleCommandConstants.SelectSquareToReveale);

            var res = _inputValidator.ValidateSquareSelection(input, _mineField.GridSize);

            if (!res.IsSuccess)
            {
                _inputOutputCommand.DisplayError(res.Errors);
                return PromptSquareSelection();
            }

            return res.Result;
        }

        public void DisplayMineField()
        {
            _inputOutputCommand.Display("");
            _inputOutputCommand.Display(ConsoleCommandConstants.DisplayMineField);

            var asciiA = Convert.ToInt32(MineSweeperConstants.CharacterA);
            var sb = new StringBuilder();
            for (var i=-1; i<_mineField.GridSize; i++)
            {
                var row = new List<string>();
                for (var j = -1; j < _mineField.GridSize; j++)
                {
                    if(i == -1)
                    {
                        if(j == -1)
                        {
                            row.Add(" ");
                        }
                        else
                        {
                            row.Add((j + 1).ToString());
                        }
                    }
                    else
                    {
                        if(j == -1)
                        {
                            row.Add(((char)(asciiA + i)).ToString());
                        }
                        else
                        {
                            var mineSquare = _mineField.Squares.Single(s => s.X == i && s.Y == j);
                            if (!mineSquare.IsRevealed)
                            {
                                row.Add("_");
                            }
                            else
                            {
                                row.Add(mineSquare.NumberOfMinesAround.ToString());
                            }
                        }
                    }
                    
                }
                var s = string.Join(" ", row);
                sb.Append(s);
                sb.AppendLine();
            }

            _inputOutputCommand.Display(sb.ToString());
        }
    }
}
