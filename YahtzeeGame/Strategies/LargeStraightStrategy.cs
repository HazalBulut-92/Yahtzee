using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class LargeStraightStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            var requiredNumbers = new int[] { 2, 3, 4, 5, 6 };
            return requiredNumbers.All(dice.Contains) ? 40 : 0;
        }
    }
}