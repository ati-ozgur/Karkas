namespace Karkas.CodeGeneration.WinApp
{
    partial class FormDatabaseProviders
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
            this.labelDatabaseProviders = new System.Windows.Forms.Label();
            this.textBoxDatabaseProviders = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelDatabaseProviders
            // 
            this.labelDatabaseProviders.AutoSize = true;
            this.labelDatabaseProviders.Location = new System.Drawing.Point(26, 33);
            this.labelDatabaseProviders.Name = "labelDatabaseProviders";
            this.labelDatabaseProviders.Size = new System.Drawing.Size(100, 13);
            this.labelDatabaseProviders.TabIndex = 24;
            this.labelDatabaseProviders.Text = "Database Providers";
            // 
            // textBoxDatabaseProviders
            // 
            this.textBoxDatabaseProviders.Location = new System.Drawing.Point(26, 57);
            this.textBoxDatabaseProviders.Multiline = true;
            this.textBoxDatabaseProviders.Name = "textBoxDatabaseProviders";
            this.textBoxDatabaseProviders.Size = new System.Drawing.Size(176, 184);
            this.textBoxDatabaseProviders.TabIndex = 23;
            this.textBoxDatabaseProviders.Text = "System.Data.SqlClient\r\nSystem.Data.OracleClient\r\nOracle.DataAccess.Client\r\nSystem" +
    ".Data.SQLite\r\n";
            // 
            // FormDatabaseProviders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 339);
            this.Controls.Add(this.labelDatabaseProviders);
            this.Controls.Add(this.textBoxDatabaseProviders);
            this.Name = "FormDatabaseProviders";
            this.Text = "Form Database Providers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDatabaseProviders;
        private System.Windows.Forms.TextBox textBoxDatabaseProviders;

    }
}