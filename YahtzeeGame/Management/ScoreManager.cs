using Serilog;
using YahtzeeGame.Interfaces;

namespace YahtzeeGame.Management
{
    public class ScoreManager
    {
        private readonly List<IScoreStrategy> _strategies;  // List of scoring strategies to be used
        private readonly ILogger _logger;   // Serilog instance for logging

        // Constructor: Initializes the list of scoring strategies and the logger
        public ScoreManager(List<IScoreStrategy> strategies)
        {
            _strategies = strategies;
            _logger = Log.Logger;
        }

        // Method to calculate and display scores for a given set of dice
        public void CalculateAndDisplayScores(int[] dice)
        {
            // Iterate over each scoring strategy and calculate the score
            foreach (var strategy in _strategies)
            {
                int score = strategy.CalculateScore(dice);  // Calculate the score using the current strategy
                _logger.Information($"Strategy {strategy.GetType().Name} scored: {score}"); // Log the score with Serilog
                Console.WriteLine($"Strategy {strategy.GetType().Name} scored: {score}");   // Print the score to the console
            }
        }
    }
}