using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Karkas.CodeGeneration.WinApp.UserControls
{
    public partial class UserControlStoredProcedureRelated : UserControl
    {
        public UserControlStoredProcedureRelated()
        {
            InitializeComponent();
        }


        public FormMain ParentMainForm
        {
            get
            {
                return (FormMain)this.ParentForm;
            }
        }



        public void fillComboBoxSchemaList(string[] schemaList)
        {
            comboBoxSchemaList.DataSource = schemaList;
			string defaultSchema = ""; // ParentMainForm.DatabaseHelper.getDefaultSchema();
            if (schemaList.Contains(defaultSchema))
            {
                comboBoxSchemaList.Text = defaultSchema;
            }
            else
            {
                comboBoxSchemaList.Text = schemaList[0];
            }
        }



        internal void fillListBoxStoredProcedures()
        {
            //DataTable dtStoredProcedureList = ParentMainForm.DatabaseHelper.getStoredProcedureListFromSchema(comboBoxSchemaList.Text);
            //listBoxStoredProcedureListesi.DataSource = dtStoredProcedureList;

        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            fillListBoxStoredProcedures();
        }

        private void buttonSemaIcinTumStoredProcedureUret_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOT IMPLEMENTED");
        }

        private void buttonProduceSelectedViews_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOT IMPLEMENTED");
        }

        private void buttonTumStoredProcedureUret_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOT IMPLEMENTED");
        }

    }
}
