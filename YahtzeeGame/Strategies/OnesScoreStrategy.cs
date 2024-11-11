using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class OnesScoreStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            return dice.Count(d => d == 1);
        }
    }
}