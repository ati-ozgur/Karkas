namespace Karkas.CodeGeneration.WinApp.UserControls
{
    partial class UserControlStoredProcedureRelated
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
            this.buttonProduceSelectedViews = new System.Windows.Forms.Button();
            this.buttonTumStoredProcedureUret = new System.Windows.Forms.Button();
            this.listBoxStoredProcedureListesi = new System.Windows.Forms.ListBox();
            this.labelStoredProcedureListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.buttonSemaIcinTumStoredProcedureUret = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonProduceSelectedViews
            // 
            this.buttonProduceSelectedViews.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProduceSelectedViews.Location = new System.Drawing.Point(560, 116);
            this.buttonProduceSelectedViews.Name = "buttonProduceSelectedViews";
            this.buttonProduceSelectedViews.Size = new System.Drawing.Size(136, 258);
            this.buttonProduceSelectedViews.TabIndex = 23;
            this.buttonProduceSelectedViews.Text = "Create selected stored procedures";
            this.buttonProduceSelectedViews.UseVisualStyleBackColor = true;
            this.buttonProduceSelectedViews.Click += new System.EventHandler(this.buttonProduceSelectedViews_Click);
            // 
            // buttonTumStoredProcedureUret
            // 
            this.buttonTumStoredProcedureUret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTumStoredProcedureUret.Location = new System.Drawing.Point(3, 3);
            this.buttonTumStoredProcedureUret.Name = "buttonTumStoredProcedureUret";
            this.buttonTumStoredProcedureUret.Size = new System.Drawing.Size(133, 107);
            this.buttonTumStoredProcedureUret.TabIndex = 22;
            this.buttonTumStoredProcedureUret.Text = "Create All Stored Procedures";
            this.buttonTumStoredProcedureUret.UseVisualStyleBackColor = true;
            this.buttonTumStoredProcedureUret.Click += new System.EventHandler(this.buttonTumStoredProcedureUret_Click);
            // 
            // listBoxStoredProcedureListesi
            // 
            this.listBoxStoredProcedureListesi.DisplayMember = "STORED_PROCEDURE_NAME";
            this.listBoxStoredProcedureListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxStoredProcedureListesi.FormattingEnabled = true;
            this.listBoxStoredProcedureListesi.ItemHeight = 20;
            this.listBoxStoredProcedureListesi.Location = new System.Drawing.Point(281, 116);
            this.listBoxStoredProcedureListesi.Name = "listBoxStoredProcedureListesi";
            this.listBoxStoredProcedureListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxStoredProcedureListesi.Size = new System.Drawing.Size(273, 258);
            this.listBoxStoredProcedureListesi.TabIndex = 21;
            // 
            // labelStoredProcedureListesi
            // 
            this.labelStoredProcedureListesi.AutoSize = true;
            this.labelStoredProcedureListesi.Location = new System.Drawing.Point(142, 113);
            this.labelStoredProcedureListesi.Name = "labelStoredProcedureListesi";
            this.labelStoredProcedureListesi.Size = new System.Drawing.Size(128, 40);
            this.labelStoredProcedureListesi.TabIndex = 20;
            this.labelStoredProcedureListesi.Text = "Stored Procedure List";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(142, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(87, 20);
            this.labelSchemaList.TabIndex = 19;
            this.labelSchemaList.Text = "Schema List";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "SCHEMA_NAME";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(281, 3);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(241, 28);
            this.comboBoxSchemaList.TabIndex = 18;
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
            // 
            // buttonSemaIcinTumStoredProcedureUret
            // 
            this.buttonSemaIcinTumStoredProcedureUret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSemaIcinTumStoredProcedureUret.Location = new System.Drawing.Point(560, 3);
            this.buttonSemaIcinTumStoredProcedureUret.Name = "buttonSemaIcinTumStoredProcedureUret";
            this.buttonSemaIcinTumStoredProcedureUret.Size = new System.Drawing.Size(136, 107);
            this.buttonSemaIcinTumStoredProcedureUret.TabIndex = 24;
            this.buttonSemaIcinTumStoredProcedureUret.Text = "Create All Stored Procedures in Schema";
            this.buttonSemaIcinTumStoredProcedureUret.UseVisualStyleBackColor = true;
            this.buttonSemaIcinTumStoredProcedureUret.Click += new System.EventHandler(this.buttonSemaIcinTumStoredProcedureUret_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonTumStoredProcedureUret, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSchemaList, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSchemaList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSemaIcinTumStoredProcedureUret, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxStoredProcedureListesi, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelStoredProcedureListesi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonProduceSelectedViews, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 377);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // UserControlStoredProcedureRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControlStoredProcedureRelated";
            this.Size = new System.Drawing.Size(699, 377);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonProduceSelectedViews;
        private System.Windows.Forms.Button buttonTumStoredProcedureUret;
        private System.Windows.Forms.ListBox listBoxStoredProcedureListesi;
        private System.Windows.Forms.Label labelStoredProcedureListesi;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private System.Windows.Forms.Button buttonSemaIcinTumStoredProcedureUret;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
