using MineSweeper;
using MineSweeper.Models;

namespace MineSweeperTests
{
    [TestFixture]
    public class GameGeneratorTests
    {
        [Test]
        public void ShouldGameFalseRunTest()
        {
            // Arrange
            var randomGenerator = new MockRandomGenerator();
            var mineFieldGenerator = new MineFieldGenerator(randomGenerator);

            var mockUserCommand = new MockUserCommand();
            var mockInputOutput = new MockInputOutput();
            var gameGenerator = new GameGenerator(mockUserCommand, mockInputOutput, mineFieldGenerator);

            gameGenerator.Run();

            // Act
            var actual = gameGenerator.MineGame.CurrentResult;

            // Assert
            Assert.That(actual, Is.EqualTo(GameResult.Lose));
        }
    }
}
