namespace NumberGuessingGame
{
    internal class Program
    {
        static readonly string[] Brackets =
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

        const int MinValue = 0;
        const int MaxValue = 1000;

        static void Main()
        {
            Random random = new Random();
            while (true)
            {
                Play(random.Next(MinValue, MaxValue), MinValue, MaxValue);
                Console.Write("Play again? (y/n) ");
                if (!"Yyes".Contains(Console.ReadLine()))
                {
                    break;
                }
            }
        }

        static void Play(int answer, int lowerBounds, int upperBounds)
        {
            while (true)
            {
                Console.Write("What is your guess? ");
                if (!int.TryParse(Console.ReadLine(), out var guess))
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
                int entryIndex = Math.Clamp((int) Math.Round(closeness * (Brackets.Length-1)), 0, Brackets.Length-1);
                Console.WriteLine("You are: {0} ({1}%)", Brackets[entryIndex], Math.Floor(closeness * 100 * MaxValue) / MaxValue);
            }
            Console.WriteLine("Yay! You got it!");
        }
    }
}