using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class ThreeOfAKindStrategyTests
    {
        [Fact]
        public void CalculateScore_ValidThreeOfAKind_ReturnsCorrectSum()
        {
            // Arrange
            var strategy = new ThreeOfAKindStrategy();
            int[] validDice = [3, 3, 3, 5, 6];
            int expectedSum = 3 + 3 + 3 + 5 + 6; // Sum of all dice values (20)

            // Act
            int actualSum = strategy.CalculateScore(validDice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void CalculateScore_InvalidDice_ThrowsArgumentException()
        {
            // Arrange
            var strategy = new ThreeOfAKindStrategy();
            int[] invalidDice = [0, 7, -1, 8];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(invalidDice));
        }

        [Fact]
        public void CalculateScore_NoThreeOfAKind_ReturnsZero()
        {
            // Arrange
            var strategy = new ThreeOfAKindStrategy();
            int[] noThreeOfAKindDice = [1, 2, 3, 4, 5];
            int expectedSum = 0;

            // Act
            int actualSum = strategy.CalculateScore(noThreeOfAKindDice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void CalculateScore_ExactlyThreeOfAKind_ReturnsCorrectSum()
        {
            // Arrange
            var strategy = new ThreeOfAKindStrategy();
            int[] exactThreeOfAKindDice = [4, 4, 4, 2, 5];
            int expectedSum = 4 + 4 + 4 + 2 + 5; // Sum of all dice values (19)

            // Act
            int actualSum = strategy.CalculateScore(exactThreeOfAKindDice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void CalculateScore_EmptyDiceArray_ReturnsZero()
        {
            // Arrange
            var strategy = new ThreeOfAKindStrategy();
            int[] emptyDice = [];
            int expectedSum = 0;

            // Act
            int actualSum = strategy.CalculateScore(emptyDice);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
    }
}