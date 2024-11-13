using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class OnesScoreStrategyTests
    {
        [Fact]
        public void CalculateScore_ValidOnes_ReturnsCorrectCount()
        {
            // Arrange
            var strategy = new OnesScoreStrategy();
            int[] dice = [1, 1, 2, 3, 1];
            int expectedScore = 3;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_NoOnes_Returns0()
        {
            // Arrange
            var strategy = new OnesScoreStrategy();
            int[] dice = [2, 2, 3, 4, 5];
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_AllOnes_ReturnsCorrectCount()
        {
            // Arrange
            var strategy = new OnesScoreStrategy();
            int[] dice = [1, 1, 1, 1, 1];
            int expectedScore = 5;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_EmptyDiceArray_Returns0()
        {
            // Arrange
            var strategy = new OnesScoreStrategy();
            int[] dice = [];
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_ThrowsExceptionForInvalidDice()
        {
            // Arrange
            var strategy = new OnesScoreStrategy();
            int[] dice = [7, 8, 9, 10, 11];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(dice));
        }
    }
}