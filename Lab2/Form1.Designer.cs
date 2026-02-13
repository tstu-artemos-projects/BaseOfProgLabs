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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
            Calculator_tabControl = new TabControl();
            Calculator_tabPage = new TabPage();
            InputOutput_panel = new Panel();
            Equality_button = new Button();
            Result_textBox = new TextBox();
            Result_label = new Label();
            OpenBracket_button = new Button();
            Вivision_button = new Button();
            Subtraction_button = new Button();
            Addition_button = new Button();
            Multiplication_button = new Button();
            CloseBracket_button = new Button();
            NumZero_button = new Button();
            NumNine_button = new Button();
            NumEight_button = new Button();
            NumThree_button = new Button();
            NumFour_button = new Button();
            NumFive_button = new Button();
            NumSix_button = new Button();
            NumSeven_button = new Button();
            NumTwo_button = new Button();
            NumOne_button = new Button();
            Input_textBox = new TextBox();
            Input_label = new Label();
            ОperationHistory_tabPage = new TabPage();
            OperationHistory_textBox = new TextBox();
            OperationHistory_label = new Label();
            Calculator_tabControl.SuspendLayout();
            Calculator_tabPage.SuspendLayout();
            InputOutput_panel.SuspendLayout();
            ОperationHistory_tabPage.SuspendLayout();
            SuspendLayout();
            // 
            // Calculator_tabControl
            // 
            Calculator_tabControl.Controls.Add(Calculator_tabPage);
            Calculator_tabControl.Controls.Add(ОperationHistory_tabPage);
            Calculator_tabControl.Location = new Point(-5, 26);
            Calculator_tabControl.Name = "Calculator_tabControl";
            Calculator_tabControl.SelectedIndex = 0;
            Calculator_tabControl.Size = new Size(1058, 627);
            Calculator_tabControl.TabIndex = 0;
            // 
            // Calculator_tabPage
            // 
            Calculator_tabPage.Controls.Add(InputOutput_panel);
            Calculator_tabPage.Controls.Add(Input_textBox);
            Calculator_tabPage.Controls.Add(Input_label);
            Calculator_tabPage.Location = new Point(8, 46);
            Calculator_tabPage.Name = "Calculator_tabPage";
            Calculator_tabPage.Padding = new Padding(3);
            Calculator_tabPage.Size = new Size(1042, 573);
            Calculator_tabPage.TabIndex = 0;
            Calculator_tabPage.Text = "Calculator";
            Calculator_tabPage.UseVisualStyleBackColor = true;
            Calculator_tabPage.Click += Calculator_tabPage_Click;
            // 
            // InputOutput_panel
            // 
            InputOutput_panel.BackColor = Color.WhiteSmoke;
            InputOutput_panel.Controls.Add(Equality_button);
            InputOutput_panel.Controls.Add(Result_textBox);
            InputOutput_panel.Controls.Add(Result_label);
            InputOutput_panel.Controls.Add(OpenBracket_button);
            InputOutput_panel.Controls.Add(Вivision_button);
            InputOutput_panel.Controls.Add(Subtraction_button);
            InputOutput_panel.Controls.Add(Addition_button);
            InputOutput_panel.Controls.Add(Multiplication_button);
            InputOutput_panel.Controls.Add(CloseBracket_button);
            InputOutput_panel.Controls.Add(NumZero_button);
            InputOutput_panel.Controls.Add(NumNine_button);
            InputOutput_panel.Controls.Add(NumEight_button);
            InputOutput_panel.Controls.Add(NumThree_button);
            InputOutput_panel.Controls.Add(NumFour_button);
            InputOutput_panel.Controls.Add(NumFive_button);
            InputOutput_panel.Controls.Add(NumSix_button);
            InputOutput_panel.Controls.Add(NumSeven_button);
            InputOutput_panel.Controls.Add(NumTwo_button);
            InputOutput_panel.Controls.Add(NumOne_button);
            InputOutput_panel.Location = new Point(62, 132);
            InputOutput_panel.Name = "InputOutput_panel";
            InputOutput_panel.Size = new Size(949, 412);
            InputOutput_panel.TabIndex = 23;
            // 
            // Equality_button
            // 
            Equality_button.Location = new Point(493, 308);
            Equality_button.Name = "Equality_button";
            Equality_button.Size = new Size(118, 77);
            Equality_button.TabIndex = 22;
            Equality_button.Text = "=";
            Equality_button.UseVisualStyleBackColor = true;
            // 
            // Result_textBox
            // 
            Result_textBox.Location = new Point(548, 12);
            Result_textBox.Name = "Result_textBox";
            Result_textBox.ReadOnly = true;
            Result_textBox.Size = new Size(344, 39);
            Result_textBox.TabIndex = 21;
            // 
            // Result_label
            // 
            Result_label.AutoSize = true;
            Result_label.Location = new Point(25, 19);
            Result_label.Name = "Result_label";
            Result_label.Size = new Size(264, 32);
            Result_label.TabIndex = 20;
            Result_label.Text = "Результат вычислений";
            Result_label.Click += label1_Click_1;
            // 
            // OpenBracket_button
            // 
            OpenBracket_button.Location = new Point(493, 94);
            OpenBracket_button.Name = "OpenBracket_button";
            OpenBracket_button.Size = new Size(118, 77);
            OpenBracket_button.TabIndex = 19;
            OpenBracket_button.Text = "(";
            OpenBracket_button.UseVisualStyleBackColor = true;
            // 
            // Вivision_button
            // 
            Вivision_button.Location = new Point(675, 308);
            Вivision_button.Name = "Вivision_button";
            Вivision_button.Size = new Size(118, 77);
            Вivision_button.TabIndex = 18;
            Вivision_button.Text = "÷";
            Вivision_button.UseVisualStyleBackColor = true;
            // 
            // Subtraction_button
            // 
            Subtraction_button.Location = new Point(821, 308);
            Subtraction_button.Name = "Subtraction_button";
            Subtraction_button.Size = new Size(118, 77);
            Subtraction_button.TabIndex = 17;
            Subtraction_button.Text = "−";
            Subtraction_button.UseVisualStyleBackColor = true;
            // 
            // Addition_button
            // 
            Addition_button.Location = new Point(821, 203);
            Addition_button.Name = "Addition_button";
            Addition_button.Size = new Size(118, 77);
            Addition_button.TabIndex = 16;
            Addition_button.Text = "+";
            Addition_button.UseVisualStyleBackColor = true;
            // 
            // Multiplication_button
            // 
            Multiplication_button.Location = new Point(675, 203);
            Multiplication_button.Name = "Multiplication_button";
            Multiplication_button.Size = new Size(118, 77);
            Multiplication_button.TabIndex = 15;
            Multiplication_button.Text = "×";
            Multiplication_button.UseVisualStyleBackColor = true;
            // 
            // CloseBracket_button
            // 
            CloseBracket_button.Location = new Point(675, 94);
            CloseBracket_button.Name = "CloseBracket_button";
            CloseBracket_button.Size = new Size(118, 77);
            CloseBracket_button.TabIndex = 13;
            CloseBracket_button.Text = ")";
            CloseBracket_button.UseVisualStyleBackColor = true;
            CloseBracket_button.Click += button1_Click_2;
            // 
            // NumZero_button
            // 
            NumZero_button.Location = new Point(493, 203);
            NumZero_button.Name = "NumZero_button";
            NumZero_button.Size = new Size(118, 77);
            NumZero_button.TabIndex = 12;
            NumZero_button.Text = "0";
            NumZero_button.UseVisualStyleBackColor = true;
            // 
            // NumNine_button
            // 
            NumNine_button.Location = new Point(335, 94);
            NumNine_button.Name = "NumNine_button";
            NumNine_button.Size = new Size(118, 77);
            NumNine_button.TabIndex = 11;
            NumNine_button.Text = "9";
            NumNine_button.UseVisualStyleBackColor = true;
            // 
            // NumEight_button
            // 
            NumEight_button.Location = new Point(188, 94);
            NumEight_button.Name = "NumEight_button";
            NumEight_button.Size = new Size(118, 77);
            NumEight_button.TabIndex = 10;
            NumEight_button.Text = "8";
            NumEight_button.UseVisualStyleBackColor = true;
            NumEight_button.Click += button1_Click_1;
            // 
            // NumThree_button
            // 
            NumThree_button.Location = new Point(335, 308);
            NumThree_button.Name = "NumThree_button";
            NumThree_button.Size = new Size(118, 77);
            NumThree_button.TabIndex = 9;
            NumThree_button.Text = "3";
            NumThree_button.UseVisualStyleBackColor = true;
            // 
            // NumFour_button
            // 
            NumFour_button.Location = new Point(25, 203);
            NumFour_button.Name = "NumFour_button";
            NumFour_button.Size = new Size(118, 77);
            NumFour_button.TabIndex = 8;
            NumFour_button.Text = "4";
            NumFour_button.UseVisualStyleBackColor = true;
            // 
            // NumFive_button
            // 
            NumFive_button.Location = new Point(188, 203);
            NumFive_button.Name = "NumFive_button";
            NumFive_button.Size = new Size(118, 77);
            NumFive_button.TabIndex = 7;
            NumFive_button.Text = "5";
            NumFive_button.UseVisualStyleBackColor = true;
            // 
            // NumSix_button
            // 
            NumSix_button.Location = new Point(335, 203);
            NumSix_button.Name = "NumSix_button";
            NumSix_button.Size = new Size(118, 77);
            NumSix_button.TabIndex = 6;
            NumSix_button.Text = "6";
            NumSix_button.UseVisualStyleBackColor = true;
            // 
            // NumSeven_button
            // 
            NumSeven_button.Location = new Point(25, 94);
            NumSeven_button.Name = "NumSeven_button";
            NumSeven_button.Size = new Size(118, 77);
            NumSeven_button.TabIndex = 5;
            NumSeven_button.Text = "7";
            NumSeven_button.UseVisualStyleBackColor = true;
            // 
            // NumTwo_button
            // 
            NumTwo_button.Location = new Point(188, 308);
            NumTwo_button.Name = "NumTwo_button";
            NumTwo_button.Size = new Size(118, 77);
            NumTwo_button.TabIndex = 4;
            NumTwo_button.Text = "2";
            NumTwo_button.UseVisualStyleBackColor = true;
            // 
            // NumOne_button
            // 
            NumOne_button.Location = new Point(25, 308);
            NumOne_button.Name = "NumOne_button";
            NumOne_button.Size = new Size(118, 77);
            NumOne_button.TabIndex = 3;
            NumOne_button.Text = "1";
            NumOne_button.UseVisualStyleBackColor = true;
            // 
            // Input_textBox
            // 
            Input_textBox.Location = new Point(610, 63);
            Input_textBox.Name = "Input_textBox";
            Input_textBox.Size = new Size(344, 39);
            Input_textBox.TabIndex = 2;
            Input_textBox.TextChanged += textBox1_TextChanged;
            // 
            // Input_label
            // 
            Input_label.AutoSize = true;
            Input_label.Location = new Point(75, 70);
            Input_label.Name = "Input_label";
            Input_label.Size = new Size(440, 32);
            Input_label.TabIndex = 1;
            Input_label.Text = " Введите арифметическое выражение";
            Input_label.Click += label2_Click;
            // 
            // ОperationHistory_tabPage
            // 
            ОperationHistory_tabPage.Controls.Add(OperationHistory_textBox);
            ОperationHistory_tabPage.Controls.Add(OperationHistory_label);
            ОperationHistory_tabPage.Location = new Point(8, 46);
            ОperationHistory_tabPage.Name = "ОperationHistory_tabPage";
            ОperationHistory_tabPage.Padding = new Padding(3);
            ОperationHistory_tabPage.Size = new Size(1042, 573);
            ОperationHistory_tabPage.TabIndex = 1;
            ОperationHistory_tabPage.Text = "ОperationHistory";
            ОperationHistory_tabPage.UseVisualStyleBackColor = true;
            ОperationHistory_tabPage.Click += tabPage2_Click;
            // 
            // OperationHistory_textBox
            // 
            OperationHistory_textBox.Location = new Point(57, 99);
            OperationHistory_textBox.Multiline = true;
            OperationHistory_textBox.Name = "OperationHistory_textBox";
            OperationHistory_textBox.ReadOnly = true;
            OperationHistory_textBox.Size = new Size(921, 334);
            OperationHistory_textBox.TabIndex = 1;
            // 
            // OperationHistory_label
            // 
            OperationHistory_label.AutoSize = true;
            OperationHistory_label.Location = new Point(390, 31);
            OperationHistory_label.Name = "OperationHistory_label";
            OperationHistory_label.Size = new Size(223, 32);
            OperationHistory_label.TabIndex = 0;
            OperationHistory_label.Text = "История операций";
            // 
            // Calculator_form
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1050, 651);
            Controls.Add(Calculator_tabControl);
            Name = "Calculator_form";
            Text = "Calculator";
            Calculator_tabControl.ResumeLayout(false);
            Calculator_tabPage.ResumeLayout(false);
            Calculator_tabPage.PerformLayout();
            InputOutput_panel.ResumeLayout(false);
            InputOutput_panel.PerformLayout();
            ОperationHistory_tabPage.ResumeLayout(false);
            ОperationHistory_tabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl Calculator_tabControl;
        private TabPage Calculator_tabPage;
        private TabPage ОperationHistory_tabPage;
        private Label Input_label;
        private TextBox Input_textBox;
        private Button NumOne_button;
        private Button NumThree_button;
        private Button NumFour_button;
        private Button NumFive_button;
        private Button NumSix_button;
        private Button NumSeven_button;
        private Button NumTwo_button;
        private Button NumZero_button;
        private Button NumNine_button;
        private Button NumEight_button;
        private Button OpenBracket_button;
        private Button Вivision_button;
        private Button Subtraction_button;
        private Button Addition_button;
        private Button Multiplication_button;
        private Button CloseBracket_button;
        private Label Result_label;
        private TextBox Result_textBox;
        private Panel InputOutput_panel;
        private Button Equality_button;
        private TextBox OperationHistory_textBox;
        private Label OperationHistory_label;
    }
}
