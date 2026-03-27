using Lab3.BookStoreLibrary;
using System.Runtime;

namespace Lab3.UI;

public partial class BibleForm : Form
{
    private bool _isProgrammaticChange = false; // проверка изменения из программы

    private readonly BookStore _store;
    private const int MaxShelves = 5;
    private const int MaxBooksInShelves = 5;

    private readonly string[] _randomAuthorBase;
    private readonly string[] _randomBookNameBase;
    private readonly string[] _randomGenreBase;

    private readonly CustomerQueue _customerQueue;
    private readonly BookMismatch _mismatchLogic = new();
    private readonly GameSettings _settings;
    private readonly GameStats _stats = new();
    private int _remainingTime;

    private const int DeliveryDelay = 10;
    private readonly List<(Book Book, int ArrivalTick)> _shippingOrders = new();

    private System.Windows.Forms.Timer _deliveryTimer;
    private System.Windows.Forms.Timer _customerTimer;
    private System.Windows.Forms.Timer _gameTickTimer;

    public BibleForm(Difficulty difficulty)
    {
        _randomGenreBase = DatabaseProcessing.ReadGenres();
        var dataBase = DatabaseProcessing.InitDatabase();

        (_randomBookNameBase, _randomAuthorBase) = DatabaseProcessing.SplitBookTitlingRecord(dataBase);

        _store = new BookStore(MaxShelves, difficulty);
        _settings = GameSettings.GetByDifficulty(difficulty);
        _customerQueue = new CustomerQueue(_settings.MaxQueue);

        InitializeComponent();

        comboBoxType.Items.AddRange(_randomGenreBase);
        SetupGame();
    }

    #region Игровая логика
    private void SetupGame()
    {
        _customerQueue.QueueLimitReached += () => EndGame("Очередь переполнена!");
        _customerQueue.UnsatisfiedLimitReached += () => EndGame("Слишком много недовольных клиентов!");

        _deliveryTimer = new System.Windows.Forms.Timer { Interval = _settings.DeliveryInterval };
        _deliveryTimer.Tick += OnDeliveryTick;

        _customerTimer = new System.Windows.Forms.Timer { Interval = _settings.CustomerInterval };
        _customerTimer.Tick += OnCustomerTick;


        _gameTickTimer = new System.Windows.Forms.Timer { Interval = _settings.DayDurationSeconds * 1000 };
        _gameTickTimer.Tick += OnGameTick;


        _deliveryTimer.Start();
        _customerTimer.Start();
        _gameTickTimer.Start();

        UpdateStatsLabel();
    }

    private void OnGameTick(object? sender, EventArgs e)
    {
        _remainingTime--;

        if (_remainingTime <= 0)
        {
            EndGame("Рабочий день окончен! Вы победили!", isVictory: true);
        }

        if (_store.Balance <= 0)
        {
            EndGame("Банкротство! Баланс исчерпан.");
        }

        UpdateStatsLabel();
    }

    private void OnDeliveryTick(object? sender, EventArgs e)
    {
        //var records = DatabaseProcessing.InitDatabase();
        //if (records.Length <= 0)
        //    return;
        //var record = records[new Random().Next(records.Length)];

        //Book deliveryBook = new Book(record.Title, record.Author,
        //                             _randomGenreBase[new Random().Next(_randomGenreBase.Length)],
        //                             new Random().Next(100, 500),
        //                             new Random().Next(200, 1000));

        //// С шансом 30% создаем ошибку
        //int chance = new Random().Next(100);
        //if (chance < 15) // Плагиат
        //{
        //    var otherRecord = records[new Random().Next(records.Length)];
        //    var fakeData = _mismatchLogic.GeneratePlagiarism(records.Select(r => r.Title).ToList(), records.Select(r => r.Author).ToList());
        //    deliveryBook = new Book(fakeData[0], fakeData[1], deliveryBook.Genre, deliveryBook.PageCount, deliveryBook.Price);
        //    deliveryBook.IsPlagiarism = true;
        //}
        //else if (chance < 30) // Опечатка
        //{
        //    string typoTitle = _mismatchLogic.GenerateTypo(deliveryBook.Title);
        //    deliveryBook = new Book(typoTitle, deliveryBook.Author, deliveryBook.Genre, deliveryBook.PageCount, deliveryBook.Price);
        //    deliveryBook.HasTypo = true;
        //}

        //_store.IncomingBooks.Enqueue(deliveryBook);

        //if (!tabControlNewBook.TabPages.Contains(tabDeliveries))
        //    tabControlNewBook.TabPages.Add(tabDeliveries);

        //UpdateDeliveryUI();

        var book = _incomingBooks.Dequeue();
        if (book == null)
            return;

    }


