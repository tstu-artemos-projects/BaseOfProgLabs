namespace Lab3.BookStoreLibrary;

/// <summary>
/// Класс, представляющий книжную полку
/// </summary>
public class Bookshelf
{
    // Приватное поле для хранения списка книг
    private readonly List<Book> _books = new();

    // Жанр книг, которые может содержать полка
    public string Genre { get; private set; }
    // Максимальная вместимость полки
    public int Capacity { get; private set; }
    // Текущее количество книг на полке
    public int CurrentCount => _books.Count;

    public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

    /// <summary>
    /// Конструктор класса Bookshelf
    /// </summary>
    /// <param name="genre">Жанр книг для полки</param>
    /// <param name="capacity">Максимальная вместимость полки</param>
    public Bookshelf(string genre, int capacity)
    {
        Genre = genre;
        Capacity = capacity;
    }

    /// <summary>
    /// Метод добавления книги на полку
    /// </summary>
    /// <param name="book">Книга для добавления</param>
    public void AddBook(Book book)
    {
        if (book.Genre != Genre)
            throw new ArgumentException($"Невозможно добавить книгу жанра {book.Genre} на полку жанра {Genre}", nameof(book));
        if (CurrentCount >= Capacity)
            throw new InvalidOperationException($"Полка жанра {Genre} достигла своей максимальной вместимости");
        _books.Add(book);
    }

    /// <summary>
    /// Метод поиска книги по названию
    /// </summary>
    /// <param name="title">Название книги</param>
    /// <returns>Найденная книга или null</returns>
    public Book FindBookByTitle(string title)
    {
        var candidate = _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase));
        if (candidate == null)
            throw new InvalidDataException($"Книга с названием '{title}' не найдена на полке жанра {Genre}");
        return candidate;
    }

    /// <summary>
    /// Метод поиска книги по идентификатору
    /// </summary>
    /// <param name="id">ID книги</param>
    /// <returns>Найденная книга или null</returns>
    public Book FindBookById(Guid id)
    {
        var candidate = _books.FirstOrDefault(b => b.Id == id);
        if (candidate == null)
            throw new InvalidDataException($"Книга с идентификатором '{id}' не найдена на полке жанра {Genre}");
        return candidate;
    }

    ///// <summary>
    ///// Метод получения всех книг с сортировкой по названию
    ///// </summary>
    ///// <returns>Отсортированный список книг</returns>
    //public IEnumerable<Book> GetAllBooks()
    //{
    //    return _books.OrderBy(b => b.Title);
    //}

    /// <summary>
    /// Метод удаления книги по названию
    /// </summary>
    /// <param name="book">Удаляемая книга</param>
    /// <returns>true если книга удалена успешно, иначе false</returns>
    public bool RemoveBook(Book book)
    {
        return _books.Remove(book);
    }

    ///// <summary>
    ///// Метод проверки наличия книги на полке
    ///// </summary>
    ///// <param name="book">Книга для проверки</param>
    ///// <returns>true если книга есть на полке, иначе false</returns>
    //public bool ContainsBook(Book book)
    //{
    //    return _books.Contains(book);
    //}
}