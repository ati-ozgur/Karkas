using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGeneration.WinApp.PersistenceService;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class FormAbbreviations : Form
    {



        public FormAbbreviations(DatabaseEntry pDatabaseEntry)
        {
            this.DatabaseEntry = pDatabaseEntry;
            InitializeComponent();

            this.listBoxAbbrevations.DataSource = null;// this.DatabaseEntry.getAbbreviationsDataSource();
        }


        public DatabaseEntry DatabaseEntry { get; set; }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            DatabaseAbbreviations abbr = new DatabaseAbbreviations();
            abbr.FullNameReplacement = textBoxReplacementText.Text;
            abbr.Abbreviation = textBoxAbbreviations.Text;





            //this.DatabaseEntry.AddAbbreviations(abbr);


            this.listBoxAbbrevations.DataSource = null;
            
        }
    }
}
