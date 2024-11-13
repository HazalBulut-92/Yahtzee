using YahtzeeGame.Helpers;
using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class LargeStraightStrategy : IScoreStrategy
    {
        private static readonly int[] RequiredNumbers = { 2, 3, 4, 5, 6 };

        public int CalculateScore(int[] dice)
        {
            DiceValidator.ValidateDiceArray(dice);

            // Sort the dice and check if it matches the required sequence
            return dice.OrderBy(d => d).SequenceEqual(RequiredNumbers) ? 40 : 0;
        }
    }
}