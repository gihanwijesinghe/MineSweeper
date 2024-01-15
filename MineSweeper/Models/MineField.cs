namespace MineSweeper.Models
{
    public class MineField
    {
        public int GridSize { get; set; }
        public IList<MineSquare> Squares { get; set; }

        public MineField() 
        {
            Squares = new List<MineSquare>();
        }
    }
}
