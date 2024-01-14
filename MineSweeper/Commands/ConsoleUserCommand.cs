using MineSweeper.AppConstants;
using MineSweeper.Validator;
using System.Text;

namespace MineSweeper.Commands
{
    public class ConsoleUserCommand : IUserCommand
    {
        private readonly IInputOutput _inputOutput;
        private readonly IInputValidator _inputValidator;

        public ConsoleUserCommand(IInputValidator inputValidator) 
        { 
            _inputValidator = inputValidator;
            _inputOutput = new ConsoleInputOutput();
        }

        public int PromptGridSize()
        {
            var gridSize = _inputOutput.PromptQuestion(ConsoleCommandConstants.EnterGridSize);

            var res = _inputValidator.ValidateAndGetGridSize(gridSize);

            if (!res.IsSuccess)
            {
                _inputOutput.DisplayError(res.Errors);
                return PromptGridSize();
            }

            return res.Result;
        }

        public (int, int) PromptSquareSelection(int gridSize)
        {
            var input = _inputOutput.PromptQuestion(ConsoleCommandConstants.SelectSquareToReveale);

            var res = _inputValidator.ValidateAndGetSquarePositions(input, gridSize);

            if (!res.IsSuccess)
            {
                _inputOutput.DisplayError(res.Errors);
                return PromptSquareSelection(gridSize);
            }

            return res.Result;
        }

        public int PromptNumberOfMines(int gridSize)
        {
            var numberOfMines = _inputOutput.PromptQuestion(ConsoleCommandConstants.EnterNumberOfMines);

            var res = _inputValidator.ValidateAndGetNumberOfMines(numberOfMines, gridSize);

            if (!res.IsSuccess)
            {
                _inputOutput.DisplayError(res.Errors);
                return PromptNumberOfMines(gridSize);
            }

            return res.Result;
        }

        public void PromptPlayAgain(bool won)
        {
            if (won)
            {
                _inputOutput.Display(ConsoleCommandConstants.CongratulationsWon);
            }
            else
            {
                _inputOutput.Display(ErrorMessageConstants.GameOverWithRevealingMine);
            }

            _inputOutput.PromptKey(ConsoleCommandConstants.PressAnyToPlayAgain);
        }

        public void DisplayAdjacentMinesAndMineField(MineField mineField, int adjacentMines)
        {
            _inputOutput.Display($"This square contains {adjacentMines} adjacent mines.");
            _inputOutput.Display(ConsoleCommandConstants.HereIsUpdatedMinField);
            DisplayMineField(mineField);
        }

        public void DisplayMineField(MineField mineField)
        {
            _inputOutput.Display("");
            _inputOutput.Display(ConsoleCommandConstants.DisplayMineField);

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

            _inputOutput.Display(sb.ToString());
        }

        public void DisplayMineFieldWithVals(MineField mineField)
        {
            _inputOutput.Display("");
            _inputOutput.Display(ConsoleCommandConstants.DisplayMineField);

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

            _inputOutput.Display(sb.ToString());
        }
    }
}
