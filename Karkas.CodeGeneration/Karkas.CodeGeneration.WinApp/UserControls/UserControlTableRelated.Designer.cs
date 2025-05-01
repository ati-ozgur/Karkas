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
			buttonSeciliTablolariUret = new Button();
			buttonTumTablolariUret = new Button();
			listBoxTables = new ListBox();
			labelTabloListesi = new Label();
			labelSchemaList = new Label();
			comboBoxSchemaList = new ComboBox();
			buttonSeciliSemaTablolariUret = new Button();
			tableLayoutPanel1 = new TableLayoutPanel();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// buttonSeciliTablolariUret
			// 
			buttonSeciliTablolariUret.AutoSize = true;
			buttonSeciliTablolariUret.Dock = DockStyle.Fill;
			buttonSeciliTablolariUret.Location = new Point(491, 72);
			buttonSeciliTablolariUret.Margin = new Padding(3, 2, 3, 2);
			buttonSeciliTablolariUret.Name = "buttonSeciliTablolariUret";
			buttonSeciliTablolariUret.Size = new Size(118, 209);
			buttonSeciliTablolariUret.TabIndex = 11;
			buttonSeciliTablolariUret.Text = "Create Selected Tables";
			buttonSeciliTablolariUret.UseVisualStyleBackColor = true;
			buttonSeciliTablolariUret.Click += buttonGenerateSelectedTables_Click;
			// 
			// buttonTumTablolariUret
			// 
			buttonTumTablolariUret.Dock = DockStyle.Fill;
			buttonTumTablolariUret.Location = new Point(3, 2);
			buttonTumTablolariUret.Margin = new Padding(3, 2, 3, 2);
			buttonTumTablolariUret.Name = "buttonTumTablolariUret";
			buttonTumTablolariUret.Size = new Size(116, 66);
			buttonTumTablolariUret.TabIndex = 10;
			buttonTumTablolariUret.Text = "Create All Tables";
			buttonTumTablolariUret.UseVisualStyleBackColor = true;
			buttonTumTablolariUret.Click += buttonGenerateAllTables_Click;
			// 
			// listBoxTables
			// 
			listBoxTables.Dock = DockStyle.Fill;
			listBoxTables.FormattingEnabled = true;
			listBoxTables.ItemHeight = 15;
			listBoxTables.Location = new Point(247, 72);
			listBoxTables.Margin = new Padding(3, 2, 3, 2);
			listBoxTables.Name = "listBoxTables";
			listBoxTables.SelectionMode = SelectionMode.MultiExtended;
			listBoxTables.Size = new Size(238, 209);
			listBoxTables.TabIndex = 9;
			// 
			// labelTabloListesi
			// 
			labelTabloListesi.AutoSize = true;
			labelTabloListesi.Location = new Point(125, 70);
			labelTabloListesi.Name = "labelTabloListesi";
			labelTabloListesi.Size = new Size(55, 15);
			labelTabloListesi.TabIndex = 8;
			labelTabloListesi.Text = "Table List";
			// 
			// labelSchemaList
			// 
			labelSchemaList.AutoSize = true;
			labelSchemaList.Location = new Point(125, 0);
			labelSchemaList.Name = "labelSchemaList";
			labelSchemaList.Size = new Size(70, 15);
			labelSchemaList.TabIndex = 7;
			labelSchemaList.Text = "Schema List";
			// 
			// comboBoxSchemaList
			// 
			comboBoxSchemaList.DisplayMember = "SCHEMA_NAME";
			comboBoxSchemaList.FormattingEnabled = true;
			comboBoxSchemaList.Location = new Point(247, 2);
			comboBoxSchemaList.Margin = new Padding(3, 2, 3, 2);
			comboBoxSchemaList.Name = "comboBoxSchemaList";
			comboBoxSchemaList.Size = new Size(211, 23);
			comboBoxSchemaList.TabIndex = 6;
			comboBoxSchemaList.SelectedValueChanged += comboBoxSchemaList_SelectedValueChanged;
			// 
			// buttonSeciliSemaTablolariUret
			// 
			buttonSeciliSemaTablolariUret.AutoSize = true;
			buttonSeciliSemaTablolariUret.Dock = DockStyle.Fill;
			buttonSeciliSemaTablolariUret.Location = new Point(491, 2);
			buttonSeciliSemaTablolariUret.Margin = new Padding(3, 2, 3, 2);
			buttonSeciliSemaTablolariUret.Name = "buttonSeciliSemaTablolariUret";
			buttonSeciliSemaTablolariUret.Size = new Size(118, 66);
			buttonSeciliSemaTablolariUret.TabIndex = 12;
			buttonSeciliSemaTablolariUret.Text = "Create Tables in Schema";
			buttonSeciliSemaTablolariUret.UseVisualStyleBackColor = true;
			buttonSeciliSemaTablolariUret.Click += buttonGenerateTablesForSelectedSchema_Click;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 4;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.Controls.Add(buttonTumTablolariUret, 0, 0);
			tableLayoutPanel1.Controls.Add(labelSchemaList, 1, 0);
			tableLayoutPanel1.Controls.Add(comboBoxSchemaList, 2, 0);
			tableLayoutPanel1.Controls.Add(listBoxTables, 2, 1);
			tableLayoutPanel1.Controls.Add(labelTabloListesi, 1, 1);
			tableLayoutPanel1.Controls.Add(buttonSeciliSemaTablolariUret, 3, 0);
			tableLayoutPanel1.Controls.Add(buttonSeciliTablolariUret, 3, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
			tableLayoutPanel1.Size = new Size(612, 283);
			tableLayoutPanel1.TabIndex = 13;
			// 
			// UserControlTableRelated
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel1);
			Margin = new Padding(4, 4, 4, 4);
			Name = "UserControlTableRelated";
			Size = new Size(612, 283);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button buttonSeciliTablolariUret;
        private System.Windows.Forms.Button buttonTumTablolariUret;
        private System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.Label labelTabloListesi;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private System.Windows.Forms.Button buttonSeciliSemaTablolariUret;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
