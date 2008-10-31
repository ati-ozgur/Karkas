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
using Karkas.Ornek.BsWrapper.Ornekler;
using Karkas.Web.Helpers.BaseClasses;

public partial class Ornekler_OrnekGridToExcelVeWord : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public override void VerifyRenderingInServerForm(Control control) { }
    protected void ButtonWord_Click(object sender, EventArgs e)
    {
        this.GridHelper.GridViewToWord(GridViewArama, "Word");
    }
    protected void ButtonExcel_Click(object sender, EventArgs e)
    {
        this.ExportHelper.ToExcel(new MusteriBsWrapper().SorgulaHepsiniGetirDataTable(), "Musteri");
    }
    protected void ButtonAra_Click(object sender, EventArgs e)
    {
    }
}
