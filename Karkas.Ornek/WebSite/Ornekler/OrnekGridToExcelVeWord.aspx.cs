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
    protected void ButtonExcelDataTable1_Click(object sender, EventArgs e)
    {
        DataTable dt = new MusteriBsWrapper().SorgulaHepsiniGetirDataTable();
        dt.Columns["Adi"].Caption = "Adı";
        dt.Columns["Soyadi"].Caption = "Soyadı";

        this.ExportHelper.ToExcel(dt);
    }
    protected void ButtonExcelDataTable2_Click(object sender, EventArgs e)
    {
        this.ExportHelper.ToExcel(new MusteriBsWrapper().SorgulaHepsiniGetirDataTable(), "Musteri");
    }
    protected void ButtonExcelDataTable3_Click(object sender, EventArgs e)
    {
        DataTable dt = new MusteriBsWrapper().SorgulaHepsiniGetirDataTable();
        dt.Columns["Adi"].Caption = "Adı";
        dt.Columns["Soyadi"].Caption = "Soyadı";

        this.ExportHelper.ToExcel(dt, "Musteri",true);
    }
    protected void ButtonExcelDataTable4_Click(object sender, EventArgs e)
    {
        DataTable dt = new MusteriBsWrapper().SorgulaHepsiniGetirDataTable();
        dt.Columns.Remove(dt.Columns["MusteriKey"]);
        dt.Columns["Adi"].Caption = "Adı";
        dt.Columns["Soyadi"].Caption = "Soyadı";

        this.ExportHelper.ToExcel(dt, "Musteri", true);
    }

    protected void ButtonExcelDataView1_Click(object sender, EventArgs e)
    {
        DataTable dt = new MusteriBsWrapper().SorgulaHepsiniGetirDataTable();

        DataView dv = new DataView(dt, "Adi LIKE 'a%'", "Adi ASC",DataViewRowState.OriginalRows);
        this.ExportHelper.ToExcel(dv);
    }
    protected void ButtonExcelDataView2_Click(object sender, EventArgs e)
    {
        DataTable dt = new MusteriBsWrapper().SorgulaHepsiniGetirDataTable();

        DataView dv = new DataView(dt, "Adi LIKE 'a%'", "Adi ASC", DataViewRowState.OriginalRows);
        this.ExportHelper.ToExcel(dv,"Musteri");
    }
    protected void ButtonExcelDataView3_Click(object sender, EventArgs e)
    {
        DataTable dt = new MusteriBsWrapper().SorgulaHepsiniGetirDataTable();
        dt.Columns["Adi"].Caption = "Adı";
        dt.Columns["Soyadi"].Caption = "Soyadı";


        DataView dv = new DataView(dt, "Adi LIKE 'a%'", "Adi ASC", DataViewRowState.OriginalRows);
        this.ExportHelper.ToExcel(dv, "Musteri",false);
    }

}
