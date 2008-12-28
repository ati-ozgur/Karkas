using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Core.Utility.ReportingServicesHelper;

public partial class Ornekler_RaporOrnekleri_RaporAcma : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonRaporAc_Click(object sender, EventArgs e)
    {
        string raporDizin = "/OrnekRaporlar/ReportMusteriBilgileri";
        KarkasRapor rapor = new KarkasRapor(raporDizin);
        rapor.RaporDosyaAd = "ReportMusteriBilgileri";
        rapor.RaporFormat = RaporFormats.PDF;
        rapor.ParametreEkle("Adi", TextBoxAdi.Text);
        rapor.ParametreEkle("Soyadi", TextBoxSoyadi.Text);
        rapor.RaporAc();
    }

    protected void ButtonRaporTarayiciIcindeAc_Click(object sender, EventArgs e)
    {
        string raporDizin = "/OrnekRaporlar/ReportMusteriBilgileri";
        KarkasRapor rapor = new KarkasRapor(raporDizin);
        rapor.RaporDosyaAd = "ReportMusteriBilgileri";
        rapor.RaporFormat = RaporFormats.PDF;
        rapor.ParametreEkle("Adi", TextBoxAdi.Text);
        rapor.ParametreEkle("Soyadi", TextBoxSoyadi.Text);
        rapor.TarayiciDavranisi = TarayiciDavranisiEnum.TarayiciIcindeGoster;
        rapor.RaporAc();
    }
}
