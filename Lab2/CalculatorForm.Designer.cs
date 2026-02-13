namespace Lab2
{
    partial class CalculatorForm
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

        private Button CreateCalculatorButton(string name, Point pos, string text, string? tokenName)
        {
            Button button = new Button();
            button.Size = new Size(118, 77);
            button.Name = name;
            button.Location = pos;
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            button.Click += AddCharIntoInputTextBox(tokenName ?? text);

            InputOutputCalucatorPanel.Controls.Add(button);
            return button;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
            InitializeTabs();
            SuspendLayout();

            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1050, 651);

            Controls.Add(CalculatorTabControl);
            Name = "CalculatorForm";
            Text = "UlitkaSoft Калькулятор";
            
            ResumeLayout(false);
        }

        private void InitializeTabs()
        {
            CalculatorTabControl = new();
            CalculatorTabControl.SuspendLayout();

            CalculatorTab();
            HistoryTab();

            CalculatorTabControl.Location = new Point(-5, 26);
            CalculatorTabControl.Name = "CalculatorTabControl";
            CalculatorTabControl.Size = new Size(1058, 627);

            CalculatorTabControl.ResumeLayout(false);
        }

        private void HistoryTab()
        {
            HistoryTabPage = new();
            HistoryLabel = new();
            HistoryOutput = new();

            HistoryTabPage.SuspendLayout();

            HistoryTabPage.Controls.Add(HistoryLabel);
            HistoryTabPage.Controls.Add(HistoryOutput);
            HistoryTabPage.Location = new Point(8, 46);
            HistoryTabPage.Name = "HistoryTabPage";
            HistoryTabPage.Padding = new Padding(3);
            HistoryTabPage.Size = new Size(1042, 573);
            HistoryTabPage.Text = "История";
            HistoryTabPage.UseVisualStyleBackColor = true;

            HistoryOutput.Location = new Point(57, 99);
            HistoryOutput.Multiline = true;
            HistoryOutput.Name = "HistoryOutput";
            HistoryOutput.ReadOnly = true;
            HistoryOutput.Size = new Size(921, 334);

            HistoryLabel.AutoSize = true;
            HistoryLabel.Location = new Point(390, 31);
            HistoryLabel.Name = "HistoryLabel";
            HistoryLabel.Size = new Size(223, 32);
            HistoryLabel.Text = "История операций";

            CalculatorTabControl.Controls.Add(HistoryTabPage);

            HistoryTabPage.ResumeLayout(false);
            HistoryTabPage.PerformLayout();
        }

        private void CalculatorTab()
        {
            CalculatorTabPage = new();
            CalculatorTabPage.SuspendLayout();

            CalculatorTabPage.Location = new Point(8, 46);
            CalculatorTabPage.Name = "CalculatorTabPage";
            CalculatorTabPage.Padding = new Padding(3);
            CalculatorTabPage.Size = new Size(1042, 573);
            CalculatorTabPage.Text = "Калькулятор";

            InputOutputCalucatorPanel = new();
            InputOutputCalucatorPanel.SuspendLayout();

            InputOutputCalucatorPanel.BackColor = Color.WhiteSmoke;
            InputOutputCalucatorPanel.Location = new Point(62, 132);
            InputOutputCalucatorPanel.Name = "InputOutputCalucatorPanel";
            InputOutputCalucatorPanel.Size = new Size(949, 412);
            InputOutputCalucatorPanel.TabIndex = 23;

            InitializationInputOutput();
            InitializationCalculatorButtons();

            CalculatorTabPage.Controls.Add(InputOutputCalucatorPanel);

            CalculatorTabControl.Controls.Add(CalculatorTabPage);

            InputOutputCalucatorPanel.ResumeLayout(false);
            InputOutputCalucatorPanel.PerformLayout();
            CalculatorTabPage.ResumeLayout(false);
            CalculatorTabPage.PerformLayout();
        }

        private void InitializationInputOutput()
        {
            ExpressionLabel = new();
            ExpressionLabel.AutoSize = true;
            ExpressionLabel.Location = new Point(75, 70);
            ExpressionLabel.Name = "ExpressionLabel";
            ExpressionLabel.Size = new Size(440, 32);
            ExpressionLabel.Text = "Введите арифметическое выражение";

            CalculatorTabPage.Controls.Add(ExpressionLabel);

            InputMathExpression = new();
            InputMathExpression.Location = new Point(610, 63);
            InputMathExpression.Name = "InputMathExpression";
            InputMathExpression.Size = new Size(344, 39);

            CalculatorTabPage.Controls.Add(InputMathExpression);


            ResultLabel = new();
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(25, 19);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(264, 32);
            ResultLabel.Text = "Результат вычислений";

            InputOutputCalucatorPanel.Controls.Add(ResultLabel);

            ResultInput = new();
            ResultInput.Location = new Point(548, 12);
            ResultInput.Name = "ResultInput";
            ResultInput.ReadOnly = true;
            ResultInput.Size = new Size(344, 39);

            InputOutputCalucatorPanel.Controls.Add(ResultInput);
        }

        private void InitializationCalculatorButtons()
        {
            NumZeroButton = CreateCalculatorButton("NumZeroButton", new Point(493, 203), "0", null);
            NumOneButton = CreateCalculatorButton("NumOneButton", new Point(25, 308), "1", null);
            NumTwoButton = CreateCalculatorButton("NumTwoButton", new Point(188, 308), "2", null);
            NumThreeButton = CreateCalculatorButton("NumThreeButton", new Point(335, 308), "3", null);
            NumFourButton = CreateCalculatorButton("NumFourButton", new Point(25, 203), "4", null);
            NumFiveButton = CreateCalculatorButton("NumFiveButton", new Point(188, 203), "5", null);
            NumSixButton = CreateCalculatorButton("NumSixButton", new Point(335, 203), "6", null);
            NumSevenButton = CreateCalculatorButton("NumSevenButton", new Point(25, 94), "7", null);
            NumEightButton = CreateCalculatorButton("NumEightButton", new Point(188, 94), "8", null);
            NumNineButton = CreateCalculatorButton("NumNineButton", new Point(335, 94), "9", null);

            OpenBracketButton = CreateCalculatorButton("OpenBracketButton", new Point(493, 94), "(", null);
            CloseBracketButton = CreateCalculatorButton("CloseBracketButton", new Point(675, 94), ")", null);

            MultiplicationButton = CreateCalculatorButton("MultiplicationButton", new Point(675, 203), "×", "*");
            DivisionButton = CreateCalculatorButton("DivisionButton", new Point(675, 308), "÷", "/");
            SubtractionButton = CreateCalculatorButton("SubtractionButton", new Point(821, 308), "−", "-");
            AdditionButton = CreateCalculatorButton("AdditionButton", new Point(821, 203), "+", "+");

            // EqualityButton (тут другая логика, напишу так)
            EqualityButton = new();

            EqualityButton.Location = new Point(821, 94);
            EqualityButton.Name = "EqualityButton";
            EqualityButton.Size = new Size(118, 77);
            EqualityButton.TabIndex = 22;
            EqualityButton.Text = "=";
            EqualityButton.UseVisualStyleBackColor = true;
            EqualityButton.Click += CalculateExpression;

            InputOutputCalucatorPanel.Controls.Add(EqualityButton);
        }

        

        private TabControl CalculatorTabControl;

        private TabPage CalculatorTabPage;

        // Панель для кнопок и вывода результата
        private Panel InputOutputCalucatorPanel;

        private Label ExpressionLabel;
        private Label ResultLabel;

        private TextBox InputMathExpression;
        private TextBox ResultInput;

        // Кнопки от 0 до 9
        private Button NumZeroButton;
        private Button NumOneButton;
        private Button NumTwoButton;
        private Button NumThreeButton;
        private Button NumFourButton;
        private Button NumFiveButton;
        private Button NumSixButton;
        private Button NumSevenButton;
        private Button NumEightButton;
        private Button NumNineButton;
        
        // Скобки
        private Button OpenBracketButton;
        private Button CloseBracketButton;

        // Операции
        private Button MultiplicationButton;
        private Button DivisionButton;
        private Button SubtractionButton;
        private Button AdditionButton;

        private Button EqualityButton;

        // История операций
        private TabPage HistoryTabPage;
        private TextBox HistoryOutput;
        private Label HistoryLabel;
    }
}
