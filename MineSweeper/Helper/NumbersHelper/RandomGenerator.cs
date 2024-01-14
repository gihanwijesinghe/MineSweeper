namespace MineSweeper.Helper.NumbersHelper
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random = new Random();

        public IEnumerable<int> GenerateRandomIntegers(int count, int max, int min = 0)
        {
            var randomIntegers = new SortedSet<int>();

            for (var i = min; i < count; i++)
            {
                var rand = GenerateRandomInteger(max, min);
                while (randomIntegers.Contains(rand))
                {
                    rand = GenerateRandomInteger(max, min);
                }

                randomIntegers.Add(rand);
            }

            return randomIntegers;

        }

        public int GenerateRandomInteger(int max, int min)
        {
            return _random.Next(min, max);
        }
    }
}
