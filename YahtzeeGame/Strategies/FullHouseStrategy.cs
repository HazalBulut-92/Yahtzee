using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class FullHouseStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            if (dice.Length != 5) return 0;
            var groupCounts = dice.GroupBy(x => x).Select(g => g.Count()).OrderByDescending(x => x).ToList();
            if (groupCounts.Count == 2 && groupCounts[0] == 3 && groupCounts[1] == 2)
            {
                return 25;
            }
            return 0;
        }
    }
}