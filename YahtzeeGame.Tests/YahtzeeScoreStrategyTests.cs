using YahtzeeGame.Strategies;

namespace YahtzeeGame.Tests
{
    public class YahtzeeScoreStrategyTests
    {
        [Fact]
        public void CalculateScore_AllDiceSame_Returns50()
        {
            // Arrange
            var strategy = new YahtzeeScoreStrategy();
            int[] dice = [3, 3, 3, 3, 3]; // All dice are the same
            int expectedScore = 50;  // Yahtzee score should be 50

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_NotAllDiceSame_Returns0()
        {
            // Arrange
            var strategy = new YahtzeeScoreStrategy();
            int[] dice = [3, 3, 3, 4, 3]; // Not all dice are the same
            int expectedScore = 0;  // No Yahtzee score, so should return 0

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_EmptyDiceArray_Returns0()
        {
            // Arrange
            var strategy = new YahtzeeScoreStrategy();
            int[] emptyDice = [];
            int expectedScore = 0;  // Empty dice array should return 0

            // Act
            int actualScore = strategy.CalculateScore(emptyDice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_DiceArrayWithMultipleDifferentNumbers_Returns0()
        {
            // Arrange
            var strategy = new YahtzeeScoreStrategy();
            int[] dice = [1, 2, 3, 4, 5]; // All dice have different values
            int expectedScore = 0;  // No Yahtzee score, so should return 0

            // Act
            int actualScore = strategy.CalculateScore(dice);

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void CalculateScore_ValidDiceArray_ThrowsArgumentException()
        {
            // Arrange
            var strategy = new YahtzeeScoreStrategy();
            int[] invalidDice = [0, 7, -1, 8];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => strategy.CalculateScore(invalidDice));
        }
    }
}