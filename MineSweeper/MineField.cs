namespace MineSweeper
{
    public class MineField
    {
        private readonly Random _random = new Random();

        public IList<MineSquare> Squares { get; set; }
        public int GridSize { get; set; }

        public MineField() 
        {
            Squares = new List<MineSquare>();
        }

        public void Initialize(int gridSize, int mines)
        {
            GridSize = gridSize;

            CreateInitialMineField(gridSize);
            PlaceMinesRandomly(gridSize, mines);
        }

        public void CreateInitialMineField(int gridSize)
        {
            for (var i = 0; i < gridSize; i++)
            {
                for (var j = 0; j < gridSize; j++)
                {
                    var square = new MineSquare(i, j);
                    Squares.Add(square);
                }
            }
        }

        public void PlaceMinesRandomly(int gridSize, int mines)
        {
            //Assume squares are numbered like below as squareNumbers
            // 0 1 2
            // 3 4 5
            // 6 7 8

            var randomNumbers = new SortedSet<int>();
            for (var i = 0; i < mines; i++)
            {
                var squareNumber = GenerateRandomNumber();
                var x = squareNumber / gridSize;
                var y = squareNumber % gridSize;

                var mineSquare = Squares.FirstOrDefault(s => s.X == x && s.Y == y);
                mineSquare.IsMine = true;
            }

            int GenerateRandomNumber()
            {
                var randomNumber = _random.Next(0, gridSize * gridSize - 1);
                if(randomNumbers.Contains(randomNumber))
                {
                    return GenerateRandomNumber();
                }

                randomNumbers.Add(randomNumber);
                return randomNumber;
            }
        }
    }
}
