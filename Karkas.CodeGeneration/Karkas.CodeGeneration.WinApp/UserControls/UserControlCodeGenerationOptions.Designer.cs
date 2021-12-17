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
            this.checkBoxAnaSinifiTekrarUret = new System.Windows.Forms.CheckBox();
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
            this.textBoxCodeGenerationDizini = new System.Windows.Forms.TextBox();
            this.labelCodeGenerationFolder = new System.Windows.Forms.Label();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.textBoxAbbrevationsAsString = new System.Windows.Forms.TextBox();
            this.labelAbbrevationsAsString = new System.Windows.Forms.Label();
            this.textBoxIgnoredSchemaList = new System.Windows.Forms.TextBox();
            this.labelIgnoredSchemaList = new System.Windows.Forms.Label();
            this.checkBoxAnaSinifOnaylamaOrnekleri = new System.Windows.Forms.CheckBox();
            this.checkBoxSequenceCodeGenerate = new System.Windows.Forms.CheckBox();
            this.toolTipCodeGenerationOptions = new System.Windows.Forms.ToolTip(this.components);
            this.buttonKisaltmalar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxIgnoreSystemTables
            // 
            this.checkBoxIgnoreSystemTables.AutoSize = true;
            this.checkBoxIgnoreSystemTables.Checked = true;
            this.checkBoxIgnoreSystemTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIgnoreSystemTables.Location = new System.Drawing.Point(292, 443);
            this.checkBoxIgnoreSystemTables.Name = "checkBoxIgnoreSystemTables";
            this.checkBoxIgnoreSystemTables.Size = new System.Drawing.Size(192, 24);
            this.checkBoxIgnoreSystemTables.TabIndex = 27;
            this.checkBoxIgnoreSystemTables.Text = "Ignore sys/system tables";
            this.checkBoxIgnoreSystemTables.UseVisualStyleBackColor = true;
            // 
            // checkBoxStoredProcedureCodeGenerate
            // 
            this.checkBoxStoredProcedureCodeGenerate.AutoSize = true;
            this.checkBoxStoredProcedureCodeGenerate.Location = new System.Drawing.Point(3, 487);
            this.checkBoxStoredProcedureCodeGenerate.Name = "checkBoxStoredProcedureCodeGenerate";
            this.checkBoxStoredProcedureCodeGenerate.Size = new System.Drawing.Size(249, 24);
            this.checkBoxStoredProcedureCodeGenerate.TabIndex = 31;
            this.checkBoxStoredProcedureCodeGenerate.Text = "Stored Procedure Code Generate";
            this.checkBoxStoredProcedureCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // checkBoxViewCodeGenerate
            // 
            this.checkBoxViewCodeGenerate.AutoSize = true;
            this.checkBoxViewCodeGenerate.Location = new System.Drawing.Point(3, 443);
            this.checkBoxViewCodeGenerate.Name = "checkBoxViewCodeGenerate";
            this.checkBoxViewCodeGenerate.Size = new System.Drawing.Size(166, 24);
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
            this.checkBoxUseSchemaNameInFolders.Location = new System.Drawing.Point(292, 531);
            this.checkBoxUseSchemaNameInFolders.Name = "checkBoxUseSchemaNameInFolders";
            this.checkBoxUseSchemaNameInFolders.Size = new System.Drawing.Size(572, 38);
            this.checkBoxUseSchemaNameInFolders.TabIndex = 29;
            this.checkBoxUseSchemaNameInFolders.Text = "Use Schema Name in Folders";
            this.checkBoxUseSchemaNameInFolders.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseSchemaNameInSql
            // 
            this.checkBoxUseSchemaNameInSql.AutoSize = true;
            this.checkBoxUseSchemaNameInSql.Checked = true;
            this.checkBoxUseSchemaNameInSql.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseSchemaNameInSql.Location = new System.Drawing.Point(292, 487);
            this.checkBoxUseSchemaNameInSql.Name = "checkBoxUseSchemaNameInSql";
            this.checkBoxUseSchemaNameInSql.Size = new System.Drawing.Size(225, 24);
            this.checkBoxUseSchemaNameInSql.TabIndex = 28;
            this.checkBoxUseSchemaNameInSql.Text = "Use Schema Name in Queries";
            this.checkBoxUseSchemaNameInSql.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnaSinifiTekrarUret
            // 
            this.checkBoxAnaSinifiTekrarUret.AutoSize = true;
            this.checkBoxAnaSinifiTekrarUret.Location = new System.Drawing.Point(292, 575);
            this.checkBoxAnaSinifiTekrarUret.Name = "checkBoxAnaSinifiTekrarUret";
            this.checkBoxAnaSinifiTekrarUret.Size = new System.Drawing.Size(191, 24);
            this.checkBoxAnaSinifiTekrarUret.TabIndex = 32;
            this.checkBoxAnaSinifiTekrarUret.Text = "Create Main Class Again";
            this.checkBoxAnaSinifiTekrarUret.UseVisualStyleBackColor = true;
            // 
            // textBoxDbProviderName
            // 
            this.textBoxDbProviderName.Location = new System.Drawing.Point(293, 93);
            this.textBoxDbProviderName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDbProviderName.Name = "textBoxDbProviderName";
            this.textBoxDbProviderName.Size = new System.Drawing.Size(168, 27);
            this.textBoxDbProviderName.TabIndex = 50;
            // 
            // labelDbProviderName
            // 
            this.labelDbProviderName.AutoSize = true;
            this.labelDbProviderName.Location = new System.Drawing.Point(4, 88);
            this.labelDbProviderName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDbProviderName.Name = "labelDbProviderName";
            this.labelDbProviderName.Size = new System.Drawing.Size(124, 20);
            this.labelDbProviderName.TabIndex = 49;
            this.labelDbProviderName.Text = "DbProviderName";
            // 
            // textBoxDatabaseNamePhysical
            // 
            this.textBoxDatabaseNamePhysical.Enabled = false;
            this.textBoxDatabaseNamePhysical.Location = new System.Drawing.Point(293, 225);
            this.textBoxDatabaseNamePhysical.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDatabaseNamePhysical.Name = "textBoxDatabaseNamePhysical";
            this.textBoxDatabaseNamePhysical.Size = new System.Drawing.Size(168, 27);
            this.textBoxDatabaseNamePhysical.TabIndex = 48;
            // 
            // labelDatabaseNamePhysical
            // 
            this.labelDatabaseNamePhysical.AutoSize = true;
            this.labelDatabaseNamePhysical.Location = new System.Drawing.Point(3, 220);
            this.labelDatabaseNamePhysical.Name = "labelDatabaseNamePhysical";
            this.labelDatabaseNamePhysical.Size = new System.Drawing.Size(172, 20);
            this.labelDatabaseNamePhysical.TabIndex = 47;
            this.labelDatabaseNamePhysical.Text = "Database Name Physical";
            // 
            // textBoxDatabaseNameLogical
            // 
            this.textBoxDatabaseNameLogical.Location = new System.Drawing.Point(293, 181);
            this.textBoxDatabaseNameLogical.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDatabaseNameLogical.Name = "textBoxDatabaseNameLogical";
            this.textBoxDatabaseNameLogical.Size = new System.Drawing.Size(168, 27);
            this.textBoxDatabaseNameLogical.TabIndex = 46;
            this.toolTipCodeGenerationOptions.SetToolTip(this.textBoxDatabaseNameLogical, "Veritabanı ismi olarak fiziksel isim yerine\r\nmantıksal bir isim vermek için kulla" +
        "nılır.\r\nBu mantıksal isim app.config/web.config\r\niçinde bağlantı çekmek için kul" +
        "lanılır.\r\n");
            // 
            // labelDatabaseNameLogical
            // 
            this.labelDatabaseNameLogical.AutoSize = true;
            this.labelDatabaseNameLogical.Location = new System.Drawing.Point(3, 176);
            this.labelDatabaseNameLogical.Name = "labelDatabaseNameLogical";
            this.labelDatabaseNameLogical.Size = new System.Drawing.Size(168, 20);
            this.labelDatabaseNameLogical.TabIndex = 45;
            this.labelDatabaseNameLogical.Text = "Database Name Logical";
            // 
            // labelDatabaseType
            // 
            this.labelDatabaseType.AutoSize = true;
            this.labelDatabaseType.Location = new System.Drawing.Point(4, 44);
            this.labelDatabaseType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDatabaseType.Name = "labelDatabaseType";
            this.labelDatabaseType.Size = new System.Drawing.Size(107, 20);
            this.labelDatabaseType.TabIndex = 44;
            this.labelDatabaseType.Text = "Database Type";
            // 
            // comboBoxDatabaseType
            // 
            this.comboBoxDatabaseType.FormattingEnabled = true;
            this.comboBoxDatabaseType.Location = new System.Drawing.Point(293, 49);
            this.comboBoxDatabaseType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDatabaseType.Name = "comboBoxDatabaseType";
            this.comboBoxDatabaseType.Size = new System.Drawing.Size(160, 28);
            this.comboBoxDatabaseType.TabIndex = 43;
            // 
            // textBoxConnectionName
            // 
            this.textBoxConnectionName.Location = new System.Drawing.Point(293, 5);
            this.textBoxConnectionName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxConnectionName.Name = "textBoxConnectionName";
            this.textBoxConnectionName.Size = new System.Drawing.Size(168, 27);
            this.textBoxConnectionName.TabIndex = 42;
            // 
            // labelConnectionName
            // 
            this.labelConnectionName.AutoSize = true;
            this.labelConnectionName.Location = new System.Drawing.Point(3, 0);
            this.labelConnectionName.Name = "labelConnectionName";
            this.labelConnectionName.Size = new System.Drawing.Size(128, 20);
            this.labelConnectionName.TabIndex = 41;
            this.labelConnectionName.Text = "Connection Name";
            // 
            // textBoxProjectNamespace
            // 
            this.textBoxProjectNamespace.Location = new System.Drawing.Point(292, 267);
            this.textBoxProjectNamespace.Name = "textBoxProjectNamespace";
            this.textBoxProjectNamespace.Size = new System.Drawing.Size(407, 27);
            this.textBoxProjectNamespace.TabIndex = 40;
            // 
            // labelProjectNamespace
            // 
            this.labelProjectNamespace.AutoSize = true;
            this.labelProjectNamespace.Location = new System.Drawing.Point(3, 264);
            this.labelProjectNamespace.Name = "labelProjectNamespace";
            this.labelProjectNamespace.Size = new System.Drawing.Size(137, 20);
            this.labelProjectNamespace.TabIndex = 39;
            this.labelProjectNamespace.Text = "Project Namespace";
            // 
            // buttonFolderDialog
            // 
            this.buttonFolderDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFolderDialog.Location = new System.Drawing.Point(870, 311);
            this.buttonFolderDialog.Name = "buttonFolderDialog";
            this.buttonFolderDialog.Size = new System.Drawing.Size(91, 38);
            this.buttonFolderDialog.TabIndex = 38;
            this.buttonFolderDialog.Text = "...";
            this.buttonFolderDialog.UseVisualStyleBackColor = true;
            // 
            // textBoxCodeGenerationDizini
            // 
            this.textBoxCodeGenerationDizini.Location = new System.Drawing.Point(292, 311);
            this.textBoxCodeGenerationDizini.Name = "textBoxCodeGenerationDizini";
            this.textBoxCodeGenerationDizini.Size = new System.Drawing.Size(407, 27);
            this.textBoxCodeGenerationDizini.TabIndex = 37;
            // 
            // labelCodeGenerationFolder
            // 
            this.labelCodeGenerationFolder.AutoSize = true;
            this.labelCodeGenerationFolder.Location = new System.Drawing.Point(3, 308);
            this.labelCodeGenerationFolder.Name = "labelCodeGenerationFolder";
            this.labelCodeGenerationFolder.Size = new System.Drawing.Size(167, 20);
            this.labelCodeGenerationFolder.TabIndex = 36;
            this.labelCodeGenerationFolder.Text = "Code Generation Folder";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(292, 135);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(407, 27);
            this.textBoxConnectionString.TabIndex = 35;
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(3, 132);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(127, 20);
            this.labelConnectionString.TabIndex = 34;
            this.labelConnectionString.Text = "Connection String";
            // 
            // textBoxAbbrevationsAsString
            // 
            this.textBoxAbbrevationsAsString.Location = new System.Drawing.Point(292, 399);
            this.textBoxAbbrevationsAsString.Name = "textBoxAbbrevationsAsString";
            this.textBoxAbbrevationsAsString.Size = new System.Drawing.Size(407, 27);
            this.textBoxAbbrevationsAsString.TabIndex = 54;
            // 
            // labelAbbrevationsAsString
            // 
            this.labelAbbrevationsAsString.AutoSize = true;
            this.labelAbbrevationsAsString.Location = new System.Drawing.Point(3, 396);
            this.labelAbbrevationsAsString.Name = "labelAbbrevationsAsString";
            this.labelAbbrevationsAsString.Size = new System.Drawing.Size(97, 20);
            this.labelAbbrevationsAsString.TabIndex = 53;
            this.labelAbbrevationsAsString.Text = "Abbrevations";
            // 
            // textBoxIgnoredSchemaList
            // 
            this.textBoxIgnoredSchemaList.Location = new System.Drawing.Point(292, 355);
            this.textBoxIgnoredSchemaList.Name = "textBoxIgnoredSchemaList";
            this.textBoxIgnoredSchemaList.Size = new System.Drawing.Size(407, 27);
            this.textBoxIgnoredSchemaList.TabIndex = 52;
            // 
            // labelIgnoredSchemaList
            // 
            this.labelIgnoredSchemaList.AutoSize = true;
            this.labelIgnoredSchemaList.Location = new System.Drawing.Point(3, 352);
            this.labelIgnoredSchemaList.Name = "labelIgnoredSchemaList";
            this.labelIgnoredSchemaList.Size = new System.Drawing.Size(143, 20);
            this.labelIgnoredSchemaList.TabIndex = 51;
            this.labelIgnoredSchemaList.Text = "Ignored Schema List";
            // 
            // checkBoxAnaSinifOnaylamaOrnekleri
            // 
            this.checkBoxAnaSinifOnaylamaOrnekleri.AutoSize = true;
            this.checkBoxAnaSinifOnaylamaOrnekleri.Location = new System.Drawing.Point(870, 575);
            this.checkBoxAnaSinifOnaylamaOrnekleri.Name = "checkBoxAnaSinifOnaylamaOrnekleri";
            this.checkBoxAnaSinifOnaylamaOrnekleri.Size = new System.Drawing.Size(91, 24);
            this.checkBoxAnaSinifOnaylamaOrnekleri.TabIndex = 33;
            this.checkBoxAnaSinifOnaylamaOrnekleri.Text = "Create Main Validation Class";
            this.checkBoxAnaSinifOnaylamaOrnekleri.UseVisualStyleBackColor = true;
            // 
            // checkBoxSequenceCodeGenerate
            // 
            this.checkBoxSequenceCodeGenerate.AutoSize = true;
            this.checkBoxSequenceCodeGenerate.Location = new System.Drawing.Point(3, 531);
            this.checkBoxSequenceCodeGenerate.Name = "checkBoxSequenceCodeGenerate";
            this.checkBoxSequenceCodeGenerate.Size = new System.Drawing.Size(198, 24);
            this.checkBoxSequenceCodeGenerate.TabIndex = 56;
            this.checkBoxSequenceCodeGenerate.Text = "Sequence Code Generate";
            this.checkBoxSequenceCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // buttonKisaltmalar
            // 
            this.buttonKisaltmalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonKisaltmalar.Location = new System.Drawing.Point(871, 401);
            this.buttonKisaltmalar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonKisaltmalar.Name = "buttonKisaltmalar";
            this.buttonKisaltmalar.Size = new System.Drawing.Size(89, 34);
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
            this.tableLayoutPanel1.Controls.Add(this.checkBoxSequenceCodeGenerate, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.buttonKisaltmalar, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxUseSchemaNameInFolders, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.labelDatabaseType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxStoredProcedureCodeGenerate, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIgnoreSystemTables, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxUseSchemaNameInSql, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDatabaseType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAbbrevationsAsString, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxViewCodeGenerate, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDbProviderName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelAbbrevationsAsString, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelConnectionString, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxIgnoredSchemaList, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBoxConnectionString, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelIgnoredSchemaList, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBoxProjectNamespace, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonFolderDialog, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDatabaseNamePhysical, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCodeGenerationDizini, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelProjectNamespace, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelCodeGenerationFolder, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelDatabaseNameLogical, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDatabaseNameLogical, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelDatabaseNamePhysical, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAnaSinifiTekrarUret, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.labelConnectionName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDbProviderName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAnaSinifOnaylamaOrnekleri, 2, 13);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.231209F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.136061F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 622);
            this.tableLayoutPanel1.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 572);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Code Generation Folder";
            // 
            // UserControlCodeGenerationOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControlCodeGenerationOptions";
            this.Size = new System.Drawing.Size(964, 622);
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
        private System.Windows.Forms.CheckBox checkBoxAnaSinifiTekrarUret;
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
        private System.Windows.Forms.TextBox textBoxCodeGenerationDizini;
        private System.Windows.Forms.Label labelCodeGenerationFolder;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TextBox textBoxAbbrevationsAsString;
        private System.Windows.Forms.Label labelAbbrevationsAsString;
        private System.Windows.Forms.TextBox textBoxIgnoredSchemaList;
        private System.Windows.Forms.Label labelIgnoredSchemaList;
        private System.Windows.Forms.CheckBox checkBoxAnaSinifOnaylamaOrnekleri;
        private System.Windows.Forms.CheckBox checkBoxSequenceCodeGenerate;
        private System.Windows.Forms.ToolTip toolTipCodeGenerationOptions;
        private System.Windows.Forms.Button buttonKisaltmalar;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
    }
}
