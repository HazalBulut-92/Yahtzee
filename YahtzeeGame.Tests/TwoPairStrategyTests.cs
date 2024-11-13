using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class TwoPairStrategyTests
    {
        [Fact]
        public void CalculateScore_TwoPairs_ReturnsCorrectScore()
        {
            // Arrange
            var strategy = new TwoPairStrategy();
            int[] dice = [2, 2, 3, 3, 6];  // Two pairs: 2 and 3
            int expectedScore = 2 * 2 + 3 * 2; // 4 + 6 = 10

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_OnePair_ReturnsZero()
        {
            // Arrange
            var strategy = new TwoPairStrategy();
            int[] dice = [4, 4, 5, 6, 2]; // One pair: 4
            int expectedScore = 0;  // Only one pair, so no valid score

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_NoPairs_ReturnsZero()
        {
            // Arrange
            var strategy = new TwoPairStrategy();
            int[] dice = { 1, 2, 3, 4, 5 }; // No pairs
            int expectedScore = 0;  // No pairs, so no valid score

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_TwoPairsWithDifferentValues_ReturnsCorrectScore()
        {
            // Arrange
            var strategy = new TwoPairStrategy();
            int[] dice = [1, 1, 4, 4, 6];  // Two pairs: 1 and 4
            int expectedScore = 1 * 2 + 4 * 2; // 2 + 8 = 10

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_EmptyDiceArray_ReturnsZero()
        {
            // Arrange
            var strategy = new TwoPairStrategy();
            int[] emptyDice = [];
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(emptyDice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_InvalidDice_ThrowsArgumentException()
        {
            // Arrange
            var strategy = new TwoPairStrategy();
            int[] invalidDice = [0, 7, -1, 8];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(invalidDice));
        }
    }
}