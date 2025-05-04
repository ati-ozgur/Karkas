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
			checkBoxUseSchemaNameInNamespaces = new CheckBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			labelAdditionalSchemaList = new Label();
			textBoxSchemaList = new TextBox();
			checkBoxOracleForceNumericPKFKColumnsToLong = new CheckBox();
			checkBoxForceOracleDecimalToIntegersAndDecimal = new CheckBox();
			checkBoxGenerateForeignKeyQueries = new CheckBox();
			checkBoxGenerateNormalClassAgain = new CheckBox();
			checkBoxGenerateNormalClassValidationExamples = new CheckBox();
			checkBoxUseFileScopedNamespace = new CheckBox();
			checkBoxUseGlobalUsings = new CheckBox();
			checkBoxUseQuotesInQueries = new CheckBox();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// checkBoxIgnoreSystemTables
			// 
			checkBoxIgnoreSystemTables.AutoSize = true;
			checkBoxIgnoreSystemTables.Checked = true;
			checkBoxIgnoreSystemTables.CheckState = CheckState.Checked;
			checkBoxIgnoreSystemTables.Location = new Point(3, 417);
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
			checkBoxStoredProcedureCodeGenerate.Location = new Point(3, 299);
			checkBoxStoredProcedureCodeGenerate.Margin = new Padding(3, 2, 3, 2);
			checkBoxStoredProcedureCodeGenerate.Name = "checkBoxStoredProcedureCodeGenerate";
			checkBoxStoredProcedureCodeGenerate.Size = new Size(172, 19);
			checkBoxStoredProcedureCodeGenerate.TabIndex = 31;
			checkBoxStoredProcedureCodeGenerate.Text = "Generate Stored Procedures";
			checkBoxStoredProcedureCodeGenerate.UseVisualStyleBackColor = true;
			// 
			// checkBoxViewCodeGenerate
			// 
			checkBoxViewCodeGenerate.AutoSize = true;
			checkBoxViewCodeGenerate.Location = new Point(3, 266);
			checkBoxViewCodeGenerate.Margin = new Padding(3, 2, 3, 2);
			checkBoxViewCodeGenerate.Name = "checkBoxViewCodeGenerate";
			checkBoxViewCodeGenerate.Size = new Size(106, 19);
			checkBoxViewCodeGenerate.TabIndex = 30;
			checkBoxViewCodeGenerate.Text = "Generate Views";
			checkBoxViewCodeGenerate.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseSchemaNameInFolders
			// 
			checkBoxUseSchemaNameInFolders.AutoSize = true;
			checkBoxUseSchemaNameInFolders.Dock = DockStyle.Fill;
			checkBoxUseSchemaNameInFolders.Location = new Point(256, 332);
			checkBoxUseSchemaNameInFolders.Margin = new Padding(3, 2, 3, 2);
			checkBoxUseSchemaNameInFolders.Name = "checkBoxUseSchemaNameInFolders";
			checkBoxUseSchemaNameInFolders.Size = new Size(331, 29);
			checkBoxUseSchemaNameInFolders.TabIndex = 29;
			checkBoxUseSchemaNameInFolders.Text = "Use Schema Name in Folders";
			toolTipCodeGenerationOptions.SetToolTip(checkBoxUseSchemaNameInFolders, " (ignored for sqlite)");
			checkBoxUseSchemaNameInFolders.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseSchemaNameInSql
			// 
			checkBoxUseSchemaNameInSql.AutoSize = true;
			checkBoxUseSchemaNameInSql.Location = new Point(256, 266);
			checkBoxUseSchemaNameInSql.Margin = new Padding(3, 2, 3, 2);
			checkBoxUseSchemaNameInSql.Name = "checkBoxUseSchemaNameInSql";
			checkBoxUseSchemaNameInSql.Size = new Size(181, 19);
			checkBoxUseSchemaNameInSql.TabIndex = 28;
			checkBoxUseSchemaNameInSql.Text = "Use Schema Name in Queries";
			toolTipCodeGenerationOptions.SetToolTip(checkBoxUseSchemaNameInSql, "(ignored for sqlite)");
			checkBoxUseSchemaNameInSql.UseVisualStyleBackColor = true;
			// 
			// textBoxDbProviderName
			// 
			textBoxDbProviderName.Location = new Point(257, 70);
			textBoxDbProviderName.Margin = new Padding(4);
			textBoxDbProviderName.Name = "textBoxDbProviderName";
			textBoxDbProviderName.Size = new Size(148, 23);
			textBoxDbProviderName.TabIndex = 50;
			// 
			// labelDbProviderName
			// 
			labelDbProviderName.AutoSize = true;
			labelDbProviderName.Location = new Point(4, 66);
			labelDbProviderName.Margin = new Padding(4, 0, 4, 0);
			labelDbProviderName.Name = "labelDbProviderName";
			labelDbProviderName.Size = new Size(98, 15);
			labelDbProviderName.TabIndex = 49;
			labelDbProviderName.Text = "DbProviderName";
			// 
			// labelDatabaseType
			// 
			labelDatabaseType.AutoSize = true;
			labelDatabaseType.Location = new Point(4, 33);
			labelDatabaseType.Margin = new Padding(4, 0, 4, 0);
			labelDatabaseType.Name = "labelDatabaseType";
			labelDatabaseType.Size = new Size(82, 15);
			labelDatabaseType.TabIndex = 44;
			labelDatabaseType.Text = "Database Type";
			// 
			// comboBoxDatabaseType
			// 
			comboBoxDatabaseType.FormattingEnabled = true;
			comboBoxDatabaseType.Location = new Point(257, 37);
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
			textBoxProjectNamespace.Location = new Point(256, 134);
			textBoxProjectNamespace.Margin = new Padding(3, 2, 3, 2);
			textBoxProjectNamespace.Name = "textBoxProjectNamespace";
			textBoxProjectNamespace.Size = new Size(331, 23);
			textBoxProjectNamespace.TabIndex = 40;
			// 
			// labelProjectNamespace
			// 
			labelProjectNamespace.AutoSize = true;
			labelProjectNamespace.Location = new Point(3, 132);
			labelProjectNamespace.Name = "labelProjectNamespace";
			labelProjectNamespace.Size = new Size(109, 15);
			labelProjectNamespace.TabIndex = 39;
			labelProjectNamespace.Text = "Project Namespace";
			// 
			// buttonFolderDialog
			// 
			buttonFolderDialog.Dock = DockStyle.Fill;
			buttonFolderDialog.Location = new Point(593, 167);
			buttonFolderDialog.Margin = new Padding(3, 2, 3, 2);
			buttonFolderDialog.Name = "buttonFolderDialog";
			buttonFolderDialog.Size = new Size(248, 29);
			buttonFolderDialog.TabIndex = 38;
			buttonFolderDialog.Text = "...";
			buttonFolderDialog.UseVisualStyleBackColor = true;
			// 
			// textBoxCodeGenerationFolder
			// 
			textBoxCodeGenerationFolder.Location = new Point(256, 167);
			textBoxCodeGenerationFolder.Margin = new Padding(3, 2, 3, 2);
			textBoxCodeGenerationFolder.Name = "textBoxCodeGenerationFolder";
			textBoxCodeGenerationFolder.Size = new Size(331, 23);
			textBoxCodeGenerationFolder.TabIndex = 37;
			// 
			// labelCodeGenerationFolder
			// 
			labelCodeGenerationFolder.AutoSize = true;
			labelCodeGenerationFolder.Location = new Point(3, 165);
			labelCodeGenerationFolder.Name = "labelCodeGenerationFolder";
			labelCodeGenerationFolder.Size = new Size(132, 15);
			labelCodeGenerationFolder.TabIndex = 36;
			labelCodeGenerationFolder.Text = "Code Generation Folder";
			// 
			// textBoxConnectionString
			// 
			textBoxConnectionString.Location = new Point(256, 101);
			textBoxConnectionString.Margin = new Padding(3, 2, 3, 2);
			textBoxConnectionString.Name = "textBoxConnectionString";
			textBoxConnectionString.Size = new Size(331, 23);
			textBoxConnectionString.TabIndex = 35;
			// 
			// labelConnectionString
			// 
			labelConnectionString.AutoSize = true;
			labelConnectionString.Location = new Point(3, 99);
			labelConnectionString.Name = "labelConnectionString";
			labelConnectionString.Size = new Size(103, 15);
			labelConnectionString.TabIndex = 34;
			labelConnectionString.Text = "Connection String";
			// 
			// textBoxIgnoredSchemaList
			// 
			textBoxIgnoredSchemaList.Location = new Point(256, 200);
			textBoxIgnoredSchemaList.Margin = new Padding(3, 2, 3, 2);
			textBoxIgnoredSchemaList.Name = "textBoxIgnoredSchemaList";
			textBoxIgnoredSchemaList.Size = new Size(331, 23);
			textBoxIgnoredSchemaList.TabIndex = 52;
			// 
			// labelIgnoredSchemaList
			// 
			labelIgnoredSchemaList.AutoSize = true;
			labelIgnoredSchemaList.Location = new Point(3, 198);
			labelIgnoredSchemaList.Name = "labelIgnoredSchemaList";
			labelIgnoredSchemaList.Size = new Size(128, 15);
			labelIgnoredSchemaList.TabIndex = 51;
			labelIgnoredSchemaList.Text = "Ignored Schema List (,)";
			// 
			// checkBoxSequenceCodeGenerate
			// 
			checkBoxSequenceCodeGenerate.AutoSize = true;
			checkBoxSequenceCodeGenerate.Location = new Point(3, 332);
			checkBoxSequenceCodeGenerate.Margin = new Padding(3, 2, 3, 2);
			checkBoxSequenceCodeGenerate.Name = "checkBoxSequenceCodeGenerate";
			checkBoxSequenceCodeGenerate.Size = new Size(132, 19);
			checkBoxSequenceCodeGenerate.TabIndex = 56;
			checkBoxSequenceCodeGenerate.Text = "Generate Sequences";
			checkBoxSequenceCodeGenerate.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseSchemaNameInNamespaces
			// 
			checkBoxUseSchemaNameInNamespaces.AutoSize = true;
			checkBoxUseSchemaNameInNamespaces.Dock = DockStyle.Fill;
			checkBoxUseSchemaNameInNamespaces.Location = new Point(256, 299);
			checkBoxUseSchemaNameInNamespaces.Margin = new Padding(3, 2, 3, 2);
			checkBoxUseSchemaNameInNamespaces.Name = "checkBoxUseSchemaNameInNamespaces";
			checkBoxUseSchemaNameInNamespaces.Size = new Size(331, 29);
			checkBoxUseSchemaNameInNamespaces.TabIndex = 60;
			checkBoxUseSchemaNameInNamespaces.Text = "Use Schema  in Namespaces";
			toolTipCodeGenerationOptions.SetToolTip(checkBoxUseSchemaNameInNamespaces, "(ignored for sqlite)");
			checkBoxUseSchemaNameInNamespaces.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
			tableLayoutPanel1.Controls.Add(labelConnectionName, 0, 0);
			tableLayoutPanel1.Controls.Add(labelDatabaseType, 0, 1);
			tableLayoutPanel1.Controls.Add(labelDbProviderName, 0, 2);
			tableLayoutPanel1.Controls.Add(labelConnectionString, 0, 3);
			tableLayoutPanel1.Controls.Add(labelProjectNamespace, 0, 4);
			tableLayoutPanel1.Controls.Add(labelCodeGenerationFolder, 0, 5);
			tableLayoutPanel1.Controls.Add(labelIgnoredSchemaList, 0, 6);
			tableLayoutPanel1.Controls.Add(labelAdditionalSchemaList, 0, 7);
			tableLayoutPanel1.Controls.Add(textBoxConnectionName, 1, 0);
			tableLayoutPanel1.Controls.Add(comboBoxDatabaseType, 1, 1);
			tableLayoutPanel1.Controls.Add(textBoxDbProviderName, 1, 2);
			tableLayoutPanel1.Controls.Add(textBoxConnectionString, 1, 3);
			tableLayoutPanel1.Controls.Add(textBoxProjectNamespace, 1, 4);
			tableLayoutPanel1.Controls.Add(textBoxCodeGenerationFolder, 1, 5);
			tableLayoutPanel1.Controls.Add(textBoxIgnoredSchemaList, 1, 6);
			tableLayoutPanel1.Controls.Add(textBoxSchemaList, 1, 7);
			tableLayoutPanel1.Controls.Add(buttonFolderDialog, 2, 5);
			tableLayoutPanel1.Controls.Add(checkBoxViewCodeGenerate, 0, 8);
			tableLayoutPanel1.Controls.Add(checkBoxStoredProcedureCodeGenerate, 0, 9);
			tableLayoutPanel1.Controls.Add(checkBoxSequenceCodeGenerate, 0, 10);
			tableLayoutPanel1.Controls.Add(checkBoxUseSchemaNameInSql, 1, 8);
			tableLayoutPanel1.Controls.Add(checkBoxUseSchemaNameInNamespaces, 1, 9);
			tableLayoutPanel1.Controls.Add(checkBoxUseSchemaNameInFolders, 1, 10);
			tableLayoutPanel1.Controls.Add(checkBoxOracleForceNumericPKFKColumnsToLong, 2, 8);
			tableLayoutPanel1.Controls.Add(checkBoxForceOracleDecimalToIntegersAndDecimal, 2, 9);
			tableLayoutPanel1.Controls.Add(checkBoxGenerateForeignKeyQueries, 2, 10);
			tableLayoutPanel1.Controls.Add(checkBoxGenerateNormalClassAgain, 0, 11);
			tableLayoutPanel1.Controls.Add(checkBoxGenerateNormalClassValidationExamples, 0, 12);
			tableLayoutPanel1.Controls.Add(checkBoxIgnoreSystemTables, 0, 13);
			tableLayoutPanel1.Controls.Add(checkBoxUseFileScopedNamespace, 1, 11);
			tableLayoutPanel1.Controls.Add(checkBoxUseGlobalUsings, 1, 12);
			tableLayoutPanel1.Controls.Add(checkBoxUseQuotesInQueries, 1, 13);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 15;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.493659F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.856583F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.856583F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.856583F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(844, 466);
			tableLayoutPanel1.TabIndex = 58;
			// 
			// labelAdditionalSchemaList
			// 
			labelAdditionalSchemaList.AutoSize = true;
			labelAdditionalSchemaList.Location = new Point(3, 231);
			labelAdditionalSchemaList.Name = "labelAdditionalSchemaList";
			labelAdditionalSchemaList.Size = new Size(84, 15);
			labelAdditionalSchemaList.TabIndex = 58;
			labelAdditionalSchemaList.Text = "Schema List (,)";
			// 
			// textBoxSchemaList
			// 
			textBoxSchemaList.Location = new Point(256, 234);
			textBoxSchemaList.Name = "textBoxSchemaList";
			textBoxSchemaList.Size = new Size(331, 23);
			textBoxSchemaList.TabIndex = 59;
			// 
			// checkBoxOracleForceNumericPKFKColumnsToLong
			// 
			checkBoxOracleForceNumericPKFKColumnsToLong.AutoSize = true;
			checkBoxOracleForceNumericPKFKColumnsToLong.Location = new Point(593, 267);
			checkBoxOracleForceNumericPKFKColumnsToLong.Name = "checkBoxOracleForceNumericPKFKColumnsToLong";
			checkBoxOracleForceNumericPKFKColumnsToLong.Size = new Size(193, 19);
			checkBoxOracleForceNumericPKFKColumnsToLong.TabIndex = 61;
			checkBoxOracleForceNumericPKFKColumnsToLong.Text = "Oracle Force PK and FK To Long";
			checkBoxOracleForceNumericPKFKColumnsToLong.UseVisualStyleBackColor = true;
			// 
			// checkBoxForceOracleDecimalToIntegersAndDecimal
			// 
			checkBoxForceOracleDecimalToIntegersAndDecimal.AutoSize = true;
			checkBoxForceOracleDecimalToIntegersAndDecimal.Location = new Point(593, 300);
			checkBoxForceOracleDecimalToIntegersAndDecimal.Name = "checkBoxForceOracleDecimalToIntegersAndDecimal";
			checkBoxForceOracleDecimalToIntegersAndDecimal.Size = new Size(195, 19);
			checkBoxForceOracleDecimalToIntegersAndDecimal.TabIndex = 62;
			checkBoxForceOracleDecimalToIntegersAndDecimal.Text = "Force Oracle Decimal To Int-Dec";
			checkBoxForceOracleDecimalToIntegersAndDecimal.UseVisualStyleBackColor = true;
			// 
			// checkBoxGenerateForeignKeyQueries
			// 
			checkBoxGenerateForeignKeyQueries.AutoSize = true;
			checkBoxGenerateForeignKeyQueries.Location = new Point(593, 333);
			checkBoxGenerateForeignKeyQueries.Name = "checkBoxGenerateForeignKeyQueries";
			checkBoxGenerateForeignKeyQueries.Size = new Size(181, 19);
			checkBoxGenerateForeignKeyQueries.TabIndex = 63;
			checkBoxGenerateForeignKeyQueries.Text = "Generate Foreign Key Queries";
			checkBoxGenerateForeignKeyQueries.UseVisualStyleBackColor = true;
			// 
			// checkBoxGenerateNormalClassAgain
			// 
			checkBoxGenerateNormalClassAgain.AutoSize = true;
			checkBoxGenerateNormalClassAgain.Location = new Point(3, 365);
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
			checkBoxGenerateNormalClassValidationExamples.Location = new Point(3, 391);
			checkBoxGenerateNormalClassValidationExamples.Margin = new Padding(3, 2, 3, 2);
			checkBoxGenerateNormalClassValidationExamples.Name = "checkBoxGenerateNormalClassValidationExamples";
			checkBoxGenerateNormalClassValidationExamples.Size = new Size(175, 19);
			checkBoxGenerateNormalClassValidationExamples.TabIndex = 33;
			checkBoxGenerateNormalClassValidationExamples.Text = "Create Main Validation Class";
			checkBoxGenerateNormalClassValidationExamples.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseFileScopedNamespace
			// 
			checkBoxUseFileScopedNamespace.AutoSize = true;
			checkBoxUseFileScopedNamespace.Location = new Point(256, 366);
			checkBoxUseFileScopedNamespace.Name = "checkBoxUseFileScopedNamespace";
			checkBoxUseFileScopedNamespace.Size = new Size(173, 19);
			checkBoxUseFileScopedNamespace.TabIndex = 64;
			checkBoxUseFileScopedNamespace.Text = "Use File Scoped Namespace";
			checkBoxUseFileScopedNamespace.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseGlobalUsings
			// 
			checkBoxUseGlobalUsings.AutoSize = true;
			checkBoxUseGlobalUsings.Location = new Point(256, 392);
			checkBoxUseGlobalUsings.Name = "checkBoxUseGlobalUsings";
			checkBoxUseGlobalUsings.Size = new Size(120, 19);
			checkBoxUseGlobalUsings.TabIndex = 65;
			checkBoxUseGlobalUsings.Text = "Use Global Usings";
			checkBoxUseGlobalUsings.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseQuotesInQueries
			// 
			checkBoxUseQuotesInQueries.AutoSize = true;
			checkBoxUseQuotesInQueries.Location = new Point(256, 418);
			checkBoxUseQuotesInQueries.Name = "checkBoxUseQuotesInQueries";
			checkBoxUseQuotesInQueries.Size = new Size(142, 19);
			checkBoxUseQuotesInQueries.TabIndex = 66;
			checkBoxUseQuotesInQueries.Text = "Use Quotes In Queries";
			checkBoxUseQuotesInQueries.UseVisualStyleBackColor = true;
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
		private CheckBox checkBoxOracleForceNumericPKFKColumnsToLong;
		private CheckBox checkBoxForceOracleDecimalToIntegersAndDecimal;
		private CheckBox checkBoxUseSchemaNameInNamespaces;
		private CheckBox checkBoxGenerateNormalClassAgain;
		private CheckBox checkBoxGenerateNormalClassValidationExamples;
		private CheckBox checkBoxGenerateForeignKeyQueries;
		private CheckBox checkBoxUseFileScopedNamespace;
		private CheckBox checkBoxUseGlobalUsings;
		private CheckBox checkBoxUseQuotesInQueries;
	}
}
