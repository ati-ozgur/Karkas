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
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class FormAbbreviations : Form
    {



        public FormAbbreviations(DatabaseEntry pDatabaseEntry)
        {
            this.DatabaseEntry = pDatabaseEntry;
            InitializeComponent();

            this.listBoxKisaltmalar.DataSource = null;// this.DatabaseEntry.getAbbreviationsDataSource();
        }


        public DatabaseEntry DatabaseEntry { get; set; }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            DatabaseAbbreviations abbr = new DatabaseAbbreviations();
            abbr.FullNameReplacement = textBoxYerineGecenYazi.Text;
            abbr.Abbreviation = textBoxKisaltma.Text;





            //this.DatabaseEntry.AddAbbreviations(abbr);


            this.listBoxKisaltmalar.DataSource = null;
            
        }
    }
}
