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
            if (this.ParentMainForm.ProduceAllTablesAreYouSure())
            {
                string[] schemaList = this.ParentMainForm.GetSchemaList();
                string hatalar = "";
                string message = "";
                try
                {
                    if (schemaList.Length == 0)
                    {
                        hatalar = ParentMainForm.DatabaseHelper.CodeGenerateAllTables();
                        message = "Code generated for all tables in database";
                    }
                    else
                    {
                        foreach(string schemaName in schemaList)
                        {
                            hatalar = hatalar + ParentMainForm.DatabaseHelper.CodeGenerateAllTablesInSchema(schemaName);
                        }
                        message = "Code generated for all tables in following schemas: " + string.Join(",",schemaList);

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

        }


        private void buttonGenerateSelectedTables_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in listBoxTableListesi.SelectedItems)
                {
                    DataRowView view = (DataRowView)item;
                    string tableSchema = view["TABLE_SCHEMA"].ToString();
                    string tableName = view["TABLE_NAME"].ToString();

                    ParentMainForm.DatabaseHelper.CodeGenerateOneTable(tableName, tableSchema);

                }
                MessageBox.Show("Codes are generated for selected tables");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        public void fillTableslistBox()
        {
            DataTable dtTableList = ParentMainForm.DatabaseHelper.getTableListFromSchema(comboBoxSchemaList.Text);
            listBoxTableListesi.DataSource = dtTableList;
        }



        public void fillComboBoxSchemaList(DataTable dtSchemaList)
        {
            if (dtSchemaList.Rows.Count > 0)
            {
                comboBoxSchemaList.DataSource = dtSchemaList;
                comboBoxSchemaList.Text = ParentMainForm.DatabaseHelper.getDefaultSchema();
            }
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            fillTableslistBox();
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

                String hatalar = ParentMainForm.DatabaseHelper.CodeGenerateAllTablesInSchema(selectedSchemaName);
                string message = "Code genereated for all tables in selected schema: " + selectedSchemaName;
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

        private string getSelectedSchemaName()
        {
            DataRowView drv = (DataRowView)comboBoxSchemaList.SelectedValue;
            string schema = drv["SCHEMA_NAME"].ToString();
            return schema;
        }


    }
}
