using MineSweeper.Helper;

namespace MineSweeper.Commands
{
    public class ConsoleInputOutput: IInputOutput
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayError(IList<FunctionError> errors)
        {
            Display(string.Join(", ", errors.Select(e => e.Message)));
        }

        public string PromptQuestion(string question)
        {
            Display(question);
            return Console.ReadLine();
        }

        public ConsoleKeyInfo PromptKey(string message)
        {
            Display(message);
            return Console.ReadKey();
        }
    }
}
