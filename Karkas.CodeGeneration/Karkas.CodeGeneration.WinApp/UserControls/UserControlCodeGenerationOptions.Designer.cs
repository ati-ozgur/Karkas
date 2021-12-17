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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxAnaSinifOnaylamaOrnekleri = new System.Windows.Forms.CheckBox();
            this.checkBoxSequenceCodeGenerate = new System.Windows.Forms.CheckBox();
            this.toolTipCodeGenerationOptions = new System.Windows.Forms.ToolTip(this.components);
            this.buttonKisaltmalar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxIgnoreSystemTables
            // 
            this.checkBoxIgnoreSystemTables.AutoSize = true;
            this.checkBoxIgnoreSystemTables.Checked = true;
            this.checkBoxIgnoreSystemTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIgnoreSystemTables.Location = new System.Drawing.Point(385, 284);
            this.checkBoxIgnoreSystemTables.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxIgnoreSystemTables.Name = "checkBoxIgnoreSystemTables";
            this.checkBoxIgnoreSystemTables.Size = new System.Drawing.Size(113, 17);
            this.checkBoxIgnoreSystemTables.TabIndex = 27;
            this.checkBoxIgnoreSystemTables.Text = "sys Tablolarını Atla";
            this.checkBoxIgnoreSystemTables.UseVisualStyleBackColor = true;
            // 
            // checkBoxStoredProcedureCodeGenerate
            // 
            this.checkBoxStoredProcedureCodeGenerate.AutoSize = true;
            this.checkBoxStoredProcedureCodeGenerate.Location = new System.Drawing.Point(12, 320);
            this.checkBoxStoredProcedureCodeGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxStoredProcedureCodeGenerate.Name = "checkBoxStoredProcedureCodeGenerate";
            this.checkBoxStoredProcedureCodeGenerate.Size = new System.Drawing.Size(184, 17);
            this.checkBoxStoredProcedureCodeGenerate.TabIndex = 31;
            this.checkBoxStoredProcedureCodeGenerate.Text = "Stored Procedure Code Generate";
            this.checkBoxStoredProcedureCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // checkBoxViewCodeGenerate
            // 
            this.checkBoxViewCodeGenerate.AutoSize = true;
            this.checkBoxViewCodeGenerate.Location = new System.Drawing.Point(11, 284);
            this.checkBoxViewCodeGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxViewCodeGenerate.Name = "checkBoxViewCodeGenerate";
            this.checkBoxViewCodeGenerate.Size = new System.Drawing.Size(124, 17);
            this.checkBoxViewCodeGenerate.TabIndex = 30;
            this.checkBoxViewCodeGenerate.Text = "View Code Generate";
            this.checkBoxViewCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseSchemaNameInFolders
            // 
            this.checkBoxUseSchemaNameInFolders.AutoSize = true;
            this.checkBoxUseSchemaNameInFolders.Checked = true;
            this.checkBoxUseSchemaNameInFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseSchemaNameInFolders.Location = new System.Drawing.Point(237, 360);
            this.checkBoxUseSchemaNameInFolders.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxUseSchemaNameInFolders.Name = "checkBoxUseSchemaNameInFolders";
            this.checkBoxUseSchemaNameInFolders.Size = new System.Drawing.Size(105, 30);
            this.checkBoxUseSchemaNameInFolders.TabIndex = 29;
            this.checkBoxUseSchemaNameInFolders.Text = "Dizinlerde Şema \r\nİsmini Kullan";
            this.checkBoxUseSchemaNameInFolders.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseSchemaNameInSql
            // 
            this.checkBoxUseSchemaNameInSql.AutoSize = true;
            this.checkBoxUseSchemaNameInSql.Checked = true;
            this.checkBoxUseSchemaNameInSql.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseSchemaNameInSql.Location = new System.Drawing.Point(237, 320);
            this.checkBoxUseSchemaNameInSql.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxUseSchemaNameInSql.Name = "checkBoxUseSchemaNameInSql";
            this.checkBoxUseSchemaNameInSql.Size = new System.Drawing.Size(110, 30);
            this.checkBoxUseSchemaNameInSql.TabIndex = 28;
            this.checkBoxUseSchemaNameInSql.Text = "Sorgularda Şema \r\nİsmini Kullan";
            this.checkBoxUseSchemaNameInSql.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnaSinifiTekrarUret
            // 
            this.checkBoxAnaSinifiTekrarUret.AutoSize = true;
            this.checkBoxAnaSinifiTekrarUret.Location = new System.Drawing.Point(24, 18);
            this.checkBoxAnaSinifiTekrarUret.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAnaSinifiTekrarUret.Name = "checkBoxAnaSinifiTekrarUret";
            this.checkBoxAnaSinifiTekrarUret.Size = new System.Drawing.Size(119, 17);
            this.checkBoxAnaSinifiTekrarUret.TabIndex = 32;
            this.checkBoxAnaSinifiTekrarUret.Text = "Ana sınıfı tekrar üret";
            this.checkBoxAnaSinifiTekrarUret.UseVisualStyleBackColor = true;
            // 
            // textBoxDbProviderName
            // 
            this.textBoxDbProviderName.Location = new System.Drawing.Point(145, 59);
            this.textBoxDbProviderName.Name = "textBoxDbProviderName";
            this.textBoxDbProviderName.Size = new System.Drawing.Size(127, 20);
            this.textBoxDbProviderName.TabIndex = 50;
            // 
            // labelDbProviderName
            // 
            this.labelDbProviderName.AutoSize = true;
            this.labelDbProviderName.Location = new System.Drawing.Point(8, 62);
            this.labelDbProviderName.Name = "labelDbProviderName";
            this.labelDbProviderName.Size = new System.Drawing.Size(88, 13);
            this.labelDbProviderName.TabIndex = 49;
            this.labelDbProviderName.Text = "DbProviderName";
            // 
            // textBoxDatabaseNamePhysical
            // 
            this.textBoxDatabaseNamePhysical.Enabled = false;
            this.textBoxDatabaseNamePhysical.Location = new System.Drawing.Point(488, 119);
            this.textBoxDatabaseNamePhysical.Name = "textBoxDatabaseNamePhysical";
            this.textBoxDatabaseNamePhysical.Size = new System.Drawing.Size(127, 20);
            this.textBoxDatabaseNamePhysical.TabIndex = 48;
            // 
            // labelDatabaseNamePhysical
            // 
            this.labelDatabaseNamePhysical.AutoSize = true;
            this.labelDatabaseNamePhysical.Location = new System.Drawing.Point(321, 122);
            this.labelDatabaseNamePhysical.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatabaseNamePhysical.Name = "labelDatabaseNamePhysical";
            this.labelDatabaseNamePhysical.Size = new System.Drawing.Size(126, 13);
            this.labelDatabaseNamePhysical.TabIndex = 47;
            this.labelDatabaseNamePhysical.Text = "Database Name Physical";
            // 
            // textBoxDatabaseNameLogical
            // 
            this.textBoxDatabaseNameLogical.Location = new System.Drawing.Point(145, 115);
            this.textBoxDatabaseNameLogical.Name = "textBoxDatabaseNameLogical";
            this.textBoxDatabaseNameLogical.Size = new System.Drawing.Size(127, 20);
            this.textBoxDatabaseNameLogical.TabIndex = 46;
            this.toolTipCodeGenerationOptions.SetToolTip(this.textBoxDatabaseNameLogical, "Veritabanı ismi olarak fiziksel isim yerine\r\nmantıksal bir isim vermek için kulla" +
        "nılır.\r\nBu mantıksal isim app.config/web.config\r\niçinde bağlantı çekmek için kul" +
        "lanılır.\r\n");
            // 
            // labelDatabaseNameLogical
            // 
            this.labelDatabaseNameLogical.AutoSize = true;
            this.labelDatabaseNameLogical.Location = new System.Drawing.Point(8, 115);
            this.labelDatabaseNameLogical.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatabaseNameLogical.Name = "labelDatabaseNameLogical";
            this.labelDatabaseNameLogical.Size = new System.Drawing.Size(121, 13);
            this.labelDatabaseNameLogical.TabIndex = 45;
            this.labelDatabaseNameLogical.Text = "Database Name Logical";
            // 
            // labelDatabaseType
            // 
            this.labelDatabaseType.AutoSize = true;
            this.labelDatabaseType.Location = new System.Drawing.Point(8, 36);
            this.labelDatabaseType.Name = "labelDatabaseType";
            this.labelDatabaseType.Size = new System.Drawing.Size(74, 13);
            this.labelDatabaseType.TabIndex = 44;
            this.labelDatabaseType.Text = "Veritabanı Tipi";
            // 
            // comboBoxDatabaseType
            // 
            this.comboBoxDatabaseType.FormattingEnabled = true;
            this.comboBoxDatabaseType.Location = new System.Drawing.Point(145, 36);
            this.comboBoxDatabaseType.Name = "comboBoxDatabaseType";
            this.comboBoxDatabaseType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDatabaseType.TabIndex = 43;
            // 
            // textBoxConnectionName
            // 
            this.textBoxConnectionName.Location = new System.Drawing.Point(146, 11);
            this.textBoxConnectionName.Name = "textBoxConnectionName";
            this.textBoxConnectionName.Size = new System.Drawing.Size(127, 20);
            this.textBoxConnectionName.TabIndex = 42;
            // 
            // labelConnectionName
            // 
            this.labelConnectionName.AutoSize = true;
            this.labelConnectionName.Location = new System.Drawing.Point(8, 11);
            this.labelConnectionName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionName.Name = "labelConnectionName";
            this.labelConnectionName.Size = new System.Drawing.Size(92, 13);
            this.labelConnectionName.TabIndex = 41;
            this.labelConnectionName.Text = "Connection Name";
            // 
            // textBoxProjectNamespace
            // 
            this.textBoxProjectNamespace.Location = new System.Drawing.Point(146, 149);
            this.textBoxProjectNamespace.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProjectNamespace.Name = "textBoxProjectNamespace";
            this.textBoxProjectNamespace.Size = new System.Drawing.Size(469, 20);
            this.textBoxProjectNamespace.TabIndex = 40;
            // 
            // labelProjectNamespace
            // 
            this.labelProjectNamespace.AutoSize = true;
            this.labelProjectNamespace.Location = new System.Drawing.Point(8, 149);
            this.labelProjectNamespace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProjectNamespace.Name = "labelProjectNamespace";
            this.labelProjectNamespace.Size = new System.Drawing.Size(100, 13);
            this.labelProjectNamespace.TabIndex = 39;
            this.labelProjectNamespace.Text = "Project Namespace";
            // 
            // buttonFolderDialog
            // 
            this.buttonFolderDialog.Location = new System.Drawing.Point(618, 180);
            this.buttonFolderDialog.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFolderDialog.Name = "buttonFolderDialog";
            this.buttonFolderDialog.Size = new System.Drawing.Size(38, 24);
            this.buttonFolderDialog.TabIndex = 38;
            this.buttonFolderDialog.Text = "...";
            this.buttonFolderDialog.UseVisualStyleBackColor = true;
            // 
            // textBoxCodeGenerationDizini
            // 
            this.textBoxCodeGenerationDizini.Location = new System.Drawing.Point(146, 180);
            this.textBoxCodeGenerationDizini.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCodeGenerationDizini.Name = "textBoxCodeGenerationDizini";
            this.textBoxCodeGenerationDizini.Size = new System.Drawing.Size(468, 20);
            this.textBoxCodeGenerationDizini.TabIndex = 37;
            // 
            // labelCodeGenerationFolder
            // 
            this.labelCodeGenerationFolder.AutoSize = true;
            this.labelCodeGenerationFolder.Location = new System.Drawing.Point(8, 183);
            this.labelCodeGenerationFolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCodeGenerationFolder.Name = "labelCodeGenerationFolder";
            this.labelCodeGenerationFolder.Size = new System.Drawing.Size(115, 13);
            this.labelCodeGenerationFolder.TabIndex = 36;
            this.labelCodeGenerationFolder.Text = "Code Generation Dizini";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(146, 84);
            this.textBoxConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(469, 20);
            this.textBoxConnectionString.TabIndex = 35;
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(8, 91);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(91, 13);
            this.labelConnectionString.TabIndex = 34;
            this.labelConnectionString.Text = "Connection String";
            // 
            // textBoxAbbrevationsAsString
            // 
            this.textBoxAbbrevationsAsString.Location = new System.Drawing.Point(146, 244);
            this.textBoxAbbrevationsAsString.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAbbrevationsAsString.Name = "textBoxAbbrevationsAsString";
            this.textBoxAbbrevationsAsString.Size = new System.Drawing.Size(469, 20);
            this.textBoxAbbrevationsAsString.TabIndex = 54;
            // 
            // labelAbbrevationsAsString
            // 
            this.labelAbbrevationsAsString.AutoSize = true;
            this.labelAbbrevationsAsString.Location = new System.Drawing.Point(8, 252);
            this.labelAbbrevationsAsString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAbbrevationsAsString.Name = "labelAbbrevationsAsString";
            this.labelAbbrevationsAsString.Size = new System.Drawing.Size(57, 13);
            this.labelAbbrevationsAsString.TabIndex = 53;
            this.labelAbbrevationsAsString.Text = "Kısaltmalar";
            // 
            // textBoxIgnoredSchemaList
            // 
            this.textBoxIgnoredSchemaList.Location = new System.Drawing.Point(146, 211);
            this.textBoxIgnoredSchemaList.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxIgnoredSchemaList.Name = "textBoxIgnoredSchemaList";
            this.textBoxIgnoredSchemaList.Size = new System.Drawing.Size(469, 20);
            this.textBoxIgnoredSchemaList.TabIndex = 52;
            // 
            // labelIgnoredSchemaList
            // 
            this.labelIgnoredSchemaList.AutoSize = true;
            this.labelIgnoredSchemaList.Location = new System.Drawing.Point(8, 214);
            this.labelIgnoredSchemaList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIgnoredSchemaList.Name = "labelIgnoredSchemaList";
            this.labelIgnoredSchemaList.Size = new System.Drawing.Size(104, 13);
            this.labelIgnoredSchemaList.TabIndex = 51;
            this.labelIgnoredSchemaList.Text = "Ignored Schema List";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxAnaSinifOnaylamaOrnekleri);
            this.groupBox1.Controls.Add(this.checkBoxAnaSinifiTekrarUret);
            this.groupBox1.Location = new System.Drawing.Point(519, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 151);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SAKLANMAYAN ÖZELLİKLER";
            // 
            // checkBoxAnaSinifOnaylamaOrnekleri
            // 
            this.checkBoxAnaSinifOnaylamaOrnekleri.AutoSize = true;
            this.checkBoxAnaSinifOnaylamaOrnekleri.Location = new System.Drawing.Point(24, 43);
            this.checkBoxAnaSinifOnaylamaOrnekleri.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAnaSinifOnaylamaOrnekleri.Name = "checkBoxAnaSinifOnaylamaOrnekleri";
            this.checkBoxAnaSinifOnaylamaOrnekleri.Size = new System.Drawing.Size(182, 17);
            this.checkBoxAnaSinifOnaylamaOrnekleri.TabIndex = 33;
            this.checkBoxAnaSinifOnaylamaOrnekleri.Text = "Ana sınıf Onaylama Örnekleri üret";
            this.checkBoxAnaSinifOnaylamaOrnekleri.UseVisualStyleBackColor = true;
            // 
            // checkBoxSequenceCodeGenerate
            // 
            this.checkBoxSequenceCodeGenerate.AutoSize = true;
            this.checkBoxSequenceCodeGenerate.Location = new System.Drawing.Point(11, 360);
            this.checkBoxSequenceCodeGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSequenceCodeGenerate.Name = "checkBoxSequenceCodeGenerate";
            this.checkBoxSequenceCodeGenerate.Size = new System.Drawing.Size(150, 17);
            this.checkBoxSequenceCodeGenerate.TabIndex = 56;
            this.checkBoxSequenceCodeGenerate.Text = "Sequence Code Generate";
            this.checkBoxSequenceCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // buttonKisaltmalar
            // 
            this.buttonKisaltmalar.Location = new System.Drawing.Point(618, 241);
            this.buttonKisaltmalar.Name = "buttonKisaltmalar";
            this.buttonKisaltmalar.Size = new System.Drawing.Size(86, 23);
            this.buttonKisaltmalar.TabIndex = 57;
            this.buttonKisaltmalar.Text = "Kısaltmalar";
            this.buttonKisaltmalar.UseVisualStyleBackColor = true;
            this.buttonKisaltmalar.Click += new System.EventHandler(this.buttonKisaltmalar_Click);
            // 
            // UserControlCodeGenerationOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonKisaltmalar);
            this.Controls.Add(this.checkBoxSequenceCodeGenerate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxAbbrevationsAsString);
            this.Controls.Add(this.labelAbbrevationsAsString);
            this.Controls.Add(this.textBoxIgnoredSchemaList);
            this.Controls.Add(this.labelIgnoredSchemaList);
            this.Controls.Add(this.textBoxDbProviderName);
            this.Controls.Add(this.labelDbProviderName);
            this.Controls.Add(this.textBoxDatabaseNamePhysical);
            this.Controls.Add(this.labelDatabaseNamePhysical);
            this.Controls.Add(this.textBoxDatabaseNameLogical);
            this.Controls.Add(this.labelDatabaseNameLogical);
            this.Controls.Add(this.labelDatabaseType);
            this.Controls.Add(this.comboBoxDatabaseType);
            this.Controls.Add(this.textBoxConnectionName);
            this.Controls.Add(this.labelConnectionName);
            this.Controls.Add(this.textBoxProjectNamespace);
            this.Controls.Add(this.labelProjectNamespace);
            this.Controls.Add(this.buttonFolderDialog);
            this.Controls.Add(this.textBoxCodeGenerationDizini);
            this.Controls.Add(this.labelCodeGenerationFolder);
            this.Controls.Add(this.textBoxConnectionString);
            this.Controls.Add(this.labelConnectionString);
            this.Controls.Add(this.checkBoxIgnoreSystemTables);
            this.Controls.Add(this.checkBoxStoredProcedureCodeGenerate);
            this.Controls.Add(this.checkBoxViewCodeGenerate);
            this.Controls.Add(this.checkBoxUseSchemaNameInFolders);
            this.Controls.Add(this.checkBoxUseSchemaNameInSql);
            this.Name = "UserControlCodeGenerationOptions";
            this.Size = new System.Drawing.Size(723, 404);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxAnaSinifOnaylamaOrnekleri;
        private System.Windows.Forms.CheckBox checkBoxSequenceCodeGenerate;
        private System.Windows.Forms.ToolTip toolTipCodeGenerationOptions;
        private System.Windows.Forms.Button buttonKisaltmalar;
    }
}
