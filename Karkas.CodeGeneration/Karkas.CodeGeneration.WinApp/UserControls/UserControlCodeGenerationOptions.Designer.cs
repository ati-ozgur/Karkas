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
            this.components = new System.ComponentModel.Container();
            this.checkBoxIgnoreSystemTables = new System.Windows.Forms.CheckBox();
            this.checkBoxStoredProcedureCodeGenerate = new System.Windows.Forms.CheckBox();
            this.checkBoxViewCodeGenerate = new System.Windows.Forms.CheckBox();
            this.checkBoxUseSchemaNameInFolders = new System.Windows.Forms.CheckBox();
            this.checkBoxUseSchemaNameInSql = new System.Windows.Forms.CheckBox();
            this.checkBoxCreateMainClassAgain = new System.Windows.Forms.CheckBox();
            this.textBoxDbProviderName = new System.Windows.Forms.TextBox();
            this.labelDbProviderName = new System.Windows.Forms.Label();
            this.textBoxDatabaseNamePhysical = new System.Windows.Forms.TextBox();
            this.labelDatabaseNamePhysical = new System.Windows.Forms.Label();
            this.textBoxDatabaseNameLogical = new System.Windows.Forms.TextBox();
            this.labelDatabaseNameLogical = new System.Windows.Forms.Label();
            this.labelDatabaseType = new System.Windows.Forms.Label();
            this.comboBoxDatabaseType = new System.Windows.Forms.ComboBox();
            this.textBoxConnectionName = new System.Windows.Forms.TextBox();
            this.labelConnectionName = new System.Windows.Forms.Label();
            this.textBoxProjectNamespace = new System.Windows.Forms.TextBox();
            this.labelProjectNamespace = new System.Windows.Forms.Label();
            this.buttonFolderDialog = new System.Windows.Forms.Button();
            this.textBoxCodeGenerationFolder = new System.Windows.Forms.TextBox();
            this.labelCodeGenerationFolder = new System.Windows.Forms.Label();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.textBoxAbbrevationsAsString = new System.Windows.Forms.TextBox();
            this.labelAbbrevationsAsString = new System.Windows.Forms.Label();
            this.textBoxIgnoredSchemaList = new System.Windows.Forms.TextBox();
            this.labelIgnoredSchemaList = new System.Windows.Forms.Label();
            this.checkBoxCreateMainClassValidationExamples = new System.Windows.Forms.CheckBox();
            this.checkBoxSequenceCodeGenerate = new System.Windows.Forms.CheckBox();
            this.toolTipCodeGenerationOptions = new System.Windows.Forms.ToolTip(this.components);
            this.buttonKisaltmalar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAdditionalSchemaList = new System.Windows.Forms.Label();
            this.textBoxAdditionalSchemaList = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxIgnoreSystemTables
            // 
            this.checkBoxIgnoreSystemTables.AutoSize = true;
            this.checkBoxIgnoreSystemTables.Checked = true;
            this.checkBoxIgnoreSystemTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIgnoreSystemTables.Location = new System.Drawing.Point(256, 343);
            this.checkBoxIgnoreSystemTables.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxIgnoreSystemTables.Name = "checkBoxIgnoreSystemTables";
            this.checkBoxIgnoreSystemTables.Size = new System.Drawing.Size(155, 19);
            this.checkBoxIgnoreSystemTables.TabIndex = 27;
            this.checkBoxIgnoreSystemTables.Text = "Ignore sys/system tables";
            this.checkBoxIgnoreSystemTables.UseVisualStyleBackColor = true;
            // 
            // checkBoxStoredProcedureCodeGenerate
            // 
            this.checkBoxStoredProcedureCodeGenerate.AutoSize = true;
            this.checkBoxStoredProcedureCodeGenerate.Location = new System.Drawing.Point(3, 374);
            this.checkBoxStoredProcedureCodeGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxStoredProcedureCodeGenerate.Name = "checkBoxStoredProcedureCodeGenerate";
            this.checkBoxStoredProcedureCodeGenerate.Size = new System.Drawing.Size(198, 19);
            this.checkBoxStoredProcedureCodeGenerate.TabIndex = 31;
            this.checkBoxStoredProcedureCodeGenerate.Text = "Stored Procedure Code Generate";
            this.checkBoxStoredProcedureCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // checkBoxViewCodeGenerate
            // 
            this.checkBoxViewCodeGenerate.AutoSize = true;
            this.checkBoxViewCodeGenerate.Location = new System.Drawing.Point(3, 343);
            this.checkBoxViewCodeGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxViewCodeGenerate.Name = "checkBoxViewCodeGenerate";
            this.checkBoxViewCodeGenerate.Size = new System.Drawing.Size(132, 19);
            this.checkBoxViewCodeGenerate.TabIndex = 30;
            this.checkBoxViewCodeGenerate.Text = "View Code Generate";
            this.checkBoxViewCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseSchemaNameInFolders
            // 
            this.checkBoxUseSchemaNameInFolders.AutoSize = true;
            this.checkBoxUseSchemaNameInFolders.Checked = true;
            this.checkBoxUseSchemaNameInFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseSchemaNameInFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUseSchemaNameInFolders.Location = new System.Drawing.Point(256, 405);
            this.checkBoxUseSchemaNameInFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxUseSchemaNameInFolders.Name = "checkBoxUseSchemaNameInFolders";
            this.checkBoxUseSchemaNameInFolders.Size = new System.Drawing.Size(500, 27);
            this.checkBoxUseSchemaNameInFolders.TabIndex = 29;
            this.checkBoxUseSchemaNameInFolders.Text = "Use Schema Name in Folders";
            this.checkBoxUseSchemaNameInFolders.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseSchemaNameInSql
            // 
            this.checkBoxUseSchemaNameInSql.AutoSize = true;
            this.checkBoxUseSchemaNameInSql.Checked = true;
            this.checkBoxUseSchemaNameInSql.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseSchemaNameInSql.Location = new System.Drawing.Point(256, 374);
            this.checkBoxUseSchemaNameInSql.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxUseSchemaNameInSql.Name = "checkBoxUseSchemaNameInSql";
            this.checkBoxUseSchemaNameInSql.Size = new System.Drawing.Size(181, 19);
            this.checkBoxUseSchemaNameInSql.TabIndex = 28;
            this.checkBoxUseSchemaNameInSql.Text = "Use Schema Name in Queries";
            this.checkBoxUseSchemaNameInSql.UseVisualStyleBackColor = true;
            // 
            // checkBoxCreateMainClassAgain
            // 
            this.checkBoxCreateMainClassAgain.AutoSize = true;
            this.checkBoxCreateMainClassAgain.Location = new System.Drawing.Point(256, 436);
            this.checkBoxCreateMainClassAgain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxCreateMainClassAgain.Name = "checkBoxCreateMainClassAgain";
            this.checkBoxCreateMainClassAgain.Size = new System.Drawing.Size(154, 19);
            this.checkBoxCreateMainClassAgain.TabIndex = 32;
            this.checkBoxCreateMainClassAgain.Text = "Create Main Class Again";
            this.checkBoxCreateMainClassAgain.UseVisualStyleBackColor = true;
            // 
            // textBoxDbProviderName
            // 
            this.textBoxDbProviderName.Location = new System.Drawing.Point(257, 66);
            this.textBoxDbProviderName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDbProviderName.Name = "textBoxDbProviderName";
            this.textBoxDbProviderName.Size = new System.Drawing.Size(148, 23);
            this.textBoxDbProviderName.TabIndex = 50;
            // 
            // labelDbProviderName
            // 
            this.labelDbProviderName.AutoSize = true;
            this.labelDbProviderName.Location = new System.Drawing.Point(4, 62);
            this.labelDbProviderName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDbProviderName.Name = "labelDbProviderName";
            this.labelDbProviderName.Size = new System.Drawing.Size(98, 15);
            this.labelDbProviderName.TabIndex = 49;
            this.labelDbProviderName.Text = "DbProviderName";
            // 
            // textBoxDatabaseNamePhysical
            // 
            this.textBoxDatabaseNamePhysical.Enabled = false;
            this.textBoxDatabaseNamePhysical.Location = new System.Drawing.Point(257, 159);
            this.textBoxDatabaseNamePhysical.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseNamePhysical.Name = "textBoxDatabaseNamePhysical";
            this.textBoxDatabaseNamePhysical.Size = new System.Drawing.Size(148, 23);
            this.textBoxDatabaseNamePhysical.TabIndex = 48;
            // 
            // labelDatabaseNamePhysical
            // 
            this.labelDatabaseNamePhysical.AutoSize = true;
            this.labelDatabaseNamePhysical.Location = new System.Drawing.Point(3, 155);
            this.labelDatabaseNamePhysical.Name = "labelDatabaseNamePhysical";
            this.labelDatabaseNamePhysical.Size = new System.Drawing.Size(136, 15);
            this.labelDatabaseNamePhysical.TabIndex = 47;
            this.labelDatabaseNamePhysical.Text = "Database Name Physical";
            // 
            // textBoxDatabaseNameLogical
            // 
            this.textBoxDatabaseNameLogical.Location = new System.Drawing.Point(257, 128);
            this.textBoxDatabaseNameLogical.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseNameLogical.Name = "textBoxDatabaseNameLogical";
            this.textBoxDatabaseNameLogical.Size = new System.Drawing.Size(148, 23);
            this.textBoxDatabaseNameLogical.TabIndex = 46;
            this.toolTipCodeGenerationOptions.SetToolTip(this.textBoxDatabaseNameLogical, "Veritabanı ismi olarak fiziksel isim yerine\r\nmantıksal bir isim vermek için kulla" +
        "nılır.\r\nBu mantıksal isim app.config/web.config\r\niçinde bağlantı çekmek için kul" +
        "lanılır.\r\n");
            // 
            // labelDatabaseNameLogical
            // 
            this.labelDatabaseNameLogical.AutoSize = true;
            this.labelDatabaseNameLogical.Location = new System.Drawing.Point(3, 124);
            this.labelDatabaseNameLogical.Name = "labelDatabaseNameLogical";
            this.labelDatabaseNameLogical.Size = new System.Drawing.Size(131, 15);
            this.labelDatabaseNameLogical.TabIndex = 45;
            this.labelDatabaseNameLogical.Text = "Database Name Logical";
            // 
            // labelDatabaseType
            // 
            this.labelDatabaseType.AutoSize = true;
            this.labelDatabaseType.Location = new System.Drawing.Point(4, 31);
            this.labelDatabaseType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDatabaseType.Name = "labelDatabaseType";
            this.labelDatabaseType.Size = new System.Drawing.Size(82, 15);
            this.labelDatabaseType.TabIndex = 44;
            this.labelDatabaseType.Text = "Database Type";
            // 
            // comboBoxDatabaseType
            // 
            this.comboBoxDatabaseType.FormattingEnabled = true;
            this.comboBoxDatabaseType.Location = new System.Drawing.Point(257, 35);
            this.comboBoxDatabaseType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDatabaseType.Name = "comboBoxDatabaseType";
            this.comboBoxDatabaseType.Size = new System.Drawing.Size(140, 23);
            this.comboBoxDatabaseType.TabIndex = 43;
            // 
            // textBoxConnectionName
            // 
            this.textBoxConnectionName.Location = new System.Drawing.Point(257, 4);
            this.textBoxConnectionName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConnectionName.Name = "textBoxConnectionName";
            this.textBoxConnectionName.Size = new System.Drawing.Size(148, 23);
            this.textBoxConnectionName.TabIndex = 42;
            // 
            // labelConnectionName
            // 
            this.labelConnectionName.AutoSize = true;
            this.labelConnectionName.Location = new System.Drawing.Point(3, 0);
            this.labelConnectionName.Name = "labelConnectionName";
            this.labelConnectionName.Size = new System.Drawing.Size(104, 15);
            this.labelConnectionName.TabIndex = 41;
            this.labelConnectionName.Text = "Connection Name";
            // 
            // textBoxProjectNamespace
            // 
            this.textBoxProjectNamespace.Location = new System.Drawing.Point(256, 188);
            this.textBoxProjectNamespace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxProjectNamespace.Name = "textBoxProjectNamespace";
            this.textBoxProjectNamespace.Size = new System.Drawing.Size(357, 23);
            this.textBoxProjectNamespace.TabIndex = 40;
            // 
            // labelProjectNamespace
            // 
            this.labelProjectNamespace.AutoSize = true;
            this.labelProjectNamespace.Location = new System.Drawing.Point(3, 186);
            this.labelProjectNamespace.Name = "labelProjectNamespace";
            this.labelProjectNamespace.Size = new System.Drawing.Size(109, 15);
            this.labelProjectNamespace.TabIndex = 39;
            this.labelProjectNamespace.Text = "Project Namespace";
            // 
            // buttonFolderDialog
            // 
            this.buttonFolderDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFolderDialog.Location = new System.Drawing.Point(762, 219);
            this.buttonFolderDialog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFolderDialog.Name = "buttonFolderDialog";
            this.buttonFolderDialog.Size = new System.Drawing.Size(79, 27);
            this.buttonFolderDialog.TabIndex = 38;
            this.buttonFolderDialog.Text = "...";
            this.buttonFolderDialog.UseVisualStyleBackColor = true;
            // 
            // textBoxCodeGenerationFolder
            // 
            this.textBoxCodeGenerationFolder.Location = new System.Drawing.Point(256, 219);
            this.textBoxCodeGenerationFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCodeGenerationFolder.Name = "textBoxCodeGenerationFolder";
            this.textBoxCodeGenerationFolder.Size = new System.Drawing.Size(357, 23);
            this.textBoxCodeGenerationFolder.TabIndex = 37;
            // 
            // labelCodeGenerationFolder
            // 
            this.labelCodeGenerationFolder.AutoSize = true;
            this.labelCodeGenerationFolder.Location = new System.Drawing.Point(3, 217);
            this.labelCodeGenerationFolder.Name = "labelCodeGenerationFolder";
            this.labelCodeGenerationFolder.Size = new System.Drawing.Size(132, 15);
            this.labelCodeGenerationFolder.TabIndex = 36;
            this.labelCodeGenerationFolder.Text = "Code Generation Folder";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(256, 95);
            this.textBoxConnectionString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(357, 23);
            this.textBoxConnectionString.TabIndex = 35;
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(3, 93);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(103, 15);
            this.labelConnectionString.TabIndex = 34;
            this.labelConnectionString.Text = "Connection String";
            // 
            // textBoxAbbrevationsAsString
            // 
            this.textBoxAbbrevationsAsString.Location = new System.Drawing.Point(256, 312);
            this.textBoxAbbrevationsAsString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAbbrevationsAsString.Name = "textBoxAbbrevationsAsString";
            this.textBoxAbbrevationsAsString.Size = new System.Drawing.Size(357, 23);
            this.textBoxAbbrevationsAsString.TabIndex = 54;
            // 
            // labelAbbrevationsAsString
            // 
            this.labelAbbrevationsAsString.AutoSize = true;
            this.labelAbbrevationsAsString.Location = new System.Drawing.Point(3, 310);
            this.labelAbbrevationsAsString.Name = "labelAbbrevationsAsString";
            this.labelAbbrevationsAsString.Size = new System.Drawing.Size(77, 15);
            this.labelAbbrevationsAsString.TabIndex = 53;
            this.labelAbbrevationsAsString.Text = "Abbrevations";
            // 
            // textBoxIgnoredSchemaList
            // 
            this.textBoxIgnoredSchemaList.Location = new System.Drawing.Point(256, 250);
            this.textBoxIgnoredSchemaList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxIgnoredSchemaList.Name = "textBoxIgnoredSchemaList";
            this.textBoxIgnoredSchemaList.Size = new System.Drawing.Size(357, 23);
            this.textBoxIgnoredSchemaList.TabIndex = 52;
            // 
            // labelIgnoredSchemaList
            // 
            this.labelIgnoredSchemaList.AutoSize = true;
            this.labelIgnoredSchemaList.Location = new System.Drawing.Point(3, 248);
            this.labelIgnoredSchemaList.Name = "labelIgnoredSchemaList";
            this.labelIgnoredSchemaList.Size = new System.Drawing.Size(114, 15);
            this.labelIgnoredSchemaList.TabIndex = 51;
            this.labelIgnoredSchemaList.Text = "Ignored Schema List";
            // 
            // checkBoxCreateMainClassValidationExamples
            // 
            this.checkBoxCreateMainClassValidationExamples.AutoSize = true;
            this.checkBoxCreateMainClassValidationExamples.Location = new System.Drawing.Point(762, 436);
            this.checkBoxCreateMainClassValidationExamples.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxCreateMainClassValidationExamples.Name = "checkBoxCreateMainClassValidationExamples";
            this.checkBoxCreateMainClassValidationExamples.Size = new System.Drawing.Size(79, 19);
            this.checkBoxCreateMainClassValidationExamples.TabIndex = 33;
            this.checkBoxCreateMainClassValidationExamples.Text = "Create Main Validation Class";
            this.checkBoxCreateMainClassValidationExamples.UseVisualStyleBackColor = true;
            // 
            // checkBoxSequenceCodeGenerate
            // 
            this.checkBoxSequenceCodeGenerate.AutoSize = true;
            this.checkBoxSequenceCodeGenerate.Location = new System.Drawing.Point(3, 405);
            this.checkBoxSequenceCodeGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSequenceCodeGenerate.Name = "checkBoxSequenceCodeGenerate";
            this.checkBoxSequenceCodeGenerate.Size = new System.Drawing.Size(158, 19);
            this.checkBoxSequenceCodeGenerate.TabIndex = 56;
            this.checkBoxSequenceCodeGenerate.Text = "Sequence Code Generate";
            this.checkBoxSequenceCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // buttonKisaltmalar
            // 
            this.buttonKisaltmalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonKisaltmalar.Location = new System.Drawing.Point(763, 314);
            this.buttonKisaltmalar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonKisaltmalar.Name = "buttonKisaltmalar";
            this.buttonKisaltmalar.Size = new System.Drawing.Size(77, 23);
            this.buttonKisaltmalar.TabIndex = 57;
            this.buttonKisaltmalar.Text = "Abbrevations";
            this.buttonKisaltmalar.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxConnectionName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxSequenceCodeGenerate, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.buttonKisaltmalar, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxUseSchemaNameInFolders, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.labelDatabaseType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxStoredProcedureCodeGenerate, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIgnoreSystemTables, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxUseSchemaNameInSql, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDatabaseType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAbbrevationsAsString, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxViewCodeGenerate, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDbProviderName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelAbbrevationsAsString, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelConnectionString, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxIgnoredSchemaList, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBoxConnectionString, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelIgnoredSchemaList, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBoxProjectNamespace, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonFolderDialog, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDatabaseNamePhysical, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCodeGenerationFolder, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelProjectNamespace, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelCodeGenerationFolder, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelDatabaseNameLogical, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDatabaseNameLogical, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelDatabaseNamePhysical, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxCreateMainClassAgain, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.labelConnectionName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDbProviderName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxCreateMainClassValidationExamples, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.labelAdditionalSchemaList, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAdditionalSchemaList, 1, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(844, 466);
            this.tableLayoutPanel1.TabIndex = 58;
            // 
            // labelAdditionalSchemaList
            // 
            this.labelAdditionalSchemaList.AutoSize = true;
            this.labelAdditionalSchemaList.Location = new System.Drawing.Point(3, 279);
            this.labelAdditionalSchemaList.Name = "labelAdditionalSchemaList";
            this.labelAdditionalSchemaList.Size = new System.Drawing.Size(128, 15);
            this.labelAdditionalSchemaList.TabIndex = 58;
            this.labelAdditionalSchemaList.Text = "Additional Schema List";
            // 
            // textBoxAdditionalSchemaList
            // 
            this.textBoxAdditionalSchemaList.Location = new System.Drawing.Point(256, 282);
            this.textBoxAdditionalSchemaList.Name = "textBoxAdditionalSchemaList";
            this.textBoxAdditionalSchemaList.Size = new System.Drawing.Size(357, 23);
            this.textBoxAdditionalSchemaList.TabIndex = 59;
            // 
            // UserControlCodeGenerationOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlCodeGenerationOptions";
            this.Size = new System.Drawing.Size(844, 466);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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
        private TextBox textBoxAdditionalSchemaList;
    }
}
