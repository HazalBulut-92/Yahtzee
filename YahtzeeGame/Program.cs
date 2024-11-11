using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using YahtzeeGame.Interfaces;
using YahtzeeGame.Management;
using YahtzeeGame.Services;
using YahtzeeGame.Strategies;

namespace YahtzeeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLogging();

            try
            {
                Log.Information("Yahtzee game started...");

                using var host = CreateHostBuilder(args).Build();

                // Resolve the GameManager service from the DI container and start the game
                var gameManager = host.Services.GetRequiredService<GameManager>();
                gameManager.StartGameLoop();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unexpected error occurred!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Set the minimum log level to Debug
                .WriteTo.Console()    // Write logs to the console
                .WriteTo.File("logs/yahtzee-.log", rollingInterval: RollingInterval.Day) // Write logs to a file with daily rolling
                .CreateLogger();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() // Use Serilog for logging
                .ConfigureServices((_, services) =>
                {
                    RegisterServices(services);
                });

        private static void RegisterServices(IServiceCollection services)
        {
            // Register IDiceRoller implementation
            services.AddSingleton<IDiceRoller, RandomDiceRoller>();

            // Register scoring strategies
            services.AddSingleton(provider => GetScoringStrategies());

            // Register ScoreManager and GameManager
            services.AddSingleton<ScoreManager>();
            services.AddSingleton<GameManager>();
        }

        private static List<IScoreStrategy> GetScoringStrategies()
        {
            // Create a list of scoring strategies to be used in the game
            return new List<IScoreStrategy>
            {
                new ChanceScoreStrategy(),        // Strategy for "Chance"
                new YahtzeeScoreStrategy(),       // Strategy for "Yahtzee"
                new OnesScoreStrategy(),          // Strategy for scoring "Ones"
                new FourOfAKindStrategy(),        // Strategy for "Four of a Kind"
                new FullHouseStrategy(),          // Strategy for "Full House"
                new LargeStraightStrategy(),      // Strategy for "Large Straight"
                new ScorePairStrategy(),          // Strategy for scoring "Pairs"
                new SmallStraightStrategy(),      // Strategy for "Small Straight"
                new ThreeOfAKindStrategy(),       // Strategy for "Three of a Kind"
                new TwoPairStrategy(),            // Strategy for "Two Pair"
                // Strategies for specific numbers from 1 to 6
                new ScoreForNumberStrategy(1),
                new ScoreForNumberStrategy(2),
                new ScoreForNumberStrategy(3),
                new ScoreForNumberStrategy(4),
                new ScoreForNumberStrategy(5),
                new ScoreForNumberStrategy(6)
            };
        }
    }
}