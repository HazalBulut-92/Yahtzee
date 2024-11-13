using YahtzeeGame.Helpers;
using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class TwoPairStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            DiceValidator.ValidateDiceArray(dice);

            var pairs = dice.GroupBy(x => x).Where(g => g.Count() >= 2).Select(g => g.Key).OrderByDescending(x => x).ToList();
            return pairs.Count >= 2 ? (pairs[0] * 2 + pairs[1] * 2) : 0;
        }
    }
}