namespace Karkas.CodeGeneration.WinApp.UserControls
{
    partial class UserControlTableRelated
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSeciliTablolariUret = new System.Windows.Forms.Button();
            this.buttonTumTablolariUret = new System.Windows.Forms.Button();
            this.listBoxTableListesi = new System.Windows.Forms.ListBox();
            this.labelTabloListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.buttonSeciliSemaTablolariUret = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSeciliTablolariUret
            // 
            this.buttonSeciliTablolariUret.Location = new System.Drawing.Point(385, 174);
            this.buttonSeciliTablolariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeciliTablolariUret.Name = "buttonSeciliTablolariUret";
            this.buttonSeciliTablolariUret.Size = new System.Drawing.Size(121, 39);
            this.buttonSeciliTablolariUret.TabIndex = 11;
            this.buttonSeciliTablolariUret.Text = "Seçili Tablolari Üret";
            this.buttonSeciliTablolariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliTablolariUret.Click += new System.EventHandler(this.buttonSeciliTablolariUret_Click);
            // 
            // buttonTumTablolariUret
            // 
            this.buttonTumTablolariUret.Location = new System.Drawing.Point(385, 55);
            this.buttonTumTablolariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTumTablolariUret.Name = "buttonTumTablolariUret";
            this.buttonTumTablolariUret.Size = new System.Drawing.Size(121, 39);
            this.buttonTumTablolariUret.TabIndex = 10;
            this.buttonTumTablolariUret.Text = "Tüm Tabloları Üret";
            this.buttonTumTablolariUret.UseVisualStyleBackColor = true;
            this.buttonTumTablolariUret.Click += new System.EventHandler(this.buttonTumTablolariUret_Click);
            // 
            // listBoxTableListesi
            // 
            this.listBoxTableListesi.DisplayMember = "FULL_TABLE_NAME";
            this.listBoxTableListesi.FormattingEnabled = true;
            this.listBoxTableListesi.Location = new System.Drawing.Point(153, 71);
            this.listBoxTableListesi.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxTableListesi.Name = "listBoxTableListesi";
            this.listBoxTableListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTableListesi.Size = new System.Drawing.Size(204, 160);
            this.listBoxTableListesi.TabIndex = 9;
            // 
            // labelTabloListesi
            // 
            this.labelTabloListesi.AutoSize = true;
            this.labelTabloListesi.Location = new System.Drawing.Point(23, 69);
            this.labelTabloListesi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTabloListesi.Name = "labelTabloListesi";
            this.labelTabloListesi.Size = new System.Drawing.Size(66, 13);
            this.labelTabloListesi.TabIndex = 8;
            this.labelTabloListesi.Text = "Tablo Listesi";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(23, 29);
            this.labelSchemaList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(78, 13);
            this.labelSchemaList.TabIndex = 7;
            this.labelSchemaList.Text = "Schema Listesi";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "SCHEMA_NAME";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(156, 31);
            this.comboBoxSchemaList.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(182, 21);
            this.comboBoxSchemaList.TabIndex = 6;
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
            // 
            // buttonSeciliSemaTablolariUret
            // 
            this.buttonSeciliSemaTablolariUret.Location = new System.Drawing.Point(385, 116);
            this.buttonSeciliSemaTablolariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeciliSemaTablolariUret.Name = "buttonSeciliSemaTablolariUret";
            this.buttonSeciliSemaTablolariUret.Size = new System.Drawing.Size(121, 39);
            this.buttonSeciliSemaTablolariUret.TabIndex = 12;
            this.buttonSeciliSemaTablolariUret.Text = "Semadaki Tablolari Üret";
            this.buttonSeciliSemaTablolariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliSemaTablolariUret.Click += new System.EventHandler(this.buttonSeciliSemaTablolariUret_Click);
            // 
            // UserControlTableRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSeciliSemaTablolariUret);
            this.Controls.Add(this.buttonSeciliTablolariUret);
            this.Controls.Add(this.buttonTumTablolariUret);
            this.Controls.Add(this.listBoxTableListesi);
            this.Controls.Add(this.labelTabloListesi);
            this.Controls.Add(this.labelSchemaList);
            this.Controls.Add(this.comboBoxSchemaList);
            this.Name = "UserControlTableRelated";
            this.Size = new System.Drawing.Size(524, 245);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSeciliTablolariUret;
        private System.Windows.Forms.Button buttonTumTablolariUret;
        private System.Windows.Forms.ListBox listBoxTableListesi;
        private System.Windows.Forms.Label labelTabloListesi;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private System.Windows.Forms.Button buttonSeciliSemaTablolariUret;

    }
}
