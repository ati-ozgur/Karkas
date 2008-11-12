using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Web.Helpers.BaseClasses;

public partial class Ornekler_AlertUpdatePanel : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    

    protected void KaydetButton_Click(object sender, EventArgs e)
    {
        MessageBox(AdiTextBox.Text + " " + SoyadiTextBox.Text);
    }

}
