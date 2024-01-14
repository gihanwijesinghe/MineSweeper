using MineSweeper.Helper;

namespace MineSweeper.Commands
{
    public interface IInputOutput
    {
        void Display(string message);
        void DisplayError(IList<FunctionError> errors);
        string PromptQuestion(string question);
        ConsoleKeyInfo PromptKey(string message);
    }
}
