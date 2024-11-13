using YahtzeeGame.Helpers;
using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class ThreeOfAKindStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            DiceValidator.ValidateDiceArray(dice);

            var threeOfAKind = dice.GroupBy(x => x).FirstOrDefault(g => g.Count() >= 3);
            return threeOfAKind != null ? dice.Sum() : 0;
        }
    }
}