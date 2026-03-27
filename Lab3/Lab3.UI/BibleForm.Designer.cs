namespace Lab3.UI;
    
partial class BibleForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibleForm));
        tabControlNewBook = new TabControl();
        tabPageMain = new TabPage();
        btnSupport = new Button();
        btnMarket = new Button();
        btnNewBook = new Button();
        labelRights = new Label();
        labelSupport = new Label();
        labelHye = new Label();
        tabNewBook = new TabPage();
        buttonReturn1 = new Button();
        groupBoxNewBook = new GroupBox();
        buttonGenerate = new Button();
        btnAddNewBook = new Button();
        buttonClearNewBook = new Button();
        numericUpDownPrice = new NumericUpDown();
        labelPrice = new Label();
        labelPages = new Label();
        numericUpDownPages = new NumericUpDown();
        labelType = new Label();
        comboBoxType = new ComboBox();
        labelID = new Label();
        labelIDforUsing = new Label();
        labelAutor = new Label();
        textBoxAutor = new TextBox();
        labelTitleBook = new Label();
        textBoxTitleBook = new TextBox();
        labelDobNewBook = new Label();
        tabPageMarket = new TabPage();
        groupBoxSearch = new GroupBox();
        textBoxSearchID = new TextBox();
        buttonSearch2 = new Button();
        label2 = new Label();
        textBoxSearchTitle = new TextBox();
        buttonSearch1 = new Button();
        label1 = new Label();
        listViewBooks = new ListView();
        groupBoxChose = new GroupBox();
        buttonSale = new Button();
        labelJanr = new Label();
        comboBoxJanr = new ComboBox();
        buttonReturn2 = new Button();
        groupBoxDetails = new GroupBox();
        btnSell = new Button();
        btnBackToSearch = new Button();
        labelInfo = new Label();
        labelMarket = new Label();
        tabPageSupport = new TabPage();
        labelAbout = new Label();
        label3 = new Label();
        buttonReturn3 = new Button();
        tabClients = new TabPage();
        clientsLabel = new Label();
        pnlCustomerProcessing = new Panel();
        labelSelectedBook = new Label();
        lstCustomerQueue = new ListBox();
        groupBox2 = new GroupBox();
        btnCancelCustomer = new Button();
        priceSellNumericUpDown = new NumericUpDown();
        btnSellToCustomer = new Button();
        label4 = new Label();
        groupBox1 = new GroupBox();
        buttonSellToProvider = new Button();
        lblCustomerRequest = new Label();
        lblUnsatisfiedCount = new Label();
        cmbAvailableBooks = new ComboBox();
        lblNoCustomers = new Label();
        tabDeliveries = new TabPage();
        label5 = new Label();
        panel1 = new Panel();
        groupBox5 = new GroupBox();
        rbTypo = new RadioButton();
        rbPlagiarism = new RadioButton();
        rbCorrect = new RadioButton();
        groupBox4 = new GroupBox();
        lblDeliveryTitle = new Label();
        txtDeliveryPrice = new TextBox();
        txtDeliveryTitle = new TextBox();
        lblDeliveryPrice = new Label();
        lblDeliveryAuthor = new Label();
        lblDeliveryGenre = new Label();
        txtDeliveryGenre = new TextBox();
        txtDeliveryAuthor = new TextBox();
        groupBox3 = new GroupBox();
        label6 = new Label();
        btnRejectDelivery = new Button();
        buttonAcceptDelivery = new Button();
        lblStatus = new Label();
        btnAcceptDelivery = new Button();
        panel2 = new Panel();
        labelStats = new Label();
        tabControlNewBook.SuspendLayout();
        tabPageMain.SuspendLayout();
        tabNewBook.SuspendLayout();
        groupBoxNewBook.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownPages).BeginInit();
        tabPageMarket.SuspendLayout();
        groupBoxSearch.SuspendLayout();
        groupBoxChose.SuspendLayout();
        groupBoxDetails.SuspendLayout();
        tabPageSupport.SuspendLayout();
        tabClients.SuspendLayout();
        pnlCustomerProcessing.SuspendLayout();
        groupBox2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)priceSellNumericUpDown).BeginInit();
        groupBox1.SuspendLayout();
        tabDeliveries.SuspendLayout();
        panel1.SuspendLayout();
        groupBox5.SuspendLayout();
        groupBox4.SuspendLayout();
        groupBox3.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // tabControlNewBook
        // 
        tabControlNewBook.Anchor = AnchorStyles.None;
        tabControlNewBook.Appearance = TabAppearance.FlatButtons;
        tabControlNewBook.Controls.Add(tabPageMain);
        tabControlNewBook.Controls.Add(tabNewBook);
        tabControlNewBook.Controls.Add(tabPageMarket);
        tabControlNewBook.Controls.Add(tabPageSupport);
        tabControlNewBook.Controls.Add(tabClients);
        tabControlNewBook.Controls.Add(tabDeliveries);
        tabControlNewBook.Location = new Point(200, 99);
        tabControlNewBook.Name = "tabControlNewBook";
        tabControlNewBook.SelectedIndex = 0;
        tabControlNewBook.Size = new Size(675, 386);
        tabControlNewBook.SizeMode = TabSizeMode.Fixed;
        tabControlNewBook.TabIndex = 0;
        tabControlNewBook.TabStop = false;
        // 
        // tabPageMain
        // 
        tabPageMain.BackColor = SystemColors.GradientInactiveCaption;
        tabPageMain.Controls.Add(btnSupport);
        tabPageMain.Controls.Add(btnMarket);
        tabPageMain.Controls.Add(btnNewBook);
        tabPageMain.Controls.Add(labelRights);
        tabPageMain.Controls.Add(labelSupport);
        tabPageMain.Controls.Add(labelHye);
        tabPageMain.Location = new Point(4, 27);
        tabPageMain.Name = "tabPageMain";
        tabPageMain.Padding = new Padding(3);
        tabPageMain.Size = new Size(667, 355);
        tabPageMain.TabIndex = 0;
        tabPageMain.Text = "Главное меню";
        // 
        // btnSupport
        // 
        btnSupport.Location = new Point(219, 248);
        btnSupport.Name = "btnSupport";
        btnSupport.Size = new Size(230, 40);
        btnSupport.TabIndex = 5;
        btnSupport.Text = "О нас";
        btnSupport.UseVisualStyleBackColor = true;
        btnSupport.Click += btnSupport_Click;
        // 
        // btnMarket
        // 
        btnMarket.Location = new Point(219, 188);
        btnMarket.Name = "btnMarket";
        btnMarket.Size = new Size(230, 40);
        btnMarket.TabIndex = 4;
        btnMarket.Text = "Открыть магазин\r\n";
        btnMarket.UseVisualStyleBackColor = true;
        btnMarket.Click += btnMarket_Click;
        // 
        // btnNewBook
        // 
        btnNewBook.Location = new Point(219, 128);
        btnNewBook.Name = "btnNewBook";
        btnNewBook.Size = new Size(230, 40);
        btnNewBook.TabIndex = 3;
        btnNewBook.Text = "Заказать новую книгу";
        btnNewBook.UseVisualStyleBackColor = true;
        btnNewBook.Click += btnNewBook_Click;
        // 
        // labelRights
        // 
        labelRights.AutoSize = true;
        labelRights.Location = new Point(189, 327);
        labelRights.Name = "labelRights";
        labelRights.Size = new Size(289, 15);
        labelRights.TabIndex = 2;
        labelRights.Text = "ⓒ 2026 Ulitka Software Inc, Все права не защищены.";
        // 
        // labelSupport
        // 
        labelSupport.AutoSize = true;
        labelSupport.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
        labelSupport.Location = new Point(90, 43);
        labelSupport.Name = "labelSupport";
        labelSupport.Size = new Size(488, 45);
        labelSupport.TabIndex = 1;
        labelSupport.Text = resources.GetString("labelSupport.Text");
        // 
        // labelHye
        // 
        labelHye.Anchor = AnchorStyles.None;
        labelHye.AutoSize = true;
        labelHye.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelHye.Location = new Point(125, 12);
        labelHye.Name = "labelHye";
        labelHye.Size = new Size(417, 21);
        labelHye.TabIndex = 0;
        labelHye.Text = "Добро пожаловать в менеджер магазина BookSell!";
        // 
        // tabNewBook
        // 
        tabNewBook.BackColor = SystemColors.GradientInactiveCaption;
        tabNewBook.Controls.Add(buttonReturn1);
        tabNewBook.Controls.Add(groupBoxNewBook);
        tabNewBook.Controls.Add(labelDobNewBook);
        tabNewBook.Location = new Point(4, 27);
        tabNewBook.Name = "tabNewBook";
        tabNewBook.Padding = new Padding(3);
        tabNewBook.Size = new Size(667, 355);
        tabNewBook.TabIndex = 1;
        tabNewBook.Text = "Заказать книгу";
        // 
        // buttonReturn1
        // 
        buttonReturn1.Location = new Point(513, 322);
        buttonReturn1.Name = "buttonReturn1";
        buttonReturn1.Size = new Size(148, 27);
        buttonReturn1.TabIndex = 13;
        buttonReturn1.Text = "Вернуться в меню";
        buttonReturn1.UseVisualStyleBackColor = true;
        buttonReturn1.Click += buttonReturn1_Click;
        // 
        // groupBoxNewBook
        // 
        groupBoxNewBook.Controls.Add(buttonGenerate);
        groupBoxNewBook.Controls.Add(btnAddNewBook);
        groupBoxNewBook.Controls.Add(buttonClearNewBook);
        groupBoxNewBook.Controls.Add(numericUpDownPrice);
        groupBoxNewBook.Controls.Add(labelPrice);
        groupBoxNewBook.Controls.Add(labelPages);
        groupBoxNewBook.Controls.Add(numericUpDownPages);
        groupBoxNewBook.Controls.Add(labelType);
        groupBoxNewBook.Controls.Add(comboBoxType);
        groupBoxNewBook.Controls.Add(labelID);
        groupBoxNewBook.Controls.Add(labelIDforUsing);
        groupBoxNewBook.Controls.Add(labelAutor);
        groupBoxNewBook.Controls.Add(textBoxAutor);
        groupBoxNewBook.Controls.Add(labelTitleBook);
        groupBoxNewBook.Controls.Add(textBoxTitleBook);
        groupBoxNewBook.Location = new Point(37, 61);
        groupBoxNewBook.Name = "groupBoxNewBook";
        groupBoxNewBook.Size = new Size(601, 233);
        groupBoxNewBook.TabIndex = 2;
        groupBoxNewBook.TabStop = false;
        groupBoxNewBook.Text = "Какую книгу желаете заказать?";
        // 
        // buttonGenerate
        // 
        buttonGenerate.Location = new Point(492, 165);
        buttonGenerate.Name = "buttonGenerate";
        buttonGenerate.Size = new Size(103, 59);
        buttonGenerate.TabIndex = 14;
        buttonGenerate.Text = "Сгенерировать";
        buttonGenerate.UseVisualStyleBackColor = true;
        buttonGenerate.Click += buttonGenerate_Click;
        // 
        // btnAddNewBook
        // 
        btnAddNewBook.Location = new Point(492, 86);
        btnAddNewBook.Name = "btnAddNewBook";
        btnAddNewBook.Size = new Size(103, 73);
        btnAddNewBook.TabIndex = 13;
        btnAddNewBook.Text = "Заказать новую книгу";
        btnAddNewBook.UseVisualStyleBackColor = true;
        btnAddNewBook.Click += btnAddNewBook_Click;
        // 
        // buttonClearNewBook
        // 
        buttonClearNewBook.Location = new Point(6, 200);
        buttonClearNewBook.Name = "buttonClearNewBook";
        buttonClearNewBook.Size = new Size(148, 27);
        buttonClearNewBook.TabIndex = 12;
        buttonClearNewBook.Text = "Очистить все поля";
        buttonClearNewBook.UseVisualStyleBackColor = true;
        buttonClearNewBook.Click += buttonClearNewBook_Click;
        // 
        // numericUpDownPrice
        // 
        numericUpDownPrice.Location = new Point(332, 116);
        numericUpDownPrice.Maximum = new decimal(new int[] { 9000000, 0, 0, 0 });
        numericUpDownPrice.Name = "numericUpDownPrice";
        numericUpDownPrice.Size = new Size(154, 23);
        numericUpDownPrice.TabIndex = 11;
        // 
        // labelPrice
        // 
        labelPrice.AutoSize = true;
        labelPrice.Location = new Point(288, 120);
        labelPrice.Name = "labelPrice";
        labelPrice.Size = new Size(38, 15);
        labelPrice.TabIndex = 10;
        labelPrice.Text = "Цена:";
        // 
        // labelPages
        // 
        labelPages.AutoSize = true;
        labelPages.Location = new Point(6, 120);
        labelPages.Name = "labelPages";
        labelPages.Size = new Size(97, 15);
        labelPages.TabIndex = 9;
        labelPages.Text = "Кол-во страниц:";
        // 
        // numericUpDownPages
        // 
        numericUpDownPages.Location = new Point(106, 116);
        numericUpDownPages.Maximum = new decimal(new int[] { 9000000, 0, 0, 0 });
        numericUpDownPages.Name = "numericUpDownPages";
        numericUpDownPages.Size = new Size(143, 23);
        numericUpDownPages.TabIndex = 8;
        // 
        // labelType
        // 
        labelType.AutoSize = true;
        labelType.Location = new Point(62, 90);
        labelType.Name = "labelType";
        labelType.Size = new Size(41, 15);
        labelType.TabIndex = 7;
        labelType.Text = "Жанр:";
        // 
        // comboBoxType
        // 
        comboBoxType.FormattingEnabled = true;
        comboBoxType.Location = new Point(106, 86);
        comboBoxType.Name = "comboBoxType";
        comboBoxType.Size = new Size(380, 23);
        comboBoxType.TabIndex = 6;
        // 
        // labelID
        // 
        labelID.AutoSize = true;
        labelID.Location = new Point(6, 168);
        labelID.Name = "labelID";
        labelID.Size = new Size(94, 15);
        labelID.TabIndex = 5;
        labelID.Text = "Идентификатор";
        // 
        // labelIDforUsing
        // 
        labelIDforUsing.AutoSize = true;
        labelIDforUsing.Location = new Point(106, 168);
        labelIDforUsing.Name = "labelIDforUsing";
        labelIDforUsing.Size = new Size(179, 15);
        labelIDforUsing.TabIndex = 4;
        labelIDforUsing.Text = "Будет присвоен автоматически";
        // 
        // labelAutor
        // 
        labelAutor.AutoSize = true;
        labelAutor.Location = new Point(29, 60);
        labelAutor.Name = "labelAutor";
        labelAutor.Size = new Size(74, 15);
        labelAutor.TabIndex = 3;
        labelAutor.Text = "Имя автора:";
        // 
        // textBoxAutor
        // 
        textBoxAutor.Location = new Point(106, 57);
        textBoxAutor.Name = "textBoxAutor";
        textBoxAutor.Size = new Size(489, 23);
        textBoxAutor.TabIndex = 2;
        // 
        // labelTitleBook
        // 
        labelTitleBook.AutoSize = true;
        labelTitleBook.Location = new Point(38, 31);
        labelTitleBook.Name = "labelTitleBook";
        labelTitleBook.Size = new Size(62, 15);
        labelTitleBook.TabIndex = 1;
        labelTitleBook.Text = "Название:";
        // 
        // textBoxTitleBook
        // 
        textBoxTitleBook.Location = new Point(106, 28);
        textBoxTitleBook.Name = "textBoxTitleBook";
        textBoxTitleBook.Size = new Size(489, 23);
        textBoxTitleBook.TabIndex = 0;
        // 
        // labelDobNewBook
        // 
        labelDobNewBook.AutoSize = true;
        labelDobNewBook.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelDobNewBook.Location = new Point(285, 15);
        labelDobNewBook.Name = "labelDobNewBook";
        labelDobNewBook.Size = new Size(104, 21);
        labelDobNewBook.TabIndex = 1;
        labelDobNewBook.Text = "Заказ книги\r\n";
        // 
        // tabPageMarket
        // 
        tabPageMarket.BackColor = SystemColors.GradientInactiveCaption;
        tabPageMarket.Controls.Add(groupBoxSearch);
        tabPageMarket.Controls.Add(listViewBooks);
        tabPageMarket.Controls.Add(groupBoxChose);
        tabPageMarket.Controls.Add(buttonReturn2);
        tabPageMarket.Controls.Add(groupBoxDetails);
        tabPageMarket.Controls.Add(labelMarket);
        tabPageMarket.Location = new Point(4, 27);
        tabPageMarket.Name = "tabPageMarket";
        tabPageMarket.Size = new Size(667, 355);
        tabPageMarket.TabIndex = 2;
        tabPageMarket.Text = "Магазин";
        // 
        // groupBoxSearch
        // 
        groupBoxSearch.Controls.Add(textBoxSearchID);
        groupBoxSearch.Controls.Add(buttonSearch2);
        groupBoxSearch.Controls.Add(label2);
        groupBoxSearch.Controls.Add(textBoxSearchTitle);
        groupBoxSearch.Controls.Add(buttonSearch1);
        groupBoxSearch.Controls.Add(label1);
        groupBoxSearch.Location = new Point(18, 155);
        groupBoxSearch.Name = "groupBoxSearch";
        groupBoxSearch.Size = new Size(422, 162);
        groupBoxSearch.TabIndex = 16;
        groupBoxSearch.TabStop = false;
        groupBoxSearch.Text = "Панель поиска";
        // 
        // textBoxSearchID
        // 
        textBoxSearchID.Location = new Point(6, 113);
        textBoxSearchID.Name = "textBoxSearchID";
        textBoxSearchID.Size = new Size(344, 23);
        textBoxSearchID.TabIndex = 20;
        // 
        // buttonSearch2
        // 
        buttonSearch2.Location = new Point(356, 111);
        buttonSearch2.Name = "buttonSearch2";
        buttonSearch2.Size = new Size(60, 27);
        buttonSearch2.TabIndex = 19;
        buttonSearch2.Text = "Поиск";
        buttonSearch2.UseVisualStyleBackColor = true;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(6, 95);
        label2.Name = "label2";
        label2.Size = new Size(156, 15);
        label2.TabIndex = 18;
        label2.Text = "Поиск по идентификатору:";
        // 
        // textBoxSearchTitle
        // 
        textBoxSearchTitle.Location = new Point(6, 49);
        textBoxSearchTitle.Name = "textBoxSearchTitle";
        textBoxSearchTitle.Size = new Size(344, 23);
        textBoxSearchTitle.TabIndex = 17;
        // 
        // buttonSearch1
        // 
        buttonSearch1.Location = new Point(356, 47);
        buttonSearch1.Name = "buttonSearch1";
        buttonSearch1.Size = new Size(60, 27);
        buttonSearch1.TabIndex = 16;
        buttonSearch1.Text = "Поиск";
        buttonSearch1.UseVisualStyleBackColor = true;
        buttonSearch1.Click += buttonSearch1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(6, 31);
        label1.Name = "label1";
        label1.Size = new Size(119, 15);
        label1.TabIndex = 3;
        label1.Text = "Поиск по названию:";
        // 
        // listViewBooks
        // 
        listViewBooks.Location = new Point(446, 12);
        listViewBooks.MultiSelect = false;
        listViewBooks.Name = "listViewBooks";
        listViewBooks.Size = new Size(204, 305);
        listViewBooks.TabIndex = 17;
        listViewBooks.UseCompatibleStateImageBehavior = false;
        listViewBooks.View = View.List;
        listViewBooks.SelectedIndexChanged += listViewBooks_SelectedIndexChanged;
        // 
        // groupBoxChose
        // 
        groupBoxChose.Controls.Add(buttonSale);
        groupBoxChose.Controls.Add(labelJanr);
        groupBoxChose.Controls.Add(comboBoxJanr);
        groupBoxChose.Location = new Point(18, 38);
        groupBoxChose.Name = "groupBoxChose";
        groupBoxChose.Size = new Size(422, 111);
        groupBoxChose.TabIndex = 15;
        groupBoxChose.TabStop = false;
        groupBoxChose.Text = "Ваши текущие параметры";
        // 
        // buttonSale
        // 
        buttonSale.Location = new Point(283, 64);
        buttonSale.Name = "buttonSale";
        buttonSale.Size = new Size(127, 27);
        buttonSale.TabIndex = 16;
        buttonSale.Text = "Распродать шкаф";
        buttonSale.UseVisualStyleBackColor = true;
        buttonSale.Click += buttonSale_Click;
        // 
        // labelJanr
        // 
        labelJanr.AutoSize = true;
        labelJanr.Location = new Point(6, 36);
        labelJanr.Name = "labelJanr";
        labelJanr.Size = new Size(84, 15);
        labelJanr.TabIndex = 3;
        labelJanr.Text = "Жанр (шкаф):";
        // 
        // comboBoxJanr
        // 
        comboBoxJanr.FormattingEnabled = true;
        comboBoxJanr.Location = new Point(96, 33);
        comboBoxJanr.Name = "comboBoxJanr";
        comboBoxJanr.Size = new Size(314, 23);
        comboBoxJanr.TabIndex = 2;
        comboBoxJanr.SelectedIndexChanged += comboBoxJanr_SelectedIndexChanged;
        // 
        // buttonReturn2
        // 
        buttonReturn2.Location = new Point(515, 323);
        buttonReturn2.Name = "buttonReturn2";
        buttonReturn2.Size = new Size(135, 29);
        buttonReturn2.TabIndex = 14;
        buttonReturn2.Text = "Вернуться в меню";
        buttonReturn2.UseVisualStyleBackColor = true;
        buttonReturn2.Click += buttonReturn2_Click;
        // 
        // groupBoxDetails
        // 
        groupBoxDetails.Controls.Add(btnSell);
        groupBoxDetails.Controls.Add(btnBackToSearch);
        groupBoxDetails.Controls.Add(labelInfo);
        groupBoxDetails.Location = new Point(18, 155);
        groupBoxDetails.Name = "groupBoxDetails";
        groupBoxDetails.Size = new Size(422, 162);
        groupBoxDetails.TabIndex = 21;
        groupBoxDetails.TabStop = false;
        groupBoxDetails.Text = "Панель информации о книге";
        groupBoxDetails.Visible = false;
        // 
        // btnSell
        // 
        btnSell.Location = new Point(6, 129);
        btnSell.Name = "btnSell";
        btnSell.Size = new Size(94, 27);
        btnSell.TabIndex = 19;
        btnSell.Text = "Продать";
        btnSell.UseVisualStyleBackColor = true;
        btnSell.Click += btnSell_Click;
        // 
        // btnBackToSearch
        // 
        btnBackToSearch.Location = new Point(356, 129);
        btnBackToSearch.Name = "btnBackToSearch";
        btnBackToSearch.Size = new Size(60, 27);
        btnBackToSearch.TabIndex = 16;
        btnBackToSearch.Text = "Назад";
        btnBackToSearch.UseVisualStyleBackColor = true;
        btnBackToSearch.Click += btnBackToSearch_Click;
        // 
        // labelInfo
        // 
        labelInfo.AutoSize = true;
        labelInfo.Location = new Point(6, 25);
        labelInfo.Name = "labelInfo";
        labelInfo.Size = new Size(250, 15);
        labelInfo.TabIndex = 3;
        labelInfo.Text = "Информация о книге: название, автор, цена";
        // 
        // labelMarket
        // 
        labelMarket.AutoSize = true;
        labelMarket.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelMarket.Location = new Point(190, 14);
        labelMarket.Name = "labelMarket";
        labelMarket.Size = new Size(78, 21);
        labelMarket.TabIndex = 2;
        labelMarket.Text = "Магазин";
        // 
        // tabPageSupport
        // 
        tabPageSupport.BackColor = SystemColors.GradientInactiveCaption;
        tabPageSupport.Controls.Add(labelAbout);
        tabPageSupport.Controls.Add(label3);
        tabPageSupport.Controls.Add(buttonReturn3);
        tabPageSupport.Location = new Point(4, 27);
        tabPageSupport.Name = "tabPageSupport";
        tabPageSupport.Size = new Size(667, 355);
        tabPageSupport.TabIndex = 3;
        tabPageSupport.Text = "О нас";
        // 
        // labelAbout
        // 
        labelAbout.AutoSize = true;
        labelAbout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelAbout.Location = new Point(311, 20);
        labelAbout.Name = "labelAbout";
        labelAbout.Size = new Size(53, 21);
        labelAbout.TabIndex = 17;
        labelAbout.Text = "О нас";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(168, 102);
        label3.Name = "label3";
        label3.Size = new Size(338, 135);
        label3.TabIndex = 16;
        label3.Text = "Это приложение - лабораторная работа №4 по дисциплине\r\n\"Основы программирования\".\r\n\r\nРазработчики:\r\nАртём Клочков\r\nТитова Мария\r\nИлюшин Николай\r\nТактаров Артемий\r\nЗалкина София\r\n";
        // 
        // buttonReturn3
        // 
        buttonReturn3.Location = new Point(529, 323);
        buttonReturn3.Name = "buttonReturn3";
        buttonReturn3.Size = new Size(135, 29);
        buttonReturn3.TabIndex = 15;
        buttonReturn3.Text = "Вернуться в меню";
        buttonReturn3.UseVisualStyleBackColor = true;
        buttonReturn3.Click += buttonReturn3_Click;
        // 
        // tabClients
        // 
        tabClients.BackColor = SystemColors.GradientInactiveCaption;
        tabClients.Controls.Add(clientsLabel);
        tabClients.Controls.Add(pnlCustomerProcessing);
        tabClients.Controls.Add(lblNoCustomers);
        tabClients.Location = new Point(4, 27);
        tabClients.Name = "tabClients";
        tabClients.Padding = new Padding(3);
        tabClients.Size = new Size(667, 355);
        tabClients.TabIndex = 4;
        tabClients.Text = "Покупатели";
        // 
        // clientsLabel
        // 
        clientsLabel.AutoSize = true;
        clientsLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
        clientsLabel.Location = new Point(225, 8);
        clientsLabel.Name = "clientsLabel";
        clientsLabel.Size = new Size(225, 20);
        clientsLabel.TabIndex = 4;
        clientsLabel.Text = "Операции продаже и клиенты";
        // 
        // pnlCustomerProcessing
        // 
        pnlCustomerProcessing.Controls.Add(labelSelectedBook);
        pnlCustomerProcessing.Controls.Add(lstCustomerQueue);
        pnlCustomerProcessing.Controls.Add(groupBox2);
        pnlCustomerProcessing.Controls.Add(groupBox1);
        pnlCustomerProcessing.Controls.Add(lblCustomerRequest);
        pnlCustomerProcessing.Controls.Add(lblUnsatisfiedCount);
        pnlCustomerProcessing.Controls.Add(cmbAvailableBooks);
        pnlCustomerProcessing.Location = new Point(84, 32);
        pnlCustomerProcessing.Margin = new Padding(3, 2, 3, 2);
        pnlCustomerProcessing.Name = "pnlCustomerProcessing";
        pnlCustomerProcessing.Size = new Size(506, 304);
        pnlCustomerProcessing.TabIndex = 3;
        pnlCustomerProcessing.Visible = false;
        // 
        // labelSelectedBook
        // 
        labelSelectedBook.AutoSize = true;
        labelSelectedBook.Location = new Point(23, 24);
        labelSelectedBook.Name = "labelSelectedBook";
        labelSelectedBook.Size = new Size(39, 15);
        labelSelectedBook.TabIndex = 10;
        labelSelectedBook.Text = "Книга";
        // 
        // lstCustomerQueue
        // 
        lstCustomerQueue.FormattingEnabled = true;
        lstCustomerQueue.Location = new Point(279, 34);
        lstCustomerQueue.Name = "lstCustomerQueue";
        lstCustomerQueue.Size = new Size(215, 154);
        lstCustomerQueue.TabIndex = 9;
        lstCustomerQueue.SelectedIndexChanged += lstCustomerQueue_SelectedIndexChanged;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(btnCancelCustomer);
        groupBox2.Controls.Add(priceSellNumericUpDown);
        groupBox2.Controls.Add(btnSellToCustomer);
        groupBox2.Controls.Add(label4);
        groupBox2.Location = new Point(17, 49);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(241, 110);
        groupBox2.TabIndex = 8;
        groupBox2.TabStop = false;
        groupBox2.Text = "Продать покупателю в очереди";
        // 
        // btnCancelCustomer
        // 
        btnCancelCustomer.Location = new Point(6, 74);
        btnCancelCustomer.Margin = new Padding(3, 2, 3, 2);
        btnCancelCustomer.Name = "btnCancelCustomer";
        btnCancelCustomer.Size = new Size(107, 31);
        btnCancelCustomer.TabIndex = 4;
        btnCancelCustomer.Text = "Отказаться";
        btnCancelCustomer.UseVisualStyleBackColor = true;
        btnCancelCustomer.Visible = false;
        btnCancelCustomer.Click += btnCancelCustomer_Click;
        // 
        // priceSellNumericUpDown
        // 
        priceSellNumericUpDown.Location = new Point(51, 45);
        priceSellNumericUpDown.Name = "priceSellNumericUpDown";
        priceSellNumericUpDown.Size = new Size(184, 23);
        priceSellNumericUpDown.TabIndex = 6;
        // 
        // btnSellToCustomer
        // 
        btnSellToCustomer.Location = new Point(128, 74);
        btnSellToCustomer.Margin = new Padding(3, 2, 3, 2);
        btnSellToCustomer.Name = "btnSellToCustomer";
        btnSellToCustomer.Size = new Size(107, 31);
        btnSellToCustomer.TabIndex = 3;
        btnSellToCustomer.Text = "Продать";
        btnSellToCustomer.UseVisualStyleBackColor = true;
        btnSellToCustomer.Visible = false;
        btnSellToCustomer.Click += btnSellToCustomer_Click;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(6, 49);
        label4.Name = "label4";
        label4.Size = new Size(35, 15);
        label4.TabIndex = 5;
        label4.Text = "Цена";
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(buttonSellToProvider);
        groupBox1.Location = new Point(17, 162);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(241, 108);
        groupBox1.TabIndex = 7;
        groupBox1.TabStop = false;
        groupBox1.Text = "Не хватает денег и нет покупателей?";
        // 
        // buttonSellToProvider
        // 
        buttonSellToProvider.Location = new Point(16, 35);
        buttonSellToProvider.Name = "buttonSellToProvider";
        buttonSellToProvider.Size = new Size(209, 52);
        buttonSellToProvider.TabIndex = 0;
        buttonSellToProvider.Text = "Продать книгу поставщику\r\n(без наценки)";
        buttonSellToProvider.UseVisualStyleBackColor = true;
        // 
        // lblCustomerRequest
        // 
        lblCustomerRequest.Location = new Point(279, 206);
        lblCustomerRequest.Name = "lblCustomerRequest";
        lblCustomerRequest.Size = new Size(215, 64);
        lblCustomerRequest.TabIndex = 0;
        lblCustomerRequest.Text = "Пожелание";
        lblCustomerRequest.Visible = false;
        // 
        // lblUnsatisfiedCount
        // 
        lblUnsatisfiedCount.AutoSize = true;
        lblUnsatisfiedCount.Location = new Point(332, 9);
        lblUnsatisfiedCount.Name = "lblUnsatisfiedCount";
        lblUnsatisfiedCount.Size = new Size(108, 15);
        lblUnsatisfiedCount.TabIndex = 4;
        lblUnsatisfiedCount.Text = "Очередь клиентов";
        lblUnsatisfiedCount.Visible = false;
        // 
        // cmbAvailableBooks
        // 
        cmbAvailableBooks.FormattingEnabled = true;
        cmbAvailableBooks.Location = new Point(68, 21);
        cmbAvailableBooks.Margin = new Padding(3, 2, 3, 2);
        cmbAvailableBooks.Name = "cmbAvailableBooks";
        cmbAvailableBooks.Size = new Size(190, 23);
        cmbAvailableBooks.TabIndex = 1;
        cmbAvailableBooks.Visible = false;
        // 
        // lblNoCustomers
        // 
        lblNoCustomers.AutoSize = true;
        lblNoCustomers.Font = new Font("Segoe UI", 12F);
        lblNoCustomers.Location = new Point(199, 194);
        lblNoCustomers.Name = "lblNoCustomers";
        lblNoCustomers.Size = new Size(276, 21);
        lblNoCustomers.TabIndex = 0;
        lblNoCustomers.Text = "У Вас пока нет ни одного покупателя";
        // 
        // tabDeliveries
        // 
        tabDeliveries.BackColor = SystemColors.GradientInactiveCaption;
        tabDeliveries.Controls.Add(label5);
        tabDeliveries.Controls.Add(panel1);
        tabDeliveries.Location = new Point(4, 27);
        tabDeliveries.Name = "tabDeliveries";
        tabDeliveries.Padding = new Padding(3);
        tabDeliveries.Size = new Size(667, 355);
        tabDeliveries.TabIndex = 5;
        tabDeliveries.Text = "Поставки";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
        label5.Location = new Point(175, 13);
        label5.Name = "label5";
        label5.Size = new Size(325, 21);
        label5.TabIndex = 15;
        label5.Text = "Пришла новая книга, @ты, Ваше мнение?";
        // 
        // panel1
        // 
        panel1.Controls.Add(groupBox5);
        panel1.Controls.Add(groupBox4);
        panel1.Controls.Add(lblStatus);
        panel1.Controls.Add(groupBox3);
        panel1.Location = new Point(65, 46);
        panel1.Name = "panel1";
        panel1.Size = new Size(545, 271);
        panel1.TabIndex = 14;
        // 
        // groupBox5
        // 
        groupBox5.Controls.Add(rbTypo);
        groupBox5.Controls.Add(rbPlagiarism);
        groupBox5.Controls.Add(rbCorrect);
        groupBox5.Location = new Point(372, 13);
        groupBox5.Name = "groupBox5";
        groupBox5.Size = new Size(152, 182);
        groupBox5.TabIndex = 16;
        groupBox5.TabStop = false;
        groupBox5.Text = "Верна ли книга?";
        // 
        // rbTypo
        // 
        rbTypo.AutoSize = true;
        rbTypo.Location = new Point(6, 51);
        rbTypo.Margin = new Padding(3, 2, 3, 2);
        rbTypo.Name = "rbTypo";
        rbTypo.Size = new Size(77, 19);
        rbTypo.TabIndex = 6;
        rbTypo.Text = "Опечатка";
        rbTypo.UseVisualStyleBackColor = true;
        // 
        // rbPlagiarism
        // 
        rbPlagiarism.AutoSize = true;
        rbPlagiarism.Location = new Point(6, 73);
        rbPlagiarism.Margin = new Padding(3, 2, 3, 2);
        rbPlagiarism.Name = "rbPlagiarism";
        rbPlagiarism.Size = new Size(70, 19);
        rbPlagiarism.TabIndex = 7;
        rbPlagiarism.Text = "Плагиат";
        rbPlagiarism.UseVisualStyleBackColor = true;
        // 
        // rbCorrect
        // 
        rbCorrect.AutoSize = true;
        rbCorrect.CausesValidation = false;
        rbCorrect.Checked = true;
        rbCorrect.Location = new Point(6, 29);
        rbCorrect.Margin = new Padding(3, 2, 3, 2);
        rbCorrect.Name = "rbCorrect";
        rbCorrect.Size = new Size(59, 19);
        rbCorrect.TabIndex = 5;
        rbCorrect.TabStop = true;
        rbCorrect.Text = "Верно";
        rbCorrect.UseVisualStyleBackColor = true;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(lblDeliveryTitle);
        groupBox4.Controls.Add(txtDeliveryPrice);
        groupBox4.Controls.Add(txtDeliveryTitle);
        groupBox4.Controls.Add(lblDeliveryPrice);
        groupBox4.Controls.Add(lblDeliveryAuthor);
        groupBox4.Controls.Add(lblDeliveryGenre);
        groupBox4.Controls.Add(txtDeliveryGenre);
        groupBox4.Controls.Add(txtDeliveryAuthor);
        groupBox4.Location = new Point(16, 34);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(350, 161);
        groupBox4.TabIndex = 15;
        groupBox4.TabStop = false;
        groupBox4.Text = "Пришедшая книга";
        // 
        // lblDeliveryTitle
        // 
        lblDeliveryTitle.AutoSize = true;
        lblDeliveryTitle.Location = new Point(6, 33);
        lblDeliveryTitle.Name = "lblDeliveryTitle";
        lblDeliveryTitle.Size = new Size(62, 15);
        lblDeliveryTitle.TabIndex = 8;
        lblDeliveryTitle.Text = "Название:";
        // 
        // txtDeliveryPrice
        // 
        txtDeliveryPrice.Location = new Point(73, 132);
        txtDeliveryPrice.Margin = new Padding(3, 2, 3, 2);
        txtDeliveryPrice.Name = "txtDeliveryPrice";
        txtDeliveryPrice.ReadOnly = true;
        txtDeliveryPrice.Size = new Size(271, 23);
        txtDeliveryPrice.TabIndex = 4;
        // 
        // txtDeliveryTitle
        // 
        txtDeliveryTitle.Location = new Point(73, 30);
        txtDeliveryTitle.Margin = new Padding(3, 2, 3, 2);
        txtDeliveryTitle.Name = "txtDeliveryTitle";
        txtDeliveryTitle.ReadOnly = true;
        txtDeliveryTitle.Size = new Size(271, 23);
        txtDeliveryTitle.TabIndex = 1;
        // 
        // lblDeliveryPrice
        // 
        lblDeliveryPrice.AutoSize = true;
        lblDeliveryPrice.Location = new Point(30, 135);
        lblDeliveryPrice.Name = "lblDeliveryPrice";
        lblDeliveryPrice.Size = new Size(38, 15);
        lblDeliveryPrice.TabIndex = 11;
        lblDeliveryPrice.Text = "Цена:";
        // 
        // lblDeliveryAuthor
        // 
        lblDeliveryAuthor.AutoSize = true;
        lblDeliveryAuthor.Location = new Point(25, 67);
        lblDeliveryAuthor.Name = "lblDeliveryAuthor";
        lblDeliveryAuthor.Size = new Size(43, 15);
        lblDeliveryAuthor.TabIndex = 9;
        lblDeliveryAuthor.Text = "Автор:";
        // 
        // lblDeliveryGenre
        // 
        lblDeliveryGenre.AutoSize = true;
        lblDeliveryGenre.Location = new Point(27, 101);
        lblDeliveryGenre.Name = "lblDeliveryGenre";
        lblDeliveryGenre.Size = new Size(41, 15);
        lblDeliveryGenre.TabIndex = 10;
        lblDeliveryGenre.Text = "Жанр:";
        // 
        // txtDeliveryGenre
        // 
        txtDeliveryGenre.Location = new Point(73, 98);
        txtDeliveryGenre.Margin = new Padding(3, 2, 3, 2);
        txtDeliveryGenre.Name = "txtDeliveryGenre";
        txtDeliveryGenre.ReadOnly = true;
        txtDeliveryGenre.Size = new Size(271, 23);
        txtDeliveryGenre.TabIndex = 3;
        // 
        // txtDeliveryAuthor
        // 
        txtDeliveryAuthor.Location = new Point(73, 64);
        txtDeliveryAuthor.Margin = new Padding(3, 2, 3, 2);
        txtDeliveryAuthor.Name = "txtDeliveryAuthor";
        txtDeliveryAuthor.ReadOnly = true;
        txtDeliveryAuthor.Size = new Size(271, 23);
        txtDeliveryAuthor.TabIndex = 2;
        // 
        // groupBox3
        // 
        groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox3.Controls.Add(label6);
        groupBox3.Controls.Add(btnRejectDelivery);
        groupBox3.Controls.Add(buttonAcceptDelivery);
        groupBox3.Location = new Point(16, 201);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(508, 61);
        groupBox3.TabIndex = 14;
        groupBox3.TabStop = false;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(210, 0);
        label6.Name = "label6";
        label6.Size = new Size(95, 15);
        label6.TabIndex = 14;
        label6.Text = "Ваши действия?";
        // 
        // btnRejectDelivery
        // 
        btnRejectDelivery.Location = new Point(260, 21);
        btnRejectDelivery.Margin = new Padding(3, 2, 3, 2);
        btnRejectDelivery.Name = "btnRejectDelivery";
        btnRejectDelivery.Size = new Size(140, 29);
        btnRejectDelivery.TabIndex = 12;
        btnRejectDelivery.Text = "Отклонить книгу";
        btnRejectDelivery.UseVisualStyleBackColor = true;
        btnRejectDelivery.Click += btnRejectDelivery_Click;
        // 
        // buttonAcceptDelivery
        // 
        buttonAcceptDelivery.Location = new Point(114, 21);
        buttonAcceptDelivery.Margin = new Padding(3, 2, 3, 2);
        buttonAcceptDelivery.Name = "buttonAcceptDelivery";
        buttonAcceptDelivery.Size = new Size(140, 29);
        buttonAcceptDelivery.TabIndex = 13;
        buttonAcceptDelivery.Text = "Принять книгу";
        buttonAcceptDelivery.UseVisualStyleBackColor = true;
        buttonAcceptDelivery.Click += buttonAcceptDelivery_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(22, 13);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(43, 15);
        lblStatus.TabIndex = 0;
        lblStatus.Text = "Статус";
        // 
        // btnAcceptDelivery
        // 
        btnAcceptDelivery.Location = new Point(139, 158);
        btnAcceptDelivery.Margin = new Padding(3, 2, 3, 2);
        btnAcceptDelivery.Name = "btnAcceptDelivery";
        btnAcceptDelivery.Size = new Size(152, 29);
        btnAcceptDelivery.TabIndex = 13;
        btnAcceptDelivery.Text = "Принять книгу";
        btnAcceptDelivery.UseVisualStyleBackColor = true;
        // 
        // panel2
        // 
        panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        panel2.BackColor = SystemColors.GradientInactiveCaption;
        panel2.Controls.Add(labelStats);
        panel2.Location = new Point(513, 42);
        panel2.Name = "panel2";
        panel2.Size = new Size(362, 35);
        panel2.TabIndex = 1;
        // 
        // labelStats
        // 
        labelStats.AutoSize = true;
        labelStats.Location = new Point(3, 10);
        labelStats.Name = "labelStats";
        labelStats.Size = new Size(109, 15);
        labelStats.TabIndex = 0;
        labelStats.Text = "Поля изменяемые";
        // 
        // BibleForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoValidate = AutoValidate.Disable;
        BackColor = SystemColors.ActiveCaption;
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(1060, 545);
        Controls.Add(panel2);
        Controls.Add(tabControlNewBook);
        Name = "BibleForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Ulitka Soft - SellBook";
        tabControlNewBook.ResumeLayout(false);
        tabPageMain.ResumeLayout(false);
        tabPageMain.PerformLayout();
        tabNewBook.ResumeLayout(false);
        tabNewBook.PerformLayout();
        groupBoxNewBook.ResumeLayout(false);
        groupBoxNewBook.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownPages).EndInit();
        tabPageMarket.ResumeLayout(false);
        tabPageMarket.PerformLayout();
        groupBoxSearch.ResumeLayout(false);
        groupBoxSearch.PerformLayout();
        groupBoxChose.ResumeLayout(false);
        groupBoxChose.PerformLayout();
        groupBoxDetails.ResumeLayout(false);
        groupBoxDetails.PerformLayout();
        tabPageSupport.ResumeLayout(false);
        tabPageSupport.PerformLayout();
        tabClients.ResumeLayout(false);
        tabClients.PerformLayout();
        pnlCustomerProcessing.ResumeLayout(false);
        pnlCustomerProcessing.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)priceSellNumericUpDown).EndInit();
        groupBox1.ResumeLayout(false);
        tabDeliveries.ResumeLayout(false);
        tabDeliveries.PerformLayout();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        groupBox5.ResumeLayout(false);
        groupBox5.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControlNewBook;
    private TabPage tabPageMain;
    private TabPage tabNewBook;
    private TabPage tabPageMarket;
    private Label labelSupport;
    private Label labelHye;
    private Label labelRights;
    private Button btnMarket;
    private Button btnNewBook;
    private Button btnSupport;
    private Label labelDobNewBook;
    private Label labelMarket;
    private GroupBox groupBoxNewBook;
    private Label labelAutor;
    private TextBox textBoxAutor;
    private Label labelTitleBook;
    private TextBox textBoxTitleBook;
    private Label labelType;
    private ComboBox comboBoxType;
    private NumericUpDown numericUpDownPages;
    private Button buttonClearNewBook;
    private NumericUpDown numericUpDownPrice;
    private Label labelPrice;
    private Label labelPages;
    private Button buttonGenerate;
    private Button btnAddNewBook;
    private Button buttonReturn1;
    private Button buttonReturn2;
    private GroupBox groupBoxChose;
    private Label labelJanr;
    private ComboBox comboBoxJanr;
    private GroupBox groupBoxSearch;
    private Button buttonSearch1;
    private Label label1;
    private TextBox textBoxSearchID;
    private Button buttonSearch2;
    private Label label2;
    private TextBox textBoxSearchTitle;
    private ListView listViewBooks;
    private TabPage tabPageSupport;
    private Button buttonReturn3;
    private Label label3;
    private Label labelAbout;
    private GroupBox groupBoxDetails;
    private Button btnSell;
    private Button btnBackToSearch;
    private Label labelInfo;
    private TabPage tabClients;
    private TabPage tabDeliveries;

    private Label lblStatus;
    private TextBox txtDeliveryTitle;
    private TextBox txtDeliveryAuthor;
    private TextBox txtDeliveryGenre;
    private TextBox txtDeliveryPrice;
    private RadioButton rbCorrect;
    private RadioButton rbTypo;
    private RadioButton rbPlagiarism;
    private Label lblDeliveryGenre;
    private Label lblDeliveryAuthor;
    private Label lblDeliveryTitle;
    private Label lblDeliveryPrice;
    private Button btnAcceptDelivery;
    private Button btnRejectDelivery;
    private Label lblNoCustomers;
    private Panel pnlCustomerProcessing;
    private Label lblCustomerRequest;
    private ComboBox cmbAvailableBooks;
    private Button btnCancelCustomer;
    private Button btnSellToCustomer;
    private Label lblUnsatisfiedCount;
    private Label labelID;
    private Label labelIDforUsing;
    private Label label4;
    private NumericUpDown priceSellNumericUpDown;
    private GroupBox groupBox1;
    private Button buttonSellToProvider;
    private GroupBox groupBox2;
    private Label clientsLabel;
    private Button buttonAcceptDelivery;
    private Panel panel1;
    private GroupBox groupBox4;
    private GroupBox groupBox3;
    private GroupBox groupBox5;
    private Label label5;
    private Label label6;
    private Button buttonSale;
    private Panel panel2;
    private Label labelStats;
    private ListBox lstCustomerQueue;
    private Label labelSelectedBook;
}
