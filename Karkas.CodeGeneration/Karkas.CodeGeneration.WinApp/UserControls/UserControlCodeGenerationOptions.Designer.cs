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
			textBoxDbProviderName = new TextBox();
			labelDbProviderName = new Label();
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
			textBoxIgnoredSchemaList = new TextBox();
			labelIgnoredSchemaList = new Label();
			checkBoxSequenceCodeGenerate = new CheckBox();
			toolTipCodeGenerationOptions = new ToolTip(components);
			tableLayoutPanel1 = new TableLayoutPanel();
			checkBoxUseSchemaNameInNamespaces = new CheckBox();
			checkBoxGenerateNormalClassAgain = new CheckBox();
			checkBoxGenerateNormalClassValidationExamples = new CheckBox();
			labelAdditionalSchemaList = new Label();
			textBoxSchemaList = new TextBox();
			checkBoxOracleForceIdentityToLong = new CheckBox();
			checkBoxForceOracleDecimalToIntegersAndDecimal = new CheckBox();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// checkBoxIgnoreSystemTables
			// 
			checkBoxIgnoreSystemTables.AutoSize = true;
			checkBoxIgnoreSystemTables.Checked = true;
			checkBoxIgnoreSystemTables.CheckState = CheckState.Checked;
			checkBoxIgnoreSystemTables.Location = new Point(256, 321);
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
			checkBoxStoredProcedureCodeGenerate.Location = new Point(3, 350);
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
			checkBoxViewCodeGenerate.Location = new Point(3, 321);
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
			checkBoxUseSchemaNameInFolders.Location = new Point(256, 379);
			checkBoxUseSchemaNameInFolders.Margin = new Padding(3, 2, 3, 2);
			checkBoxUseSchemaNameInFolders.Name = "checkBoxUseSchemaNameInFolders";
			checkBoxUseSchemaNameInFolders.Size = new Size(500, 25);
			checkBoxUseSchemaNameInFolders.TabIndex = 29;
			checkBoxUseSchemaNameInFolders.Text = "Use Schema Name in Folders (ignored for sqlite)";
			checkBoxUseSchemaNameInFolders.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseSchemaNameInSql
			// 
			checkBoxUseSchemaNameInSql.AutoSize = true;
			checkBoxUseSchemaNameInSql.Checked = true;
			checkBoxUseSchemaNameInSql.CheckState = CheckState.Checked;
			checkBoxUseSchemaNameInSql.Location = new Point(256, 350);
			checkBoxUseSchemaNameInSql.Margin = new Padding(3, 2, 3, 2);
			checkBoxUseSchemaNameInSql.Name = "checkBoxUseSchemaNameInSql";
			checkBoxUseSchemaNameInSql.Size = new Size(282, 19);
			checkBoxUseSchemaNameInSql.TabIndex = 28;
			checkBoxUseSchemaNameInSql.Text = "Use Schema Name in Queries (ignored for sqlite)";
			checkBoxUseSchemaNameInSql.UseVisualStyleBackColor = true;
			// 
			// textBoxDbProviderName
			// 
			textBoxDbProviderName.Location = new Point(257, 62);
			textBoxDbProviderName.Margin = new Padding(4);
			textBoxDbProviderName.Name = "textBoxDbProviderName";
			textBoxDbProviderName.Size = new Size(148, 23);
			textBoxDbProviderName.TabIndex = 50;
			// 
			// labelDbProviderName
			// 
			labelDbProviderName.AutoSize = true;
			labelDbProviderName.Location = new Point(4, 58);
			labelDbProviderName.Margin = new Padding(4, 0, 4, 0);
			labelDbProviderName.Name = "labelDbProviderName";
			labelDbProviderName.Size = new Size(98, 15);
			labelDbProviderName.TabIndex = 49;
			labelDbProviderName.Text = "DbProviderName";
			// 
			// labelDatabaseType
			// 
			labelDatabaseType.AutoSize = true;
			labelDatabaseType.Location = new Point(4, 29);
			labelDatabaseType.Margin = new Padding(4, 0, 4, 0);
			labelDatabaseType.Name = "labelDatabaseType";
			labelDatabaseType.Size = new Size(82, 15);
			labelDatabaseType.TabIndex = 44;
			labelDatabaseType.Text = "Database Type";
			// 
			// comboBoxDatabaseType
			// 
			comboBoxDatabaseType.FormattingEnabled = true;
			comboBoxDatabaseType.Location = new Point(257, 33);
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
			textBoxProjectNamespace.Location = new Point(256, 176);
			textBoxProjectNamespace.Margin = new Padding(3, 2, 3, 2);
			textBoxProjectNamespace.Name = "textBoxProjectNamespace";
			textBoxProjectNamespace.Size = new Size(357, 23);
			textBoxProjectNamespace.TabIndex = 40;
			// 
			// labelProjectNamespace
			// 
			labelProjectNamespace.AutoSize = true;
			labelProjectNamespace.Location = new Point(3, 174);
			labelProjectNamespace.Name = "labelProjectNamespace";
			labelProjectNamespace.Size = new Size(109, 15);
			labelProjectNamespace.TabIndex = 39;
			labelProjectNamespace.Text = "Project Namespace";
			// 
			// buttonFolderDialog
			// 
			buttonFolderDialog.Dock = DockStyle.Fill;
			buttonFolderDialog.Location = new Point(762, 205);
			buttonFolderDialog.Margin = new Padding(3, 2, 3, 2);
			buttonFolderDialog.Name = "buttonFolderDialog";
			buttonFolderDialog.Size = new Size(79, 25);
			buttonFolderDialog.TabIndex = 38;
			buttonFolderDialog.Text = "...";
			buttonFolderDialog.UseVisualStyleBackColor = true;
			// 
			// textBoxCodeGenerationFolder
			// 
			textBoxCodeGenerationFolder.Location = new Point(256, 205);
			textBoxCodeGenerationFolder.Margin = new Padding(3, 2, 3, 2);
			textBoxCodeGenerationFolder.Name = "textBoxCodeGenerationFolder";
			textBoxCodeGenerationFolder.Size = new Size(357, 23);
			textBoxCodeGenerationFolder.TabIndex = 37;
			// 
			// labelCodeGenerationFolder
			// 
			labelCodeGenerationFolder.AutoSize = true;
			labelCodeGenerationFolder.Location = new Point(3, 203);
			labelCodeGenerationFolder.Name = "labelCodeGenerationFolder";
			labelCodeGenerationFolder.Size = new Size(132, 15);
			labelCodeGenerationFolder.TabIndex = 36;
			labelCodeGenerationFolder.Text = "Code Generation Folder";
			// 
			// textBoxConnectionString
			// 
			textBoxConnectionString.Location = new Point(256, 89);
			textBoxConnectionString.Margin = new Padding(3, 2, 3, 2);
			textBoxConnectionString.Name = "textBoxConnectionString";
			textBoxConnectionString.Size = new Size(357, 23);
			textBoxConnectionString.TabIndex = 35;
			// 
			// labelConnectionString
			// 
			labelConnectionString.AutoSize = true;
			labelConnectionString.Location = new Point(3, 87);
			labelConnectionString.Name = "labelConnectionString";
			labelConnectionString.Size = new Size(103, 15);
			labelConnectionString.TabIndex = 34;
			labelConnectionString.Text = "Connection String";
			// 
			// textBoxIgnoredSchemaList
			// 
			textBoxIgnoredSchemaList.Location = new Point(256, 234);
			textBoxIgnoredSchemaList.Margin = new Padding(3, 2, 3, 2);
			textBoxIgnoredSchemaList.Name = "textBoxIgnoredSchemaList";
			textBoxIgnoredSchemaList.Size = new Size(357, 23);
			textBoxIgnoredSchemaList.TabIndex = 52;
			// 
			// labelIgnoredSchemaList
			// 
			labelIgnoredSchemaList.AutoSize = true;
			labelIgnoredSchemaList.Location = new Point(3, 232);
			labelIgnoredSchemaList.Name = "labelIgnoredSchemaList";
			labelIgnoredSchemaList.Size = new Size(128, 15);
			labelIgnoredSchemaList.TabIndex = 51;
			labelIgnoredSchemaList.Text = "Ignored Schema List (,)";
			// 
			// checkBoxSequenceCodeGenerate
			// 
			checkBoxSequenceCodeGenerate.AutoSize = true;
			checkBoxSequenceCodeGenerate.Location = new Point(3, 379);
			checkBoxSequenceCodeGenerate.Margin = new Padding(3, 2, 3, 2);
			checkBoxSequenceCodeGenerate.Name = "checkBoxSequenceCodeGenerate";
			checkBoxSequenceCodeGenerate.Size = new Size(158, 19);
			checkBoxSequenceCodeGenerate.TabIndex = 56;
			checkBoxSequenceCodeGenerate.Text = "Sequence Code Generate";
			checkBoxSequenceCodeGenerate.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.Controls.Add(checkBoxUseSchemaNameInNamespaces, 0, 15);
			tableLayoutPanel1.Controls.Add(textBoxConnectionName, 1, 0);
			tableLayoutPanel1.Controls.Add(checkBoxSequenceCodeGenerate, 0, 13);
			tableLayoutPanel1.Controls.Add(checkBoxUseSchemaNameInFolders, 1, 13);
			tableLayoutPanel1.Controls.Add(labelDatabaseType, 0, 1);
			tableLayoutPanel1.Controls.Add(checkBoxStoredProcedureCodeGenerate, 0, 12);
			tableLayoutPanel1.Controls.Add(checkBoxIgnoreSystemTables, 1, 11);
			tableLayoutPanel1.Controls.Add(checkBoxUseSchemaNameInSql, 1, 12);
			tableLayoutPanel1.Controls.Add(comboBoxDatabaseType, 1, 1);
			tableLayoutPanel1.Controls.Add(checkBoxViewCodeGenerate, 0, 11);
			tableLayoutPanel1.Controls.Add(textBoxDbProviderName, 1, 2);
			tableLayoutPanel1.Controls.Add(labelConnectionString, 0, 3);
			tableLayoutPanel1.Controls.Add(textBoxIgnoredSchemaList, 1, 8);
			tableLayoutPanel1.Controls.Add(textBoxConnectionString, 1, 3);
			tableLayoutPanel1.Controls.Add(labelIgnoredSchemaList, 0, 8);
			tableLayoutPanel1.Controls.Add(textBoxProjectNamespace, 1, 6);
			tableLayoutPanel1.Controls.Add(buttonFolderDialog, 2, 7);
			tableLayoutPanel1.Controls.Add(textBoxCodeGenerationFolder, 1, 7);
			tableLayoutPanel1.Controls.Add(labelProjectNamespace, 0, 6);
			tableLayoutPanel1.Controls.Add(labelCodeGenerationFolder, 0, 7);
			tableLayoutPanel1.Controls.Add(checkBoxGenerateNormalClassAgain, 1, 15);
			tableLayoutPanel1.Controls.Add(labelConnectionName, 0, 0);
			tableLayoutPanel1.Controls.Add(labelDbProviderName, 0, 2);
			tableLayoutPanel1.Controls.Add(checkBoxGenerateNormalClassValidationExamples, 2, 15);
			tableLayoutPanel1.Controls.Add(labelAdditionalSchemaList, 0, 9);
			tableLayoutPanel1.Controls.Add(textBoxSchemaList, 1, 9);
			tableLayoutPanel1.Controls.Add(checkBoxOracleForceIdentityToLong, 1, 14);
			tableLayoutPanel1.Controls.Add(checkBoxForceOracleDecimalToIntegersAndDecimal, 0, 14);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 16;
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
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666667F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(844, 466);
			tableLayoutPanel1.TabIndex = 58;
			// 
			// checkBoxUseSchemaNameInNamespaces
			// 
			checkBoxUseSchemaNameInNamespaces.AutoSize = true;
			checkBoxUseSchemaNameInNamespaces.Checked = true;
			checkBoxUseSchemaNameInNamespaces.CheckState = CheckState.Checked;
			checkBoxUseSchemaNameInNamespaces.Dock = DockStyle.Fill;
			checkBoxUseSchemaNameInNamespaces.Location = new Point(3, 428);
			checkBoxUseSchemaNameInNamespaces.Margin = new Padding(3, 2, 3, 2);
			checkBoxUseSchemaNameInNamespaces.Name = "checkBoxUseSchemaNameInNamespaces";
			checkBoxUseSchemaNameInNamespaces.Size = new Size(247, 36);
			checkBoxUseSchemaNameInNamespaces.TabIndex = 60;
			checkBoxUseSchemaNameInNamespaces.Text = "Use Schema Name in Namespaces (ignored for sqlite)";
			checkBoxUseSchemaNameInNamespaces.UseVisualStyleBackColor = true;
			// 
			// checkBoxGenerateNormalClassAgain
			// 
			checkBoxGenerateNormalClassAgain.AutoSize = true;
			checkBoxGenerateNormalClassAgain.Location = new Point(256, 428);
			checkBoxGenerateNormalClassAgain.Margin = new Padding(3, 2, 3, 2);
			checkBoxGenerateNormalClassAgain.Name = "checkBoxGenerateNormalClassAgain";
			checkBoxGenerateNormalClassAgain.Size = new Size(154, 19);
			checkBoxGenerateNormalClassAgain.TabIndex = 32;
			checkBoxGenerateNormalClassAgain.Text = "Create Main Class Again";
			checkBoxGenerateNormalClassAgain.UseVisualStyleBackColor = true;
			// 
			// checkBoxGenerateNormalClassValidationExamples
			// 
			checkBoxGenerateNormalClassValidationExamples.AutoSize = true;
			checkBoxGenerateNormalClassValidationExamples.Location = new Point(762, 428);
			checkBoxGenerateNormalClassValidationExamples.Margin = new Padding(3, 2, 3, 2);
			checkBoxGenerateNormalClassValidationExamples.Name = "checkBoxGenerateNormalClassValidationExamples";
			checkBoxGenerateNormalClassValidationExamples.Size = new Size(79, 19);
			checkBoxGenerateNormalClassValidationExamples.TabIndex = 33;
			checkBoxGenerateNormalClassValidationExamples.Text = "Create Main Validation Class";
			checkBoxGenerateNormalClassValidationExamples.UseVisualStyleBackColor = true;
			// 
			// labelAdditionalSchemaList
			// 
			labelAdditionalSchemaList.AutoSize = true;
			labelAdditionalSchemaList.Location = new Point(3, 261);
			labelAdditionalSchemaList.Name = "labelAdditionalSchemaList";
			labelAdditionalSchemaList.Size = new Size(84, 15);
			labelAdditionalSchemaList.TabIndex = 58;
			labelAdditionalSchemaList.Text = "Schema List (,)";
			// 
			// textBoxSchemaList
			// 
			textBoxSchemaList.Location = new Point(256, 264);
			textBoxSchemaList.Name = "textBoxSchemaList";
			textBoxSchemaList.Size = new Size(357, 23);
			textBoxSchemaList.TabIndex = 59;
			// 
			// checkBoxOracleForceIdentityToLong
			// 
			checkBoxOracleForceIdentityToLong.AutoSize = true;
			checkBoxOracleForceIdentityToLong.Location = new Point(256, 409);
			checkBoxOracleForceIdentityToLong.Name = "checkBoxOracleForceIdentityToLong";
			checkBoxOracleForceIdentityToLong.Size = new Size(180, 14);
			checkBoxOracleForceIdentityToLong.TabIndex = 61;
			checkBoxOracleForceIdentityToLong.Text = "Oracle Force Identity To Long";
			checkBoxOracleForceIdentityToLong.UseVisualStyleBackColor = true;
			// 
			// checkBoxForceOracleDecimalToIntegersAndDecimal
			// 
			checkBoxForceOracleDecimalToIntegersAndDecimal.AutoSize = true;
			checkBoxForceOracleDecimalToIntegersAndDecimal.Location = new Point(3, 409);
			checkBoxForceOracleDecimalToIntegersAndDecimal.Name = "checkBoxForceOracleDecimalToIntegersAndDecimal";
			checkBoxForceOracleDecimalToIntegersAndDecimal.Size = new Size(247, 14);
			checkBoxForceOracleDecimalToIntegersAndDecimal.TabIndex = 62;
			checkBoxForceOracleDecimalToIntegersAndDecimal.Text = "Force Oracle Decimal To Integers And Decimal";
			checkBoxForceOracleDecimalToIntegersAndDecimal.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.TextBox textBoxDbProviderName;
        private System.Windows.Forms.Label labelDbProviderName;
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
        private System.Windows.Forms.TextBox textBoxIgnoredSchemaList;
        private System.Windows.Forms.Label labelIgnoredSchemaList;
        private System.Windows.Forms.CheckBox checkBoxSequenceCodeGenerate;
        private System.Windows.Forms.ToolTip toolTipCodeGenerationOptions;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label labelAdditionalSchemaList;
        private TextBox textBoxSchemaList;
		private CheckBox checkBoxGenerateNormalClassAgain;
		private CheckBox checkBoxGenerateNormalClassValidationExamples;
		private CheckBox checkBoxUseSchemaNameInNamespaces;
		private CheckBox checkBoxOracleForceIdentityToLong;
		private CheckBox checkBoxForceOracleDecimalToIntegersAndDecimal;
	}
}
