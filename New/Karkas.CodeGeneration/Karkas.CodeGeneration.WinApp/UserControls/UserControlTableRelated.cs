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




        private void buttonTumTablolariUret_Click(object sender, EventArgs e)
        {
            if (this.ParentMainForm.TumVeritabaniKodUretmeEminMisiniz())
            {

                try
                {

                    String hatalar = ParentMainForm.DatabaseHelper.CodeGenerateAllTables();
                    string message = "TÜM TABLOLAR İÇİN KOD ÜRETİLDİ";
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


        private void buttonSeciliTablolariUret_Click(object sender, EventArgs e)
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
                MessageBox.Show("SEÇİLEN TABLOLAR İÇİN KOD ÜRETİLDİ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        public void listBoxTableListDoldur()
        {
            DataTable dtTableList = ParentMainForm.DatabaseHelper.getTableListFromSchema(comboBoxSchemaList.Text);
            listBoxTableListesi.DataSource = dtTableList;
        }



        public void comboBoxSchemaListDoldur(DataTable dtSchemaList)
        {
            if (dtSchemaList.Rows.Count > 0)
            {
                comboBoxSchemaList.DataSource = dtSchemaList;
                comboBoxSchemaList.Text = ParentMainForm.DatabaseHelper.getDefaultSchema();
            }
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxTableListDoldur();
        }






        internal void setComboBoxSchemaListText(string pText)
        {
            comboBoxSchemaList.Text = pText;
        }

        private void buttonSeciliSemaTablolariUret_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedSchemaName = getSelectedSchemaName();

                String hatalar = ParentMainForm.DatabaseHelper.CodeGenerateAllTablesInSchema(selectedSchemaName);
                string message = "TÜM TABLOLAR İÇİN KOD ÜRETİLDİ";
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
