namespace Lab3StoreLibraryTests
{
    public class BookStoreTest
    {
        // Успешное добавление полки в магазин
        [Fact]
        public void AddShelf_WhenValid_ShouldAddShelf()
        {
            var store = new BookStore(5);
            var shelf = new Bookshelf("Фантастика", 10); // Исправлено: указан capacity

            store.AddShelf(shelf);

            Assert.Single(store.Shelves);
            Assert.Equal("Фантастика", store.Shelves.First().Genre);
        }

        [Fact]
        public void RemoveShelf_WhenValid_ShouldRemoveShelf()
        {
            var store = new BookStore(5);
            var shelf = new Bookshelf("Фантастика", 10); // Исправлено: указан capacity

            store.AddShelf(shelf);

            Assert.True(store.RemoveShelf(shelf));
        }

        //Попытка добавить больше полок, чем разрешено — выбрасывает исключение
        [Fact]
        public void AddShelf_WhenMaxShelvesReached_ShouldThrowException()
        {
            var store = new BookStore(1);
            var shelf1 = new Bookshelf("Фантастика", 10);
            var shelf2 = new Bookshelf("Детектив", 10);

            store.AddShelf(shelf1);

            var exception = Assert.Throws<InvalidOperationException>(() => store.AddShelf(shelf2));
            Assert.Contains("Максимальное количество полок в магазине достигнуто", exception.Message);
        }

        // Тест: Продажа книги увеличивает баланс магазина
        [Fact]
        public void ProcessSale_WhenBookExists_ShouldUpdateBalance()
        {
            var store = new BookStore(5);
            var shelf = new Bookshelf("Фантастика", 10);
            var book = new Book("Властелин колец", "Дж.Р.Р. Толкин", "Фантастика", 1200, 10.50m);
            shelf.AddBook(book);
            store.AddShelf(shelf);

            store.ProcessSale(book);

            Assert.Equal(10.50m, store.Balance);
        }

        //Продажа книги, которой нет в магазине — выбрасывает исключение
        [Fact]
        public void ProcessSale_WhenBookNotFound_ShouldThrowException()
        {
            var store = new BookStore(5);
            var bookNotInStore = new Book("Чужая книга", "Аноним", "Научная фантастика", 300, 5.00m);

            var exception = Assert.Throws<InvalidDataException>(() => store.ProcessSale(bookNotInStore));
            Assert.Contains("не найдена ни на одной полке магазина", exception.Message);
        }

        // Начальный баланс магазина равен нулю
        [Fact]
        public void Constructor_InitialBalance_ShouldBeZero()
        {
            var store = new BookStore(5);
            Assert.Equal(0m, store.Balance);
        }
    }
}