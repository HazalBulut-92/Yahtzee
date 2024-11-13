namespace YahtzeeGame.Helpers
{
    public static class DiceValidator
    {
        public static void ValidateDiceArray(int[] dice)
        {
            if (dice.Any(d => d < 1 || d > 6))
            {
                throw new ArgumentException("Dice array contains invalid values. All values must be between 1 and 6.");
            }
        }
    }
}
