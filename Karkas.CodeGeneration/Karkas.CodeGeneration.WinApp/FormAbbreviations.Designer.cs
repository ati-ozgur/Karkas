﻿namespace Karkas.CodeGeneration.WinApp
{
    partial class FormAbbreviations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.listBoxAbbrevations = new System.Windows.Forms.ListBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAbbreviations = new System.Windows.Forms.TextBox();
            this.textBoxReplacementText = new System.Windows.Forms.TextBox();
            this.buttonSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxKisaltmalar
            // 
            this.listBoxAbbrevations.FormattingEnabled = true;
            this.listBoxAbbrevations.Location = new System.Drawing.Point(12, 123);
            this.listBoxAbbrevations.Name = "listBoxAbbrevations";
            this.listBoxAbbrevations.Size = new System.Drawing.Size(243, 212);
            this.listBoxAbbrevations.TabIndex = 0;
            // 
            // buttonEkle
            // 
            this.buttonInsert.Location = new System.Drawing.Point(408, 11);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(75, 23);
            this.buttonInsert.TabIndex = 1;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kısaltma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Yerine Geçen Yazı";
            // 
            // textBoxKisaltma
            // 
            this.textBoxAbbreviations.Location = new System.Drawing.Point(165, 21);
            this.textBoxAbbreviations.Name = "textBoxKisaltma";
            this.textBoxAbbreviations.Size = new System.Drawing.Size(100, 20);
            this.textBoxAbbreviations.TabIndex = 4;
            // 
            // textBoxYerineGecenYazi
            // 
            this.textBoxReplacementText.Location = new System.Drawing.Point(165, 49);
            this.textBoxReplacementText.Name = "textBoxYerineGecenYazi";
            this.textBoxReplacementText.Size = new System.Drawing.Size(100, 20);
            this.textBoxReplacementText.TabIndex = 5;
            // 
            // buttonSil
            // 
            this.buttonSil.Location = new System.Drawing.Point(408, 68);
            this.buttonSil.Name = "buttonSil";
            this.buttonSil.Size = new System.Drawing.Size(75, 23);
            this.buttonSil.TabIndex = 6;
            this.buttonSil.Text = "Delete";
            this.buttonSil.UseVisualStyleBackColor = true;
            // 
            // FormAbbravetions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 386);
            this.Controls.Add(this.buttonSil);
            this.Controls.Add(this.textBoxReplacementText);
            this.Controls.Add(this.textBoxAbbreviations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.listBoxAbbrevations);
            this.Name = "FormAbbravetions";
            this.Text = "FormKisaltmalar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAbbrevations;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAbbreviations;
        private System.Windows.Forms.TextBox textBoxReplacementText;
        private System.Windows.Forms.Button buttonSil;
    }
}