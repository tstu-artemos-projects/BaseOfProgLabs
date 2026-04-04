namespace Lab3.BookStoreLibraryTests;
public class BookTest
{
    [Fact]
    // Проверяем, что при создании книги через конструктор все её свойства (название, автор, жанр, кол-во страниц, цена) получают правильные значения, переданные в конструктор.
    // Также проверяем, что у новой книги автоматически генерируется уникальный Id.
    public void TestBookCreation_InitializesPropertiesCorrectly()
    {
        string title = "Тестовая книга";
        string author = "Тестовый автор";
        string genre = "Тестовый жанр";
        int pageCount = 300;
        decimal price = 999.99m;

        var book = new Book(title, author, genre, pageCount, price);

        Assert.Equal(title, book.Title);
        Assert.Equal(author, book.Author);
        Assert.Equal(genre, book.Genre);
        Assert.Equal(pageCount, book.PageCount);
        Assert.Equal(price, book.Price);

        Assert.NotEqual(Guid.Empty, book.Id);
    }

    [Fact]
    // Проверяем, что статический метод GenerateRandomBook корректно создает новый объект книги, выбирая случайные значения для названия, автора и жанра из переданных ему массивов.
    // Также проверяем, что кол-во страниц и цена находятся в заданных диапазонах.
    public void TestGenerateRandomBook_CreatesValidBookFromArrays()
    {
        string[] testNames = { "Книга1", "Книга2" };
        string[] testAuthors = { "Автор1", "Автор2" };
        string[] testGenres = { "Жанр1", "Жанр2" };

        var randomBook = Book.RandomBookFromDatabase(
            testNames.Select((value, index) => new BookTitlingRecord(value, testAuthors[index], testGenres[index])).ToArray()
        );

        Assert.NotNull(randomBook);
        Assert.Contains(randomBook.Title, testNames);
        Assert.Contains(randomBook.Author, testAuthors);
        Assert.Contains(randomBook.Genre, testGenres);
        Assert.InRange(randomBook.PageCount, 100, 1999);
        Assert.InRange(randomBook.Price, 100m, 4999m);
    }
}
