using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arit.Web.UserControls
{
    public partial class AritOnayImageButton : System.Web.UI.UserControl
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
        /// 


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


        public string aoimtext = "";
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
        public string Text
        {
            get
            {
                return aoimtext;
            }
            set
            {
                aoimtext = value;
            }
        }
        public bool Enabled
        {
            get
            {
                return OnayImageButton.Enabled;
            }
            set
            {
                OnayImageButton.Enabled = value;
            }
        }

        public string ImageURL
        {
            set
            {
                OnayImageButton.ImageUrl = value;
            }
        }
        public string CommandArgument
        {
            get
            {
                return OnayImageButton.CommandArgument;
            }
            set
            {
                OnayImageButton.CommandArgument = value;
            }
        }
        public string CommandName
        {
            get
            {
                return OnayImageButton.CommandName;
            }
            set
            {
                OnayImageButton.CommandName = value;
            }
        }
        public string ToolTip
        {
            get
            {
                return OnayImageButton.ToolTip;
            }
            set
            {
                OnayImageButton.ToolTip = value;
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

        public event ImageClickEventHandler Click
        {
            add
            {
                this.OnayImageButton.Click += value;
                base.Events.AddHandler(EventClick, value);
            }
            remove
            {
                this.OnayImageButton.Click -= value;
            }
        }
        //ARITONAYIMAGEBUTTON U LINKBUTONA CAST ETMEK ICIN 
        public static explicit operator LinkButton(AritOnayImageButton arg)
        {
            LinkButton linkBtn = new LinkButton();
            linkBtn.CommandArgument = arg.OnayImageButton.CommandArgument;
            linkBtn.CommandName = arg.OnayImageButton.CommandName;
            linkBtn.ToolTip = arg.OnayImageButton.ToolTip;
            return linkBtn;
        }
        //ARITONAYIMAGEBUTTON U IMAGEBUTTON CAST ETMEK ICIN
        public static explicit operator ImageButton(AritOnayImageButton arg)
        {
            return arg.OnayImageButton;
        }
    }
}
