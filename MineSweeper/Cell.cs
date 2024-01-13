using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Cell
    {
        public int X {  get; set; }
        public int Y {  get; set; }
        public bool IsMine { get; set; }
        public int NumberOfMinesAround { get; set; }
        public bool IsRevealed { get; set; }

        public Cell(int x, int y) 
        { 
            X = x;
            Y = y;
        }
    }
}
