using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class SmallStraightStrategyTests
    {
        [Fact]
        public void CalculateScore_ValidSmallStraight_ReturnsCorrectScore()
        {
            // Arrange
            var strategy = new SmallStraightStrategy();
            int[] dice = [1, 2, 3, 4, 5];
            int expectedScore = 30;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_MissingSmallStraight_Returns0()
        {
            // Arrange
            var strategy = new SmallStraightStrategy();
            int[] dice = [1, 2, 3, 4, 6];
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_ContainsExtraNumbers_Returns0()
        {
            // Arrange
            var strategy = new SmallStraightStrategy();
            int[] dice = [1, 2, 3, 4, 6, 6];
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
            var strategy = new SmallStraightStrategy();
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
            var strategy = new SmallStraightStrategy();
            int[] dice = [7, 8, 9, 10, 11];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(dice));
        }
    }
}