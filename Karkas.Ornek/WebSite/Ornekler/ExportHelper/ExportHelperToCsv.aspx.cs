using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Web.Helpers.BaseClasses;
using System.Data;
using Karkas.Ornek.BsWrapper.Ornekler;
using System.Text;

public partial class Ornekler_ExportHelper_ExportHelperToCsv : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonCsv_Click(object sender, EventArgs e)
    {
        MusteriBsWrapper wrapper = new MusteriBsWrapper();
        DataTable dt = wrapper.SorgulaHepsiniGetirDataTable();

        this.ExportHelper.ToCsv(dt, "Deneme", "csv", false, Encoding.UTF8);
    }
}
