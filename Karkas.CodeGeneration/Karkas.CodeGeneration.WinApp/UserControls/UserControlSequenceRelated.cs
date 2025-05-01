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



        public void fillComboBoxSchemaList(string[] schemaList)
        {
            comboBoxSchemaList.DataSource = schemaList;
			string defaultSchema = "";//ParentMainForm.DatabaseHelper.getDefaultSchema();
            if (schemaList.Contains(defaultSchema))
            {
                comboBoxSchemaList.Text = defaultSchema;
            }
            else
            {
                comboBoxSchemaList.Text = schemaList[0];
            }
        }


        internal void fillListBoxSequences()
        {
            string selectedSchema = comboBoxSchemaList.Text;
            if(!string.IsNullOrWhiteSpace(selectedSchema))
            {
                //DataTable dtSequenceList = ParentMainForm.DatabaseHelper.getSequenceListFromSchema(selectedSchema);
                //listBoxSequences.DataSource = dtSequenceList;
            }

        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            fillListBoxSequences();
        }

        private void buttonGenerateSelectedSequences_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxSequences.SelectedItems)
            {
                DataRowView view = (DataRowView)item;
                string schemaName = view["SEQ_SCHEMA_NAME"].ToString();
                string sequenceName = view["SEQUENCE_NAME"].ToString();
                //ParentMainForm.DatabaseHelper.CodeGenerateOneSequence(schemaName,sequenceName);

            }

            MessageBox.Show("Code generated for selected sequences");
        }

        private void buttonGenerateAllSequencesInDatabase_Click(object sender, EventArgs e)
        {

            MessageBox.Show("NOT IMPLEMENTED YET");

        }


        private void buttonGenerateSequenceInSelectedSchema_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBoxSchemaList.SelectedValue != null)
                {
                    string selectedSchemaName = comboBoxSchemaList.SelectedValue.ToString();


					string errors = "";//ParentMainForm.DatabaseHelper.CodeGenerateAllSequencesInSchema(selectedSchemaName);
                    string message = $"Sequences created in schema {selectedSchemaName}";
                    if (!string.IsNullOrEmpty(errors))
                    {
                        message = message + ", Errors " + errors;
                    }
                    MessageBox.Show(message);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
