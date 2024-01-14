namespace MineSweeper.Helper.NumbersHelper
{
    public interface IRandomGenerator
    {
        IEnumerable<int> GenerateRandomIntegers(int count, int max, int min = 0);
    }
}
