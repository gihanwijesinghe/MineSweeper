using MineSweeper.Helper.FunctionsHelper;
using MineSweeper.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperTests
{
    public class MockInputOutput : IInputOutput
    {
        public void Display(string message)
        {
           
        }

        public void DisplayError(IList<FunctionError> errors)
        {
            
        }

        public ConsoleKeyInfo PromptKey(string message)
        {
            return new ConsoleKeyInfo();
        }

        public string PromptQuestion(string question)
        {
            return "";
        }
    }
}
