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

    public IReadOnlyCollection<Bookshelf> Shelves => _shelves.AsReadOnly();

    /// <summary>
    /// Конструктор класса BookStore
    /// </summary>
    /// <param name="maxShelves">Максимальное количество полок</param>
    public BookStore(int maxShelves)
    {
        MaxShelves = maxShelves;
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

    ///// <summary>
    ///// Метод получения всех полок магазина
    ///// </summary>
    ///// <returns>Коллекция полок</returns>
    //public IEnumerable<Bookshelf> GetShelves()
    //{
    //    return _shelves;
    //}

    /// <summary>
    /// Метод обработки продажи книги
    /// </summary>
    /// <param name="book">Продаваемая книга</param>
    public void ProcessSale(Book book)
    {
        // Поиск полки, на которой находится книга
        Bookshelf shelf = FindShelfWithBook(book);
        // Получение суммы продажи
        decimal saleAmount = book.Sell(shelf);
        // Обновление баланса магазина
        Balance += saleAmount;

    }
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

}
