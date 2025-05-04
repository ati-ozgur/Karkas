using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.WinApp.UserControls
{
    public partial class UserControlCodeGenerationOptions : UserControl
    {
        public UserControlCodeGenerationOptions()
        {
            InitializeComponent();
            comboBoxDatabaseType.DataSource = DatabaseType.DatabaseTypeList;

        }



        public void getLastAccessedConnectionToTextbox()
        {
			CodeGenerationConfig entry = DatabaseService.GetLastAccessedDatabaseEntry();

			if (entry != null)
			{
				databaseEntryToForm(entry);
			}
		}


		private string HomeDirectory
        {
            get
            {
                string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                       Environment.OSVersion.Platform == PlatformID.MacOSX)
                    ? Environment.GetEnvironmentVariable("HOME")
                    : Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return homePath;

            }
        }

        private string getCodeGenerationDirectory()
        {
            string codeGenerationDirectory = textBoxCodeGenerationFolder.Text.Replace("$HOME", HomeDirectory);
            return codeGenerationDirectory;
        }

        public CodeGenerationConfig getDatabaseEntry()
        {

			CodeGenerationConfig entry = new CodeGenerationConfig();



            entry.CodeGenerationDirectory = getCodeGenerationDirectory();
            entry.ConnectionDatabaseType = comboBoxDatabaseType.SelectedValue.ToString();
            entry.ConnectionDbProviderName = textBoxDbProviderName.Text;
            entry.ConnectionName = textBoxConnectionName.Text;
            entry.ConnectionString = textBoxConnectionString.Text;
			entry.ForceOracleDecimalToIntegersAndDecimal = checkBoxForceOracleDecimalToIntegersAndDecimal.Checked;
			entry.GenerateForeignKeyQueries = checkBoxGenerateForeignKeyQueries.Checked;
            entry.GenerateNormalClassAgain = checkBoxGenerateNormalClassAgain.Checked;
            entry.GenerateNormalClassValidationExamples = checkBoxGenerateNormalClassValidationExamples.Checked;
            entry.IgnoredSchemaList = textBoxIgnoredSchemaList.Text;
			entry.IgnoreSystemTables = checkBoxIgnoreSystemTables.Checked;
			entry.OracleForceNumericPKFKColumnsToLong = checkBoxOracleForceNumericPKFKColumnsToLong.Checked;
            entry.ProjectNameSpace = textBoxProjectNamespace.Text;
            entry.SchemaList = textBoxSchemaList.Text;
            entry.SequenceCodeGenerate = checkBoxSequenceCodeGenerate.Checked;
            entry.StoredProcedureCodeGenerate = checkBoxStoredProcedureCodeGenerate.Checked;
			entry.UseFileScopedNamespace = checkBoxUseFileScopedNamespace.Checked;
			entry.UseGlobalUsings = checkBoxUseGlobalUsings.Checked;
			entry.UseQuotesInQueries = checkBoxUseQuotesInQueries.Checked;
            entry.UseSchemaNameInFolders = checkBoxUseSchemaNameInFolders.Checked;
			entry.UseSchemaNameInNamespaces = checkBoxUseSchemaNameInNamespaces.Checked;
            entry.UseSchemaNameInSqlQueries = checkBoxUseSchemaNameInSql.Checked;
            entry.ViewCodeGenerate = checkBoxViewCodeGenerate.Checked;
            entry.setTimeValues();
            return entry;


        }

        private void buttonFolderDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBoxCodeGenerationFolder.Text = folderBrowserDialog.SelectedPath;
            }

        }


        public void databaseEntryToForm(CodeGenerationConfig entry)
        {
            textBoxConnectionName.Text = entry.ConnectionName;
            comboBoxDatabaseType.SelectedItem = entry.ConnectionDatabaseType;

            textBoxDbProviderName.Text = entry.ConnectionDbProviderName;


            if (!string.IsNullOrWhiteSpace(entry.ConnectionString))
            {
                textBoxConnectionString.Text = entry.ConnectionString;
            }

            if (!string.IsNullOrWhiteSpace(entry.ProjectNameSpace))
            {
                textBoxProjectNamespace.Text = entry.ProjectNameSpace;
            }

            if (!string.IsNullOrWhiteSpace(entry.CodeGenerationDirectory))
            {
                textBoxCodeGenerationFolder.Text = entry.CodeGenerationDirectory;
            }



			checkBoxForceOracleDecimalToIntegersAndDecimal.Checked = entry.OracleForceNumericPKFKColumnsToLong;
			checkBoxGenerateForeignKeyQueries.Checked = entry.GenerateForeignKeyQueries;
			checkBoxIgnoreSystemTables.Checked = entry.IgnoreSystemTables;
			checkBoxOracleForceNumericPKFKColumnsToLong.Checked = entry.OracleForceNumericPKFKColumnsToLong;
			checkBoxSequenceCodeGenerate.Checked = entry.SequenceCodeGenerate;
			checkBoxStoredProcedureCodeGenerate.Checked = entry.StoredProcedureCodeGenerate;
			checkBoxUseFileScopedNamespace.Checked = entry.UseFileScopedNamespace;
			checkBoxUseGlobalUsings.Checked = entry.UseGlobalUsings;
			checkBoxUseQuotesInQueries.Checked = entry.UseQuotesInQueries;
			checkBoxUseSchemaNameInFolders.Checked = entry.UseSchemaNameInFolders;
			checkBoxUseSchemaNameInNamespaces.Checked = entry.UseSchemaNameInNamespaces;
			checkBoxUseSchemaNameInSql.Checked = entry.UseSchemaNameInSqlQueries;
			checkBoxViewCodeGenerate.Checked = entry.ViewCodeGenerate;


			textBoxIgnoredSchemaList.Text = entry.IgnoredSchemaList;
            textBoxSchemaList.Text = entry.SchemaList;


        }

        public void ClearInputControlValues()
        {
            
            textBoxCodeGenerationFolder.Text = "";
            textBoxConnectionName.Text = "";
            textBoxProjectNamespace.Text = "";
            textBoxConnectionString.Text = "";

        }


        public string ConnectionString
        {
            get
            {
                return textBoxConnectionString.Text.Replace("$HOME",HomeDirectory);
            }
        }

        public string ConnectionDbProviderName 
        { 
            get
            {
                return textBoxDbProviderName.Text;
            }
        }

        public string ConnectionName
        {
            get
            {
                return textBoxConnectionName.Text;
            }
        }

        public string SelectedDatabaseType
        {
            get
            {
                return comboBoxDatabaseType.SelectedItem.ToString();
            }
        }

        public FormMain ParentMainForm
        {
            get
            {
                return (FormMain)this.ParentForm;
            }
        }

        private void buttonAbbreviations_Click(object sender, EventArgs e)
        {
            Form frm = new FormAbbreviations(getDatabaseEntry());
            frm.ShowDialog();
        }

        public string[] GetSchemaList()
        {
            if(string.IsNullOrEmpty(this.textBoxSchemaList.Text))
            {
                return null;
            }

            string[] schemaList = this.textBoxSchemaList.Text.Split(",");
            return schemaList;
        }
    }
}
