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
using Karkas.Core.Utility.ReportingServicesHelper;

public partial class Ornekler_RaporOrnekleri_RaporKopyalaveDataSourceSetleme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonRaporAc_Click(object sender, EventArgs e)
    {
        string raporDizin = "/OrnekRaporlar/ReportMusteriBilgileri";
        KarkasRapor rapor = new KarkasRapor(raporDizin);
        rapor.OnBeforeRaporAl += new BeforeRaporAl(KarkasRapor_OnBeforeRaporAl);
        rapor.RaporDosyaAd = "ReportMusteriBilgileri";
        rapor.RaporFormat = RaporFormats.PDF;
        rapor.ParametreEkle("Adi", TextBoxAdi.Text);
        rapor.ParametreEkle("Soyadi", TextBoxSoyadi.Text);
        rapor.RaporAc();
    }
    void KarkasRapor_OnBeforeRaporAl(KarkasRapor rapor)
    {
        RaporuKopyalaVeDataSourceunuAta(rapor);
    }

    public void RaporuKopyalaVeDataSourceunuAta(KarkasRapor rapor)
    {
        string[] splitted = rapor.RaporAd.Split('/');
        string yeniRaporAd = splitted[splitted.Length - 1];
        splitted[splitted.Length - 1] = String.Empty;
        string raporYolu = String.Join("/", splitted).TrimEnd('/');

        if (!rapor.RaporVarMi(yeniRaporAd, raporYolu))
        {
            rapor.RaporKopyalaVeDataSourceunuAta(yeniRaporAd, raporYolu, "OrnekRaporlar", raporYolu, "OrnekRaporlar");
        }
        rapor.RaporAd = String.Format("{0}/{1}", raporYolu, yeniRaporAd);
    }
}

