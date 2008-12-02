using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Web.Helpers.CustomControls;

public partial class Ornekler_KarkasTreeView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RootNodelariDoldur();
        }
    }

    private void RootNodelariDoldur()
    {
        for (int i = 0; i < 5; i++)
        {
            //başlangıç olarak tree'ye root node ekle
            KarkasTreeNode rootNode = new KarkasTreeNode();
            rootNode.GosterilecekText = "Deneme ÇÖŞĞÜIİ";
            rootNode.PopulateOnDemand = true;
            rootNode.Value = i.ToString();
            rootNode.GosterilecekToolTip = "ÇÜŞŞŞŞğğğğİİİİıııııöööööÖÖÖ";
            //rootNode.CssClass = "GorevTreeNodeBaslik";
            rootNode.SelectAction = TreeNodeSelectAction.None;
            trvEvrakSafahati.Nodes.Add(rootNode);
        }
    }

    public void trvEvrakSafahati_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        for (int i = 0; i < 5; i++)
        {
            //başlangıç olarak tree'ye root node ekle
            KarkasTreeNode childNode = new KarkasTreeNode();
            childNode.GosterilecekText = "Deneme ÇÖŞĞÜIİ";
            childNode.PopulateOnDemand = true;
            childNode.Value = i.ToString();
            childNode.GosterilecekToolTip = "ÇÜŞŞŞŞğğğğİİİİıııııöööööÖÖÖ";
            //rootNode.CssClass = "GorevTreeNodeBaslik";
            childNode.SelectAction = TreeNodeSelectAction.None;
            e.Node.ChildNodes.Add(childNode);
        }
    }
}
