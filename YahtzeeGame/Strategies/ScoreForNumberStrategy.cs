using YahtzeeGame.Interfaces;
namespace YahtzeeGame.Strategies
{
    public class ScoreForNumberStrategy : IScoreStrategy
    {
        private readonly int _number;

        public ScoreForNumberStrategy(int number)
        {
            _number = number;
        }

        public int CalculateScore(int[] dice)
        {
            return dice.Where(d => d == _number).Sum();
        }
    }
}