    private void OnCustomerTick(object? sender, EventArgs e)
    {
        var rnd = new Random();
        Customer customer;

        if (rnd.Next(2) == 0) // Хочет конкретную книгу
        {
            var records = DatabaseProcessing.InitDatabase();
            var record = records[rnd.Next(records.Length)];
            customer = new Customer(rnd.Next(1000), RequestType.SpecificBook, record.Title, record.Author, null, rnd.Next(500, 2000));
        }
        else // Хочет жанр
            customer = new Customer(rnd.Next(1000), RequestType.Genre, null, null, _randomGenreBase[rnd.Next(_randomGenreBase.Length)], rnd.Next(300, 1500));

        if (_customerQueue.Enqueue(customer))
            UpdateCustomerListUI();
    }

    private void EndGame(string reason, bool isVictory = false)
    {
        _deliveryTimer.Stop();
        _customerTimer.Stop();
        _gameTickTimer.Stop();

        string message = $"{(isVictory ? "ПОБЕДА!" : "ИГРА ОКОНЧЕНА")}\nПричина: {reason}\n\n" +
                         $"Статистика:\n" +
                         $"- Книг продано: {_stats.BooksSold}\n" +
                         $"- Ошибок выявлено: {_stats.ErrorsCaught}\n" +
                         $"- Финальный баланс: {_store.Balance} руб.\n" +
                         $"- Штрафов выплачено: {_stats.FinesPaid} руб.";

        MessageBox.Show(message, "Результаты дня", MessageBoxButtons.OK, isVictory ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        this.Close();
    }
    #endregion

    #region Игровой UI

    private void UpdateDeliveryUI()
    {
        if (_store.IncomingBooks.Count == 0)
        {
            if (tabControlNewBook.TabPages.Contains(tabDeliveries))
                tabControlNewBook.TabPages.Remove(tabDeliveries);
            return;
        }

        if (!tabControlNewBook.TabPages.Contains(tabDeliveries))
            tabControlNewBook.TabPages.Add(tabDeliveries);

        Book currentBook = _store.IncomingBooks.Peek();

        txtDeliveryTitle.Text = currentBook.Title;
        txtDeliveryAuthor.Text = currentBook.Author;
        txtDeliveryGenre.Text = currentBook.Genre;
        txtDeliveryPrice.Text = currentBook.Price.ToString("F2");

        rbCorrect.Checked = true;

        lblStatus.Text = $"Книг в очереди на проверку: {_store.IncomingBooks.Count}";
    }

    private void UpdateStatsLabel()
    {
        labelStats.Text = $"" +
            $"Время: {_remainingTime}с | " +
            $"Баланс: {_store.Balance}₽ | " +
            $"Очередь: {_customerQueue.Count}/{_settings.MaxQueue} | " +
            $"Недовольные: {_customerQueue.UnsatisfiedCount}/{_settings.MaxUnsatisfied}";
    }

    private void UpdateCustomerListUI()
    {
        var customers = _customerQueue.GetQueueSnapshot();

        if (customers.Count == 0)
        {
            lblNoCustomers.Visible = true;
            pnlCustomerProcessing.Visible = false;
            lstCustomerQueue.Items.Clear();
        }
        else
        {
            lblNoCustomers.Visible = false;
            pnlCustomerProcessing.Visible = true;

            lstCustomerQueue.Items.Clear();
            foreach (var customer in customers)
            {
                string requestInfo = customer.Type == RequestType.SpecificBook
                    ? $"Книга: {customer.DesiredTitle}"
                    : $"Жанр: {customer.DesiredGenre}";

                lstCustomerQueue.Items.Add($"Покупатель #{customer.Id} [{requestInfo}]");
            }

            if (lstCustomerQueue.SelectedIndex == -1)
                lstCustomerQueue.SelectedIndex = 0;

            UpdateSelectedCustomerDetails();
        }

        UpdateStatsLabel();
    }

    private void UpdateSelectedCustomerDetails()
    {
        if (lstCustomerQueue.SelectedIndex == -1) return;

        var customers = _customerQueue.GetQueueSnapshot();
        var selectedCustomer = customers[lstCustomerQueue.SelectedIndex];

        lblCustomerRequest.Visible = true;
        lblUnsatisfiedCount.Visible = true;

        if (selectedCustomer.Type == RequestType.SpecificBook)
        {
            lblCustomerRequest.Text = $"Ищет: {selectedCustomer.DesiredTitle}\nАвтор: {selectedCustomer.DesiredAuthor}";
        }
        else
        {
            lblCustomerRequest.Text = $"Хочет любой жанр: {selectedCustomer.DesiredGenre}";
        }

        btnSellToCustomer.Visible = true;
        btnCancelCustomer.Visible = true;
        cmbAvailableBooks.Visible = true;

        RefreshAvailableBooksForCustomer(selectedCustomer);
    }

    private void RefreshAvailableBooksForCustomer(Customer customer)
    {
        cmbAvailableBooks.Items.Clear();

        foreach (var shelf in _store.Shelves)
            foreach (var book in shelf.Books)
                if (customer.CheckBook(book))
                    cmbAvailableBooks.Items.Add(book);

        if (cmbAvailableBooks.Items.Count > 0)
        {
            cmbAvailableBooks.DisplayMember = "DisplayTitle";
            cmbAvailableBooks.SelectedIndex = 0;
        }
    }

    #endregion

    private void tabControlNewBook_DrawItem(object sender, DrawItemEventArgs e)
    {
        TabControl tc = (TabControl)sender;
        TabPage page = tc.TabPages[e.Index];
        Rectangle rect = tc.GetTabRect(e.Index);

        Color backColor = (e.State == DrawItemState.Selected) ? Color.MediumPurple : Color.LightGray;
        Color textColor = Color.White;

        using (Brush brush = new SolidBrush(backColor))
        using (Pen pen = new Pen(backColor))
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int radius = 10;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Левый верх
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Правый верх
            path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom); // Низ прямой
            path.CloseFigure();

            e.Graphics.FillPath(brush, path);

            TextRenderer.DrawText(e.Graphics, page.Text, tc.Font, rect, textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }
    }

