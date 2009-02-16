using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;

namespace Arit.Web.UserControls
{
    public partial class AritOnayLinkButton : System.Web.UI.UserControl
    {

        //SAYFADA SCRIPTMANAGER DINAMIK YUKLENMESINI ISTERSENIZ ASAGIDAKI KODU COMMENTTEN CIKARIN. 
        //GENELDE MASTERPAGE VEYA BASEPAGE OLMADIGI DURUMLARDA ISINIZE YARAR
        //DATABIND METODU ICINDE PREINIT VE INITLER CALISMAMAKTA. O NEDENLE SAYFALARA MANUEL OLARAK 
        //SCRIPTMANAGER EKLEMENIZ GEREKIR.

        protected override void OnInit(EventArgs e)
        {
            //Page.PreInit += delegate(object sender, EventArgs e_Init)
            //{
            //    if (ScriptManager.GetCurrent(Page) == null)
            //    {
            //        ScriptManager sMgr = new ScriptManager();
            //        sMgr.EnablePartialRendering = true;
            //        foreach (Control c in Page.Controls)
            //        {
            //            if (c is System.Web.UI.HtmlControls.HtmlForm)
            //                c.Controls.Add(sMgr);
            //        }
            //    }
            //};
           

            //Page.Init += delegate(object sender, EventArgs e_Init)
            //{
            //    if (ScriptManager.GetCurrent(Page) == null)
            //    {
            //        ScriptManager sMgr = new ScriptManager();
            //        sMgr.EnablePartialRendering = true;
            //        foreach (Control c in Page.Controls)
            //        {
            //            if (c is System.Web.UI.HtmlControls.HtmlForm)
            //                c.Controls.Add(sMgr);
            //        }
            //    }
            //};

            base.OnInit(e);

        }


        /// <summary>
        /// Client'ta javascript olarak calisacak kodu setler
        /// </summary>
        public string OnClientCancel
        {
            get
            {
                return cbe.OnClientCancel;
            }
            set
            {
                cbe.OnClientCancel = value;
            }
        }

        private string mstrBeklemeMesaj = "Lütfen Bekleyin";


        public string Text
        {
            get
            {
                if (OnayButton != null)
                {
                    return OnayButton.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                OnayButton.Text = value;
            }
        }

        public string OnayMesaj
        {
            get
            {
                return cbe.ConfirmText;
            }
            set
            {
                cbe.ConfirmText = value;
            }
        }
        public string BeklemeMesaj
        {
            get
            {
                return mstrBeklemeMesaj;
            }
            set
            {
                mstrBeklemeMesaj = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return OnayButton.Enabled;
            }
            set
            {
                OnayButton.Enabled = value;
            }
        }

        protected override void AddParsedSubObject(object obj)
        {
            if (this.HasControls())
            {
                base.AddParsedSubObject(obj);
            }
            else if (obj is LiteralControl)
            {
                this.Text = ((LiteralControl)obj).Text;
            }
            else
            {
                string text1 = this.Text;
                if (text1.Length != 0)
                {
                    this.Text = string.Empty;
                    base.AddParsedSubObject(new LiteralControl(text1));
                }
                base.AddParsedSubObject(obj);
            }
        }

        public string CommandName
        {
            get
            {
                return OnayButton.CommandName;
            }
            set
            {
                OnayButton.CommandName = value;
            }
        }

        public Color ForeColor
        {
            get
            {
                return OnayButton.ForeColor;
            }
            set
            {
                OnayButton.ForeColor = value;
            }
        }
        public string CommandArgument
        {
            get
            {
                return OnayButton.CommandArgument;
            }
            set
            {
                OnayButton.CommandArgument = value;
            }
        }

        protected virtual void OnClick(EventArgs e)
        {

            EventHandler handler = (EventHandler)base.Events[EventClick];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private static readonly object EventClick;

        public event EventHandler Click
        {
            add
            {
                this.OnayButton.Click += value;
                base.Events.AddHandler(EventClick, value);
            }
            remove
            {
                this.OnayButton.Click -= value;
            }
        }

        public string OnClientClick
        {
            get 
            {
                return OnayButton.OnClientClick;
            }
            set 
            {
                OnayButton.OnClientClick = value;
            }
        }
        //ARITONAYIMAGEBUTTON U LINKBUTONA CAST ETMEK ICIN 
        public static explicit operator LinkButton(AritOnayLinkButton arg)
        {
            return arg.OnayButton;
        }

    }
}

