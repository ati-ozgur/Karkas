using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Karkas.Web.Helpers.CustomControls
{
    /// <summary>
    /// bu trievew'in olmasinin tek nedeni normal asp.net treeviewin turkce karakterlerde sorun cikartmasidir
    /// </summary>
    [Serializable]
    public class KarkasTreeView : TreeView
    {
        protected override TreeNode CreateNode()
        {
            return new KarkasTreeNode(this, false);
        }
    }
}
