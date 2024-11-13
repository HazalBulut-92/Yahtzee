using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class FullHouseStrategyTests
    {
        [Fact]
        public void CalculateScore_ValidFullHouse_Returns25()
        {
            // Arrange
            var strategy = new FullHouseStrategy();
            int[] dice = [2, 2, 3, 3, 3]; // Valid full house (three 3s and two 2s)
            int expectedScore = 25;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_NotAFullHouse_Returns0()
        {
            // Arrange
            var strategy = new FullHouseStrategy();
            int[] dice = [1, 1, 2, 3, 4]; // Not a full house
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_FullHouseWithDifferentNumbers_Returns25()
        {
            // Arrange
            var strategy = new FullHouseStrategy();
            int[] dice = [4, 4, 4, 2, 2]; // Valid full house (three 4s and two 2s)
            int expectedScore = 25;

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_ThreeOfAKindOnly_Returns0()
        {
            // Arrange
            var strategy = new FullHouseStrategy();
            int[] dice = [5, 5, 5, 2, 3]; // Only three of a kind, not a full house
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
            var strategy = new FullHouseStrategy();
            int[] emptyDice = []; // Empty array
            int expectedScore = 0;

            // Act
            int actualScore = strategy.CalculateScore(emptyDice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_DiceArrayWithInvalidNumbers_ThrowsArgumentException()
        {
            // Arrange
            var strategy = new FullHouseStrategy();
            int[] invalidDice = [0, 7, 7, -1, 8]; // Contains invalid numbers

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(invalidDice));
        }
    }
}