using YahtzeeGame.Interfaces;
namespace YahtzeeGame.Strategies
{
    public class YahtzeeScoreStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            return dice.GroupBy(d => d).Any(g => g.Count() == 5) ? 50 : 0;
        }
    }
}