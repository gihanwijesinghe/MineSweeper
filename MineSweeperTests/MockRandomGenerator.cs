using MineSweeper.Helper.NumbersHelper;

namespace MineSweeperTests
{
    public class MockRandomGenerator : IRandomGenerator
    {
        public IEnumerable<int> GenerateRandomIntegers(int count, int max, int min = 0)
        {
            var res = new List<int>();
            for(var i = 0; i < count; i++)
            {
                res.Add(i);
            }

            return res;
        }
    }
}