    private void buttonGenerate_Click(object sender, EventArgs e)
    {
        if (_randomGenreBase.Length == 0 || _randomAuthorBase.Length == 0 || _randomBookNameBase.Length == 0) return;

        var randomBook = Book.GenerateRandomBook(_randomBookNameBase, _randomAuthorBase, _randomGenreBase);

        textBoxTitleBook.Text = randomBook.Title;
        textBoxAutor.Text = randomBook.Author;
        comboBoxType.SelectedItem = randomBook.Genre;

        numericUpDownPages.Value = Math.Clamp(randomBook.PageCount, numericUpDownPages.Minimum, numericUpDownPages.Maximum);
        numericUpDownPrice.Value = Math.Clamp(randomBook.Price, numericUpDownPrice.Minimum, numericUpDownPrice.Maximum);
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

        //labelIDforUsing.Text = "(будет назначен автоматически)"; // обнуление label с ID

        textBoxTitleBook.Focus(); // для удобства переводим фокус на первое поле
    }

    private Bookshelf GetOrCreateShelf(string genre)
    {
        // Ищем существующий шкаф этого жанра
        var shelf = _store.Shelves.FirstOrDefault(s => s.Genre == genre);
        if (shelf != null) return shelf;

        // Если шкафа нет, пытаемся добавить новый
        if (_store.Shelves.Count < _store.MaxShelves)
        {
            var newShelf = new Bookshelf(genre, 10); // Вместимость 10 книг
            _store.AddShelf(newShelf);
            return newShelf;
        }

        // Если лимит шкафов исчерпан, ищем пустой шкаф для переназначения
        var emptyShelf = _store.Shelves.FirstOrDefault(s => s.CurrentCount == 0);
        if (emptyShelf != null)
        {
            _store.RemoveShelf(emptyShelf);
            MessageBox.Show($"Лимит жанров исчерпан. Пустой шкаф переназначен под жанр {genre}");

            var replacedShelf = new Bookshelf(genre, MaxBooksInShelves);
            _store.AddShelf(replacedShelf);
            return replacedShelf;
        }

        throw new InvalidOperationException("Достигнут лимит шкафов. Распродайте один из них.");
    }

