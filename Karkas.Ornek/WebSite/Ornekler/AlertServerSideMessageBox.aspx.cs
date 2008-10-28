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
using Karkas.Web.Helpers.BaseClasses;

public partial class Ornekler_AlertServerSideMessageBox : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void KaydetButton_Click(object sender, EventArgs e)
    {
        MessageBox(AdiTextBox.Text + " " + SoyadiTextBox.Text);
    }
}
