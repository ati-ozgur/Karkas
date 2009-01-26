using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Web.Helpers.BaseClasses;

public partial class Ornekler_PopUpOrnekleri_OrnekAnaSayfa : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        this.JavascriptHelper.PopUpWindowEventiEkle(ButtonPopUpTilda2, "~/Ornekler/PopUpOrnekleri/OrnekPopUp.aspx", 100, 100, true);
        this.JavascriptHelper.PopUpWindowEventiEkle(ButtonPopUp, "/Website/Ornekler/PopUpOrnekleri/OrnekPopUp.aspx", 100, 100, true);
    }
    protected void ButtonPopUpTilda1_Click(object sender, EventArgs e)
    {
        this.JavascriptHelper.PopUpWindowBaslangictaAc("~/Ornekler/PopUpOrnekleri/OrnekPopUp.aspx", 100, 100, true);
    }
}
