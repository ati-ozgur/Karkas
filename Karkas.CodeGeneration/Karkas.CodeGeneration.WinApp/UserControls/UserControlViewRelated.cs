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
    public partial class UserControlViewRelated : UserControl
    {
        public UserControlViewRelated()
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


        public void listBoxViewListDoldur()
        {
            //DataTable dtViewList = ParentMainForm.DatabaseHelper.getViewListFromSchema(comboBoxSchemaList.Text);
            //listBoxViewListesi.DataSource = dtViewList;
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxViewListDoldur();
        }

        private void buttonProduceSelectedViews_Click(object sender, EventArgs e)
        {
            {
                foreach (var item in listBoxViewListesi.SelectedItems)
                {
                    DataRowView view = (DataRowView)item;
                    string viewSchema = view["VIEW_SCHEMA"].ToString();
                    string viewName = view["VIEW_NAME"].ToString();


                    try
                    {
                        //ParentMainForm.DatabaseHelper.CodeGenerateOneView(viewName, viewSchema);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                MessageBox.Show("SEÇİLEN TABLOLAR İÇİN KOD ÜRETİLDİ");

            }


        }

        private void buttonProduceAllViews_Click(object sender, EventArgs e)
        {
            if (this.ParentMainForm.ProduceAllTablesAreYouSure())
            {

                try
                {


					String hatalar = "";//ParentMainForm.DatabaseHelper.CodeGenerateAllViews();
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

        private void buttonSeciliSemaViewUret_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedSchemaName = getSelectedSchemaName();

				String hatalar = ""; // ParentMainForm.DatabaseHelper.CodeGenerateAllViewsInSchema(selectedSchemaName);
                string message = string.Format("Secilen ŞEMA {0} için , TÜM TABLOLAR İÇİN KOD ÜRETİLDİ", selectedSchemaName);
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

