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
    /// <summary>
    /// Метод добавления книги на полку 
    /// </summary>
    public void AddBook(Book book)
    {
        // если полка пустая, она принимает любой жанр и "фиксирует" его
        if (string.IsNullOrEmpty(Genre))
        {
            Genre = book.Genre;
        }
        // Проверка жанра только если полка уже имеет зафиксированный жанр
        else if (book.Genre != Genre)
        {
            throw new ArgumentException(
                $"Невозможно добавить книгу жанра '{book.Genre}' на полку жанра '{Genre}'",
                nameof(book));
        }

        if (CurrentCount >= Capacity)
            throw new InvalidOperationException(
                $"Полка жанра '{Genre}' достигла максимальной вместимости");

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

    /// <summary>
    /// Метод удаления книги с полки
    /// </summary>
    public bool RemoveBook(Book book)
    {
        bool removed = _books.Remove(book);

        //  если полка стала пустой, сбрасываем привязку к жанру
        if (removed && _books.Count == 0)
        {
            Genre = string.Empty; // или null, в зависимости от вашей логики
        }

        return removed;
    }




}