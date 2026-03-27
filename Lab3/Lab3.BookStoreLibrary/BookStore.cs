namespace Lab3.BookStoreLibrary;

/// <summary>
/// Класс, представляющий книжный магазин
/// </summary>
public class BookStore
{
    // Приватное поле для хранения списка полок
    private readonly List<Bookshelf> _shelves = new();

    // Текущий баланс магазина
    public decimal Balance { get; private set; }
    // Максимальное количество полок в магазине
    public int MaxShelves { get; private set; }


    // очередь книг, ожидающих проверки (поставки)
    public Queue<Book> IncomingBooks { get; } = new();

    // счётчик неудовлетворённых клиентов
    public int UnsatisfiedCustomersCount { get; private set; } = 0;

    // список известных пар книга-автор (база данных)
    private readonly HashSet<(string Title, string Author)> _knownBooks = new();

    // События для уведомления формы (для Game Over)
    public event Action? OnBalanceZero;
    public event Action? OnUnsatisfiedLimitReached;

    public IReadOnlyCollection<Bookshelf> Shelves => _shelves.AsReadOnly();

    /// <summary>
    /// Конструктор класса BookStore
    /// </summary>
    /// <param name="maxShelves">Максимальное количество полок</param>
    public BookStore(int maxShelves, Difficulty difficulty)
    {
        MaxShelves = maxShelves;
        switch (difficulty)
        {
            case Difficulty.Easy:
                Balance = 1000m;
                break;
            case Difficulty.Normal:
                Balance = 500m;
                break;
            case Difficulty.Hard:
                Balance = 200m;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null);
        }
    }

    /// <summary>
    /// Метод добавления новой полки в магазин
    /// </summary>
    /// <param name="shelf">Полка для добавления</param>
    public void AddShelf(Bookshelf shelf)
    {
        // Проверка на превышение максимального количества полок
        if (_shelves.Count >= MaxShelves)
            throw new InvalidOperationException($"Невозможно добавить полку жанра {shelf.Genre}. Максимальное количество полок в магазине достигнуто.");
        _shelves.Add(shelf);
    }

    /// <summary>
    /// Метод удаления полки в магазин
    /// </summary>
    /// <param name="shelf">Полка для добавления</param>
    /// <returns>true, если удалено успешно, иначе - false</returns>
    public bool RemoveShelf(Bookshelf shelf)
    {
        // Проверка на превышение максимального количества полок
        //if (_shelves.Count >= MaxShelves)
        //    throw new InvalidOperationException($"Невозможно добавить полку жанра {shelf.Genre}. Максимальное количество полок в магазине достигнуто.");

        return _shelves.Remove(shelf);
    }


    /// <summary>
    /// Метод обработки продажи книги
    /// </summary>
    /// <param name="book">Продаваемая книга</param>
    public void ProcessSale(Book book, decimal? price)
    {
        // Поиск полки, на которой находится книга
        Bookshelf shelf = FindShelfWithBook(book);
        // Получение суммы продажи
        decimal saleAmount = book.Sell(shelf);
        // Обновление баланса магазина
        Balance += price ?? saleAmount;
    }

    /// <summary>
    /// Штраф за неудовлетворённого клиента или за неверную книгу
    /// </summary>
    /// <param name="amount">Количество средств</param>
    public void Penalty(decimal amount) => Balance -= amount;

    /// <summary>
    /// Премия за поимку ошибки
    /// </summary>
    /// <param name="amount">Количество средств</param>
    public void Award(decimal amount) => Balance += amount;

    /// <summary>
    /// Приватный метод поиска полки по книге
    /// </summary>
    /// <param name="book">Книга для поиска</param>
    /// <returns>Полка, содержащая книгу, или null</returns>
    private Bookshelf FindShelfWithBook(Book book)
    {
        foreach (var shelf in _shelves)
            if (shelf.Books.Contains(book))
                return shelf;
        throw new InvalidDataException($"Книга с названием '{book.Title}' не найдена ни на одной полке магазина");
    }

    /// <summary>
    /// Загрузка базы данных известных книг из файла
    /// </summary>
    public void LoadBookDatabase(string filePath)
    {
        if (!File.Exists(filePath)) return;

        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(',');
            if (parts.Length >= 2)
            {
                _knownBooks.Add((parts[0].Trim(), parts[1].Trim()));
            }
        }
    }

    /// <summary>
    /// Сохранение новой пары книга-автор в базу данных
    /// </summary>
    public void SaveBookToDatabase(string title, string author, string filePath)
    {
        if (_knownBooks.Contains((title, author))) return;

        _knownBooks.Add((title, author));
        File.AppendAllText(filePath, $"{title},{author}\n");
    }

    /// <summary>
    /// Проверка на плагиат 
    /// </summary>
    public bool IsPlagiarism(string title, string author)
    {
        foreach (var (dbTitle, dbAuthor) in _knownBooks)
            if (string.Equals(dbTitle, title, StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(dbAuthor, author, StringComparison.OrdinalIgnoreCase))
                return true;
        return false;
    }

    public bool OrderBook(Book book)
    {
        if (Balance < book.Price)
            return false;

        Balance -= book.Price;
        IncomingBooks.Enqueue(book);
        return true;
    }
}
