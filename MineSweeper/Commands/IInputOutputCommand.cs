using MineSweeper.Helper;

namespace MineSweeper.Commands
{
    public interface IInputOutputCommand
    {
        void Display(string message);
        void DisplayError(IList<FunctionError> errors);
        string PromptUser(string question);
    }
}
