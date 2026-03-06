namespace Lab3.UI;

public partial class BibleForm : Form
{
    private bool _isProgrammaticChange = false; // проверка изменения из программы

    /// <summary>
    /// Статический метод чтения базы данных из файла
    /// </summary>
    /// <param name="fileName">Имя файла с данными</param>
    /// <returns>Массив строк из файла</returns>
    public static string[] ReadBase(string fileName)
    {
        StreamReader f = new(fileName);
        string s = f.ReadToEnd();
        string[] buf = s.Split("\n");
        return buf;
    }

    public readonly string[] RandomGenreBase = ReadBase("Genre.txt");
    public readonly string[] RandomAuthorBase = ReadBase("Authors.txt");
    public readonly string[] RandomBookNameBase = ReadBase("BookName.txt");

    public BibleForm()
    {
        InitializeComponent();
    }

    private void btnNewBook_Click(object sender, EventArgs e)
    {
        _isProgrammaticChange = true;
        tabControlNewBook.SelectedTab = tabNewBook;
        _isProgrammaticChange = false;
    }

    private void btnSupport_Click(object sender, EventArgs e)
    {
        _isProgrammaticChange = true;
        tabControlNewBook.SelectedTab = tabPageSupport;
        _isProgrammaticChange = false;
    }

    private void btnMarket_Click(object sender, EventArgs e)
    {
        _isProgrammaticChange = true;
        tabControlNewBook.SelectedTab = tabPageMarket;
        _isProgrammaticChange = false;
    }

    private void tabControlNewBook_Selecting(object sender, TabControlCancelEventArgs e)
    {
        // Если вкладка меняется кликом мыши, а не кодом — отменяем действие
        if (!_isProgrammaticChange)
        {
            e.Cancel = true;
        }
    }

    private void buttonClearNewBook_Click(object sender, EventArgs e)
    {
        textBoxTitleBook.Clear();
        textBoxAutor.Clear(); // очистка текстовых полей

        if (comboBoxType.Items.Count > 0)
            comboBoxType.SelectedIndex = -1; // очистка комбобокса

        numericUpDownPages.Value = numericUpDownPages.Minimum;
        numericUpDownPrice.Value = numericUpDownPrice.Minimum; // очистка цены и страниц

        labelIDforUsing.Text = "(будет назначен автоматически)"; // обнуление label с ID

        textBoxTitleBook.Focus(); // для удобства переводим фокус на первое поле
    }

    private void btnAddNewBook_Click(object sender, EventArgs e)
    {
        try
        {
            ValidateInput(); // проверка валидации
            // Тут логика добавления...
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void ShowError(Exception ex)
    {
        string message, title;

        switch (ex)
        {
            case ArgumentException argEx:
                message = $"Ошибка в поле {argEx.ParamName}: {argEx.Message}";
                title = "Ошибка валидации";
                break;

            case FormatException:
                message = "Неверный формат входных данных.";
                title = "Ошибка формата";
                break;

            default:
                message = $"Непредвиденная ошибка: {ex.Message}";
                title = "Критическая ошибка";
                break;
        }

        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void ValidateInput()
    {
        // Проверка названия для поиска
        if (string.IsNullOrWhiteSpace(textBoxSearchTitle.Text))
            throw new ArgumentException("Поле 'Поиск по названию' не может быть пустым", "SearchTitle");

        // Проверка ID (должно быть числом)
        if (!int.TryParse(textBoxSearchID.Text, out int id) || id <= 0)
            throw new ArgumentException("ID должен быть положительным целым числом", "SearchID");

        // Проверка названия книги
        if (string.IsNullOrWhiteSpace(textBoxTitleBook.Text))
            throw new ArgumentException("Название книги обязательно для заполнения", "TitleBook");

        // Проверка автора
        if (string.IsNullOrWhiteSpace(textBoxAutor.Text))
            throw new ArgumentException("Укажите автора книги", "Author");

        // Проверка количества страниц
        if (numericUpDownPages.Value <= 0)
            throw new ArgumentException("Количество страниц должно быть больше 0", "Pages");
    }

    private void buttonReturn1_Click(object sender, EventArgs e) => tabControlNewBook.SelectedTab = tabPageMain;
    private void buttonReturn2_Click(object sender, EventArgs e) => tabControlNewBook.SelectedTab = tabPageMain;
    private void buttonReturn3_Click(object sender, EventArgs e) => tabControlNewBook.SelectedTab = tabPageMain;

    private void buttonSearch1_Click(object sender, EventArgs e)
    {
        try
        {
            ValidateInput();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void listViewBooks_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Если в списке выбрана хотя бы одна книга
        if (listViewBooks.SelectedItems.Count > 0)
        {
            groupBoxSearch.Visible = false;
            groupBoxDetails.Visible = true;

            // Пример получения данных (логика заглушки)
            var title = listViewBooks.SelectedItems[0].Text;
            var author = "Автор книги";
            var price = 500;

            labelInfo.Text = $"Книга: {title}\nАвтор: {author}\nЦена: {price} руб.";

            // Устанавливаем детали на то же место, где был поиск
            groupBoxDetails.Location = groupBoxSearch.Location;
            groupBoxDetails.Size = groupBoxSearch.Size;
        }
        else
        {
            groupBoxSearch.Visible = true;
            groupBoxDetails.Visible = false;
        }
    }

    private void btnBackToSearch_Click(object sender, EventArgs e)
    {
        listViewBooks.SelectedIndices.Clear(); // Снимаем выделение, чтобы вернуться к поиску
    }

    private void btnSell_Click(object sender, EventArgs e)
    {
        if (listViewBooks.SelectedItems.Count > 0)
        {
            var selectedItem = listViewBooks.SelectedItems[0];
            listViewBooks.Items.Remove(selectedItem); // удаление книги из списка

            groupBoxDetails.Visible = false;
            groupBoxSearch.Visible = true;

            MessageBox.Show("Книга успешно продана!", "Продажа");
        }
    }
}