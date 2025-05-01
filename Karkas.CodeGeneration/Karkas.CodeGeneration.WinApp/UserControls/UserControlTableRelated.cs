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
    public partial class UserControlTableRelated : UserControl
    {
        public UserControlTableRelated()
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




        private void buttonGenerateAllTables_Click(object sender, EventArgs e)
        {
            string[] schemaList = this.ParentMainForm.GetSchemaList();
            if (schemaList.Length == 0)
            {
                bool answer = this.ParentMainForm.ProduceAllTablesAreYouSure();
                if (!answer)
                {
                    return;
                }
            }

            string hatalar = "";
            string message = "";
            try
            {
                if (schemaList.Length == 0)
                {
					hatalar = "";// ParentMainForm.DatabaseHelper.CodeGenerateAllTables();
                    message = "Code generated for all tables in database";
                }
                else
                {
                    foreach (string schemaName in schemaList)
                    {
						hatalar = hatalar; //+ ParentMainForm.DatabaseHelper.CodeGenerateAllTablesInSchema(schemaName);
                    }
                    message = "Code generated for all tables in following schemas: " + string.Join(",", schemaList);

                }

                if (!string.IsNullOrEmpty(hatalar))
                {
                    message = message + ", HATALAR " + hatalar;
                }
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void buttonGenerateSelectedTables_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in listBoxTables.SelectedItems)
                {
                    string full_table_name = item.ToString();
					string[] l = full_table_name.Split(".");
                    string tableSchema = l[0];
                    string tableName = l[1];

                    ParentMainForm.DatabaseHelper.CodeGenerateOneTable(tableName, tableSchema);

                }
                MessageBox.Show("Codes are generated for selected tables");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        public void fillTablesInListBox()
        {
            var dtTableList = ParentMainForm.DatabaseHelper.GetTableListFromSchema(comboBoxSchemaList.Text);
			List<string> displayList = new List<string>();
			foreach (var d in dtTableList)
			{
				string fullTableName = d["FULL_TABLE_NAME"].ToString();
				displayList.Add(fullTableName);
			}

			listBoxTables.DataSource = displayList;
        }



        public void fillComboBoxSchemaList(string[] schemaList)
        {
            comboBoxSchemaList.DataSource = schemaList;
			string defaultSchema = ""; //= ParentMainForm.DatabaseHelper.getDefaultSchema();
            if (schemaList.Contains(defaultSchema))
            {
                comboBoxSchemaList.Text = defaultSchema;
            }
            else
            {
                comboBoxSchemaList.Text = schemaList[0];
            }
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            fillTablesInListBox();
        }






        internal void setComboBoxSchemaListText(string pText)
        {
            comboBoxSchemaList.Text = pText;
        }

        private void buttonGenerateTablesForSelectedSchema_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedSchemaName = getSelectedSchemaName();

				String errorMessages = ""; // ParentMainForm.DatabaseHelper.CodeGenerateAllTablesInSchema(selectedSchemaName);
                string message = "Code genereated for all tables in selected schema: " + selectedSchemaName;
                if (!string.IsNullOrEmpty(errorMessages))
                {
                    message = message + ", ERRORS: " + errorMessages;
                }
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string getSelectedSchemaName()
        {
            string schemaName = comboBoxSchemaList.SelectedValue as string;
            if (schemaName != null)
            {
                return schemaName;
            }
            DataRowView drv = comboBoxSchemaList.SelectedValue as DataRowView;

            if (drv != null)
            {
                schemaName = drv["SCHEMA_NAME"].ToString();
                return schemaName;
            }
            throw new ArgumentException("problem in the schema binding");
        }


    }
}
