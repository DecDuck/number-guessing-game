namespace NumberGuessingGame
{
    internal abstract class Program
    {
        static readonly string[] Brackets =
        {
            "The f*cking Artic circle.",
            "Frozen!",
            "Wintery",
            "Frigid",
            "Very Cold",
            "Cold",
            "Chilly",
            "Numbing",
            "Brisk",
            "Nippy",
            "Toasty",
            "Warm",
            "Very Warm",
            "Hot",
            "Very Hot",
            "Boiling!",
            "The surface of the f*cking sun.",
        };

        static readonly Random Random = new();

        static void Main()
        {
            while (true)
            {
                MainMenu();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome to DecDuck's Number Guessing Game!");
            int i = ConsoleSelector.Select(new[]
            {
                "Play",
                "Options",
                "Quit"
            });
            switch (i)
            {
                case 0:
                    Console.Clear();
                    Play(Random.Next(Settings.MinValue, Settings.MaxValue), Settings.MinValue, Settings.MaxValue);
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
                Console.WriteLine("Options:");
                string[] options =
                {
                    "Difficulty: " + Settings.Difficulty,
                    "Range: " + Settings.MinValue + "-" + Settings.MaxValue,
                    "Exit"
                };
                int i = ConsoleSelector.Select(options);
                switch (i)
                {
                    case 0:
                        Settings.Difficulty =
                            (Settings.DifficultyEnum)ConsoleSelector.Select(
                                Enum.GetNames(typeof(Settings.DifficultyEnum)));
                        break;
                    case 1:
                        int[][] rangeOptions =
                        {
                            new[] { 0, 10 },
                            new[] { 0, 100 },
                            new[] { 0, 1000 }
                        };
                        int[] range =
                            rangeOptions[ConsoleSelector.Select(rangeOptions.Select(e => e[0] + "-" + e[1]).ToArray())];
                        Settings.MinValue = range[0];
                        Settings.MaxValue = range[1];
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
                float closeness = 1 - (float)Math.Abs(answer - guess) / (upperBounds - lowerBounds);
                // Fetch the relevant entry
                int entryIndex = Math.Clamp((int)Math.Round(closeness * (Brackets.Length - 1)), 0, Brackets.Length - 1);
                Console.WriteLine("You are: " + Brackets[entryIndex] + " " +
                                  ("("+ (Brackets.Length - 1 - entryIndex) + " levels away from guessing it)"),
                                  (Settings.Difficulty <= Settings.DifficultyEnum.Easy
                                    ? "(" + (answer > guess ? "Lower" : "Higher") + ")"
                                    : "") +
                                  (Settings.Difficulty <= Settings.DifficultyEnum.Normal
                                      ? "(" + Math.Floor(closeness * 100 * Settings.MaxValue) / Settings.MaxValue + ") "
                                      : ""));
            }

            Console.WriteLine("Yay! You got it! The answer was: "+ answer);
        }
    }
}