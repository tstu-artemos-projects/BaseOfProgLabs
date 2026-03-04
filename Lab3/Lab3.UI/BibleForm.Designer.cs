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
        groupBoxDetails = new GroupBox();
        btnSell = new Button();
        btnBackToSearch = new Button();
        labelInfo = new Label();
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
        labelBalance = new Label();
        labelBalanceUsed = new Label();
        buttonReturn2 = new Button();
        labelMarket = new Label();
        tabPageSupport = new TabPage();
        labelAbout = new Label();
        label3 = new Label();
        buttonReturn3 = new Button();
        tabControlNewBook.SuspendLayout();
        tabPageMain.SuspendLayout();
        tabNewBook.SuspendLayout();
        groupBoxNewBook.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownPages).BeginInit();
        tabPageMarket.SuspendLayout();
        groupBoxSearch.SuspendLayout();
        groupBoxDetails.SuspendLayout();
        groupBoxChose.SuspendLayout();
        tabPageSupport.SuspendLayout();
        SuspendLayout();
        // 
        // tabControlNewBook
        // 
        tabControlNewBook.Appearance = TabAppearance.FlatButtons;
        tabControlNewBook.Controls.Add(tabPageMain);
        tabControlNewBook.Controls.Add(tabNewBook);
        tabControlNewBook.Controls.Add(tabPageMarket);
        tabControlNewBook.Controls.Add(tabPageSupport);
        tabControlNewBook.Location = new Point(0, 0);
        tabControlNewBook.Name = "tabControlNewBook";
        tabControlNewBook.SelectedIndex = 0;
        tabControlNewBook.Size = new Size(468, 321);
        tabControlNewBook.SizeMode = TabSizeMode.Fixed;
        tabControlNewBook.TabIndex = 0;
        tabControlNewBook.TabStop = false;
        // 
        // tabPageMain
        // 
        tabPageMain.BackColor = Color.Transparent;
        tabPageMain.Controls.Add(btnSupport);
        tabPageMain.Controls.Add(btnMarket);
        tabPageMain.Controls.Add(btnNewBook);
        tabPageMain.Controls.Add(labelRights);
        tabPageMain.Controls.Add(labelSupport);
        tabPageMain.Controls.Add(labelHye);
        tabPageMain.Location = new Point(4, 27);
        tabPageMain.Name = "tabPageMain";
        tabPageMain.Padding = new Padding(3);
        tabPageMain.Size = new Size(460, 290);
        tabPageMain.TabIndex = 0;
        tabPageMain.Text = "Главное меню";
        tabPageMain.Click += tabPageMain_Click;
        // 
        // btnSupport
        // 
        btnSupport.Location = new Point(95, 203);
        btnSupport.Name = "btnSupport";
        btnSupport.Size = new Size(229, 28);
        btnSupport.TabIndex = 5;
        btnSupport.Text = "О нас";
        btnSupport.UseVisualStyleBackColor = true;
        btnSupport.Click += btnSupport_Click;
        // 
        // btnMarket
        // 
        btnMarket.Location = new Point(95, 158);
        btnMarket.Name = "btnMarket";
        btnMarket.Size = new Size(229, 28);
        btnMarket.TabIndex = 4;
        btnMarket.Text = "Открыть магазин\r\n";
        btnMarket.UseVisualStyleBackColor = true;
        btnMarket.Click += btnMarket_Click;
        // 
        // btnNewBook
        // 
        btnNewBook.Location = new Point(95, 114);
        btnNewBook.Name = "btnNewBook";
        btnNewBook.Size = new Size(229, 28);
        btnNewBook.TabIndex = 3;
        btnNewBook.Text = "Добавить новую книгу";
        btnNewBook.UseVisualStyleBackColor = true;
        btnNewBook.Click += btnNewBook_Click;
        // 
        // labelRights
        // 
        labelRights.AutoSize = true;
        labelRights.Location = new Point(95, 271);
        labelRights.Name = "labelRights";
        labelRights.Size = new Size(229, 15);
        labelRights.TabIndex = 2;
        labelRights.Text = "ⓒ 2026 Ulitka Soft, Все права защищены.";
        // 
        // labelSupport
        // 
        labelSupport.AutoSize = true;
        labelSupport.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
        labelSupport.Location = new Point(15, 43);
        labelSupport.Name = "labelSupport";
        labelSupport.Size = new Size(438, 30);
        labelSupport.TabIndex = 1;
        labelSupport.Text = "С помощью этого приложения вы можете управлять ресурсами библиотеки \r\nудалённо. Жмите на кнопку нужного действия ниже и дерзайте!\r\n";
        // 
        // labelHye
        // 
        labelHye.AutoSize = true;
        labelHye.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelHye.Location = new Point(15, 12);
        labelHye.Name = "labelHye";
        labelHye.Size = new Size(395, 21);
        labelHye.TabIndex = 0;
        labelHye.Text = "Добро пожаловать в библиотечный менеджер! ";
        // 
        // tabNewBook
        // 
        tabNewBook.Controls.Add(buttonReturn1);
        tabNewBook.Controls.Add(groupBoxNewBook);
        tabNewBook.Controls.Add(labelDobNewBook);
        tabNewBook.Location = new Point(4, 27);
        tabNewBook.Name = "tabNewBook";
        tabNewBook.Padding = new Padding(3);
        tabNewBook.Size = new Size(460, 290);
        tabNewBook.TabIndex = 1;
        tabNewBook.Text = "Новая книга";
        tabNewBook.UseVisualStyleBackColor = true;
        // 
        // buttonReturn1
        // 
        buttonReturn1.Location = new Point(265, 14);
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
        groupBoxNewBook.Location = new Point(17, 47);
        groupBoxNewBook.Name = "groupBoxNewBook";
        groupBoxNewBook.Size = new Size(416, 233);
        groupBoxNewBook.TabIndex = 2;
        groupBoxNewBook.TabStop = false;
        groupBoxNewBook.Text = "Вводите нужные данные здесь для добавления новой книги";
        // 
        // buttonGenerate
        // 
        buttonGenerate.Location = new Point(162, 186);
        buttonGenerate.Name = "buttonGenerate";
        buttonGenerate.Size = new Size(234, 27);
        buttonGenerate.TabIndex = 14;
        buttonGenerate.Text = "Сгенерировать рандомные данные \r\n";
        buttonGenerate.UseVisualStyleBackColor = true;
        // 
        // btnAddNewBook
        // 
        btnAddNewBook.Location = new Point(293, 89);
        btnAddNewBook.Name = "btnAddNewBook";
        btnAddNewBook.Size = new Size(103, 73);
        btnAddNewBook.TabIndex = 13;
        btnAddNewBook.Text = "Добавить новую книгу";
        btnAddNewBook.UseVisualStyleBackColor = true;
        btnAddNewBook.Click += btnAddNewBook_Click;
        // 
        // buttonClearNewBook
        // 
        buttonClearNewBook.Location = new Point(6, 186);
        buttonClearNewBook.Name = "buttonClearNewBook";
        buttonClearNewBook.Size = new Size(148, 27);
        buttonClearNewBook.TabIndex = 12;
        buttonClearNewBook.Text = "Очистить все поля";
        buttonClearNewBook.UseVisualStyleBackColor = true;
        buttonClearNewBook.Click += buttonClearNewBook_Click;
        // 
        // numericUpDownPrice
        // 
        numericUpDownPrice.Location = new Point(227, 139);
        numericUpDownPrice.Name = "numericUpDownPrice";
        numericUpDownPrice.Size = new Size(48, 23);
        numericUpDownPrice.TabIndex = 11;
        // 
        // labelPrice
        // 
        labelPrice.AutoSize = true;
        labelPrice.Location = new Point(186, 141);
        labelPrice.Name = "labelPrice";
        labelPrice.Size = new Size(38, 15);
        labelPrice.TabIndex = 10;
        labelPrice.Text = "Цена:";
        // 
        // labelPages
        // 
        labelPages.AutoSize = true;
        labelPages.Location = new Point(6, 141);
        labelPages.Name = "labelPages";
        labelPages.Size = new Size(97, 15);
        labelPages.TabIndex = 9;
        labelPages.Text = "Кол-во страниц:";
        // 
        // numericUpDownPages
        // 
        numericUpDownPages.Location = new Point(106, 139);
        numericUpDownPages.Name = "numericUpDownPages";
        numericUpDownPages.Size = new Size(48, 23);
        numericUpDownPages.TabIndex = 8;
        // 
        // labelType
        // 
        labelType.AutoSize = true;
        labelType.Location = new Point(62, 89);
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
        comboBoxType.Size = new Size(169, 23);
        comboBoxType.TabIndex = 6;
        // 
        // labelID
        // 
        labelID.AutoSize = true;
        labelID.Location = new Point(6, 115);
        labelID.Name = "labelID";
        labelID.Size = new Size(94, 15);
        labelID.TabIndex = 5;
        labelID.Text = "Идентификатор";
        // 
        // labelIDforUsing
        // 
        labelIDforUsing.AutoSize = true;
        labelIDforUsing.Location = new Point(106, 115);
        labelIDforUsing.Name = "labelIDforUsing";
        labelIDforUsing.Size = new Size(179, 15);
        labelIDforUsing.TabIndex = 4;
        labelIDforUsing.Text = "Будет присвоен автоматически";
        // 
        // labelAutor
        // 
        labelAutor.AutoSize = true;
        labelAutor.Location = new Point(29, 57);
        labelAutor.Name = "labelAutor";
        labelAutor.Size = new Size(74, 15);
        labelAutor.TabIndex = 3;
        labelAutor.Text = "Имя автора:";
        // 
        // textBoxAutor
        // 
        textBoxAutor.Location = new Point(106, 57);
        textBoxAutor.Name = "textBoxAutor";
        textBoxAutor.Size = new Size(290, 23);
        textBoxAutor.TabIndex = 2;
        // 
        // labelTitleBook
        // 
        labelTitleBook.AutoSize = true;
        labelTitleBook.Location = new Point(6, 28);
        labelTitleBook.Name = "labelTitleBook";
        labelTitleBook.Size = new Size(97, 15);
        labelTitleBook.TabIndex = 1;
        labelTitleBook.Text = "Название книги:";
        // 
        // textBoxTitleBook
        // 
        textBoxTitleBook.Location = new Point(106, 28);
        textBoxTitleBook.Name = "textBoxTitleBook";
        textBoxTitleBook.Size = new Size(290, 23);
        textBoxTitleBook.TabIndex = 0;
        // 
        // labelDobNewBook
        // 
        labelDobNewBook.AutoSize = true;
        labelDobNewBook.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelDobNewBook.Location = new Point(17, 12);
        labelDobNewBook.Name = "labelDobNewBook";
        labelDobNewBook.Size = new Size(211, 21);
        labelDobNewBook.TabIndex = 1;
        labelDobNewBook.Text = "Добавление новой книги\r\n";
        // 
        // tabPageMarket
        // 
        tabPageMarket.BackColor = Color.Transparent;
        tabPageMarket.Controls.Add(groupBoxSearch);
        tabPageMarket.Controls.Add(listViewBooks);
        tabPageMarket.Controls.Add(groupBoxChose);
        tabPageMarket.Controls.Add(buttonReturn2);
        tabPageMarket.Controls.Add(labelMarket);
        tabPageMarket.Location = new Point(4, 27);
        tabPageMarket.Name = "tabPageMarket";
        tabPageMarket.Size = new Size(460, 290);
        tabPageMarket.TabIndex = 2;
        tabPageMarket.Text = "Магазин";
        // 
        // groupBoxSearch
        // 
        groupBoxSearch.Controls.Add(groupBoxDetails);
        groupBoxSearch.Controls.Add(textBoxSearchID);
        groupBoxSearch.Controls.Add(buttonSearch2);
        groupBoxSearch.Controls.Add(label2);
        groupBoxSearch.Controls.Add(textBoxSearchTitle);
        groupBoxSearch.Controls.Add(buttonSearch1);
        groupBoxSearch.Controls.Add(label1);
        groupBoxSearch.Location = new Point(18, 184);
        groupBoxSearch.Name = "groupBoxSearch";
        groupBoxSearch.Size = new Size(422, 96);
        groupBoxSearch.TabIndex = 16;
        groupBoxSearch.TabStop = false;
        groupBoxSearch.Text = "Панель поиска";
        // 
        // groupBoxDetails
        // 
        groupBoxDetails.Controls.Add(btnSell);
        groupBoxDetails.Controls.Add(btnBackToSearch);
        groupBoxDetails.Controls.Add(labelInfo);
        groupBoxDetails.Location = new Point(0, 0);
        groupBoxDetails.Name = "groupBoxDetails";
        groupBoxDetails.Size = new Size(422, 78);
        groupBoxDetails.TabIndex = 21;
        groupBoxDetails.TabStop = false;
        groupBoxDetails.Text = "Панель информации о книге";
        groupBoxDetails.Visible = false;
        // 
        // btnSell
        // 
        btnSell.Location = new Point(241, 43);
        btnSell.Name = "btnSell";
        btnSell.Size = new Size(94, 27);
        btnSell.TabIndex = 19;
        btnSell.Text = "Продать";
        btnSell.UseVisualStyleBackColor = true;
        btnSell.Click += btnSell_Click;
        // 
        // btnBackToSearch
        // 
        btnBackToSearch.Location = new Point(356, 45);
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
        // textBoxSearchID
        // 
        textBoxSearchID.Location = new Point(168, 55);
        textBoxSearchID.Name = "textBoxSearchID";
        textBoxSearchID.Size = new Size(182, 23);
        textBoxSearchID.TabIndex = 20;
        // 
        // buttonSearch2
        // 
        buttonSearch2.Location = new Point(356, 55);
        buttonSearch2.Name = "buttonSearch2";
        buttonSearch2.Size = new Size(60, 27);
        buttonSearch2.TabIndex = 19;
        buttonSearch2.Text = "Поиск";
        buttonSearch2.UseVisualStyleBackColor = true;
        buttonSearch2.Click += button1_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(6, 55);
        label2.Name = "label2";
        label2.Size = new Size(156, 15);
        label2.TabIndex = 18;
        label2.Text = "Поиск по идентификатору:";
        // 
        // textBoxSearchTitle
        // 
        textBoxSearchTitle.Location = new Point(128, 25);
        textBoxSearchTitle.Name = "textBoxSearchTitle";
        textBoxSearchTitle.Size = new Size(222, 23);
        textBoxSearchTitle.TabIndex = 17;
        // 
        // buttonSearch1
        // 
        buttonSearch1.Location = new Point(356, 19);
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
        label1.Location = new Point(6, 25);
        label1.Name = "label1";
        label1.Size = new Size(119, 15);
        label1.TabIndex = 3;
        label1.Text = "Поиск по названию:";
        // 
        // listViewBooks
        // 
        listViewBooks.Location = new Point(259, 12);
        listViewBooks.MultiSelect = false;
        listViewBooks.Name = "listViewBooks";
        listViewBooks.Size = new Size(181, 175);
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
        groupBoxChose.Controls.Add(labelBalance);
        groupBoxChose.Controls.Add(labelBalanceUsed);
        groupBoxChose.Location = new Point(18, 49);
        groupBoxChose.Name = "groupBoxChose";
        groupBoxChose.Size = new Size(231, 101);
        groupBoxChose.TabIndex = 15;
        groupBoxChose.TabStop = false;
        groupBoxChose.Text = "Ваши текущие параметры";
        // 
        // buttonSale
        // 
        buttonSale.Location = new Point(96, 62);
        buttonSale.Name = "buttonSale";
        buttonSale.Size = new Size(127, 27);
        buttonSale.TabIndex = 16;
        buttonSale.Text = "Распродать шкаф";
        buttonSale.UseVisualStyleBackColor = true;
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
        comboBoxJanr.Size = new Size(127, 23);
        comboBoxJanr.TabIndex = 2;
        // 
        // labelBalance
        // 
        labelBalance.AutoSize = true;
        labelBalance.Location = new Point(6, 64);
        labelBalance.Name = "labelBalance";
        labelBalance.Size = new Size(49, 15);
        labelBalance.TabIndex = 1;
        labelBalance.Text = "Баланс:";
        // 
        // labelBalanceUsed
        // 
        labelBalanceUsed.AutoSize = true;
        labelBalanceUsed.Location = new Point(53, 64);
        labelBalanceUsed.Name = "labelBalanceUsed";
        labelBalanceUsed.Size = new Size(41, 15);
        labelBalanceUsed.TabIndex = 0;
        labelBalanceUsed.Text = "вывод";
        // 
        // buttonReturn2
        // 
        buttonReturn2.Location = new Point(114, 12);
        buttonReturn2.Name = "buttonReturn2";
        buttonReturn2.Size = new Size(135, 29);
        buttonReturn2.TabIndex = 14;
        buttonReturn2.Text = "Вернуться в меню";
        buttonReturn2.UseVisualStyleBackColor = true;
        buttonReturn2.Click += buttonReturn2_Click;
        // 
        // labelMarket
        // 
        labelMarket.AutoSize = true;
        labelMarket.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelMarket.Location = new Point(18, 14);
        labelMarket.Name = "labelMarket";
        labelMarket.Size = new Size(78, 21);
        labelMarket.TabIndex = 2;
        labelMarket.Text = "Магазин\r\n";
        // 
        // tabPageSupport
        // 
        tabPageSupport.Controls.Add(labelAbout);
        tabPageSupport.Controls.Add(label3);
        tabPageSupport.Controls.Add(buttonReturn3);
        tabPageSupport.Location = new Point(4, 27);
        tabPageSupport.Name = "tabPageSupport";
        tabPageSupport.Size = new Size(460, 290);
        tabPageSupport.TabIndex = 3;
        tabPageSupport.Text = "О нас";
        tabPageSupport.UseVisualStyleBackColor = true;
        // 
        // labelAbout
        // 
        labelAbout.AutoSize = true;
        labelAbout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelAbout.Location = new Point(24, 16);
        labelAbout.Name = "labelAbout";
        labelAbout.Size = new Size(53, 21);
        labelAbout.TabIndex = 17;
        labelAbout.Text = "О нас\r\n";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(24, 55);
        label3.Name = "label3";
        label3.Size = new Size(401, 150);
        label3.TabIndex = 16;
        label3.Text = resources.GetString("label3.Text");
        // 
        // buttonReturn3
        // 
        buttonReturn3.Location = new Point(139, 251);
        buttonReturn3.Name = "buttonReturn3";
        buttonReturn3.Size = new Size(135, 29);
        buttonReturn3.TabIndex = 15;
        buttonReturn3.Text = "Вернуться в меню";
        buttonReturn3.UseVisualStyleBackColor = true;
        buttonReturn3.Click += buttonReturn3_Click;
        // 
        // FormManager
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoValidate = AutoValidate.Disable;
        BackgroundImage = Properties.Resources.b2dffd3b7b204e29e4c4b67d977199a11;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(847, 319);
        Controls.Add(tabControlNewBook);
        Name = "FormManager";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Ulitka Soft - Библиотечный менеджер";
        Load += FormManager_Load;
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
        groupBoxDetails.ResumeLayout(false);
        groupBoxDetails.PerformLayout();
        groupBoxChose.ResumeLayout(false);
        groupBoxChose.PerformLayout();
        tabPageSupport.ResumeLayout(false);
        tabPageSupport.PerformLayout();
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
    private Label labelID;
    private Label labelIDforUsing;
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
    private Label labelBalance;
    private Label labelBalanceUsed;
    private Button buttonSale;
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
}
