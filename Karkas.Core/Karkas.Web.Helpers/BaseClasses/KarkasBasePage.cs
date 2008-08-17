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
        private readonly Karkas.Web.Helpers.HelperClasses.JavascriptHelper jsHelper;
        private IMessageBox mBox = null;

        public KarkasBasePage()
        {
            this.jsHelper = new Karkas.Web.Helpers.HelperClasses.JavascriptHelper(this);
        }

        public void DropDownlaraBindEt(IList list, DropDownList dropDownList, string valueField, string textField)
        {
            DropDownlaraBindEtStatic(list, dropDownList, valueField, textField);
        }

        public static void DropDownlaraBindEtStatic(IList list, DropDownList dropDownList, string valueField, string textField)
        {
            if (list.Count > 0)
            {
                dropDownList.DataSource = list;
                dropDownList.DataTextField = textField;
                dropDownList.DataValueField = valueField;
                dropDownList.DataBind();
            }
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
                this.mBox = (IMessageBox) base.Master.FindControl("MessageBox1");
                if (this.mBox != null)
                {
                    this.mBox.Show("", MesajTuruEnum.None);
                }
            }
            base.OnLoad(e);
        }

        public Guid FirmaKey
        {
            get
            {
                return (Guid) this.Session["FirmaKey"];
            }
            set
            {
                this.Session["FirmaKey"] = value;
            }
        }

        public short FirmaNeviNo
        {
            get
            {
                return (short) this.Session["FirmaNeviNo"];
            }
            set
            {
                this.Session["FirmaNeviNo"] = value;
            }
        }

        public Karkas.Web.Helpers.HelperClasses.JavascriptHelper JavascriptHelper
        {
            get
            {
                return this.jsHelper;
            }
        }

    }
}

