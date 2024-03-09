namespace Karkas.CodeGeneration.WinApp.UserControls
{
    partial class UserControlCodeGenerationOptions
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
            components = new System.ComponentModel.Container();
            checkBoxIgnoreSystemTables = new CheckBox();
            checkBoxStoredProcedureCodeGenerate = new CheckBox();
            checkBoxViewCodeGenerate = new CheckBox();
            checkBoxUseSchemaNameInFolders = new CheckBox();
            checkBoxUseSchemaNameInSql = new CheckBox();
            checkBoxCreateMainClassAgain = new CheckBox();
            textBoxDbProviderName = new TextBox();
            labelDbProviderName = new Label();
            textBoxDatabaseNamePhysical = new TextBox();
            labelDatabaseNamePhysical = new Label();
            textBoxDatabaseNameLogical = new TextBox();
            labelDatabaseNameLogical = new Label();
            labelDatabaseType = new Label();
            comboBoxDatabaseType = new ComboBox();
            textBoxConnectionName = new TextBox();
            labelConnectionName = new Label();
            textBoxProjectNamespace = new TextBox();
            labelProjectNamespace = new Label();
            buttonFolderDialog = new Button();
            textBoxCodeGenerationFolder = new TextBox();
            labelCodeGenerationFolder = new Label();
            textBoxConnectionString = new TextBox();
            labelConnectionString = new Label();
            textBoxAbbrevationsAsString = new TextBox();
            labelAbbrevationsAsString = new Label();
            textBoxIgnoredSchemaList = new TextBox();
            labelIgnoredSchemaList = new Label();
            checkBoxCreateMainClassValidationExamples = new CheckBox();
            checkBoxSequenceCodeGenerate = new CheckBox();
            toolTipCodeGenerationOptions = new ToolTip(components);
            buttonKisaltmalar = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            labelAdditionalSchemaList = new Label();
            textBoxSchemaList = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // checkBoxIgnoreSystemTables
            // 
            checkBoxIgnoreSystemTables.AutoSize = true;
            checkBoxIgnoreSystemTables.Checked = true;
            checkBoxIgnoreSystemTables.CheckState = CheckState.Checked;
            checkBoxIgnoreSystemTables.Location = new Point(256, 343);
            checkBoxIgnoreSystemTables.Margin = new Padding(3, 2, 3, 2);
            checkBoxIgnoreSystemTables.Name = "checkBoxIgnoreSystemTables";
            checkBoxIgnoreSystemTables.Size = new Size(155, 19);
            checkBoxIgnoreSystemTables.TabIndex = 27;
            checkBoxIgnoreSystemTables.Text = "Ignore sys/system tables";
            checkBoxIgnoreSystemTables.UseVisualStyleBackColor = true;
            // 
            // checkBoxStoredProcedureCodeGenerate
            // 
            checkBoxStoredProcedureCodeGenerate.AutoSize = true;
            checkBoxStoredProcedureCodeGenerate.Location = new Point(3, 374);
            checkBoxStoredProcedureCodeGenerate.Margin = new Padding(3, 2, 3, 2);
            checkBoxStoredProcedureCodeGenerate.Name = "checkBoxStoredProcedureCodeGenerate";
            checkBoxStoredProcedureCodeGenerate.Size = new Size(198, 19);
            checkBoxStoredProcedureCodeGenerate.TabIndex = 31;
            checkBoxStoredProcedureCodeGenerate.Text = "Stored Procedure Code Generate";
            checkBoxStoredProcedureCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // checkBoxViewCodeGenerate
            // 
            checkBoxViewCodeGenerate.AutoSize = true;
            checkBoxViewCodeGenerate.Location = new Point(3, 343);
            checkBoxViewCodeGenerate.Margin = new Padding(3, 2, 3, 2);
            checkBoxViewCodeGenerate.Name = "checkBoxViewCodeGenerate";
            checkBoxViewCodeGenerate.Size = new Size(132, 19);
            checkBoxViewCodeGenerate.TabIndex = 30;
            checkBoxViewCodeGenerate.Text = "View Code Generate";
            checkBoxViewCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseSchemaNameInFolders
            // 
            checkBoxUseSchemaNameInFolders.AutoSize = true;
            checkBoxUseSchemaNameInFolders.Checked = true;
            checkBoxUseSchemaNameInFolders.CheckState = CheckState.Checked;
            checkBoxUseSchemaNameInFolders.Dock = DockStyle.Fill;
            checkBoxUseSchemaNameInFolders.Location = new Point(256, 405);
            checkBoxUseSchemaNameInFolders.Margin = new Padding(3, 2, 3, 2);
            checkBoxUseSchemaNameInFolders.Name = "checkBoxUseSchemaNameInFolders";
            checkBoxUseSchemaNameInFolders.Size = new Size(500, 27);
            checkBoxUseSchemaNameInFolders.TabIndex = 29;
            checkBoxUseSchemaNameInFolders.Text = "Use Schema Name in Folders (ignored for sqlite)";
            checkBoxUseSchemaNameInFolders.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseSchemaNameInSql
            // 
            checkBoxUseSchemaNameInSql.AutoSize = true;
            checkBoxUseSchemaNameInSql.Checked = true;
            checkBoxUseSchemaNameInSql.CheckState = CheckState.Checked;
            checkBoxUseSchemaNameInSql.Location = new Point(256, 374);
            checkBoxUseSchemaNameInSql.Margin = new Padding(3, 2, 3, 2);
            checkBoxUseSchemaNameInSql.Name = "checkBoxUseSchemaNameInSql";
            checkBoxUseSchemaNameInSql.Size = new Size(282, 19);
            checkBoxUseSchemaNameInSql.TabIndex = 28;
            checkBoxUseSchemaNameInSql.Text = "Use Schema Name in Queries (ignored for sqlite)";
            checkBoxUseSchemaNameInSql.UseVisualStyleBackColor = true;
            // 
            // checkBoxCreateMainClassAgain
            // 
            checkBoxCreateMainClassAgain.AutoSize = true;
            checkBoxCreateMainClassAgain.Location = new Point(256, 436);
            checkBoxCreateMainClassAgain.Margin = new Padding(3, 2, 3, 2);
            checkBoxCreateMainClassAgain.Name = "checkBoxCreateMainClassAgain";
            checkBoxCreateMainClassAgain.Size = new Size(154, 19);
            checkBoxCreateMainClassAgain.TabIndex = 32;
            checkBoxCreateMainClassAgain.Text = "Create Main Class Again";
            checkBoxCreateMainClassAgain.UseVisualStyleBackColor = true;
            // 
            // textBoxDbProviderName
            // 
            textBoxDbProviderName.Location = new Point(257, 66);
            textBoxDbProviderName.Margin = new Padding(4);
            textBoxDbProviderName.Name = "textBoxDbProviderName";
            textBoxDbProviderName.Size = new Size(148, 23);
            textBoxDbProviderName.TabIndex = 50;
            // 
            // labelDbProviderName
            // 
            labelDbProviderName.AutoSize = true;
            labelDbProviderName.Location = new Point(4, 62);
            labelDbProviderName.Margin = new Padding(4, 0, 4, 0);
            labelDbProviderName.Name = "labelDbProviderName";
            labelDbProviderName.Size = new Size(98, 15);
            labelDbProviderName.TabIndex = 49;
            labelDbProviderName.Text = "DbProviderName";
            // 
            // textBoxDatabaseNamePhysical
            // 
            textBoxDatabaseNamePhysical.Enabled = false;
            textBoxDatabaseNamePhysical.Location = new Point(257, 159);
            textBoxDatabaseNamePhysical.Margin = new Padding(4);
            textBoxDatabaseNamePhysical.Name = "textBoxDatabaseNamePhysical";
            textBoxDatabaseNamePhysical.Size = new Size(148, 23);
            textBoxDatabaseNamePhysical.TabIndex = 48;
            // 
            // labelDatabaseNamePhysical
            // 
            labelDatabaseNamePhysical.AutoSize = true;
            labelDatabaseNamePhysical.Location = new Point(3, 155);
            labelDatabaseNamePhysical.Name = "labelDatabaseNamePhysical";
            labelDatabaseNamePhysical.Size = new Size(136, 15);
            labelDatabaseNamePhysical.TabIndex = 47;
            labelDatabaseNamePhysical.Text = "Database Name Physical";
            // 
            // textBoxDatabaseNameLogical
            // 
            textBoxDatabaseNameLogical.Location = new Point(257, 128);
            textBoxDatabaseNameLogical.Margin = new Padding(4);
            textBoxDatabaseNameLogical.Name = "textBoxDatabaseNameLogical";
            textBoxDatabaseNameLogical.Size = new Size(148, 23);
            textBoxDatabaseNameLogical.TabIndex = 46;
            toolTipCodeGenerationOptions.SetToolTip(textBoxDatabaseNameLogical, "Veritabanı ismi olarak fiziksel isim yerine\r\nmantıksal bir isim vermek için kullanılır.\r\nBu mantıksal isim app.config/web.config\r\niçinde bağlantı çekmek için kullanılır.\r\n");
            // 
            // labelDatabaseNameLogical
            // 
            labelDatabaseNameLogical.AutoSize = true;
            labelDatabaseNameLogical.Location = new Point(3, 124);
            labelDatabaseNameLogical.Name = "labelDatabaseNameLogical";
            labelDatabaseNameLogical.Size = new Size(131, 15);
            labelDatabaseNameLogical.TabIndex = 45;
            labelDatabaseNameLogical.Text = "Database Name Logical";
            // 
            // labelDatabaseType
            // 
            labelDatabaseType.AutoSize = true;
            labelDatabaseType.Location = new Point(4, 31);
            labelDatabaseType.Margin = new Padding(4, 0, 4, 0);
            labelDatabaseType.Name = "labelDatabaseType";
            labelDatabaseType.Size = new Size(82, 15);
            labelDatabaseType.TabIndex = 44;
            labelDatabaseType.Text = "Database Type";
            // 
            // comboBoxDatabaseType
            // 
            comboBoxDatabaseType.FormattingEnabled = true;
            comboBoxDatabaseType.Location = new Point(257, 35);
            comboBoxDatabaseType.Margin = new Padding(4);
            comboBoxDatabaseType.Name = "comboBoxDatabaseType";
            comboBoxDatabaseType.Size = new Size(140, 23);
            comboBoxDatabaseType.TabIndex = 43;
            // 
            // textBoxConnectionName
            // 
            textBoxConnectionName.Location = new Point(257, 4);
            textBoxConnectionName.Margin = new Padding(4);
            textBoxConnectionName.Name = "textBoxConnectionName";
            textBoxConnectionName.Size = new Size(148, 23);
            textBoxConnectionName.TabIndex = 42;
            // 
            // labelConnectionName
            // 
            labelConnectionName.AutoSize = true;
            labelConnectionName.Location = new Point(3, 0);
            labelConnectionName.Name = "labelConnectionName";
            labelConnectionName.Size = new Size(104, 15);
            labelConnectionName.TabIndex = 41;
            labelConnectionName.Text = "Connection Name";
            // 
            // textBoxProjectNamespace
            // 
            textBoxProjectNamespace.Location = new Point(256, 188);
            textBoxProjectNamespace.Margin = new Padding(3, 2, 3, 2);
            textBoxProjectNamespace.Name = "textBoxProjectNamespace";
            textBoxProjectNamespace.Size = new Size(357, 23);
            textBoxProjectNamespace.TabIndex = 40;
            // 
            // labelProjectNamespace
            // 
            labelProjectNamespace.AutoSize = true;
            labelProjectNamespace.Location = new Point(3, 186);
            labelProjectNamespace.Name = "labelProjectNamespace";
            labelProjectNamespace.Size = new Size(109, 15);
            labelProjectNamespace.TabIndex = 39;
            labelProjectNamespace.Text = "Project Namespace";
            // 
            // buttonFolderDialog
            // 
            buttonFolderDialog.Dock = DockStyle.Fill;
            buttonFolderDialog.Location = new Point(762, 219);
            buttonFolderDialog.Margin = new Padding(3, 2, 3, 2);
            buttonFolderDialog.Name = "buttonFolderDialog";
            buttonFolderDialog.Size = new Size(79, 27);
            buttonFolderDialog.TabIndex = 38;
            buttonFolderDialog.Text = "...";
            buttonFolderDialog.UseVisualStyleBackColor = true;
            // 
            // textBoxCodeGenerationFolder
            // 
            textBoxCodeGenerationFolder.Location = new Point(256, 219);
            textBoxCodeGenerationFolder.Margin = new Padding(3, 2, 3, 2);
            textBoxCodeGenerationFolder.Name = "textBoxCodeGenerationFolder";
            textBoxCodeGenerationFolder.Size = new Size(357, 23);
            textBoxCodeGenerationFolder.TabIndex = 37;
            // 
            // labelCodeGenerationFolder
            // 
            labelCodeGenerationFolder.AutoSize = true;
            labelCodeGenerationFolder.Location = new Point(3, 217);
            labelCodeGenerationFolder.Name = "labelCodeGenerationFolder";
            labelCodeGenerationFolder.Size = new Size(132, 15);
            labelCodeGenerationFolder.TabIndex = 36;
            labelCodeGenerationFolder.Text = "Code Generation Folder";
            // 
            // textBoxConnectionString
            // 
            textBoxConnectionString.Location = new Point(256, 95);
            textBoxConnectionString.Margin = new Padding(3, 2, 3, 2);
            textBoxConnectionString.Name = "textBoxConnectionString";
            textBoxConnectionString.Size = new Size(357, 23);
            textBoxConnectionString.TabIndex = 35;
            // 
            // labelConnectionString
            // 
            labelConnectionString.AutoSize = true;
            labelConnectionString.Location = new Point(3, 93);
            labelConnectionString.Name = "labelConnectionString";
            labelConnectionString.Size = new Size(103, 15);
            labelConnectionString.TabIndex = 34;
            labelConnectionString.Text = "Connection String";
            // 
            // textBoxAbbrevationsAsString
            // 
            textBoxAbbrevationsAsString.Location = new Point(256, 312);
            textBoxAbbrevationsAsString.Margin = new Padding(3, 2, 3, 2);
            textBoxAbbrevationsAsString.Name = "textBoxAbbrevationsAsString";
            textBoxAbbrevationsAsString.Size = new Size(357, 23);
            textBoxAbbrevationsAsString.TabIndex = 54;
            // 
            // labelAbbrevationsAsString
            // 
            labelAbbrevationsAsString.AutoSize = true;
            labelAbbrevationsAsString.Location = new Point(3, 310);
            labelAbbrevationsAsString.Name = "labelAbbrevationsAsString";
            labelAbbrevationsAsString.Size = new Size(77, 15);
            labelAbbrevationsAsString.TabIndex = 53;
            labelAbbrevationsAsString.Text = "Abbrevations";
            // 
            // textBoxIgnoredSchemaList
            // 
            textBoxIgnoredSchemaList.Location = new Point(256, 250);
            textBoxIgnoredSchemaList.Margin = new Padding(3, 2, 3, 2);
            textBoxIgnoredSchemaList.Name = "textBoxIgnoredSchemaList";
            textBoxIgnoredSchemaList.Size = new Size(357, 23);
            textBoxIgnoredSchemaList.TabIndex = 52;
            // 
            // labelIgnoredSchemaList
            // 
            labelIgnoredSchemaList.AutoSize = true;
            labelIgnoredSchemaList.Location = new Point(3, 248);
            labelIgnoredSchemaList.Name = "labelIgnoredSchemaList";
            labelIgnoredSchemaList.Size = new Size(128, 15);
            labelIgnoredSchemaList.TabIndex = 51;
            labelIgnoredSchemaList.Text = "Ignored Schema List (,)";
            // 
            // checkBoxCreateMainClassValidationExamples
            // 
            checkBoxCreateMainClassValidationExamples.AutoSize = true;
            checkBoxCreateMainClassValidationExamples.Location = new Point(762, 436);
            checkBoxCreateMainClassValidationExamples.Margin = new Padding(3, 2, 3, 2);
            checkBoxCreateMainClassValidationExamples.Name = "checkBoxCreateMainClassValidationExamples";
            checkBoxCreateMainClassValidationExamples.Size = new Size(79, 19);
            checkBoxCreateMainClassValidationExamples.TabIndex = 33;
            checkBoxCreateMainClassValidationExamples.Text = "Create Main Validation Class";
            checkBoxCreateMainClassValidationExamples.UseVisualStyleBackColor = true;
            // 
            // checkBoxSequenceCodeGenerate
            // 
            checkBoxSequenceCodeGenerate.AutoSize = true;
            checkBoxSequenceCodeGenerate.Location = new Point(3, 405);
            checkBoxSequenceCodeGenerate.Margin = new Padding(3, 2, 3, 2);
            checkBoxSequenceCodeGenerate.Name = "checkBoxSequenceCodeGenerate";
            checkBoxSequenceCodeGenerate.Size = new Size(158, 19);
            checkBoxSequenceCodeGenerate.TabIndex = 56;
            checkBoxSequenceCodeGenerate.Text = "Sequence Code Generate";
            checkBoxSequenceCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // buttonKisaltmalar
            // 
            buttonKisaltmalar.Dock = DockStyle.Fill;
            buttonKisaltmalar.Location = new Point(763, 314);
            buttonKisaltmalar.Margin = new Padding(4);
            buttonKisaltmalar.Name = "buttonKisaltmalar";
            buttonKisaltmalar.Size = new Size(77, 23);
            buttonKisaltmalar.TabIndex = 57;
            buttonKisaltmalar.Text = "Abbrevations";
            buttonKisaltmalar.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(textBoxConnectionName, 1, 0);
            tableLayoutPanel1.Controls.Add(checkBoxSequenceCodeGenerate, 0, 13);
            tableLayoutPanel1.Controls.Add(buttonKisaltmalar, 2, 10);
            tableLayoutPanel1.Controls.Add(checkBoxUseSchemaNameInFolders, 1, 13);
            tableLayoutPanel1.Controls.Add(labelDatabaseType, 0, 1);
            tableLayoutPanel1.Controls.Add(checkBoxStoredProcedureCodeGenerate, 0, 12);
            tableLayoutPanel1.Controls.Add(checkBoxIgnoreSystemTables, 1, 11);
            tableLayoutPanel1.Controls.Add(checkBoxUseSchemaNameInSql, 1, 12);
            tableLayoutPanel1.Controls.Add(comboBoxDatabaseType, 1, 1);
            tableLayoutPanel1.Controls.Add(textBoxAbbrevationsAsString, 1, 10);
            tableLayoutPanel1.Controls.Add(checkBoxViewCodeGenerate, 0, 11);
            tableLayoutPanel1.Controls.Add(textBoxDbProviderName, 1, 2);
            tableLayoutPanel1.Controls.Add(labelAbbrevationsAsString, 0, 10);
            tableLayoutPanel1.Controls.Add(labelConnectionString, 0, 3);
            tableLayoutPanel1.Controls.Add(textBoxIgnoredSchemaList, 1, 8);
            tableLayoutPanel1.Controls.Add(textBoxConnectionString, 1, 3);
            tableLayoutPanel1.Controls.Add(labelIgnoredSchemaList, 0, 8);
            tableLayoutPanel1.Controls.Add(textBoxProjectNamespace, 1, 6);
            tableLayoutPanel1.Controls.Add(buttonFolderDialog, 2, 7);
            tableLayoutPanel1.Controls.Add(textBoxDatabaseNamePhysical, 1, 5);
            tableLayoutPanel1.Controls.Add(textBoxCodeGenerationFolder, 1, 7);
            tableLayoutPanel1.Controls.Add(labelProjectNamespace, 0, 6);
            tableLayoutPanel1.Controls.Add(labelCodeGenerationFolder, 0, 7);
            tableLayoutPanel1.Controls.Add(labelDatabaseNameLogical, 0, 4);
            tableLayoutPanel1.Controls.Add(textBoxDatabaseNameLogical, 1, 4);
            tableLayoutPanel1.Controls.Add(labelDatabaseNamePhysical, 0, 5);
            tableLayoutPanel1.Controls.Add(checkBoxCreateMainClassAgain, 1, 14);
            tableLayoutPanel1.Controls.Add(labelConnectionName, 0, 0);
            tableLayoutPanel1.Controls.Add(labelDbProviderName, 0, 2);
            tableLayoutPanel1.Controls.Add(checkBoxCreateMainClassValidationExamples, 2, 14);
            tableLayoutPanel1.Controls.Add(labelAdditionalSchemaList, 0, 9);
            tableLayoutPanel1.Controls.Add(textBoxSchemaList, 1, 9);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 15;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(844, 466);
            tableLayoutPanel1.TabIndex = 58;
            // 
            // labelAdditionalSchemaList
            // 
            labelAdditionalSchemaList.AutoSize = true;
            labelAdditionalSchemaList.Location = new Point(3, 279);
            labelAdditionalSchemaList.Name = "labelAdditionalSchemaList";
            labelAdditionalSchemaList.Size = new Size(84, 15);
            labelAdditionalSchemaList.TabIndex = 58;
            labelAdditionalSchemaList.Text = "Schema List (,)";
            // 
            // textBoxSchemaList
            // 
            textBoxSchemaList.Location = new Point(256, 282);
            textBoxSchemaList.Name = "textBoxSchemaList";
            textBoxSchemaList.Size = new Size(357, 23);
            textBoxSchemaList.TabIndex = 59;
            // 
            // UserControlCodeGenerationOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4);
            Name = "UserControlCodeGenerationOptions";
            Size = new Size(844, 466);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxIgnoreSystemTables;
        private System.Windows.Forms.CheckBox checkBoxStoredProcedureCodeGenerate;
        private System.Windows.Forms.CheckBox checkBoxViewCodeGenerate;
        private System.Windows.Forms.CheckBox checkBoxUseSchemaNameInFolders;
        private System.Windows.Forms.CheckBox checkBoxUseSchemaNameInSql;
        private System.Windows.Forms.CheckBox checkBoxCreateMainClassAgain;
        private System.Windows.Forms.TextBox textBoxDbProviderName;
        private System.Windows.Forms.Label labelDbProviderName;
        private System.Windows.Forms.TextBox textBoxDatabaseNamePhysical;
        private System.Windows.Forms.Label labelDatabaseNamePhysical;
        private System.Windows.Forms.TextBox textBoxDatabaseNameLogical;
        private System.Windows.Forms.Label labelDatabaseNameLogical;
        private System.Windows.Forms.Label labelDatabaseType;
        private System.Windows.Forms.ComboBox comboBoxDatabaseType;
        private System.Windows.Forms.TextBox textBoxConnectionName;
        private System.Windows.Forms.Label labelConnectionName;
        private System.Windows.Forms.TextBox textBoxProjectNamespace;
        private System.Windows.Forms.Label labelProjectNamespace;
        private System.Windows.Forms.Button buttonFolderDialog;
        private System.Windows.Forms.TextBox textBoxCodeGenerationFolder;
        private System.Windows.Forms.Label labelCodeGenerationFolder;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TextBox textBoxAbbrevationsAsString;
        private System.Windows.Forms.Label labelAbbrevationsAsString;
        private System.Windows.Forms.TextBox textBoxIgnoredSchemaList;
        private System.Windows.Forms.Label labelIgnoredSchemaList;
        



        private System.Windows.Forms.CheckBox checkBoxCreateMainClassValidationExamples;
        private System.Windows.Forms.CheckBox checkBoxSequenceCodeGenerate;
        private System.Windows.Forms.ToolTip toolTipCodeGenerationOptions;
        private System.Windows.Forms.Button buttonKisaltmalar;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label labelAdditionalSchemaList;
        private TextBox textBoxSchemaList;
    }
}
