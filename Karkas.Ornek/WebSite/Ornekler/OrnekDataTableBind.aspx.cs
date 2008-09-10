using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Web.Helpers.BaseClasses;
using Karkas.Ornek.BsWrapper.Ornekler;
using System.Data;

public partial class Ornekler_OrnekDataTableBind : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MusteriBsWrapper wrapper = new MusteriBsWrapper();
            DataTable dt = wrapper.SorgulaAdiIle("");
            this.ListHelper.ListControlaBindEt(dt, MusteriDropDownList, "MusteriKey", "TamAdi");
            this.ListHelper.ListControlaBindEtLutfenEkle(dt, MusteriLutfenDropDownList, "MusteriKey", "TamAdi");

        }
    }
}
