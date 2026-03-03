namespace Lab1.UI
{
    partial class ConvertionForm : Form
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
            labelTo = new Label();
            labelFrom = new Label();
            comboBoxTo = new ComboBox();
            comboBoxFrom = new ComboBox();
            labelInput = new Label();
            textBoxInput = new TextBox();
            textBoxResult = new TextBox();
            buttonConvert = new Button();
            buttonClear = new Button();
            labelResult = new Label();
            labelTitle = new Label();
            SuspendLayout();
            // 
            // labelTo
            // 
            labelTo.AutoSize = true;
            labelTo.Font = new Font("Sitka Heading", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTo.Location = new Point(92, 183);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(88, 23);
            labelTo.TabIndex = 0;
            labelTo.Text = "В систему:";
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.Font = new Font("Sitka Heading", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelFrom.Location = new Point(92, 126);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(102, 23);
            labelFrom.TabIndex = 2;
            labelFrom.Text = "Из системы:";
            // 
            // comboBoxTo
            // 
            comboBoxTo.FormattingEnabled = true;
            comboBoxTo.Items.AddRange(AvailableBases);
            comboBoxTo.Location = new Point(294, 186);
            comboBoxTo.Margin = new Padding(3, 2, 3, 2);
            comboBoxTo.Name = "comboBoxTo";
            comboBoxTo.Size = new Size(149, 23);
            comboBoxTo.TabIndex = 3;
            //comboBoxTo.SelectedIndexChanged += IntoComboBoxChanged;
            // 
            // comboBoxFrom
            // 
            comboBoxFrom.FormattingEnabled = true;
            comboBoxFrom.Items.AddRange(AvailableBases);
            comboBoxFrom.Location = new Point(294, 129);
            comboBoxFrom.Margin = new Padding(3, 2, 3, 2);
            comboBoxFrom.Name = "comboBoxFrom";
            comboBoxFrom.Size = new Size(149, 23);
            comboBoxFrom.TabIndex = 4;
            //comboBoxFrom.SelectedIndexChanged += FromComboBoxChanged;
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Font = new Font("Sitka Heading", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelInput.Location = new Point(88, 76);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(132, 23);
            labelInput.TabIndex = 5;
            labelInput.Text = "Исходное число:";
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(294, 79);
            textBoxInput.Margin = new Padding(3, 2, 3, 2);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(149, 23);
            textBoxInput.TabIndex = 6;
            //textBoxInput.TextChanged += NumStringTextChanged;
            // 
            // textBoxResult
            // 
            textBoxResult.Location = new Point(193, 324);
            textBoxResult.Margin = new Padding(3, 2, 3, 2);
            textBoxResult.Name = "textBoxResult";
            textBoxResult.Size = new Size(149, 23);
            textBoxResult.TabIndex = 7;
            // 
            // buttonConvert
            // 
            buttonConvert.Font = new Font("Sitka Heading", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonConvert.Location = new Point(88, 234);
            buttonConvert.Margin = new Padding(3, 2, 3, 2);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(149, 34);
            buttonConvert.TabIndex = 8;
            buttonConvert.Text = "Перевести";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += ConvertClick;
            // 
            // buttonClear
            // 
            buttonClear.Font = new Font("Sitka Heading", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonClear.Location = new Point(294, 234);
            buttonClear.Margin = new Padding(3, 2, 3, 2);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(149, 34);
            buttonClear.TabIndex = 9;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += ClearClick;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Sitka Heading", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelResult.Location = new Point(220, 292);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(84, 23);
            labelResult.TabIndex = 10;
            labelResult.Text = "Результат";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Sitka Heading", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTitle.Location = new Point(111, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(295, 28);
            labelTitle.TabIndex = 11;
            labelTitle.Text = "Калькулятор  систем счисления";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(545, 373);
            Controls.Add(labelTitle);
            Controls.Add(labelResult);
            Controls.Add(buttonClear);
            Controls.Add(buttonConvert);
            Controls.Add(textBoxResult);
            Controls.Add(textBoxInput);
            Controls.Add(labelInput);
            Controls.Add(comboBoxFrom);
            Controls.Add(comboBoxTo);
            Controls.Add(labelFrom);
            Controls.Add(labelTo);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTo;
        private Label labelFrom;
        private ComboBox comboBoxTo;
        private ComboBox comboBoxFrom;
        private Label labelInput;
        private TextBox textBoxInput;
        private TextBox textBoxResult;
        private Button buttonConvert;
        private Button buttonClear;
        private Label labelResult;
        private Label labelTitle;
    }
}
