using YahtzeeGame.Interfaces;
namespace YahtzeeGame.Services
{
    public class RandomDiceRoller : IDiceRoller
    {
        private readonly Random _random = new Random(); // Instance of the Random class to generate random numbers

        // Method to roll a specified number of dice and return the results as an array
        public int[] RollDice(int numberOfDice)
        {
            return Enumerable.Range(0, numberOfDice).Select(_ => _random.Next(1, 7)).ToArray();
        }
    }
}