namespace Karkas.CodeGeneration.WinApp
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
            this.listBoxKisaltmalar = new System.Windows.Forms.ListBox();
            this.buttonEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKisaltma = new System.Windows.Forms.TextBox();
            this.textBoxYerineGecenYazi = new System.Windows.Forms.TextBox();
            this.buttonSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxKisaltmalar
            // 
            this.listBoxKisaltmalar.FormattingEnabled = true;
            this.listBoxKisaltmalar.Location = new System.Drawing.Point(12, 123);
            this.listBoxKisaltmalar.Name = "listBoxKisaltmalar";
            this.listBoxKisaltmalar.Size = new System.Drawing.Size(243, 212);
            this.listBoxKisaltmalar.TabIndex = 0;
            // 
            // buttonEkle
            // 
            this.buttonEkle.Location = new System.Drawing.Point(408, 11);
            this.buttonEkle.Name = "buttonEkle";
            this.buttonEkle.Size = new System.Drawing.Size(75, 23);
            this.buttonEkle.TabIndex = 1;
            this.buttonEkle.Text = "Ekle";
            this.buttonEkle.UseVisualStyleBackColor = true;
            this.buttonEkle.Click += new System.EventHandler(this.buttonEkle_Click);
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
            this.textBoxKisaltma.Location = new System.Drawing.Point(165, 21);
            this.textBoxKisaltma.Name = "textBoxKisaltma";
            this.textBoxKisaltma.Size = new System.Drawing.Size(100, 20);
            this.textBoxKisaltma.TabIndex = 4;
            // 
            // textBoxYerineGecenYazi
            // 
            this.textBoxYerineGecenYazi.Location = new System.Drawing.Point(165, 49);
            this.textBoxYerineGecenYazi.Name = "textBoxYerineGecenYazi";
            this.textBoxYerineGecenYazi.Size = new System.Drawing.Size(100, 20);
            this.textBoxYerineGecenYazi.TabIndex = 5;
            // 
            // buttonSil
            // 
            this.buttonSil.Location = new System.Drawing.Point(408, 68);
            this.buttonSil.Name = "buttonSil";
            this.buttonSil.Size = new System.Drawing.Size(75, 23);
            this.buttonSil.TabIndex = 6;
            this.buttonSil.Text = "Sil";
            this.buttonSil.UseVisualStyleBackColor = true;
            // 
            // FormAbbravetions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 386);
            this.Controls.Add(this.buttonSil);
            this.Controls.Add(this.textBoxYerineGecenYazi);
            this.Controls.Add(this.textBoxKisaltma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEkle);
            this.Controls.Add(this.listBoxKisaltmalar);
            this.Name = "FormAbbravetions";
            this.Text = "FormKisaltmalar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxKisaltmalar;
        private System.Windows.Forms.Button buttonEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKisaltma;
        private System.Windows.Forms.TextBox textBoxYerineGecenYazi;
        private System.Windows.Forms.Button buttonSil;
    }
}