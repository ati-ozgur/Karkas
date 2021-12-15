using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGeneration.WinApp.PersistenceService;
using Karkas.CodeGenerationHelper.Interfaces;

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
            DatabaseEntry entry = DatabaseService.getLastAccessedDatabaseEntry();

            if (entry != null)
            {
                databaseEntryToForm(entry);
            }
        }

        public DatabaseEntry getDatabaseEntry()
        {

            DatabaseEntry entry = new DatabaseEntry();
            entry.ConnectionName = textBoxConnectionName.Text;
            entry.ConnectionDatabaseType = comboBoxDatabaseType.SelectedValue.ToString();
            entry.ConnectionDbProviderName = textBoxDbProviderName.Text;

            entry.ConnectionString = textBoxConnectionString.Text;

            entry.DatabaseNamePhysical = textBoxDatabaseNamePhysical.Text;
            entry.DatabaseNameLogical = textBoxDatabaseNameLogical.Text;

            entry.ProjectNameSpace = textBoxProjectNamespace.Text;
            entry.CodeGenerationDirectory = textBoxCodeGenerationDizini.Text;

            entry.ViewCodeGenerate = checkBoxViewCodeGenerate.Checked.ToString();
            entry.SequenceCodeGenerate = checkBoxSequenceCodeGenerate.Checked.ToString();

            entry.StoredProcedureCodeGenerate = checkBoxStoredProcedureCodeGenerate.Checked.ToString();
            entry.UseSchemaNameInSqlQueries = checkBoxUseSchemaNameInSql.Checked.ToString();
            entry.UseSchemaNameInFolders = checkBoxUseSchemaNameInFolders.Checked.ToString();
            entry.IgnoreSystemTables = checkBoxIgnoreSystemTables.Checked.ToString();
            entry.IgnoredSchemaList = textBoxIgnoredSchemaList.Text;
            if (string.IsNullOrEmpty(textBoxAbbrevationsAsString.Text))
            {
                entry.AbbrevationsAsString = null;
            }
            else
            {
                entry.AbbrevationsAsString = textBoxAbbrevationsAsString.Text;
            }


            entry.AnaSinifiTekrarUret = checkBoxAnaSinifiTekrarUret.Checked;
            entry.AnaSinifOnaylamaOrnekleriUret = checkBoxAnaSinifOnaylamaOrnekleri.Checked;
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
                textBoxCodeGenerationDizini.Text = folderBrowserDialog.SelectedPath;
            }

        }


        public void databaseEntryToForm(DatabaseEntry entry)
        {
            textBoxConnectionName.Text = entry.ConnectionName;
            comboBoxDatabaseType.SelectedItem = entry.ConnectionDatabaseType;

            textBoxDbProviderName.Text = entry.ConnectionDbProviderName;


            if (!string.IsNullOrWhiteSpace(entry.ConnectionString))
            {
                textBoxConnectionString.Text = entry.ConnectionString;
            }

            textBoxDatabaseNameLogical.Text = entry.DatabaseNameLogical;
            textBoxDatabaseNamePhysical.Text = entry.DatabaseNamePhysical;
            if (!string.IsNullOrWhiteSpace(entry.ProjectNameSpace))
            {
                textBoxProjectNamespace.Text = entry.ProjectNameSpace;
            }

            if (!string.IsNullOrWhiteSpace(entry.CodeGenerationDirectory))
            {
                textBoxCodeGenerationDizini.Text = entry.CodeGenerationDirectory;
            }

            bool parsedValue;
            if (bool.TryParse(entry.ViewCodeGenerate, out parsedValue))
            {
                checkBoxViewCodeGenerate.Checked = parsedValue;
            }
            if (bool.TryParse(entry.StoredProcedureCodeGenerate, out parsedValue))
            {
                checkBoxStoredProcedureCodeGenerate.Checked = parsedValue;
            }
            if (bool.TryParse(entry.UseSchemaNameInSqlQueries, out parsedValue))
            {
                checkBoxUseSchemaNameInSql.Checked = parsedValue;
            }
            if (bool.TryParse(entry.UseSchemaNameInFolders, out parsedValue))
            {
                checkBoxUseSchemaNameInFolders.Checked = parsedValue;
            }
            if (bool.TryParse(entry.IgnoreSystemTables, out parsedValue))
            {
                checkBoxIgnoreSystemTables.Checked = parsedValue;
            }
            if (bool.TryParse(entry.SequenceCodeGenerate, out parsedValue))
            {
                checkBoxSequenceCodeGenerate.Checked = parsedValue;
            }

            textBoxIgnoredSchemaList.Text = entry.IgnoredSchemaList;
            textBoxAbbrevationsAsString.Text = entry.AbbrevationsAsString;


        }

        public void databaseNameLabelDoldur(IDatabase databaseHelper)
        {
           textBoxDatabaseNamePhysical.Text = databaseHelper.DatabaseNamePhysical;
        }

        public void ClearInputControlValues()
        {
            
            textBoxCodeGenerationDizini.Text = "";
            textBoxConnectionName.Text = "";
            textBoxProjectNamespace.Text = "";
            textBoxConnectionString.Text = "";

        }


        public string ConnectionString
        {
            get
            {
                return textBoxConnectionString.Text;
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

        private void buttonKisaltmalar_Click(object sender, EventArgs e)
        {
            Form frm = new FormAbbreviations(getDatabaseEntry());
            frm.ShowDialog();
        }

    }
}
