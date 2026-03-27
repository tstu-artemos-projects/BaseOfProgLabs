namespace Lab3.UI;

public record BookTitlingRecord(string Title, string Author);

public class DatabaseProcessing
{
    public const string DATABASE_FILENAME = "Database.txt";
    public const string BOOK_AUTHOR_PAIRS_FILENAME = "BookAuthorPairs.txt";
    public const string GGENRES_FILENAME = "Genre.txt";

    /// <summary>
    /// Разбивает массив записей о книгах на два отдельных массива: один для названий книг, другой для авторов. Каждый элемент в массиве названий книг соответствует элементу в массиве авторов по индексу.
    /// </summary>
    /// <param name="records">Массив записей пар "название книга"</param>
    /// <returns>Первый массив - названия, второй - авторы</returns>
    public static (string[], string[]) SplitBookTitlingRecord(BookTitlingRecord[] records)
    {
        var title = records.Select(r => r.Title).ToArray();
        var authors = records.Select(r => r.Author).ToArray();

        return (title, authors);
    }

    /// <summary>
    /// Статический метод чтения базы данных из файла
    /// </summary>
    /// <param name="fileName">Имя файла с данными</param>
    /// <returns>Массив строк из файла</returns>
    private static BookTitlingRecord[] ReadBookAuthorPairs(string fileName)
    {
        string[] titles;
        string[] authors;
        if (!File.Exists(fileName))
        {
            return Array.Empty<BookTitlingRecord>(); // Возвращаем пустые массивы, если файл не найден
        }

        var lines = File.ReadAllLines(fileName);

        List<BookTitlingRecord> records = new List<BookTitlingRecord>();

        for (int i = 0; i + 1 < lines.Length; i += 2)
        {
            records.Add(new BookTitlingRecord(lines[i], lines[i + 1]));
        }

        return records.ToArray();
    }

    /// <summary>
    /// Чтение из файлов с жанрами и возвращение массива жанров
    /// </summary>
    /// <returns>Массив жанров</returns>
    public static string[] ReadGenres()
    {
        string[] GenreBase;

        if (File.Exists(GGENRES_FILENAME))
            GenreBase = File.ReadAllLines(GGENRES_FILENAME);
        else
            GenreBase = Array.Empty<string>(); // Или используйте стандартный набор

        return GenreBase;
    }

    /// <summary>
    /// Инициализация базы данных. Если файл с данными не найден, то он создается на основе другого файла с парами "книга-автор"
    /// </summary>
    /// <returns>Пары книг "название-автор"</returns>
    public static BookTitlingRecord[] InitDatabase()
    {
        var pairs = ReadBookAuthorPairs(DATABASE_FILENAME);

        if (pairs.Length == 0)
        {
            pairs = ReadBookAuthorPairs(BOOK_AUTHOR_PAIRS_FILENAME);
            WriteDatabase(pairs);
        }

        return pairs;
    }

    /// <summary>
    /// Записать в файл базу данных, которая состоит из пар "название книги - автор"
    /// </summary>
    /// <param name="records">
    /// Пары книг "название-автор", которые нужно записать в файл. Каждая пара будет записана в виде двух строк: первая строка - название книги, вторая строка - автор книги.
    /// </param>
    public static void WriteDatabase(BookTitlingRecord[] records)
    {
        List<string> lines = new List<string>();
        foreach (var record in records)
        {
            lines.Add(record.Title);
            lines.Add(record.Author);
        }
        File.WriteAllLines(DATABASE_FILENAME, lines);
    }
}