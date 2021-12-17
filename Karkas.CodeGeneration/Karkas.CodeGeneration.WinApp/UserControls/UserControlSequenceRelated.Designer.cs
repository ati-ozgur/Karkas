namespace Karkas.CodeGeneration.WinApp.UserControls
{
    partial class UserControlSequenceRelated
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
            this.buttonSeciliSequenceUret = new System.Windows.Forms.Button();
            this.buttonTumSequencesUret = new System.Windows.Forms.Button();
            this.listBoxSequenceListesi = new System.Windows.Forms.ListBox();
            this.labelSequenceListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSeciliSequenceUret
            // 
            this.buttonSeciliSequenceUret.Location = new System.Drawing.Point(421, 116);
            this.buttonSeciliSequenceUret.Name = "buttonSeciliSequenceUret";
            this.buttonSeciliSequenceUret.Size = new System.Drawing.Size(221, 73);
            this.buttonSeciliSequenceUret.TabIndex = 23;
            this.buttonSeciliSequenceUret.Text = "Create Selected Sequences";
            this.buttonSeciliSequenceUret.UseVisualStyleBackColor = true;
            this.buttonSeciliSequenceUret.Click += new System.EventHandler(this.buttonSeciliSequenceUret_Click);
            // 
            // buttonTumSequencesUret
            // 
            this.buttonTumSequencesUret.Location = new System.Drawing.Point(421, 3);
            this.buttonTumSequencesUret.Name = "buttonTumSequencesUret";
            this.buttonTumSequencesUret.Size = new System.Drawing.Size(221, 61);
            this.buttonTumSequencesUret.TabIndex = 22;
            this.buttonTumSequencesUret.Text = "Create all sequences";
            this.buttonTumSequencesUret.UseVisualStyleBackColor = true;
            this.buttonTumSequencesUret.Click += new System.EventHandler(this.buttonTumSequencesUret_Click);
            // 
            // listBoxSequenceListesi
            // 
            this.listBoxSequenceListesi.DisplayMember = "SEQUENCE_NAME";
            this.listBoxSequenceListesi.FormattingEnabled = true;
            this.listBoxSequenceListesi.ItemHeight = 20;
            this.listBoxSequenceListesi.Location = new System.Drawing.Point(212, 116);
            this.listBoxSequenceListesi.Name = "listBoxSequenceListesi";
            this.listBoxSequenceListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSequenceListesi.Size = new System.Drawing.Size(203, 244);
            this.listBoxSequenceListesi.TabIndex = 21;
            // 
            // labelSequenceListesi
            // 
            this.labelSequenceListesi.AutoSize = true;
            this.labelSequenceListesi.Location = new System.Drawing.Point(3, 113);
            this.labelSequenceListesi.Name = "labelSequenceListesi";
            this.labelSequenceListesi.Size = new System.Drawing.Size(99, 20);
            this.labelSequenceListesi.TabIndex = 20;
            this.labelSequenceListesi.Text = "Sequence List";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(3, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(87, 20);
            this.labelSchemaList.TabIndex = 19;
            this.labelSchemaList.Text = "Schema List";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "SCHEMA_NAME";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(212, 3);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(203, 28);
            this.comboBoxSchemaList.TabIndex = 18;
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.labelSchemaList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeciliSequenceUret, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSchemaList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSequenceListesi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonTumSequencesUret, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSequenceListesi, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 377);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // UserControlSequenceRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControlSequenceRelated";
            this.Size = new System.Drawing.Size(699, 377);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSeciliSequenceUret;
        private System.Windows.Forms.Button buttonTumSequencesUret;
        private System.Windows.Forms.ListBox listBoxSequenceListesi;
        private System.Windows.Forms.Label labelSequenceListesi;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
