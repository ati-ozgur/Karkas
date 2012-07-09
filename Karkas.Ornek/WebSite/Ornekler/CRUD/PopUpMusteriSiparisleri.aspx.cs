using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Web.Helpers.BaseClasses;
using Karkas.Ornek.BsWrapper.Ornekler;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Web.Helpers;
using Karkas.Web.Helpers.HelperClasses;

public partial class Ornekler_CRUD_PopUpMusteriSiparisleri : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiparisleriGetir();
        }
    }
    private void SiparisleriGetir()
    {
        GridViewSiparis.DataSource = new MusteriSiparisBsWrapper().SorgulaMusteriKeyIle(new Guid(Request.QueryString["MusteriKey"].ToString()));
        GridViewSiparis.DataBind();
    }
    protected void GridViewSiparis_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            new MusteriSiparisBsWrapper().Sil(new Guid(e.CommandArgument.ToString()));
            MessageBox("Sipariş silinmiştir", MesajTuruEnum.Basari);
            SiparisleriGetir();
        }
    }
    protected void ButtonKaydet_Click(object sender, EventArgs e)
    {
        try
        {
            MusteriSiparis siparis = new MusteriSiparis();
            MusteriSiparisBsWrapper siparisWp = new MusteriSiparisBsWrapper();
            siparis.MusteriKey = new Guid(Request.QueryString["MusteriKey"].ToString());
            siparis.MusteriSiparisKey = Guid.NewGuid();
            siparis.SiparisTarihi = Convert.ToDateTime(TextBoxTarih.Text);
            siparis.Tutar = Convert.ToDecimal(TextBoxTutar.Text);
            siparisWp.Ekle(siparis);
            SiparisleriGetir();
            MessageBox("Sipariş kaydedilmiştir", MesajTuruEnum.Basari);
        }
        catch (Exception exc)
        {
            MessageBox("Sipariş kaydedilirken bir hata ile karşılaşıldı. Hata metni : " + exc.Message, MesajTuruEnum.Hata);
            
        }
    }
}
