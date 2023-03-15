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
    public partial class UserControlSequenceRelated : UserControl
    {
        public UserControlSequenceRelated()
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



        public void comboBoxSchemaListDoldur(DataTable dtSchemaList)
        {
            if (dtSchemaList.Rows.Count > 0)
            {
                comboBoxSchemaList.DataSource = dtSchemaList;
                comboBoxSchemaList.Text = ParentMainForm.DatabaseHelper.getDefaultSchema();
            }
        }



        internal void listBoxSequenceListDoldur()
        {
            DataTable dtSequenceList = ParentMainForm.DatabaseHelper.getSequenceListFromSchema(comboBoxSchemaList.Text);
            listBoxSequenceListesi.DataSource = dtSequenceList;

        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxSequenceListDoldur();
        }

        private void buttonSeciliSequenceUret_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxSequenceListesi.SelectedItems)
            {
                DataRowView view = (DataRowView)item;
                string schemaName = view["SEQ_SCHEMA_NAME"].ToString();
                string sequenceName = view["SEQUENCE_NAME"].ToString();
                ParentMainForm.DatabaseHelper.CodeGenerateOneSequence(
                     sequenceName
                    , schemaName
                    );

            }

            MessageBox.Show("SEÇİLEN SEQUENCES İÇİN KOD ÜRETİLDİ");
        }

        private void buttonGenerateAllSequencesInDatabase_Click(object sender, EventArgs e)
        {

            MessageBox.Show("NOT IMPLEMENTED YET");

        }

        private string getSelectedSchemaName()
        {
            DataRowView drv = (DataRowView) comboBoxSchemaList.SelectedValue;
            string schema = drv["SCHEMA_NAME"].ToString();
            return schema;
        }

        private void buttonGenerateSequenceInSelectedSchema_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedSchemaName = getSelectedSchemaName();


                string errors = ParentMainForm.DatabaseHelper.CodeGenerateAllSequencesInSchema(selectedSchemaName);
                string message = $"Sequences created in schema {selectedSchemaName}";
                if (!string.IsNullOrEmpty(errors))
                {
                    message = message + ", Errors " + errors;
                }
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
