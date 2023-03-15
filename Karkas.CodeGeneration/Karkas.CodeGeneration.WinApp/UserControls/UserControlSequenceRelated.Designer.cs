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
            this.buttonCreateSequenceInSchema = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSeciliSequenceUret
            // 
            this.buttonSeciliSequenceUret.Location = new System.Drawing.Point(491, 86);
            this.buttonSeciliSequenceUret.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSeciliSequenceUret.Name = "buttonSeciliSequenceUret";
            this.buttonSeciliSequenceUret.Size = new System.Drawing.Size(118, 55);
            this.buttonSeciliSequenceUret.TabIndex = 23;
            this.buttonSeciliSequenceUret.Text = "Create Selected Sequences";
            this.buttonSeciliSequenceUret.UseVisualStyleBackColor = true;
            this.buttonSeciliSequenceUret.Click += new System.EventHandler(this.buttonSeciliSequenceUret_Click);
            // 
            // buttonTumSequencesUret
            // 
            this.buttonTumSequencesUret.Location = new System.Drawing.Point(3, 2);
            this.buttonTumSequencesUret.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTumSequencesUret.Name = "buttonTumSequencesUret";
            this.buttonTumSequencesUret.Size = new System.Drawing.Size(116, 46);
            this.buttonTumSequencesUret.TabIndex = 22;
            this.buttonTumSequencesUret.Text = "Create all sequences in all Database";
            this.buttonTumSequencesUret.UseVisualStyleBackColor = true;
            this.buttonTumSequencesUret.Click += new System.EventHandler(this.buttonTumSequencesUret_Click);
            // 
            // listBoxSequenceListesi
            // 
            this.listBoxSequenceListesi.DisplayMember = "SEQUENCE_NAME";
            this.listBoxSequenceListesi.FormattingEnabled = true;
            this.listBoxSequenceListesi.ItemHeight = 15;
            this.listBoxSequenceListesi.Location = new System.Drawing.Point(247, 86);
            this.listBoxSequenceListesi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxSequenceListesi.Name = "listBoxSequenceListesi";
            this.listBoxSequenceListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSequenceListesi.Size = new System.Drawing.Size(178, 184);
            this.listBoxSequenceListesi.TabIndex = 21;
            // 
            // labelSequenceListesi
            // 
            this.labelSequenceListesi.AutoSize = true;
            this.labelSequenceListesi.Location = new System.Drawing.Point(125, 84);
            this.labelSequenceListesi.Name = "labelSequenceListesi";
            this.labelSequenceListesi.Size = new System.Drawing.Size(79, 15);
            this.labelSequenceListesi.TabIndex = 20;
            this.labelSequenceListesi.Text = "Sequence List";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(125, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(70, 15);
            this.labelSchemaList.TabIndex = 19;
            this.labelSchemaList.Text = "Schema List";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "SCHEMA_NAME";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(247, 2);
            this.comboBoxSchemaList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(178, 23);
            this.comboBoxSchemaList.TabIndex = 18;
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonTumSequencesUret, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSchemaList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSchemaList, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeciliSequenceUret, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSequenceListesi, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSequenceListesi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateSequenceInSchema, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(612, 283);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // buttonCreateSequenceInSchema
            // 
            this.buttonCreateSequenceInSchema.Location = new System.Drawing.Point(491, 2);
            this.buttonCreateSequenceInSchema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateSequenceInSchema.Name = "buttonCreateSequenceInSchema";
            this.buttonCreateSequenceInSchema.Size = new System.Drawing.Size(116, 46);
            this.buttonCreateSequenceInSchema.TabIndex = 24;
            this.buttonCreateSequenceInSchema.Text = "Create all sequences in all Database";
            this.buttonCreateSequenceInSchema.UseVisualStyleBackColor = true;
            this.buttonCreateSequenceInSchema.Click += new System.EventHandler(this.buttonCreateSequenceInSchema_Click);
            // 
            // UserControlSequenceRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControlSequenceRelated";
            this.Size = new System.Drawing.Size(612, 283);
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
        private Button buttonCreateSequenceInSchema;
    }
}
