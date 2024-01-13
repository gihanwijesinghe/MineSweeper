using MineSweeper.AppConstants;
using MineSweeper.Command;
using MineSweeper.Validator;
namespace MineSweeper
{
    public class Game
    {
        private readonly IInputOutputCommand _inputOutputCommand;
        private readonly IInputValidator _inputValidator;

        public Game(IInputOutputCommand inputOutputCommand, IInputValidator inputValidator) 
        { 
            _inputOutputCommand = inputOutputCommand;
            _inputValidator = inputValidator;
        }

        public void Run()
        {
            var gridSize = PromptGridSize();
            var numberOfMines = PromptNumberOfMines(gridSize);
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
    }
}
