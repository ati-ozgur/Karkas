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
            this.labelDatabaseProviders.Location = new System.Drawing.Point(30, 38);
            this.labelDatabaseProviders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDatabaseProviders.Name = "labelDatabaseProviders";
            this.labelDatabaseProviders.Size = new System.Drawing.Size(107, 15);
            this.labelDatabaseProviders.TabIndex = 24;
            this.labelDatabaseProviders.Text = "Database Providers";
            // 
            // textBoxDatabaseProviders
            // 
            this.textBoxDatabaseProviders.Location = new System.Drawing.Point(30, 66);
            this.textBoxDatabaseProviders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxDatabaseProviders.Multiline = true;
            this.textBoxDatabaseProviders.Name = "textBoxDatabaseProviders";
            this.textBoxDatabaseProviders.Size = new System.Drawing.Size(205, 212);
            this.textBoxDatabaseProviders.TabIndex = 23;
            this.textBoxDatabaseProviders.Text = @"

---SQL Server---
System.Data.SqlClient
Integrated Security = SSPI; Persist Security Info=False;Initial Catalog=KARKAS_EXAMPLE;Data Source=localhost
--------------------------
---Oracle---
System.Data.OracleClient
Oracle.DataAccess.Client
Oracle.ManagedDataAccess.Client
Data Source=KARKAS_EXAMPLE;User Id=APPUSER;Password=appuser;
---Sqlite---
System.Data.SQLite
            
            
            ";
            // 
            // FormDatabaseProviders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 391);
            this.Controls.Add(this.labelDatabaseProviders);
            this.Controls.Add(this.textBoxDatabaseProviders);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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