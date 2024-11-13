using YahtzeeGame.Helpers;
using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class FourOfAKindStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            DiceValidator.ValidateDiceArray(dice);

            var fourOfAKind = dice.GroupBy(x => x).FirstOrDefault(g => g.Count() >= 4);
            return fourOfAKind != null ? dice.Sum() : 0;
        }
    }
}