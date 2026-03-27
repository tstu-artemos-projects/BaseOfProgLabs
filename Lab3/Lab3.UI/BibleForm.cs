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

    private System.Windows.Forms.Timer _customerTimer;
    private System.Windows.Forms.Timer _gameTickTimer;
    private System.Windows.Forms.Timer _randomDeliveryTimer;

    public BibleForm(Difficulty difficulty)
    {
        _randomGenreBase = DatabaseProcessing.ReadGenres();
        var dataBase = DatabaseProcessing.InitDatabase();

        (_randomBookNameBase, _randomAuthorBase) = DatabaseProcessing.SplitBookTitlingRecord(dataBase);

        _store = new BookStore(MaxShelves, difficulty);
        _settings = GameSettings.GetByDifficulty(difficulty);
        _customerQueue = new CustomerQueue(_settings.MaxQueue);

        InitializeComponent();
        tabControlNewBook.TabPages.Remove(tabDeliveries);

        comboBoxType.Items.AddRange(_randomGenreBase);
        SetupGame();
    }

    #region Основная игровая логика
    private void SetupGame()
    {
        _customerQueue.QueueLimitReached += () => EndGame("Очередь переполнена!");
        _customerQueue.UnsatisfiedLimitReached += () => EndGame("Слишком много недовольных клиентов!");

        _customerTimer = new System.Windows.Forms.Timer { Interval = _settings.CustomerInterval };
        _customerTimer.Tick += OnCustomerTick;

        _randomDeliveryTimer = new System.Windows.Forms.Timer { Interval = _settings.DeliveryInterval };
        _randomDeliveryTimer.Tick += OnRandomDeliveryTick;

        _gameTickTimer = new System.Windows.Forms.Timer { Interval = _settings.DayDurationSeconds * 1000 };
        _gameTickTimer.Tick += OnGameTick;

        _customerTimer.Start();
        _randomDeliveryTimer.Start();
        _gameTickTimer.Start();

        UpdateStatsLabel();
    }

    private void OnRandomDeliveryTick(object? sender, EventArgs e)
    {
        var records = DatabaseProcessing.InitDatabase();
        var record = records[new Random().Next(records.Length)];


        Book deliveryBook = new Book(record.Title, record.Author,
                                     _randomGenreBase[new Random().Next(_randomGenreBase.Length)],
                                     new Random().Next(100, 500),
                                     new Random().Next(100, 500));

        int chance = new Random().Next(100);
        if (chance < 20) // Плагиат
        {
            var otherRecord = records[new Random().Next(records.Length)];
            var fakeData = _mismatchLogic.GeneratePlagiarism(records.Select(r => r.Title).ToList(), records.Select(r => r.Author).ToList());
            deliveryBook = new Book(fakeData[0], fakeData[1], deliveryBook.Genre, deliveryBook.PageCount, deliveryBook.Price);
            deliveryBook.IsPlagiarism = true;
        }
        else if (chance < 50) // Опечатка
        {
            string typoTitle = _mismatchLogic.GenerateTypo(deliveryBook.Title);
            deliveryBook = new Book(typoTitle, deliveryBook.Author, deliveryBook.Genre, deliveryBook.PageCount, deliveryBook.Price);
            deliveryBook.HasTypo = true;
        }

        _store.IncomingBooks.Enqueue(deliveryBook);
        if (!tabControlNewBook.TabPages.Contains(tabDeliveries))
            tabControlNewBook.TabPages.Add(tabDeliveries);

        UpdateDeliveryUI();
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

    #region Обновления игрового UI

    private void UpdateDeliveryUI()
    {
        UpdateStatsLabel();
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

        if (!currentBook.IsOrdered && currentBook.PurchasePrice > _store.Balance)
            buttonAcceptDelivery.Enabled = false;

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
        UpdateStatsLabel();
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

    #endregion

    #region UI логика для заказа книги
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

    #endregion

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
        if (!_isProgrammaticChange)
        {
            e.Cancel = true;
        }
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

            _store.ProcessSale(selectedBook, null);

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



    private async void btnAddNewBook_Click(object sender, EventArgs e)
    {
        try
        {
            ValidateInputForAdding();

            // Нужные поля для книги
            decimal price = numericUpDownPrice.Value;

            if (_store.Balance < price)
            {
                MessageBox.Show("Недостаточно средств для заказа этой книги!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = textBoxTitleBook.Text.Trim();
            string author = textBoxAutor.Text.Trim();
            string genre = comboBoxType.Text.Trim();
            int pages = (int)numericUpDownPages.Value;

            Book orderedBook = new Book(title, author, genre, pages, price, true);
            orderedBook.IsPlagiarism = false;
            orderedBook.HasTypo = false;

            if (_store.OrderBook(orderedBook))
            {
                MessageBox.Show($"Книга '{title}' успешно заказана! Ждите её с доставки", "Успех");

                await Task.Delay(3500);

                UpdateDeliveryUI();
                UpdateStatsLabel();
            }

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
                _store.ProcessSale(book, null);
            }
            MessageBox.Show($"Все книги из шкафа '{selectedGenre}' проданы.");
            UpdateMarketUI();
        }
    }

    private Book CheckAndAssignEdition(Book newBook)
    {
        int maxEdition = 0;
        bool exists = false;

        foreach (var shelf in _store.Shelves)
        {
            // Ищем книги с таким же названием и автором (используем OriginalTitle для опечаток)
            var matches = shelf.Books.Where(b =>
                b.OriginalTitle.Equals(newBook.OriginalTitle, StringComparison.OrdinalIgnoreCase) &&
                b.Author.Equals(newBook.Author, StringComparison.OrdinalIgnoreCase));

            if (matches.Any())
            {
                exists = true;
                int currentMax = matches.Max(m => m.EditionNumber);
                if (currentMax > maxEdition) maxEdition = currentMax;
            }
        }

        if (exists)
        {
            newBook.EditionNumber = maxEdition + 1;
        }

        return newBook;
    }


    private void buttonAcceptDelivery_Click(object sender, EventArgs e)
    {
        if (_store.IncomingBooks.Count == 0) return;

        Book book = _store.IncomingBooks.Peek();
        bool hasError = book.IsPlagiarism || book.HasTypo;
        bool userNoticedError = !rbCorrect.Checked;

        if (!userNoticedError && hasError)
        {
            //_store.ProcessSale(new Book("Штраф", "Система", "Штраф", 0, -15));
            _store.Penalty(15);
            _stats.FinesPaid += 15;
            MessageBox.Show("Вы приняли книгу с ошибкой! Штраф 15р.", "Невнимательность", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        try
        {
            Bookshelf shelf = GetOrCreateShelf(book.Genre);

            book = CheckAndAssignEdition(book);
            shelf.AddBook(book);

            _store.IncomingBooks.Dequeue();

            if (!book.IsOrdered)
                _store.Penalty(book.Price);

            UpdateDeliveryUI();
            UpdateMarketUI();
            MessageBox.Show($"Книга '{book.DisplayTitle}' добавлена в шкаф {book.Genre}.");
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Нет места", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnRejectDelivery_Click(object sender, EventArgs e)
    {
        if (_store.IncomingBooks.Count == 0) return;

        Book currentBook = _store.IncomingBooks.Dequeue();
        if ((currentBook.HasTypo && rbTypo.Checked) || (currentBook.IsPlagiarism && rbPlagiarism.Checked))
        {
            // Игрок молодец, нашел ошибку
            decimal bonus = 10m;
            _store.Award(bonus);

            _stats.ErrorsCaught++;
            MessageBox.Show($"Верно! Вы нашли брак. Премия: {bonus} руб.");

            UpdateDeliveryUI();
        }
        else if (!currentBook.HasTypo && !currentBook.IsPlagiarism)
        {
            // Игрок отклонил хорошую книгу
            MessageBox.Show("Вы отклонили качественную книгу. Деньги за заказ не возвращаются.");
        }

    }

    private void RefreshAvailableBooks(Customer customer)
    {
        cmbAvailableBooks.Items.Clear();
        foreach (var shelf in _store.Shelves)
            foreach (var book in shelf.Books)
                if (customer.CheckBook(book)) // Проверка жанра или названия
                    cmbAvailableBooks.Items.Add(book);

        if (cmbAvailableBooks.Items.Count > 0)
        {
            cmbAvailableBooks.SelectedIndex = 0;
            btnSellToCustomer.Enabled = true;
        }
        else
        {
            btnSellToCustomer.Enabled = false; // Нет подходящих книг в наличии
        }
    }

    private void btnSellToCustomer_Click(object sender, EventArgs e)
    {
        if (lstCustomerQueue.SelectedIndex == -1 || cmbAvailableBooks.SelectedItem == null) return;

        var customers = _customerQueue.GetQueueSnapshot();
        var customer = customers[lstCustomerQueue.SelectedIndex];
        var book = (Book)cmbAvailableBooks.SelectedItem;
        decimal salePrice = priceSellNumericUpDown.Value;

        decimal maxAllowedPrice = book.PurchasePrice * 1.15m;

        if (!customer.CheckPrice(salePrice))
        {
            MessageBox.Show("У покупателя не хватает денег на эту цену. Он уходит.");
            _customerQueue.CustomerLeavesUnsatisfied(customer);
        }
        else
        {
            _store.ProcessSale(book, salePrice);

            _customerQueue.ServeCustomer(customer);
            _stats.BooksSold++;
            _stats.TotalEarned += salePrice;

            MessageBox.Show($"Успешно продано за {salePrice} руб.!");
        }

        UpdateCustomerListUI();
        UpdateMarketUI();
    }

    private void lstCustomerQueue_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstCustomerQueue.SelectedIndex == -1) return;

        var customers = _customerQueue.GetQueueSnapshot();
        var selectedCustomer = customers[lstCustomerQueue.SelectedIndex];

        if (selectedCustomer.Type == RequestType.SpecificBook)
            lblCustomerRequest.Text = $"Ищет: {selectedCustomer.DesiredTitle}\nАвтор: {selectedCustomer.DesiredAuthor}";
        else
            lblCustomerRequest.Text = $"Хочет жанр: {selectedCustomer.DesiredGenre}";

        priceSellNumericUpDown.Maximum = Math.Round(selectedCustomer.MaxPrice * 2m);
        priceSellNumericUpDown.Minimum = Math.Round(0m);
        priceSellNumericUpDown.Value = Math.Round(selectedCustomer.MaxPrice * 0.9m);

        RefreshAvailableBooks(selectedCustomer);
    }

    private void btnCancelCustomer_Click(object sender, EventArgs e)
    {
        if (lstCustomerQueue.SelectedIndex == -1) return;

        var customers = _customerQueue.GetQueueSnapshot();
        var customer = customers[lstCustomerQueue.SelectedIndex];

        _customerQueue.CustomerLeavesUnsatisfied(customer);
        MessageBox.Show("Вы отказали клиенту. Счетчик недовольных вырос.");

        UpdateCustomerListUI();

    }
}