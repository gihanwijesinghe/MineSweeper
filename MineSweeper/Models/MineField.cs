namespace MineSweeper.Models
{
    public class MineField
    {
        public int GridSize { get; set; }
        public IList<MineSquare> Squares { get; set; }

        public MineField(int gridSize) 
        { 
            GridSize = gridSize;
            Squares = new List<MineSquare>();
        }
    }
}
