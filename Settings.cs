namespace NumberGuessingGame;

public class Settings
{
    public enum DifficultyEnum
    {
        Easy,
        Normal,
        Hard
    }

    public static DifficultyEnum Difficulty = DifficultyEnum.Normal;
}