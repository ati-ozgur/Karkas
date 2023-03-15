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
            this.buttonGenerateSelectedSequences = new System.Windows.Forms.Button();
            this.buttonGenerateAllSequencesInDatabase = new System.Windows.Forms.Button();
            this.listBoxSequences = new System.Windows.Forms.ListBox();
            this.labelSequenceList = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGenerateSequenceInSelectedSchema = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerateSelectedSequences
            // 
            this.buttonGenerateSelectedSequences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGenerateSelectedSequences.Location = new System.Drawing.Point(491, 86);
            this.buttonGenerateSelectedSequences.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGenerateSelectedSequences.Name = "buttonGenerateSelectedSequences";
            this.buttonGenerateSelectedSequences.Size = new System.Drawing.Size(118, 195);
            this.buttonGenerateSelectedSequences.TabIndex = 23;
            this.buttonGenerateSelectedSequences.Text = "Create Selected Sequences";
            this.buttonGenerateSelectedSequences.UseVisualStyleBackColor = true;
            this.buttonGenerateSelectedSequences.Click += new System.EventHandler(this.buttonGenerateSelectedSequences_Click);
            // 
            // buttonGenerateAllSequencesInDatabase
            // 
            this.buttonGenerateAllSequencesInDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGenerateAllSequencesInDatabase.Location = new System.Drawing.Point(3, 2);
            this.buttonGenerateAllSequencesInDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGenerateAllSequencesInDatabase.Name = "buttonGenerateAllSequencesInDatabase";
            this.buttonGenerateAllSequencesInDatabase.Size = new System.Drawing.Size(116, 80);
            this.buttonGenerateAllSequencesInDatabase.TabIndex = 22;
            this.buttonGenerateAllSequencesInDatabase.Text = "Create all sequences in all Database";
            this.buttonGenerateAllSequencesInDatabase.UseVisualStyleBackColor = true;
            this.buttonGenerateAllSequencesInDatabase.Click += new System.EventHandler(this.buttonGenerateAllSequencesInDatabase_Click);
            // 
            // listBoxSequences
            // 
            this.listBoxSequences.DisplayMember = "SEQUENCE_NAME";
            this.listBoxSequences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSequences.FormattingEnabled = true;
            this.listBoxSequences.ItemHeight = 15;
            this.listBoxSequences.Location = new System.Drawing.Point(247, 86);
            this.listBoxSequences.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxSequences.Name = "listBoxSequences";
            this.listBoxSequences.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSequences.Size = new System.Drawing.Size(238, 195);
            this.listBoxSequences.TabIndex = 21;
            this.listBoxSequences.ValueMember = "SEQUENCE_NAME";
            // 
            // labelSequenceList
            // 
            this.labelSequenceList.AutoSize = true;
            this.labelSequenceList.Location = new System.Drawing.Point(125, 84);
            this.labelSequenceList.Name = "labelSequenceList";
            this.labelSequenceList.Size = new System.Drawing.Size(79, 15);
            this.labelSequenceList.TabIndex = 20;
            this.labelSequenceList.Text = "Sequence List";
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
            this.tableLayoutPanel1.Controls.Add(this.buttonGenerateAllSequencesInDatabase, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSchemaList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSchemaList, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonGenerateSelectedSequences, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSequences, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSequenceList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonGenerateSequenceInSelectedSchema, 3, 0);
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
            // buttonGenerateSequenceInSelectedSchema
            // 
            this.buttonGenerateSequenceInSelectedSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGenerateSequenceInSelectedSchema.Location = new System.Drawing.Point(491, 2);
            this.buttonGenerateSequenceInSelectedSchema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGenerateSequenceInSelectedSchema.Name = "buttonGenerateSequenceInSelectedSchema";
            this.buttonGenerateSequenceInSelectedSchema.Size = new System.Drawing.Size(118, 80);
            this.buttonGenerateSequenceInSelectedSchema.TabIndex = 24;
            this.buttonGenerateSequenceInSelectedSchema.Text = "Create all sequences in all Database";
            this.buttonGenerateSequenceInSelectedSchema.UseVisualStyleBackColor = true;
            this.buttonGenerateSequenceInSelectedSchema.Click += new System.EventHandler(this.buttonGenerateSequenceInSelectedSchema_Click);
            // 
            // UserControlSequenceRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlSequenceRelated";
            this.Size = new System.Drawing.Size(612, 283);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateSelectedSequences;
        private System.Windows.Forms.Button buttonGenerateAllSequencesInDatabase;
        private System.Windows.Forms.ListBox listBoxSequences;
        private System.Windows.Forms.Label labelSequenceList;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonGenerateSequenceInSelectedSchema;
    }
}
