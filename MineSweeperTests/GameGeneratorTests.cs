using MineSweeper;
using MineSweeper.Commands;
using MineSweeper.Models;
using Moq;

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

        [TestCase(0, 0, GameResult.Lose)]
        [TestCase(0, 1, GameResult.Lose)]
        [TestCase(0, 2, GameResult.Lose)]
        public void ShouldLoseRunTest(int x, int y, GameResult expected)
        {
            // Arrange
            var randomGenerator = new MockRandomGenerator();
            var mineFieldGenerator = new MineFieldGenerator(randomGenerator);

            Mock<IUserCommand> mockUserCommand = new Mock<IUserCommand>();
            mockUserCommand.Setup(x => x.PromptSquareSelection(It.IsAny<int>())).Returns((x, y));
            mockUserCommand.Setup(x => x.PromptPlayAgain(It.IsAny<bool>(), It.IsAny<bool>())).Returns(false);
            mockUserCommand.Setup(x => x.PromptNumberOfMines(It.IsAny<int>())).Returns(3);
            mockUserCommand.Setup(x => x.PromptGridSize()).Returns(3);

            var mockInputOutput = new MockInputOutput();
            var gameGenerator = new GameGenerator(mockUserCommand.Object, mockInputOutput, mineFieldGenerator);

            gameGenerator.Run();

            // Act
            var actual = gameGenerator.MineGame.CurrentResult;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
