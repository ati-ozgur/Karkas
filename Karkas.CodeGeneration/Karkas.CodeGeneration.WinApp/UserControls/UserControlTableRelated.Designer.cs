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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSeciliTablolariUret
            // 
            this.buttonSeciliTablolariUret.AutoSize = true;
            this.buttonSeciliTablolariUret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSeciliTablolariUret.Location = new System.Drawing.Point(560, 97);
            this.buttonSeciliTablolariUret.Name = "buttonSeciliTablolariUret";
            this.buttonSeciliTablolariUret.Size = new System.Drawing.Size(136, 277);
            this.buttonSeciliTablolariUret.TabIndex = 11;
            this.buttonSeciliTablolariUret.Text = "Create Selected Tables";
            this.buttonSeciliTablolariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliTablolariUret.Click += new System.EventHandler(this.buttonGenerateSelectedTables_Click);
            // 
            // buttonTumTablolariUret
            // 
            this.buttonTumTablolariUret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTumTablolariUret.Location = new System.Drawing.Point(3, 3);
            this.buttonTumTablolariUret.Name = "buttonTumTablolariUret";
            this.buttonTumTablolariUret.Size = new System.Drawing.Size(133, 88);
            this.buttonTumTablolariUret.TabIndex = 10;
            this.buttonTumTablolariUret.Text = "Create All Tables";
            this.buttonTumTablolariUret.UseVisualStyleBackColor = true;
            this.buttonTumTablolariUret.Click += new System.EventHandler(this.buttonProduceAllTables_Click);
            // 
            // listBoxTableListesi
            // 
            this.listBoxTableListesi.DisplayMember = "FULL_TABLE_NAME";
            this.listBoxTableListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTableListesi.FormattingEnabled = true;
            this.listBoxTableListesi.ItemHeight = 20;
            this.listBoxTableListesi.Location = new System.Drawing.Point(281, 97);
            this.listBoxTableListesi.Name = "listBoxTableListesi";
            this.listBoxTableListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTableListesi.Size = new System.Drawing.Size(273, 277);
            this.listBoxTableListesi.TabIndex = 9;
            // 
            // labelTabloListesi
            // 
            this.labelTabloListesi.AutoSize = true;
            this.labelTabloListesi.Location = new System.Drawing.Point(142, 94);
            this.labelTabloListesi.Name = "labelTabloListesi";
            this.labelTabloListesi.Size = new System.Drawing.Size(70, 20);
            this.labelTabloListesi.TabIndex = 8;
            this.labelTabloListesi.Text = "Table List";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(142, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(87, 20);
            this.labelSchemaList.TabIndex = 7;
            this.labelSchemaList.Text = "Schema List";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "SCHEMA_NAME";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(281, 3);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(241, 28);
            this.comboBoxSchemaList.TabIndex = 6;
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
            // 
            // buttonSeciliSemaTablolariUret
            // 
            this.buttonSeciliSemaTablolariUret.AutoSize = true;
            this.buttonSeciliSemaTablolariUret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSeciliSemaTablolariUret.Location = new System.Drawing.Point(560, 3);
            this.buttonSeciliSemaTablolariUret.Name = "buttonSeciliSemaTablolariUret";
            this.buttonSeciliSemaTablolariUret.Size = new System.Drawing.Size(136, 88);
            this.buttonSeciliSemaTablolariUret.TabIndex = 12;
            this.buttonSeciliSemaTablolariUret.Text = "Create Tables in Schema";
            this.buttonSeciliSemaTablolariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliSemaTablolariUret.Click += new System.EventHandler(this.buttonSeciliSemaTablolariUret_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonTumTablolariUret, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSchemaList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSchemaList, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxTableListesi, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTabloListesi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeciliSemaTablolariUret, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeciliTablolariUret, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 377);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // UserControlTableRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControlTableRelated";
            this.Size = new System.Drawing.Size(699, 377);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSeciliTablolariUret;
        private System.Windows.Forms.Button buttonTumTablolariUret;
        private System.Windows.Forms.ListBox listBoxTableListesi;
        private System.Windows.Forms.Label labelTabloListesi;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private System.Windows.Forms.Button buttonSeciliSemaTablolariUret;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
