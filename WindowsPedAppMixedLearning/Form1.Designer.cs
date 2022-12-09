﻿namespace WindowsPedAppMixedLearning
{
    partial class Form1
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
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.OpenInformationButton = new System.Windows.Forms.Button();
            this.OpenLiteraturesButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OpenTheoryButton = new System.Windows.Forms.Button();
            this.MainButtonPanel = new System.Windows.Forms.Panel();
            this.OpenMainMenuButton = new System.Windows.Forms.Button();
            this.PrevButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.TheoryPanel = new System.Windows.Forms.Panel();
            this.TheoryButton4 = new System.Windows.Forms.Button();
            this.TheoryButton3 = new System.Windows.Forms.Button();
            this.TheoryButton2 = new System.Windows.Forms.Button();
            this.TheoryButton1 = new System.Windows.Forms.Button();
            this.LiteraturesPanel = new System.Windows.Forms.Panel();
            this.LiteraturesTextBox = new System.Windows.Forms.RichTextBox();
            this.InformationPanel = new System.Windows.Forms.Panel();
            this.InformationTextBox = new System.Windows.Forms.RichTextBox();
            this.TheoryTextPanel = new System.Windows.Forms.Panel();
            this.TheoryTextBox1 = new System.Windows.Forms.RichTextBox();
            this.MainMenuPanel.SuspendLayout();
            this.MainButtonPanel.SuspendLayout();
            this.TheoryPanel.SuspendLayout();
            this.LiteraturesPanel.SuspendLayout();
            this.InformationPanel.SuspendLayout();
            this.TheoryTextPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MainMenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainMenuPanel.Controls.Add(this.OpenInformationButton);
            this.MainMenuPanel.Controls.Add(this.OpenLiteraturesButton);
            this.MainMenuPanel.Controls.Add(this.button2);
            this.MainMenuPanel.Controls.Add(this.OpenTheoryButton);
            this.MainMenuPanel.Location = new System.Drawing.Point(12, 12);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(440, 580);
            this.MainMenuPanel.TabIndex = 0;
            // 
            // OpenInformationButton
            // 
            this.OpenInformationButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenInformationButton.Location = new System.Drawing.Point(140, 492);
            this.OpenInformationButton.Name = "OpenInformationButton";
            this.OpenInformationButton.Size = new System.Drawing.Size(160, 30);
            this.OpenInformationButton.TabIndex = 3;
            this.OpenInformationButton.Text = "О приложении";
            this.OpenInformationButton.UseVisualStyleBackColor = true;
            this.OpenInformationButton.Click += new System.EventHandler(this.OpenInformation);
            // 
            // OpenLiteraturesButton
            // 
            this.OpenLiteraturesButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenLiteraturesButton.Location = new System.Drawing.Point(140, 456);
            this.OpenLiteraturesButton.Name = "OpenLiteraturesButton";
            this.OpenLiteraturesButton.Size = new System.Drawing.Size(160, 30);
            this.OpenLiteraturesButton.TabIndex = 2;
            this.OpenLiteraturesButton.Text = "Доп. литература";
            this.OpenLiteraturesButton.UseVisualStyleBackColor = true;
            this.OpenLiteraturesButton.Click += new System.EventHandler(this.OpenLiteratures);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(140, 420);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // OpenTheoryButton
            // 
            this.OpenTheoryButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenTheoryButton.Location = new System.Drawing.Point(140, 384);
            this.OpenTheoryButton.Name = "OpenTheoryButton";
            this.OpenTheoryButton.Size = new System.Drawing.Size(160, 30);
            this.OpenTheoryButton.TabIndex = 0;
            this.OpenTheoryButton.Text = "Теория";
            this.OpenTheoryButton.UseVisualStyleBackColor = true;
            this.OpenTheoryButton.Click += new System.EventHandler(this.OpenTheory);
            // 
            // MainButtonPanel
            // 
            this.MainButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainButtonPanel.Controls.Add(this.OpenMainMenuButton);
            this.MainButtonPanel.Controls.Add(this.PrevButton);
            this.MainButtonPanel.Controls.Add(this.BackButton);
            this.MainButtonPanel.Location = new System.Drawing.Point(12, 598);
            this.MainButtonPanel.Name = "MainButtonPanel";
            this.MainButtonPanel.Size = new System.Drawing.Size(440, 56);
            this.MainButtonPanel.TabIndex = 1;
            // 
            // OpenMainMenuButton
            // 
            this.OpenMainMenuButton.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OpenMainMenuButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.OpenMainMenuButton.Location = new System.Drawing.Point(129, 3);
            this.OpenMainMenuButton.Name = "OpenMainMenuButton";
            this.OpenMainMenuButton.Size = new System.Drawing.Size(180, 47);
            this.OpenMainMenuButton.TabIndex = 2;
            this.OpenMainMenuButton.Text = "⌂";
            this.OpenMainMenuButton.UseVisualStyleBackColor = true;
            this.OpenMainMenuButton.Click += new System.EventHandler(this.OpenMainMenu);
            // 
            // PrevButton
            // 
            this.PrevButton.Enabled = false;
            this.PrevButton.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PrevButton.Location = new System.Drawing.Point(315, 3);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(120, 47);
            this.PrevButton.TabIndex = 1;
            this.PrevButton.Text = "→";
            this.PrevButton.UseVisualStyleBackColor = true;
            this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BackButton.Location = new System.Drawing.Point(3, 3);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(120, 47);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "←";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // TheoryPanel
            // 
            this.TheoryPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TheoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TheoryPanel.Controls.Add(this.TheoryButton4);
            this.TheoryPanel.Controls.Add(this.TheoryButton3);
            this.TheoryPanel.Controls.Add(this.TheoryButton2);
            this.TheoryPanel.Controls.Add(this.TheoryButton1);
            this.TheoryPanel.Location = new System.Drawing.Point(474, 12);
            this.TheoryPanel.Name = "TheoryPanel";
            this.TheoryPanel.Size = new System.Drawing.Size(440, 580);
            this.TheoryPanel.TabIndex = 1;
            // 
            // TheoryButton4
            // 
            this.TheoryButton4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TheoryButton4.Location = new System.Drawing.Point(54, 356);
            this.TheoryButton4.Name = "TheoryButton4";
            this.TheoryButton4.Size = new System.Drawing.Size(160, 46);
            this.TheoryButton4.TabIndex = 7;
            this.TheoryButton4.Text = "Теория\r\nТеория";
            this.TheoryButton4.UseVisualStyleBackColor = true;
            this.TheoryButton4.Click += new System.EventHandler(this.TheoryButton4_Click);
            // 
            // TheoryButton3
            // 
            this.TheoryButton3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TheoryButton3.Location = new System.Drawing.Point(54, 256);
            this.TheoryButton3.Name = "TheoryButton3";
            this.TheoryButton3.Size = new System.Drawing.Size(160, 46);
            this.TheoryButton3.TabIndex = 6;
            this.TheoryButton3.Text = "Теория\r\nТеория";
            this.TheoryButton3.UseVisualStyleBackColor = true;
            this.TheoryButton3.Click += new System.EventHandler(this.TheoryButton3_Click);
            // 
            // TheoryButton2
            // 
            this.TheoryButton2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TheoryButton2.Location = new System.Drawing.Point(54, 156);
            this.TheoryButton2.Name = "TheoryButton2";
            this.TheoryButton2.Size = new System.Drawing.Size(160, 46);
            this.TheoryButton2.TabIndex = 5;
            this.TheoryButton2.Text = "Теория\r\nТеория";
            this.TheoryButton2.UseVisualStyleBackColor = true;
            this.TheoryButton2.Click += new System.EventHandler(this.TheoryButton2_Click);
            // 
            // TheoryButton1
            // 
            this.TheoryButton1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TheoryButton1.Location = new System.Drawing.Point(54, 56);
            this.TheoryButton1.Name = "TheoryButton1";
            this.TheoryButton1.Size = new System.Drawing.Size(160, 46);
            this.TheoryButton1.TabIndex = 4;
            this.TheoryButton1.Text = "Теория\r\nТеория";
            this.TheoryButton1.UseVisualStyleBackColor = true;
            this.TheoryButton1.Click += new System.EventHandler(this.TheoryButton1_Click);
            // 
            // LiteraturesPanel
            // 
            this.LiteraturesPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LiteraturesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LiteraturesPanel.Controls.Add(this.LiteraturesTextBox);
            this.LiteraturesPanel.Location = new System.Drawing.Point(474, 12);
            this.LiteraturesPanel.Name = "LiteraturesPanel";
            this.LiteraturesPanel.Size = new System.Drawing.Size(440, 580);
            this.LiteraturesPanel.TabIndex = 2;
            // 
            // LiteraturesTextBox
            // 
            this.LiteraturesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LiteraturesTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LiteraturesTextBox.Location = new System.Drawing.Point(20, 20);
            this.LiteraturesTextBox.Name = "LiteraturesTextBox";
            this.LiteraturesTextBox.Size = new System.Drawing.Size(400, 540);
            this.LiteraturesTextBox.TabIndex = 1;
            this.LiteraturesTextBox.Text = "";
            // 
            // InformationPanel
            // 
            this.InformationPanel.BackColor = System.Drawing.SystemColors.Control;
            this.InformationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InformationPanel.Controls.Add(this.InformationTextBox);
            this.InformationPanel.Location = new System.Drawing.Point(474, 12);
            this.InformationPanel.Name = "InformationPanel";
            this.InformationPanel.Size = new System.Drawing.Size(440, 580);
            this.InformationPanel.TabIndex = 3;
            // 
            // InformationTextBox
            // 
            this.InformationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InformationTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InformationTextBox.Location = new System.Drawing.Point(20, 20);
            this.InformationTextBox.Name = "InformationTextBox";
            this.InformationTextBox.Size = new System.Drawing.Size(400, 540);
            this.InformationTextBox.TabIndex = 1;
            this.InformationTextBox.Text = "";
            // 
            // TheoryTextPanel
            // 
            this.TheoryTextPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TheoryTextPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TheoryTextPanel.Controls.Add(this.TheoryTextBox1);
            this.TheoryTextPanel.Location = new System.Drawing.Point(937, 12);
            this.TheoryTextPanel.Name = "TheoryTextPanel";
            this.TheoryTextPanel.Size = new System.Drawing.Size(440, 580);
            this.TheoryTextPanel.TabIndex = 3;
            // 
            // TheoryTextBox1
            // 
            this.TheoryTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TheoryTextBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TheoryTextBox1.Location = new System.Drawing.Point(20, 20);
            this.TheoryTextBox1.Name = "TheoryTextBox1";
            this.TheoryTextBox1.Size = new System.Drawing.Size(400, 540);
            this.TheoryTextBox1.TabIndex = 1;
            this.TheoryTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1389, 661);
            this.Controls.Add(this.TheoryPanel);
            this.Controls.Add(this.TheoryTextPanel);
            this.Controls.Add(this.MainMenuPanel);
            this.Controls.Add(this.InformationPanel);
            this.Controls.Add(this.LiteraturesPanel);
            this.Controls.Add(this.MainButtonPanel);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MainMenuPanel.ResumeLayout(false);
            this.MainButtonPanel.ResumeLayout(false);
            this.TheoryPanel.ResumeLayout(false);
            this.LiteraturesPanel.ResumeLayout(false);
            this.InformationPanel.ResumeLayout(false);
            this.TheoryTextPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel MainMenuPanel;
        private Panel MainButtonPanel;
        private Panel TheoryPanel;
        private Panel LiteraturesPanel;
        private Button OpenTheoryButton;
        private Button OpenInformationButton;
        private Button OpenLiteraturesButton;
        private Button button2;
        private Button BackButton;
        private Button OpenMainMenuButton;
        private Button PrevButton;
        private RichTextBox LiteraturesTextBox;
        private Panel InformationPanel;
        private RichTextBox InformationTextBox;
        private Button TheoryButton4;
        private Button TheoryButton3;
        private Button TheoryButton2;
        private Button TheoryButton1;
        private Panel TheoryTextPanel;
        private RichTextBox TheoryTextBox1;
    }
}