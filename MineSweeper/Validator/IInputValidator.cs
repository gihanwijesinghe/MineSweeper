using MineSweeper.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Validator
{
    public interface IInputValidator
    {
        FunctionResult<int> ValidateGridSize(string input);
    }
}
