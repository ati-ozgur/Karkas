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

namespace Arit.Core.UserControls
{

    public partial class AritOnayLinkButton : System.Web.UI.UserControl
    {

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

    




        //private string mstrOnayMesaj = "Silmek istediğinize emin misiniz?";
        private string mstrBeklemeMesaj = "Lütfen Bekleyin";
        //private string mstrText = "";




        public string text
        {
            get
            {
                return "";
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
        protected override void AddParsedSubObject(object obj)
        {
            if (this.HasControls())
            {
                base.AddParsedSubObject(obj);
            }
            else if (obj is LiteralControl)
            {
                this.text = ((LiteralControl)obj).Text;
            }
            else
            {
                string text1 = this.text;
                if (text1.Length != 0)
                {
                    this.text = string.Empty;
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


    }
}
