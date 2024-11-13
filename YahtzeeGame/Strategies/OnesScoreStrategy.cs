using YahtzeeGame.Helpers;
using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Strategies
{
    public class OnesScoreStrategy : IScoreStrategy
    {
        public int CalculateScore(int[] dice)
        {
            DiceValidator.ValidateDiceArray(dice);

            return dice.Count(d => d == 1);
        }
    }
}