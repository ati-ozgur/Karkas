namespace Karkas.Web.Helpers.BaseClasses
{
    using Karkas.Web.Helpers.Classes;
    using Karkas.Web.Helpers.HelperClasses;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public abstract class KarkasBasePage : Page
    {
        private readonly KarkasWebHelper.JavascriptHelper jsHelper;
        private readonly KarkasWebHelper.ListHelper listHelper;
        private readonly KarkasWebHelper.GridHelper gridHelper;
        private readonly KarkasWebHelper.QueryStringHelper queryHelper;



        IMessageBox mBox = null;

        public KarkasBasePage()
        {
            this.jsHelper = new KarkasWebHelper.JavascriptHelper(this);
            this.listHelper = new KarkasWebHelper.ListHelper();
            this.gridHelper = new KarkasWebHelper.GridHelper(this);
            this.queryHelper = new KarkasWebHelper.QueryStringHelper();

            System.Data.DataTable dt = new System.Data.DataTable();
            this.listHelper.ListControlaBindEt(dt, null, "", "");
        }




        public void MessageBox(string pMessage)
        {
            if (mBox != null)
            {
                this.mBox.Show(pMessage);
            }
            else
            {
                this.JavascriptHelper.Alert(pMessage);
            }
        }

        public void MessageBox(string[] pMessageList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in pMessageList)
            {
                sb.Append(s + Environment.NewLine);
            }
            this.MessageBox(sb.ToString());
        }

        public void MessageBox(List<string> pMessageList)
        {
            this.MessageBox(pMessageList.ToArray());
        }

        public void MessageBox(string pMesaj, MesajTuruEnum pMesajTur)
        {
            if (mBox != null)
            {
                this.mBox.Show(pMesaj, pMesajTur);
            }
            else
            {
                this.JavascriptHelper.Alert(pMesaj);
            }
        }

        public void MessageBoxClose()
        {
            if (mBox != null)
            {
                this.mBox.Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!base.IsPostBack)
            {
            }
            if (base.Master != null)
            {
                this.mBox = base.Master.FindControl("MessageBox1") as IMessageBox;
            }
            if (mBox == null)
            {
                this.mBox = this.FindControl("MessageBox1") as IMessageBox;
            }
            base.OnLoad(e);
        }

        public KarkasWebHelper.ListHelper ListHelper
        {
            get { return listHelper; }
        }

        public KarkasWebHelper.JavascriptHelper JavascriptHelper
        {
            get
            {
                return this.jsHelper;
            }
        }
        public KarkasWebHelper.GridHelper GridHelper
        {
            get { return gridHelper; }
        }


    }
}

