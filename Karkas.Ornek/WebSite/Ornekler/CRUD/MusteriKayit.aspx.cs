using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.BsWrapper.Ornekler;
using Karkas.Web.Helpers.BaseClasses;
using Karkas.Web.Helpers.Classes;

public partial class Ornekler_CRUD_MusteriKayit : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BilgileriGetir();
        }
    }
    private void BilgileriGetir()
    {
        if (Request.QueryString["Durum"] == "Guncelle")
        {
            Musteri musteri = new Musteri();
            MusteriBsWrapper musteriWp = new MusteriBsWrapper();
            musteri = musteriWp.SorgulaMusteriKeyIle(new Guid(Request.QueryString["MusteriKey"].ToString()));
            if (musteri != null)
            {
                TextBoxAdi.Text = musteri.Adi;
                TextBoxDogumTarihi.Text = musteri.DogumTarihi.Value.ToShortDateString();
                TextBoxIkinciAdi.Text = musteri.IkinciAdi;
                TextBoxSoyadi.Text = musteri.Soyadi;
                if (musteri.AktifMi)
                    CheckBoxAktifmi.Checked = true;
                else
                    CheckBoxAktifmi.Checked = false;
            }
        }
    }
    protected void ButtonKaydet_Click(object sender, EventArgs e)
    {
        try
        {
            Musteri musteri = new Musteri();
            MusteriBsWrapper musteriWp = new MusteriBsWrapper();
            musteri.Adi = TextBoxAdi.Text;
            if (CheckBoxAktifmi.Checked)
                musteri.AktifMi = true;
            else
                musteri.AktifMi = false;
            musteri.DogumTarihi = Convert.ToDateTime(TextBoxDogumTarihi.Text);
            musteri.IkinciAdi = TextBoxIkinciAdi.Text;
            musteri.Soyadi = TextBoxSoyadi.Text;

            if (Request.QueryString["Durum"] == "Guncelle")
            {
                musteri.MusteriKey = new Guid(Request.QueryString["MusteriKey"].ToString());
                musteriWp.Guncelle(musteri);
            }
            else
            {
                musteri.MusteriKey = Guid.NewGuid();
                musteriWp.Ekle(musteri);
            }
            MessageBox("Müşteri Kaydedilmiştir", MesajTuruEnum.Basari);
        }
        catch (Exception exc)
        {
            MessageBox("Müşteri Kaydedilirken bir hata ile karşılaşıldı. Hata Metni : " + exc.Message, MesajTuruEnum.Basari);
        }
    }
}
