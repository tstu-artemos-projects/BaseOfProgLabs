using System.Collections;
using System.Security.Principal;
using BookStoreLibrary;

namespace BookStoreLibrary
{
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

        public static Book GenerateRandomBook()
        {
            /// <summary>
            /// Статический метод создания случайной книги
            /// </summary>
            /// <returns>Объект книги с случайными параметрами</returns>
            var random = new Random();
            string [] book_name = ReadBase("BookName");
            string[] authors = ReadBase("Authors");
            string[] genre = ReadBase("Genre");
            return new Book(
                title: book_name[random.Next(0, book_name.Length)],
                author: authors[random.Next(0, authors.Length)],
                genre: genre[random.Next(0, genre.Length)],
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
            shelf.RemoveBook(Title);
            return Price;
        }

        /// <summary>
        /// Статический метод чтения базы данных из файла
        /// </summary>
        /// <param name="file_name">Имя файла с данными</param>
        /// <returns>Массив строк из файла</returns>
        public static string [] ReadBase(string file_name)
        {
            StreamReader f = new StreamReader(file_name);
            string s = f.ReadToEnd();
            string[] buf = s.Split("\n");
            return buf;
        }
    }

    
}
