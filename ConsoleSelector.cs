namespace NumberGuessingGame;

public class ConsoleSelector
{
    // Expects an empty console
    public static int Select(string[] options)
    {
        int longestOptionLength = 0;
        foreach (string option in options)
        {
            if (option.Length > longestOptionLength)
            {
                longestOptionLength = option.Length;
            }
        }
        Console.CursorVisible = false;
        int selected = 0;
        ConsoleKey key = ConsoleKey.D0; // D0 does nothing
        while (key != ConsoleKey.Enter)
        {
            RenderOptions(options, selected, longestOptionLength + 4);
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow) selected--;
            if (key == ConsoleKey.DownArrow) selected++;
            selected = Math.Clamp(selected, 0, options.Length - 1);
        }
        Console.CursorVisible = true;
        Console.Clear();

        return selected;
    }

    static void RenderOptions(string[] options, int selected, int longestOptionLength)
    {
        Console.WriteLine("Select option");
        for (int i = 0; i < options.Length; i++)
        {
            if (selected == i)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }

            Console.WriteLine(" ({0}) {1}{2}", i + 1, options[i], new String(' ', longestOptionLength - options[i].Length));
        }

        Console.CursorTop -= 1 + options.Length;
        Console.ResetColor();
    }
}