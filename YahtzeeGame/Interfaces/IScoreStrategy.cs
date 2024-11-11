namespace YahtzeeGame.Interfaces
{
    public interface IScoreStrategy
    {
        int CalculateScore(int[] dice);
    }
}