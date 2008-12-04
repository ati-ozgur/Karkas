using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Karkas.Web.Helpers.CustomControls
{
    [Serializable]
    public class KarkasTreeNode : TreeNode
    {
        public string CssClass { get; set; }

        public string GosterilecekText { get; set; }

        public string GosterilecekToolTip { get; set; }

        //texti atayamasin diye kimse hide et
        private new string Text { get; set; }

        public KarkasTreeNode()
            : base()
        {
            //hidden olmayan parent textini bos ata (valueler textin yaninda gorunmesin diye)
            base.Text = "";
        }

        public KarkasTreeNode(TreeView owner, bool isRoot)
            : base(owner, isRoot)
        {
            //hidden olmayan parent textini bos ata (valueler textin yaninda gorunmesin diye)
            base.Text = "";
        }

        protected override void RenderPreText(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
            if (!String.IsNullOrEmpty(GosterilecekToolTip))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Title, GosterilecekToolTip);
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.Write(GosterilecekText);
            base.RenderPreText(writer);
        }

        protected override void RenderPostText(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
            base.RenderPostText(writer);
        }

        protected override void LoadViewState(Object savedState)
        {
            if (savedState != null)
            {
                object[] myState = (object[])savedState;
                if (myState[0] != null)
                    base.LoadViewState(myState[0]);
                if (myState[1] != null)
                    GosterilecekText = (String)myState[1];
                if (myState[2] != null)
                    CssClass = (String)myState[2];
                if (myState[3] != null)
                    GosterilecekToolTip = (String)myState[3];
            }
        }

        protected override Object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object[] allStates = new object[4];
            allStates[0] = baseState;
            allStates[1] = GosterilecekText;
            allStates[2] = CssClass;
            allStates[3] = GosterilecekToolTip;
            return allStates;
        }
    }
}
