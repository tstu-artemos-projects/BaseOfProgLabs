namespace Lab3.BookStoreLibrary;

/// <summary>
/// Класс, представляющий книгу в магазине
/// </summary>
public class Book
{
    // Уникальный идентификатор книги
    public Guid Id { get; private set; }
    // Название книги
    public string Title { get; private set; }
    // Автор книги
    public string Author { get; private set; }
    // Жанр книги
    public string Genre { get; private set; }
    // Количество страниц
    public int PageCount { get; private set; }
    // Цена книги
    public decimal Price { get; private set; }

    /// <summary>
    /// Конструктор класса Book
    /// </summary>
    /// <param name="title">Название книги</param>
    /// <param name="author">Автор книги</param>
    /// <param name="genre">Жанр книги</param>
    /// <param name="pageCount">Количество страниц</param>
    /// <param name="price">Цена книги</param>
    public Book(string title, string author, string genre, int pageCount, decimal price)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        Genre = genre;
        PageCount = pageCount;
        Price = price;
    }

    /// <summary>
    /// Статический метод создания случайной книги
    /// </summary>
    /// <param name="authors">Массив авторов для случайного выбора</param>
    /// <param name="bookNames">Массив названий книг для случайного выбора</param>
    /// <param name="genres">Массив жанров для случайного выбора</param>
    /// <returns>Объект книги с случайными параметрами</returns>
    public static Book GenerateRandomBook(
        string[] bookNames,
        string[] authors,
        string[] genres
    )
    {
        var random = new Random();
        return new Book(
            title: bookNames[random.Next(0, bookNames.Length)],
            author: authors[random.Next(0, authors.Length)],
            genre: genres[random.Next(0, genres.Length)],
            pageCount: random.Next(100, 2000),
            price: random.Next(100, 5000)
        );
    }

    /// <summary>
    /// Метод продажи книги
    /// </summary>
    /// <param name="shelf">Полка, с которой продается книга</param>
    /// <returns>Сумма продажи</returns>
    public decimal Sell(Bookshelf shelf)
    {
        shelf.RemoveBook(this);
        return Price;
    }
}
