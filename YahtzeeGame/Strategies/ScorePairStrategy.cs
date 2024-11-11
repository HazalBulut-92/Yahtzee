using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class ScorePairStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            var pairs = dice.GroupBy(x => x).Where(g => g.Count() >= 2).Select(g => g.Key).OrderByDescending(x => x).ToList();
            return pairs.Any() ? pairs.First() * 2 : 0;
        }
    }
}