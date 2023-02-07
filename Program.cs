namespace NumberGuessingGame
{
    internal class Program
    {
        static readonly string[] brackets =
        {
            "Frozen!",
            "Wintery",
            "Frigid",
            "Very Cold",
            "Cold",
            "Chilly",
            "Brisk",
            "Numbing",
            "Nippy",
            "Toasty",
            "Warm",
            "Very Warm",
            "Hot",
            "Very Hot",
            "Boiling!",
        };

        const int MIN_VALUE = 0;
        const int MAX_VALUE = 100;

        static void Main(string[] args)
        {
            Random random = new Random();
            while (true)
            {
                Play(random.Next(MIN_VALUE, MAX_VALUE), MIN_VALUE, MAX_VALUE);
                Console.Write("Play again? (y/n) ");
                if (!"Yyes".Contains(Console.ReadLine()))
                {
                    break;
                }
            }
        }

        static void Play(int answer, int lowerBounds, int upperBounds)
        {
            int guess;
            while (true)
            {
                Console.Write("What is your guess? ");
                if (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Invalid guess!");
                    continue;
                }
                if (guess == answer)
                {
                    break;
                }
                // Calculate how close we were
                float closeness = 1 - ((float) Math.Abs(answer - guess) / (upperBounds - lowerBounds));
                // Otherwise, fetch the relevant entry
                int entryIndex = Math.Clamp((int) Math.Round(closeness * (brackets.Length-1)), 0, brackets.Length-1);
                Console.WriteLine("You are: {0} ({1}%)", brackets[entryIndex], Math.Floor(closeness * 100));
            }
            Console.WriteLine("Yay! You got it!");
        }
    }
}