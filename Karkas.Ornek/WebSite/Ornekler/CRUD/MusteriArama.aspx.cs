using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Web.Helpers.BaseClasses;
using Karkas.Ornek.BsWrapper.Ornekler;

public partial class Ornekler_CRUD_MusteriArama : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonAra_Click(object sender, EventArgs e)
    {
        Ara();
    }
    private void Ara()
    {
        bool pDurum = false;
        if (CheckBoxAktifmi.Checked)
            pDurum = true;
        GridViewArama.DataSource = new MusteriBsWrapper().SorgulaAdiSoyadiVeDurumuIle(TextBoxAdi.Text, TextBoxSoyadi.Text, pDurum);
        GridViewArama.DataBind();
    }
    protected void GridViewArama_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            JavascriptHelper.PopUpWindowEventiEkle(((HyperLink)e.Row.FindControl("HyperLinkSiparis")), "PopUpMusteriSiparisleri.aspx?MusteriKey=" + 
                GridViewArama.DataKeys[e.Row.RowIndex]["MusteriKey"].ToString(), 800, 600, true);
            ((HyperLink)e.Row.FindControl("HyperLinkGuncelle")).NavigateUrl = "MusteriKayit.aspx?Durum=Guncelle&MusteriKey=" + GridViewArama.DataKeys[e.Row.RowIndex]["MusteriKey"].ToString();

            if (e.Row.Cells[4].Text == "True")
            {
                e.Row.Cells[4].Text = "Aktif";
            }
            else
            {
                e.Row.Cells[4].Text = "Pasif";
            }
        }
    }
    protected void GridViewArama_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewArama.PageIndex = e.NewPageIndex;
        Ara();
    }
}
