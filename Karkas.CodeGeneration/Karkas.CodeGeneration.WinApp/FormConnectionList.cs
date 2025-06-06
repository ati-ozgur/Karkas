using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class FormConnectionList : Form
    {
        public FormConnectionList()
        {
            InitializeComponent();

            bindListBox();

            

        }

        private void bindListBox()
        {
            var list = DatabaseService.GetAllDatabaseEntries();

            listBoxConnectionList.DataSource = list;
        }
        public CodeGenerationConfig SelectedDatabaseEntry { get; set; }

        private void listBoxConnectionList_DoubleClick(object sender, EventArgs e)
        {
            SelectedDatabaseEntry = (CodeGenerationConfig)listBoxConnectionList.SelectedItem;
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SelectedDatabaseEntry = (CodeGenerationConfig)listBoxConnectionList.SelectedItem;
            //DatabaseService.deleteDatabase(SelectedDatabaseEntry);
            bindListBox();

        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            SelectedDatabaseEntry = (CodeGenerationConfig)listBoxConnectionList.SelectedItem;
            this.Close();

        }
    }
}
