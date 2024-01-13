using MineSweeper.AppConstants;
using MineSweeper.Validator;
using System.Text;

namespace MineSweeper.Commands
{
    public class ConsoleUserCommand : IUserCommand
    {
        private readonly IInputOutputCommand _inputOutputCommand;
        private readonly IInputValidator _inputValidator;

        public ConsoleUserCommand(IInputValidator inputValidator) 
        { 
            _inputValidator = inputValidator;
            _inputOutputCommand = new ConsoleCommand();
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

        public (int, int) PromptSquareSelection(int gridSize)
        {
            var input = _inputOutputCommand.PromptUser(ConsoleCommandConstants.SelectSquareToReveale);

            var res = _inputValidator.ValidateSquareSelection(input, gridSize);

            if (!res.IsSuccess)
            {
                _inputOutputCommand.DisplayError(res.Errors);
                return PromptSquareSelection(gridSize);
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

        public void DisplayMineField(MineField mineField)
        {
            _inputOutputCommand.Display("");
            _inputOutputCommand.Display(ConsoleCommandConstants.DisplayMineField);

            var asciiA = Convert.ToInt32(MineSweeperConstants.CharacterA);
            var sb = new StringBuilder();
            for (var i = -1; i < mineField.GridSize; i++)
            {
                var row = new List<string>();
                for (var j = -1; j < mineField.GridSize; j++)
                {
                    if (i == -1)
                    {
                        if (j == -1)
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
                        if (j == -1)
                        {
                            row.Add(((char)(asciiA + i)).ToString());
                        }
                        else
                        {
                            var mineSquare = mineField.Squares.Single(s => s.X == i && s.Y == j);
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

        public void DisplayMineFieldWithVals(MineField mineField)
        {
            _inputOutputCommand.Display("");
            _inputOutputCommand.Display(ConsoleCommandConstants.DisplayMineField);

            var asciiA = Convert.ToInt32(MineSweeperConstants.CharacterA);
            var sb = new StringBuilder();
            for (var i = -1; i < mineField.GridSize; i++)
            {
                var row = new List<string>();
                for (var j = -1; j < mineField.GridSize; j++)
                {
                    if (i == -1)
                    {
                        if (j == -1)
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
                        if (j == -1)
                        {
                            row.Add(((char)(asciiA + i)).ToString());
                        }
                        else
                        {
                            var mineSquare = mineField.Squares.Single(s => s.X == i && s.Y == j);
                            if (mineSquare.IsMine)
                            {
                                row.Add("*");
                            }
                            else
                            {
                                if (mineSquare.IsRevealed)
                                {
                                    row.Add(mineSquare.NumberOfMinesAround.ToString());
                                }
                                else
                                {
                                    row.Add("?");
                                }

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
