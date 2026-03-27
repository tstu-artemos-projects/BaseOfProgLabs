namespace Lab3.BookStoreLibrary;

/// <summary>
/// Класс, представляющий книгу в магазине
/// </summary>
public class Book
{
    public Guid Id { get; private set; } // Уникальный идентификатор книги
    public string Title { get; private set; } // Название книги  
    public string Author { get; private set; } // Автор книги   
    public string Genre { get; private set; } // Жанр книги  
    public int PageCount { get; private set; } // Количество страниц   
    public decimal Price { get; private set; } // Цена книги

    public bool IsOrdered { get; private set; }
    public bool IsPlagiarism { get; set; } // Является ли книга плагиатом
    public bool HasTypo { get; set; } // Есть ли опечатка в названии
    public string? OriginalTitle { get; set; } // Правильное название (если есть ошибка)
    public int EditionNumber { get; set; } = 1; // Номер издания (для сиквелов)
    public decimal PurchasePrice { get; private set; }


    // Вычисляемое свойство для отображения названия с учётом сиквела
    public string DisplayTitle => EditionNumber > 1 ? $"{Title} {EditionNumber}" : Title;//Если EditionNumber = 1, то возвращает Бесы, если EditionNumber = 2 возвращает Бесы 2

    /// <summary>
    /// Конструктор класса Book
    /// </summary>
    /// <param name="title">Название книги</param>
    /// <param name="author">Автор книги</param>
    /// <param name="genre">Жанр книги</param>
    /// <param name="pageCount">Количество страниц</param>
    /// <param name="price">Цена книги</param>
    /// <param name="isOrdered">Заказана ли книга?</param>
    public Book(string title, string author, string genre, int pageCount, decimal price, bool isOrdered = false)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        Genre = genre;
        PageCount = pageCount;
        Price = price;
        PurchasePrice = price;

        IsPlagiarism = false;
        HasTypo = false;
        OriginalTitle = title;
        EditionNumber = 1;
        IsOrdered = isOrdered;
    }


    /// <summary>
    /// Статический метод создания случайной книги
    /// </summary>
    /// <param name="authors">Массив авторов для случайного выбора</param>
    /// <param name="bookNames">Массив названий книг для случайного выбора</param>
    /// <param name="genres">Массив жанров для случайного выбора</param>
    /// <returns>Объект книги с случайными параметрами</returns>
    public static Book GenerateRandomBook(string[] bookNames, string[] authors, string[] genres)
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

    /// <summary>
    /// Создаёт сиквел книги 
    /// </summary>
    public static Book CreateSequel(Book originalBook)
    {
        var sequel = new Book(
            originalBook.Title,
            originalBook.Author,
            originalBook.Genre,  // Жанр может отличаться, но название и автор - те же
            originalBook.PageCount,
            originalBook.Price
        )
        {
            EditionNumber = originalBook.EditionNumber + 1,
            OriginalTitle = originalBook.OriginalTitle
        };
        return sequel;
    }

    /// <summary>
    /// Создаёт копию книги с опечаткой в названии
    /// </summary>
    public Book CreateWithTypo()
    {
        var typoBook = new Book(Title, Author, Genre, PageCount, Price)
        {
            HasTypo = true,
            OriginalTitle = Title,
            IsPlagiarism = false
        };

        // Замена случайного символа (исключая повтор той же буквы)
        var random = new Random();
        var chars = Title.ToCharArray();
        int index = random.Next(0, chars.Length);
        char originalChar = chars[index];

        // Подбираем другой символ
        char newChar;
        do
        {
            newChar = (char)random.Next(32, 126); 
        } 
        while (newChar == originalChar);

        chars[index] = newChar;
        typoBook.Title = new string(chars);

        return typoBook;
    }
}
