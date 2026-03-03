using BookStoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

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
        if (!(CurrentCount >= Capacity && book.Genre != Genre))
        _books.Add(book);
    }

    // <summary>
    /// Метод поиска книги по названию
    /// </summary>
    /// <param name="title">Название книги</param>
    /// <returns>Найденная книга или null</returns>
    public Book FindByTitle(string title)
    {
        return _books.FirstOrDefault(b => b.Title == title);
    }

    /// <summary>
    /// Метод поиска книги по идентификатору
    /// </summary>
    /// <param name="id">ID книги</param>
    /// <returns>Найденная книга или null</returns>
    public Book FindById(Guid id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    /// <summary>
    /// Метод получения всех книг с сортировкой по названию
    /// </summary>
    /// <returns>Отсортированный список книг</returns>
    public IEnumerable<Book> GetAllBooks()
    {
        return _books.OrderBy(b => b.Title);
    }

    /// <summary>
    /// Метод удаления книги по названию
    /// </summary>
    /// <param name="title">Название удаляемой книги</param>
    /// <returns>true если книга удалена, иначе false</returns>
    public bool RemoveBook(string title)
    {
        Book bookToRemove = FindByTitle(title);

        if (bookToRemove != null)
        {
            return _books.Remove(bookToRemove);
        }

        return false;
    }

    /// <summary>
    /// Метод проверки наличия книги на полке
    /// </summary>
    /// <param name="book">Книга для проверки</param>
    /// <returns>true если книга есть на полке, иначе false</returns>
    public bool ContainsBook(Book book)
    {
        return _books.Contains(book);
    }
}