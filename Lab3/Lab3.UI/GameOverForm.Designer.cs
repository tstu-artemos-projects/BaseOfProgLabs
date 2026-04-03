using System.ComponentModel;

namespace Lab3.UI;

partial class GameOverForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        pictureBox1 = new System.Windows.Forms.PictureBox();
        closeButton = new System.Windows.Forms.Button();
        titling = new System.Windows.Forms.Label();
        panel1 = new System.Windows.Forms.Panel();
        statsText = new System.Windows.Forms.Label();
        labelReason = new System.Windows.Forms.Label();
        labelStats = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.BackgroundImage = global::Lab3.UI.Properties.Resources.WinPig;
        pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
        pictureBox1.Location = new System.Drawing.Point(0, 0);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(331, 324);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // closeButton
        // 
        closeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
        closeButton.Location = new System.Drawing.Point(331, 287);
        closeButton.Margin = new System.Windows.Forms.Padding(5);
        closeButton.Name = "closeButton";
        closeButton.Size = new System.Drawing.Size(469, 37);
        closeButton.TabIndex = 2;
        closeButton.Text = "Хм, ну хорошо";
        closeButton.UseVisualStyleBackColor = true;
        closeButton.Click += closeButton_Click;
        // 
        // titling
        // 
        titling.Dock = System.Windows.Forms.DockStyle.Top;
        titling.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        titling.Location = new System.Drawing.Point(331, 0);
        titling.Name = "titling";
        titling.Size = new System.Drawing.Size(469, 24);
        titling.TabIndex = 1;
        titling.Text = "Вы победили!";
        titling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // panel1
        // 
        panel1.Controls.Add(statsText);
        panel1.Controls.Add(labelReason);
        panel1.Controls.Add(labelStats);
        panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        panel1.Location = new System.Drawing.Point(331, 24);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(469, 263);
        panel1.TabIndex = 3;
        // 
        // statsText
        // 
        statsText.Dock = System.Windows.Forms.DockStyle.Fill;
        statsText.Location = new System.Drawing.Point(0, 27);
        statsText.Name = "statsText";
        statsText.Size = new System.Drawing.Size(469, 209);
        statsText.TabIndex = 1;
        statsText.Text = "Тут должна быть статистика";
        // 
        // labelReason
        // 
        labelReason.Dock = System.Windows.Forms.DockStyle.Bottom;
        labelReason.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
        labelReason.Location = new System.Drawing.Point(0, 236);
        labelReason.Name = "labelReason";
        labelReason.Size = new System.Drawing.Size(469, 27);
        labelReason.TabIndex = 2;
        labelReason.Text = "Причина: ВЫ КРУТЫШ";
        labelReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelStats
        // 
        labelStats.Dock = System.Windows.Forms.DockStyle.Top;
        labelStats.Location = new System.Drawing.Point(0, 0);
        labelStats.Name = "labelStats";
        labelStats.Size = new System.Drawing.Size(469, 27);
        labelStats.TabIndex = 0;
        labelStats.Text = "Статистика";
        labelStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // GameOverForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        ClientSize = new System.Drawing.Size(800, 324);
        Controls.Add(panel1);
        Controls.Add(closeButton);
        Controls.Add(titling);
        Controls.Add(pictureBox1);
        Text = "Победа!!!";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label labelReason;

    private System.Windows.Forms.Label statsText;

    private System.Windows.Forms.Label labelStats;

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.Button closeButton;

    private System.Windows.Forms.Label titling;

    private System.Windows.Forms.PictureBox pictureBox1;

    #endregion
}