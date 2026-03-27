namespace Lab3.BookStoreLibrary;

/// <summary>
/// Нынешняя игровая статистика, которая отображает количество проданных книг, пойманных ошибок,
/// уплаченных штрафов и общую сумму заработанных денег.
/// Эти данные обновляются в реальном времени по мере развития игрового процесса и служат для оценки успеха
/// игрока в управлении книжным магазином.
/// </summary>
public class GameStats
{
    public int BooksSold { get; set; } = 0;
    public int ErrorsCaught { get; set; } = 0;
    public int FinesPaid { get; set; } = 0;
    public decimal TotalEarned { get; set; } = 0;
}

/// <summary>
/// Настройки игры, которые определяют сложность и динамику игрового процесса.
/// Включают в себя интервалы между доставками и появлением клиентов, максимальную длину очереди,
/// допустимое количество неудовлетворенных клиентов и продолжительность дня в секундах.
/// </summary>
public class GameSettings
{
    public int DeliveryInterval { get; set; }
    public int CustomerInterval { get; set; }
    public int MaxQueue { get; set; }
    public int MaxUnsatisfied { get; set; }
    public int DayDurationSeconds { get; set; }

    public static GameSettings GetByDifficulty(Difficulty difficulty) => difficulty switch
    {
        Difficulty.Easy => new() { DeliveryInterval = 15000, CustomerInterval = 20000, MaxQueue = 5, MaxUnsatisfied = 5, DayDurationSeconds = 180 },
        Difficulty.Normal => new() { DeliveryInterval = 10000, CustomerInterval = 15000, MaxQueue = 4, MaxUnsatisfied = 4, DayDurationSeconds = 300 },
        Difficulty.Hard => new() { DeliveryInterval = 7000, CustomerInterval = 10000, MaxQueue = 3, MaxUnsatisfied = 3, DayDurationSeconds = 420 },
        _ => throw new ArgumentOutOfRangeException()
    };
}

public record BookOrder(Book book, int arrivalTick);