using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class ScoreForNumberStrategyTests
    {
        [Fact]
        public void CalculateScore_ValidNumber_ReturnsCorrectSum()
        {
            // Arrange
            var strategy = new ScoreForNumberStrategy(3);
            int[] dice = [3, 1, 3, 5, 3];
            int expectedScore = 9;  // 3 + 3 + 3

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_NumberNotInDice_Returns0()
        {
            // Arrange
            var strategy = new ScoreForNumberStrategy(4);
            int[] dice = [2, 3, 5, 1, 6];
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_AllSameNumber_ReturnsCorrectSum()
        {
            // Arrange
            var strategy = new ScoreForNumberStrategy(2);
            int[] dice = [2, 2, 2, 2, 2];
            int expectedScore = 10;  // 2 + 2 + 2 + 2 + 2

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_EmptyDiceArray_Returns0()
        {
            // Arrange
            var strategy = new ScoreForNumberStrategy(5);
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
            var strategy = new ScoreForNumberStrategy(1);
            int[] dice = [7, 8, 9, 10, 11];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(dice));
        }
    }
}