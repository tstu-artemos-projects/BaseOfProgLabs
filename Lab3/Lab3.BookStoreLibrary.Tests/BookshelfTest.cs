namespace Lab3.BookStoreLibraryTests;

public class BookshelfTest
{
    // Проверяем, что при создании полки правильно устанавливаются жанр и вместимость
    [Fact]
    public void Constructor_SetsGenreAndCapacity()
    {
        var shelf = new Bookshelf("Фантастика", 3);
        Assert.Equal("Фантастика", shelf.Genre);
        Assert.Equal(3, shelf.Capacity);
    }

    [Fact]
    public void FindBookById_ThrowsInvalidDataException_WhenWrongId()
    {
        var shelf = new Bookshelf("Детектив", 5);

        Assert.Throws<InvalidDataException>(() => shelf.FindBookById(new Guid()));
    }
    
    [Fact]
    public void FindBookByName_ThrowsInvalidDataException_WhenWrongName()
    {
        var shelf = new Bookshelf("Детектив", 5);

        Assert.Throws<InvalidDataException>(() => shelf.FindBookByTitle("sdfsadg"));
    }

    //Проверяем, что книга правильного жанра успешно добавляется и счётчик увеличивается
    [Fact]
    public void AddBook_CorrectGenre_IncreasesCount()
    {
        var shelf = new Bookshelf("Детектив", 5);
        var book = new Book("Кейс №1", "А. Иванов", "Детектив", 200, 299.99m);

        shelf.AddBook(book);

        Assert.Equal(1, shelf.CurrentCount);
        Assert.Contains(book, shelf.Books);
    }

    // Проверяем, что при попытке добавить книгу другого жанра выбрасывается исключение
    [Fact]
    public void AddBook_WrongGenre_ThrowsArgumentException()
    {
        var shelf = new Bookshelf("Поэзия", 10);
        var book = new Book("Роман", "Б. Петров", "Роман", 300, 199.00m);

        var ex = Assert.Throws<ArgumentException>(() => shelf.AddBook(book));
        Assert.Contains("Роман", ex.Message);
    }

    // Проверяем, что при попытке добавить книгу в заполненную полку выбрасывается исключение
    [Fact]
    public void AddBook_WhenFull_ThrowsInvalidOperationException()
    {
        var shelf = new Bookshelf("Наука", 1);
        var book1 = new Book("Теория", "С. Сидоров", "Наука", 150, 499.00m);
        shelf.AddBook(book1);

        var book2 = new Book("Практика", "С. Сидоров", "Наука", 120, 399.00m);
        var ex = Assert.Throws<InvalidOperationException>(() => shelf.AddBook(book2));
        Assert.Contains("максимальной вместимости", ex.Message);
    }

    // Проверяем, что поиск книги по названию (без учёта регистра) возвращает правильную книгу
    [Fact]
    public void FindBookByTitle_FindsBook()
    {
        var shelf = new Bookshelf("Фэнтези", 2);
        var book = new Book("Властелин колец", "Тolkien", "Фэнтези", 1200, 999.99m);
        shelf.AddBook(book);

        var found = shelf.FindBookByTitle("властелин колец"); // регистр не важен
        Assert.Same(book, found);
    }

    // Проверяем, что поиск книги по ID возвращает правильную книгу
    [Fact]
    public void FindBookById_FindsBook()
    {
        var shelf = new Bookshelf("История", 1);
        var book = new Book("Римская империя", "А. Кузнецов", "История", 500, 599.00m);
        shelf.AddBook(book);

        var found = shelf.FindBookById(book.Id);
        Assert.Same(book, found);
    }

    // Проверяем, что удаление книги проходит успешно и счётчик уменьшается
    [Fact]
    public void RemoveBook_RemovesBook()
    {
        var shelf = new Bookshelf("Психология", 1);
        var book = new Book("Мышление", "Д. Канеман", "Психология", 400, 799.00m);
        shelf.AddBook(book);

        bool removed = shelf.RemoveBook(book);
        Assert.True(removed);
        Assert.Equal(0, shelf.CurrentCount);
    }
}