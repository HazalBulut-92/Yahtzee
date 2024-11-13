using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class ChanceScoreStrategyTests
    {
        [Fact]
        public void CalculateScore_ValidDiceValues_ReturnsCorrectSum()
        {
            // Arrange
            var strategy = new ChanceScoreStrategy();
            int[] validDice = [1, 3, 5, 2, 6];
            int expectedSum = 17;

            // Act
            int actualSum = strategy.CalculateScore(validDice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void CalculateScore_InvalidDiceValues_ThrowsArgumentException()
        {
            // Arrange
            var strategy = new ChanceScoreStrategy();
            int[] invalidDice = [0, 7, -1, 8];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(invalidDice));
        }

        [Fact]
        public void CalculateScore_EmptyDiceArray_ReturnsZero()
        {
            // Arrange
            var strategy = new ChanceScoreStrategy();
            int[] emptyDice = [];
            int expectedSum = 0;

            // Act
            int actualSum = strategy.CalculateScore(emptyDice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
    }
}
