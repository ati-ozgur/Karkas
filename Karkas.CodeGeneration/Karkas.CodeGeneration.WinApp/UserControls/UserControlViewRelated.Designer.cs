namespace Karkas.CodeGeneration.WinApp.UserControls
{
    partial class UserControlViewRelated
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
            this.buttonSeciliViewlariUret = new System.Windows.Forms.Button();
            this.buttonTumViewlariUret = new System.Windows.Forms.Button();
            this.listBoxViewListesi = new System.Windows.Forms.ListBox();
            this.labelViewListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.buttonSeciliSemaViewUret = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSeciliViewlariUret
            // 
            this.buttonSeciliViewlariUret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSeciliViewlariUret.Location = new System.Drawing.Point(560, 97);
            this.buttonSeciliViewlariUret.Name = "buttonSeciliViewlariUret";
            this.buttonSeciliViewlariUret.Size = new System.Drawing.Size(136, 277);
            this.buttonSeciliViewlariUret.TabIndex = 17;
            this.buttonSeciliViewlariUret.Text = "Select Selected Views";
            this.buttonSeciliViewlariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliViewlariUret.Click += new System.EventHandler(this.buttonSeciliViewlariUret_Click);
            // 
            // buttonTumViewlariUret
            // 
            this.buttonTumViewlariUret.Location = new System.Drawing.Point(3, 3);
            this.buttonTumViewlariUret.Name = "buttonTumViewlariUret";
            this.buttonTumViewlariUret.Size = new System.Drawing.Size(133, 69);
            this.buttonTumViewlariUret.TabIndex = 16;
            this.buttonTumViewlariUret.Text = "Create All Views";
            this.buttonTumViewlariUret.UseVisualStyleBackColor = true;
            this.buttonTumViewlariUret.Click += new System.EventHandler(this.buttonProduceAllViews_Click);
            // 
            // listBoxViewListesi
            // 
            this.listBoxViewListesi.DisplayMember = "FULL_VIEW_NAME";
            this.listBoxViewListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxViewListesi.FormattingEnabled = true;
            this.listBoxViewListesi.ItemHeight = 20;
            this.listBoxViewListesi.Location = new System.Drawing.Point(281, 97);
            this.listBoxViewListesi.Name = "listBoxViewListesi";
            this.listBoxViewListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxViewListesi.Size = new System.Drawing.Size(273, 277);
            this.listBoxViewListesi.TabIndex = 15;
            // 
            // labelViewListesi
            // 
            this.labelViewListesi.AutoSize = true;
            this.labelViewListesi.Location = new System.Drawing.Point(142, 94);
            this.labelViewListesi.Name = "labelViewListesi";
            this.labelViewListesi.Size = new System.Drawing.Size(67, 20);
            this.labelViewListesi.TabIndex = 14;
            this.labelViewListesi.Text = "View List";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(142, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(87, 20);
            this.labelSchemaList.TabIndex = 13;
            this.labelSchemaList.Text = "Schema List";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "SCHEMA_NAME";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(281, 3);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(241, 28);
            this.comboBoxSchemaList.TabIndex = 12;
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
            // 
            // buttonSeciliSemaViewUret
            // 
            this.buttonSeciliSemaViewUret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSeciliSemaViewUret.Location = new System.Drawing.Point(560, 3);
            this.buttonSeciliSemaViewUret.Name = "buttonSeciliSemaViewUret";
            this.buttonSeciliSemaViewUret.Size = new System.Drawing.Size(136, 88);
            this.buttonSeciliSemaViewUret.TabIndex = 18;
            this.buttonSeciliSemaViewUret.Text = "Create Views in Schema";
            this.buttonSeciliSemaViewUret.UseVisualStyleBackColor = true;
            this.buttonSeciliSemaViewUret.Click += new System.EventHandler(this.buttonSeciliSemaViewUret_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonTumViewlariUret, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSchemaList, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSchemaList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeciliSemaViewUret, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxViewListesi, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelViewListesi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeciliViewlariUret, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 377);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // UserControlViewRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControlViewRelated";
            this.Size = new System.Drawing.Size(699, 377);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSeciliViewlariUret;
        private System.Windows.Forms.Button buttonTumViewlariUret;
        private System.Windows.Forms.ListBox listBoxViewListesi;
        private System.Windows.Forms.Label labelViewListesi;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private System.Windows.Forms.Button buttonSeciliSemaViewUret;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
