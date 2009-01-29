using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.BsWrapper.Ornekler;


public partial class Ornekler_LinqOrnekleri_GridSort : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridViewMusteriListesi.DataSource = MusteriListesi;
            GridViewMusteriListesi.DataBind();
        }
    }

    private List<Musteri> MusteriListesi
    {
        get
        {
            if (Session["MusteriListesi"] == null)
            {
                MusteriBsWrapper wrapper = new MusteriBsWrapper();
                List<Musteri> liste = wrapper.SorgulaHepsiniGetir();
                Session["MusteriListesi"] = liste;

            }
            return (List<Musteri>)Session["MusteriListesi"];
        }
    }

    protected void GridViewMusteriListesi_Sorting(object sender, GridViewSortEventArgs e)
    {
        if ((ViewState["SortExpression"] != null) && (ViewState["SortExpression"].ToString() != e.SortExpression))
        {
            ViewState["SortExpression"] = e.SortExpression;
        }
        else
        {
            if (ViewState["SortDirection"] != null)
            {
                e.SortDirection = (SortDirection)ViewState["SortDirection"];
            }
        }


            List<Musteri> liste = MusteriListesi;
            IEnumerable<Musteri> sonuc = null;
            if (e.SortExpression == "Adi" && e.SortDirection == SortDirection.Ascending)
            {
                sonuc = from musteri in liste
                        orderby musteri.Adi ascending
                        select musteri;
                ViewState["SortDirection"] = SortDirection.Descending;
            }
            else if (e.SortExpression == "Adi" && e.SortDirection == SortDirection.Descending)
            {
                sonuc = from musteri in liste
                        orderby musteri.Adi descending
                        select musteri;
                ViewState["SortDirection"] = SortDirection.Ascending;

            }
            if (sonuc != null)
            {
                List<Musteri> sortedListe = (List<Musteri>)sonuc.ToList();
                GridViewMusteriListesi.DataSource = sortedListe;
                GridViewMusteriListesi.DataBind();
            }

    }
}
