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

        private IMessageBox mBox = null;

        public KarkasBasePage()
        {
            this.jsHelper = new KarkasWebHelper.JavascriptHelper(this);
            this.listHelper = new  KarkasWebHelper.ListHelper();
        }




        public void MessageBox(string pMessage)
        {
            this.mBox.Show(pMessage);
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
            this.mBox.Show(pMesaj, pMesajTur);
        }

        public void MessageBoxClose()
        {
            this.mBox.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!base.IsPostBack)
            {
            }
            if (base.Master != null)
            {
                this.mBox = (IMessageBox)base.Master.FindControl("MessageBox1");
                if (this.mBox != null)
                {
                    this.mBox.Show("", MesajTuruEnum.None);
                }
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

    }
}

