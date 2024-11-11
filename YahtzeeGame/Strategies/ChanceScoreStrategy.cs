using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class ChanceScoreStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            return dice.Sum();
        }
    }
}