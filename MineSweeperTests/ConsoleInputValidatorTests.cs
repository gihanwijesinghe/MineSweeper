using MineSweeper.AppConstants;
using MineSweeper.Validator;

namespace MineSweeperTests
{
    [TestFixture]
    public class ConsoleInputValidatorTests
    {
        [TestCase("3", 3)]
        [TestCase("4", 4)]
        public void ShouldTrueValidateAndGetGridSizeTest(string input, int expected)
        {
            // Arrange
            var validator = new ConsoleInputValidator();

            // Act
            var result = validator.ValidateAndGetGridSize(input);
            var actual = result.Result;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("", ErrorMessageConstants.IncorrectInput)]
        [TestCase("a", ErrorMessageConstants.IncorrectInput)]
        [TestCase("2a", ErrorMessageConstants.IncorrectInput)]
        [TestCase("1", ErrorMessageConstants.LessThanMinimumGridSize)]
        [TestCase("11", ErrorMessageConstants.MoreThanMaximumGridSize)]
        public void SholdGiveErrorValidateAndGetGridSizeTest(string input, string expected)
        {
            // Arrange
            var validator = new ConsoleInputValidator();

            // Act
            var result = validator.ValidateAndGetGridSize(input);
            var actual = result.Errors[0].Message;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("3", 3, 3)]
        [TestCase("4", 4, 4)]
        public void ShouldTrueValidateAndGetNumberOfMinesTest(string input, int gridSize, int expected)
        {
            // Arrange
            var validator = new ConsoleInputValidator();

            // Act
            var result = validator.ValidateAndGetNumberOfMines(input, gridSize);
            var actual = result.Result;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("", 3, ErrorMessageConstants.IncorrectInput)]
        [TestCase("a", 3, ErrorMessageConstants.IncorrectInput)]
        [TestCase("2a", 3, ErrorMessageConstants.IncorrectInput)]
        [TestCase("0", 3, ErrorMessageConstants.ShouldHaveAtleastOneMine)]
        [TestCase("4", 3, ErrorMessageConstants.MaximumMinesError)]
        public void SholdGiveErrorValidateAndGetNumberOfMinesTest(string input, int gridSize, string expected)
        {
            // Arrange
            var validator = new ConsoleInputValidator();

            // Act
            var result = validator.ValidateAndGetNumberOfMines(input, gridSize);
            var actual = result.Errors[0].Message;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}