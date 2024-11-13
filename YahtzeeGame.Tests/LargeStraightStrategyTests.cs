using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class LargeStraightStrategyTests
    {
        [Fact]
        public void CalculateScore_ValidLargeStraight_Returns40()
        {
            // Arrange
            var strategy = new LargeStraightStrategy();
            int[] dice = [2, 3, 4, 5, 6]; // Valid large straight
            int expectedScore = 40;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_InvalidLargeStraight_Returns0()
        {
            // Arrange
            var strategy = new LargeStraightStrategy();
            int[] dice = [1, 2, 3, 4, 5]; // Not a valid large straight
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_PartialStraight_Returns0()
        {
            // Arrange
            var strategy = new LargeStraightStrategy();
            int[] dice = [2, 3, 4, 5, 1]; // Partial straight, not valid large straight
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_EmptyDiceArray_Returns0()
        {
            // Arrange
            var strategy = new LargeStraightStrategy();
            int[] emptyDice = []; // Empty array
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(emptyDice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_DuplicateNumbersInArray_Returns0()
        {
            // Arrange
            var strategy = new LargeStraightStrategy();
            int[] dice = [2, 2, 4, 5, 6]; // Duplicate number, not a valid large straight
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_DiceArrayWithInvalidNumbers_ThrowsArgumentException()
        {
            // Arrange
            var strategy = new LargeStraightStrategy();
            int[] invalidDice = [0, 7, 2, 3, 5]; // Contains invalid numbers

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(invalidDice));
        }
    }
}