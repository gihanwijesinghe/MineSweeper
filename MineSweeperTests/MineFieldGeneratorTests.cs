using MineSweeper;
using MineSweeper.Helper.NumbersHelper;

namespace MineSweeperTests
{
    [TestFixture]
    public class MineFieldGeneratorTests
    {
        [TestCase(2, 4)]
        [TestCase(4, 16)]
        public void ShouldTrueGenerateInitialMineFieldTest(int gridSize, int expected)
        {
            // Arrange
            var randomGenerator = new RandomGenerator();
            var mineFieldGenerator = new MineFieldGenerator(randomGenerator);

            // Act
            mineFieldGenerator.GenerateInitialMineField(gridSize);
            var actual = mineFieldGenerator.MineField.Squares.Count();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(2, 0, 0, 0)]
        [TestCase(2, 1, 0, 1)]
        [TestCase(2, 2, 1, 0)]
        [TestCase(2, 3, 1, 1)]
        public void ShouldIndexesEqualGenerateInitialMineFieldTest(int gridSize, int index, int expectedX, int expectedY)
        {
            // Arrange
            var randomGenerator = new MockRandomGenerator();
            var mineFieldGenerator = new MineFieldGenerator(randomGenerator);

            // Act
            mineFieldGenerator.GenerateInitialMineField(gridSize);
            var actualX = mineFieldGenerator.MineField.Squares[index].X;
            var actualY = mineFieldGenerator.MineField.Squares[index].Y;

            // Assert
            Assert.That(actualX, Is.EqualTo(expectedX));
            Assert.That(actualY, Is.EqualTo(expectedY));
        }

        [TestCase(0, 0, true)]
        [TestCase(0, 1, true)]
        [TestCase(0, 2, true)]
        [TestCase(1, 0, false)]
        public void ShouldIndexesEqualPlaceMinesRandomlyTest(int x, int y, bool isMine)
        {
            // Arrange
            var randomGenerator = new MockRandomGenerator();
            var mineFieldGenerator = new MineFieldGenerator(randomGenerator);

            // Act
            mineFieldGenerator.GenerateInitialMineField(3);
            mineFieldGenerator.PlaceMinesRandomly(3, 3);
            var actual = mineFieldGenerator.MineField.Squares.Single(s => s.X == x && s.Y == y).IsMine;

            // Assert
            Assert.That(actual, Is.EqualTo(isMine));
        }
    }
}
