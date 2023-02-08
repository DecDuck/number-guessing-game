namespace NumberGuessingGame;

public abstract class Settings
{
    public enum DifficultyEnum
    {
        Easy,
        Normal,
        Hard
    }

    public static DifficultyEnum Difficulty = DifficultyEnum.Normal;
    
    public static int MinValue = 0;
    public static int MaxValue = 100;

}