    private void ValidateInputForAdding()
    {
        if (string.IsNullOrWhiteSpace(textBoxTitleBook.Text))
            throw new ArgumentException("Название книги не может быть пустым", "Название");
        if (string.IsNullOrWhiteSpace(textBoxAutor.Text))
            throw new ArgumentException("Автор не указан", "Автор");
        if (comboBoxType.SelectedIndex == -1 && string.IsNullOrWhiteSpace(comboBoxType.Text))
            throw new ArgumentException("Выберите или введите жанр", "Жанр");
    }


    private string GetUniqueTitle(string baseTitle, string baseAuthor)
    {
        string currentTitle = baseTitle;
        string currentAuthor = baseAuthor;
        int counter = 2;

        // Проверяем все книги во всех шкафах магазина
        while (_store.Shelves.Any(s => s.Books.Any(b => b.Title.Equals(currentTitle, StringComparison.OrdinalIgnoreCase) &&
        b.Author.Equals(currentAuthor, StringComparison.OrdinalIgnoreCase)))) //Добавлена проверка на соответствие автора
        {
            currentTitle = $"{baseTitle} {counter}";
            counter++;
        }
        return currentTitle;
    }

    private void buttonSearch2_Click(object sender, EventArgs e)
    {
        if (!Guid.TryParse(textBoxSearchID.Text, out Guid id))
        {
            MessageBox.Show("Введите корректный GUID идентификатор.");
            return;
        }

        foreach (var shelf in _store.Shelves)
        {
            try
            {
                var book = shelf.FindBookById(id);
                ShowBookDetails(book);
                return;
            }
            catch { continue; }
        }
        MessageBox.Show("Книга не найдена.");
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

            case InvalidDataException:
                message = $"Ошибка данных: {ex.Message}";
                title = "Ошибка данных";
                break;

            case InvalidOperationException:
                message = $"Ошибка при исполнении: {ex.Message}";
                title = "Ошибка доступа";
                break;

            default:
                message = $"Непредвиденная ошибка: {ex.Message}";
                title = "Критическая ошибка";
                break;
        }

        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void UpdateMarketUI()
    {
        // Обновляем баланс
        //labelBalanceUsed.Text = $"{_store.Balance} руб.";

        // Обновляем список доступных жанров (шкафов) в магазине
        var currentGenre = comboBoxJanr.SelectedItem?.ToString();
        comboBoxJanr.Items.Clear();
        foreach (var shelf in _store.Shelves)
        {
            comboBoxJanr.Items.Add(shelf.Genre);
        }

        if (currentGenre != null && comboBoxJanr.Items.Contains(currentGenre))
            comboBoxJanr.SelectedItem = currentGenre;

        RefreshBookList();
    }

    private void RefreshBookList()
    {
        listViewBooks.Items.Clear();
        string selectedGenre = comboBoxJanr.SelectedItem?.ToString();
        if (string.IsNullOrEmpty(selectedGenre)) return;

        var shelf = _store.Shelves.FirstOrDefault(s => s.Genre == selectedGenre);
        if (shelf == null) return;

        foreach (var book in shelf.Books)
        {
            var item = new ListViewItem(book.Title);
            item.Tag = book; // Сохраняем ссылку на объект книги
            listViewBooks.Items.Add(item);
        }
    }

