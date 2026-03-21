namespace Lab3.BookStoreLibrary;

public class BookMismatch
{
    private Random random;
    /// <summary>
    /// Создание плагиата
    /// </summary>
    /// <param name="titles">Названия книг из "Базы данных"</param>
    /// <param name="authors">Авторы из "Базы данных"</param>
    /// <returns>Не соответствующие друг другу автор и название книги</returns>
    public string [] GeneratePlagiarism(List<string> titles, List<string> authors)
    {
        random = new Random();

        // Перемешиваем списки
        Shuffle(titles);
        Shuffle(authors);

        // Создаем фальшивую книгу
        string fakeTitle = titles[random.Next(titles.Count)];
        string fakeAuthor = authors[random.Next(authors.Count)];

        // Проверяем, чтобы не совпала оригинальная комбинация
        for (int i = 0; i < titles.Count; i++)
        {
            while(fakeTitle == titles[i] && fakeAuthor == authors[i])
            {
                fakeAuthor = authors[random.Next(authors.Count)];
            }
        }
        return [fakeTitle, fakeAuthor];
    }
    /// <summary>
    /// Перемешивание массивов
    /// </summary>
    /// <param name="list">Массив для перемешивания</param>
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    /// <summary>
    /// Создание названий с опечаткой
    /// </summary>
    /// <param name="originalTitle">Оригинальное название</param>
    /// <returns>Название с опечаткой</returns>
    public string GenerateTypo(string originalTitle)
    {
        string[] validChars = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я", " " };
        // Выбираем случайную позицию для замены
        int index = random.Next(originalTitle.Length);
        char originalChar = originalTitle[index];

        // Получаем список допустимых символов без исходного
        List<string> possibleChars = validChars.Where(c => c != originalChar.ToString()).ToList();

        // Выбираем новый символ
        string newChar = possibleChars[random.Next(possibleChars.Count)];

        // Формируем новое название с опечаткой
        return originalTitle.Substring(0, index) + newChar + originalTitle.Substring(index + 1);
    }
    /// <summary>
    /// Проверка на плагиат
    /// </summary>
    /// <param name="titles">Возможные названия книг</param>
    /// <param name="authors">Возможные авторы</param>
    /// <param name="incomingTitle">Проверяемое название</param>
    /// <param name="incomingAuthor">Проверяемый автор</param>
    /// <returns>true, если в "Базе данных" название не соответствует автору</returns>
    public bool IsPlagiarism(List<string> titles, List<string> authors, string incomingTitle, string incomingAuthor)
    {
        List<int> indexes = new List<int>();
        // Проверяем, существует ли такое название в базе
        if (titles.Contains(incomingTitle, StringComparer.OrdinalIgnoreCase))
        {
            for (int i = 0; i < titles.Count; i++)
            {
                // Получаем все индексы, где встречается это название
                if (titles[i].Equals(incomingTitle, StringComparison.OrdinalIgnoreCase))
                {
                    indexes.Add(i);
                }
            }
            var titleIndexes = indexes;

            // Проверяем, все ли авторы для этого названия совпадают с incomingAuthor
            foreach (var index in titleIndexes)
            {
                // Если нашли название с другим автором - это плагиат
                if (!authors[index].Equals(incomingAuthor, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }
        return false;
    }
    /// <summary>
    /// Проверка на опечатку
    /// </summary>
    /// <param name="incomingTitle">Проверяемая строка</param>
    /// <param name="existingTitles">Возможные варианты названий </param>
    /// <returns>true, если в проверяемом названии есть опечатка</returns>
    public bool IsTypo(string incomingTitle, List<string> existingTitles)
    {
        // Предварительно фильтруем по длине
        var candidates = existingTitles.Where(t => t.Length == incomingTitle.Length).ToList();

        foreach (var candidate in candidates)
        {
            if (CheckSingleDifference(incomingTitle, candidate))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Проверка на ровно одно различие в строках
    /// </summary>
    /// <param name="title1">Строка 1</param>
    /// <param name="title2">Строка 2</param>
    /// <returns>true, если в сравниваемых строках ровно одно отличие</returns>
    private bool CheckSingleDifference(string title1, string title2)
    {
        int diffCount = 0;
        for (int i = 0; i < title1.Length; i++)
        {
            if (title1[i] != title2[i])
            {
                diffCount++;
                if (diffCount > 1)
                    return false;
            }
        }
        return diffCount == 1;
    }

}
