using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.UI
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public static class DifficultyExtensions
    {
        //  ИДЕЯ: можно добавить методы расширения для получения параметров, зависящих от сложности, например:
        //public static int GetMaxQueueLength(this Difficulty difficulty)
        //{
        //    return difficulty switch
        //    {
        //        Difficulty.Easy => 5,
        //        Difficulty.Normal => 4,
        //        Difficulty.Hard => 3,
        //        _ => throw new ArgumentOutOfRangeException(nameof(difficulty), "Unknown difficulty level")
        //    };
        //}

        public static string ToDisplayString(Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Easy => "Легкий",
                Difficulty.Normal => "Нормальный",
                Difficulty.Hard => "Сложный",
                _ => throw new ArgumentOutOfRangeException(nameof(difficulty), "Unknown difficulty level")
            };
        }
    }
}
