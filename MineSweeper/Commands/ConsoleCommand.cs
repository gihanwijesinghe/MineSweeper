using MineSweeper.Helper;

namespace MineSweeper.Commands
{
    public class ConsoleCommand : IInputOutputCommand
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public string PromptUser(string question)
        {
            Display(question);
            return Console.ReadLine();
        }

        public void DisplayError(IList<FunctionError> errors)
        {
            Display(string.Join(", ", errors.Select(e => e.Message)));
        }
    }
}
