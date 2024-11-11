using YahtzeeGame.Interfaces;
using Serilog;

namespace YahtzeeGame.Management
{
    public class GameManager
    {
        private readonly IDiceRoller _diceRoller;
        private readonly ScoreManager _scoreManager;
        private readonly ILogger _logger;

        public GameManager(IDiceRoller diceRoller, ScoreManager scoreManager)
        {
            _diceRoller = diceRoller;
            _scoreManager = scoreManager;
            _logger = Log.Logger;
        }

        public void StartGameLoop()
        {
            _logger.Information("Game started");
            bool keepPlaying = true;
            while (keepPlaying)
            {
                int[] dice = _diceRoller.RollDice(5);
                _logger.Information("Dice rolled: {0}", string.Join(", ", dice));
                _scoreManager.CalculateAndDisplayScores(dice);

                Console.WriteLine("Play again? (yes/no)");
                keepPlaying = Console.ReadLine()?.ToLower() == "yes";
            }
            _logger.Information("Game ended!");
        }
    }
}