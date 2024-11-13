using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class ScorePairStrategyTests
    {
        [Fact]
        public void CalculateScore_ValidPair_ReturnsCorrectScore()
        {
            // Arrange
            var strategy = new ScorePairStrategy();
            int[] dice = [1, 1, 3, 4, 5];
            int expectedScore = 2;  // Pair of 1's, 1 * 2 = 2

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_MultiplePairs_ReturnsLargestPairScore()
        {
            // Arrange
            var strategy = new ScorePairStrategy();
            int[] dice = [2, 2, 4, 4, 6];
            int expectedScore = 8;  // Pair of 4's, 4 * 2 = 8

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_NoPairs_Returns0()
        {
            // Arrange
            var strategy = new ScorePairStrategy();
            int[] dice = [1, 2, 3, 4, 5];
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
            var strategy = new ScorePairStrategy();
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
            var strategy = new ScorePairStrategy();
            int[] dice = [7, 8, 9, 10, 11];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(dice));
        }
    }
}