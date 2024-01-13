namespace MineSweeper
{
    public class MineSquare
    {
        public int X {  get; set; }
        public int Y {  get; set; }
        public bool IsMine { get; set; }
        public int NumberOfMinesAround { get; set; }
        public bool IsRevealed { get; set; }

        public MineSquare(int x, int y) 
        { 
            X = x;
            Y = y;
        }
    }
}
