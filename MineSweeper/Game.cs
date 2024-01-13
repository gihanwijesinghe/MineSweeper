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
            var gridSize = PromptGridSize(ConsoleCommandConstants.EnterGridSize);
        }

        public int PromptGridSize(string promptMessage)
        {
            var gridSize = _inputOutputCommand.PromptUser(promptMessage);

            var res = _inputValidator.ValidateGridSize(gridSize);

            if (!res.IsSuccess)
            {
                _inputOutputCommand.DisplayError(res.Errors);
                return PromptGridSize(ConsoleCommandConstants.EnterGridSize);
            }

            return res.Result;
        }
    }
}
