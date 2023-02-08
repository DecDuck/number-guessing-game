namespace NumberGuessingGame
{
    internal abstract class Program
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

        static Random _random = new Random();

        const int MinValue = 0;
        const int MaxValue = 100;

        static void Main()
        {
            while (true)
            {
                MainMenu();
            }
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome to DecDuck's Number Guessing Game!");
            int i = ConsoleSelector.Select(new string[]
            {
                "Play",
                "Options",
                "Quit"
            });
            switch (i)
            {
                case 0:
                    Console.Clear();
                    Play(_random.Next(MinValue, MaxValue), MinValue, MaxValue);
                    break;
                case 1:
                    OptionsMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }

        static void OptionsMenu()
        {
            while (true)
            {
                string[] options =
                {
                    "Difficulty: " + Settings.Difficulty,
                    "Exit"
                };
                int i = ConsoleSelector.Select(options);
                switch (i)
                {
                    case 0:
                        Settings.Difficulty = (Settings.DifficultyEnum) ConsoleSelector.Select(Enum.GetNames(typeof(Settings.DifficultyEnum)));
                        break;
                    default:
                        return;
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
                // Fetch the relevant entry
                int entryIndex = Math.Clamp((int) Math.Round(closeness * (Brackets.Length-1)), 0, Brackets.Length-1);
                Console.WriteLine("You are: {0} ({1}%)", Brackets[entryIndex], Math.Floor(closeness * 100 * MaxValue) / MaxValue);
            }
            Console.WriteLine("Yay! You got it!");
        }
    }
}