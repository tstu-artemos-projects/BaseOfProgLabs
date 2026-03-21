using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab3.UI
{
    partial class ConfirmationForm
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
            btnNo = new Button();
            btnYes = new Button();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // btnNo
            // 
            btnNo.Location = new Point(434, 226);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(95, 29);
            btnNo.TabIndex = 0;
            btnNo.Text = "Нет";
            btnNo.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            btnYes.Location = new Point(258, 226);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(95, 29);
            btnYes.TabIndex = 1;
            btnYes.Text = "Да";
            btnYes.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(371, 124);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(50, 20);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMessage);
            Controls.Add(btnYes);
            Controls.Add(btnNo);
            Name = "ConfirmationFrom";
            Text = "ConfirmationFrom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNo;
        private Button btnYes;
        private Label lblMessage;
    }
}