    private void btnSell_Click(object sender, EventArgs e)
    {
        if (listViewBooks.SelectedItems.Count > 0)
        {
            Book selectedBook = (Book)listViewBooks.SelectedItems[0].Tag;

            _store.ProcessSale(selectedBook);

            MessageBox.Show($"Книга '{selectedBook.Title}' продана!", "Продажа");

            UpdateMarketUI();
            groupBoxDetails.Visible = false;
            groupBoxSearch.Visible = true;
        }
    }


    private void comboBoxJanr_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshBookList();
    }



    private void btnAddNewBook_Click(object sender, EventArgs e)
    {
        try
        {
            ValidateInputForAdding();

            string title = textBoxTitleBook.Text.Trim();
            string author = textBoxAutor.Text.Trim();
            string genre = comboBoxType.Text.Trim();
            int pages = (int)numericUpDownPages.Value;
            decimal price = numericUpDownPrice.Value;

            title = GetUniqueTitle(title, author);

            Bookshelf shelf = GetOrCreateShelf(genre);

            Book newBook = new Book(title, author, genre, pages, price);
            //shelf.AddBook(newBook);

            //labelIDforUsing.Text = newBook.Id.ToString();
            //UpdateMarketUI();
            MessageBox.Show($"Книга '{title}' успешно заказана! Ждите её", "Успех");
            _incomingBooks.Enqueue(newBook);
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }

    }

    private void buttonReturn1_Click(object sender, EventArgs e) => tabControlNewBook.SelectedTab = tabPageMain;
    private void buttonReturn2_Click(object sender, EventArgs e) => tabControlNewBook.SelectedTab = tabPageMain;
    private void buttonReturn3_Click(object sender, EventArgs e) => tabControlNewBook.SelectedTab = tabPageMain;

    private void listViewBooks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listViewBooks.SelectedItems.Count > 0)
        {
            ShowBookDetails((Book)listViewBooks.SelectedItems[0].Tag);
        }
    }

    private void ShowBookDetails(Book book)
    {
        groupBoxSearch.Visible = false;
        groupBoxDetails.Visible = true;
        groupBoxDetails.Location = groupBoxSearch.Location;

        labelInfo.Text = $"Название: {book.Title}\n" +
                         $"Автор: {book.Author}\n" +
                         $"Цена: {book.Price} руб. " +
                         $"Страниц: {book.PageCount}\n" +
                         $"ID: {book.Id.ToString()}";

        btnSell.Tag = book;
    }

    private void btnBackToSearch_Click(object sender, EventArgs e)
    {
        groupBoxSearch.Visible = true;
        groupBoxDetails.Visible = false;
        listViewBooks.SelectedIndices.Clear(); // Снимаем выделение, чтобы вернуться к поиску
    }

    private void buttonSearch1_Click(object sender, EventArgs e)
    {
        string searchText = textBoxSearchTitle.Text.Trim();
        if (string.IsNullOrEmpty(searchText)) return;

        foreach (var shelf in _store.Shelves)
        {
            try
            {
                var book = shelf.FindBookByTitle(searchText);
                ShowBookDetails(book);
                return;
            }
            catch { continue; }
        }
        MessageBox.Show("Книга не найдена.");
    }

    private void buttonSale_Click(object sender, EventArgs e)
    {
        string selectedGenre = comboBoxJanr.SelectedItem?.ToString();
        if (string.IsNullOrEmpty(selectedGenre)) return;

        var shelf = _store.Shelves.FirstOrDefault(s => s.Genre == selectedGenre);
        if (shelf != null)
        {
            var booksToSell = shelf.Books.ToList();
            foreach (var book in booksToSell)
            {
                _store.ProcessSale(book);
            }
            MessageBox.Show($"Все книги из шкафа '{selectedGenre}' проданы.");
            UpdateMarketUI();
        }
    }
}