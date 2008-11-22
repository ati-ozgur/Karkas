using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.Utility.ReportingServicesHelper;
using System.IO;

namespace Karkas.Core.DataUtil.TestConsoleApp.RaporCagirmaOrnekleri
{
    public class RaporCagirmaMusteri
    {

        public static void RaporOrnekleriAl()
        {
            raporSadaceIsim();
            raporDogumTarihi();
            raporAktifler();
            raporOnemliler();
            raporPasifler();
            raporKredisiYuksek();
        }

        private static void raporSadaceIsim()
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = RaporFormats.PDF;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            Byte[] rapor = oRapor.RaporAl();


            File.WriteAllBytes("SadaceIsim.pdf", rapor);
        }
        private static void raporDogumTarihi()
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = RaporFormats.PDF;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("DogumTarihi", new DateTime(2000, 1, 1));
            //oRapor.ParametreEkle("AktifMi", true);
            //oRapor.ParametreEkle("Onemi", 5);
            Byte[] rapor = oRapor.RaporAl();

            File.WriteAllBytes("DogumTarihi.pdf", rapor);
        }
        private static void raporAktifler()
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = RaporFormats.PDF;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("AktifMi", true);
            //oRapor.ParametreEkle("Onemi", 5);
            Byte[] rapor = oRapor.RaporAl();

            File.WriteAllBytes("Aktifler.pdf", rapor);
        }
        private static void raporPasifler()
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = RaporFormats.PDF;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("AktifMi", false);
            Byte[] rapor = oRapor.RaporAl();

            File.WriteAllBytes("Pasifler.pdf", rapor);
        }

        private static void raporOnemliler()
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = RaporFormats.PDF;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("Onemi", 5);
            Byte[] rapor = oRapor.RaporAl();
            File.WriteAllBytes("Onemliler.pdf", rapor);
        }
        private static void raporKredisiYuksek()
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = RaporFormats.PDF;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("Kredisi", 1000.0f);
            Byte[] rapor = oRapor.RaporAl();
            File.WriteAllBytes("KredisiYuksek.pdf", rapor);
        }

    }
}
