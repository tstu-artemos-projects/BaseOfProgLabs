namespace Lab3.UI
{
    partial class TitleForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleForm));
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnEasy = new System.Windows.Forms.Button();
            btnNormal = new System.Windows.Forms.Button();
            btnHard = new System.Windows.Forms.Button();
            btnAboutGame = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 20F);
            label1.Location = new System.Drawing.Point(92, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(119, 37);
            label1.TabIndex = 0;
            label1.Text = "SellBook";
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(0, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(88, 17);
            label2.TabIndex = 7;
            // 
            // btnEasy
            // 
            btnEasy.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnEasy.Location = new System.Drawing.Point(103, 133);
            btnEasy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnEasy.Name = "btnEasy";
            btnEasy.Size = new System.Drawing.Size(108, 32);
            btnEasy.TabIndex = 2;
            btnEasy.Text = "Легкий";
            btnEasy.UseVisualStyleBackColor = true;
            btnEasy.Click += BtnEasy_Click;
            // 
            // btnNormal
            // 
            btnNormal.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnNormal.Location = new System.Drawing.Point(103, 169);
            btnNormal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new System.Drawing.Size(108, 32);
            btnNormal.TabIndex = 3;
            btnNormal.Text = "Нормальный";
            btnNormal.UseVisualStyleBackColor = true;
            btnNormal.Click += BtnNormal_Click;
            // 
            // btnHard
            // 
            btnHard.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnHard.Location = new System.Drawing.Point(103, 205);
            btnHard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnHard.Name = "btnHard";
            btnHard.Size = new System.Drawing.Size(108, 32);
            btnHard.TabIndex = 4;
            btnHard.Text = "Сложный";
            btnHard.UseVisualStyleBackColor = true;
            btnHard.Click += BtnHard_Click;
            // 
            // btnAboutGame
            // 
            btnAboutGame.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnAboutGame.Location = new System.Drawing.Point(103, 261);
            btnAboutGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnAboutGame.Name = "btnAboutGame";
            btnAboutGame.Size = new System.Drawing.Size(108, 32);
            btnAboutGame.TabIndex = 5;
            btnAboutGame.Text = "Об игре";
            btnAboutGame.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            label3.Location = new System.Drawing.Point(206, 310);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(482, 19);
            label3.TabIndex = 6;
            label3.Text = "(C) 2026 Ulitka Software Inc. Все права не защищены, но красть не хорошо";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            label4.Location = new System.Drawing.Point(58, 100);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(198, 19);
            label4.TabIndex = 8;
            label4.Text = "Выберите уровень сложности";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("pictureBox1.Image"));
            pictureBox1.Location = new System.Drawing.Point(306, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(360, 252);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // TitleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            ClientSize = new System.Drawing.Size(700, 338);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnAboutGame);
            Controls.Add(btnHard);
            Controls.Add(btnNormal);
            Controls.Add(btnEasy);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Text = "TitleForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnAboutGame_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Label label2;
        private Button btnEasy;
        private Button btnNormal;
        private Button btnHard;
        private System.Windows.Forms.Button btnAboutGame;
        private System.Windows.Forms.Label label3;
        private Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}