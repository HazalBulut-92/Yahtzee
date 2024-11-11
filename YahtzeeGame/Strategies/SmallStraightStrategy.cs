using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class SmallStraightStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            var requiredNumbers = new int[] { 1, 2, 3, 4, 5 };
            return requiredNumbers.All(dice.Contains) ? 30 : 0;
        }
    }
}