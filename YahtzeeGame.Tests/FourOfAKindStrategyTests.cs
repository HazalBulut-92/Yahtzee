using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class FourOfAKindStrategyTests
    {
        [Fact]
        public void CalculateScore_FourOfAKind_ReturnsSumOfDice()
        {
            // Arrange
            var strategy = new FourOfAKindStrategy();
            int[] dice = [3, 3, 3, 3, 5];
            int expectedSum = 3 + 3 + 3 + 3 + 5;

            // Act
            int actualSum = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void CalculateScore_NoFourOfAKind_ReturnsZero()
        {
            // Arrange
            var strategy = new FourOfAKindStrategy();
            int[] dice = [1, 2, 3, 4, 5];
            int expectedSum = 0;

            // Act
            int actualSum = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void CalculateScore_ExactFourOfAKind_ReturnsSumOfDice()
        {
            // Arrange
            var strategy = new FourOfAKindStrategy();
            int[] dice = [2, 2, 2, 2, 6];
            int expectedSum = 2 + 2 + 2 + 2 + 6;

            // Act
            int actualSum = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void CalculateScore_FiveOfAKind_ReturnsSumOfDice()
        {
            // Arrange
            var strategy = new FourOfAKindStrategy();
            int[] dice = [4, 4, 4, 4, 4];
            int expectedSum = 4 + 4 + 4 + 4 + 4;

            // Act
            int actualSum = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void CalculateScore_ThrowsExceptionForInvalidDice()
        {
            // Arrange
            var strategy = new FourOfAKindStrategy();
            int[] dice = [7, 8, 9, 10, 11];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(dice));
        }
    }
}