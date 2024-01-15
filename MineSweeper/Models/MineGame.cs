namespace MineSweeper.Models
{
    public class MineGame
    {
        public GameState State { get; set; }
        public GameResult CurrentResult { get; set; }
    }

    public enum GameState
    {
        None = 0,
        Running = 1,
        Stop = 2,
    }

    public enum GameResult
    {
        None = 0,
        Win = 1,
        Lose = 2
    }
}
