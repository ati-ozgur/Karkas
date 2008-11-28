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

        public static void RaporOrnekleriAl(RaporFormats format)
        {
            raporSadaceIsim(format);
            raporDogumTarihi(format);
            raporAktifler(format);
            raporOnemliler(format);
            raporPasifler(format);
            raporKredisiYuksek(format);
            YardimMasasiOrnekRapor(format);
        }

        public static void YardimMasasiOrnekRapor(RaporFormats format)
        {
            string raporDizin = "/YardimMasasiRapor/YardimMasasiIstatistikRaporu";
            KarkasRapor rapor = new KarkasRapor(raporDizin);
            rapor.RaporDosyaAd = "IstatistikRaporu";
            rapor.RaporFormat = format;
            rapor.ParametreEkle("pTarihBaslangic", new DateTime(2000, 1, 1));
            rapor.ParametreEkle("pTarihBitis", new DateTime(2010, 1, 1));
            Byte[] sonuc = rapor.RaporAl();
            File.WriteAllBytes(String.Format("Istatistik.{0}", getReportExtension(format)), sonuc);
        }


        private static void raporSadaceIsim(RaporFormats format)
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = format;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.UseDefaultCredentials = true;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            Byte[] rapor = oRapor.RaporAl();

            File.WriteAllBytes(String.Format("SadaceIsim.{0}", getReportExtension(format)), rapor);
        }
        private static void raporDogumTarihi(RaporFormats format)
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = format;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.UseDefaultCredentials = true;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("DogumTarihi", new DateTime(2000, 1, 1));
            //oRapor.ParametreEkle("AktifMi", true);
            //oRapor.ParametreEkle("Onemi", 5);
            Byte[] rapor = oRapor.RaporAl();

            File.WriteAllBytes(String.Format("DogumTarihi.{0}", getReportExtension(format)), rapor);
        }
        private static void raporAktifler(RaporFormats format)
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = format;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.UseDefaultCredentials = true;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("AktifMi", true);
            //oRapor.ParametreEkle("Onemi", 5);
            Byte[] rapor = oRapor.RaporAl();

            File.WriteAllBytes(String.Format("Aktifler.{0}", getReportExtension(format)), rapor);
        }
        private static void raporPasifler(RaporFormats format)
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = format;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.UseDefaultCredentials = true;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("AktifMi", false);
            Byte[] rapor = oRapor.RaporAl();

            File.WriteAllBytes(String.Format("Pasifler.{0}", getReportExtension(format)), rapor);
        }

        private static void raporOnemliler(RaporFormats format)
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = format;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.UseDefaultCredentials = true;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("Onemi", 5);
            Byte[] rapor = oRapor.RaporAl();

            File.WriteAllBytes(String.Format("Onemliler.{0}", getReportExtension(format)), rapor);
        }
        private static void raporKredisiYuksek(RaporFormats format)
        {
            KarkasRapor oRapor = new KarkasRapor("/OrnekRaporlar/OrneklerMusteri");
            oRapor.RaporFormat = format;
            oRapor.UseDefaultCredentials = true;
            oRapor.WebServiceSecurityModel = KarkasRapor.WebServiceSecurityModelConstants.NTLM;
            oRapor.UseDefaultCredentials = true;
            oRapor.ParametreEkle("Adi", "");
            oRapor.ParametreEkle("Soyadi", "");
            oRapor.ParametreEkle("Kredisi", 1000.0f);
            Byte[] rapor = oRapor.RaporAl();

            File.WriteAllBytes(String.Format("KredisiYuksek.{0}", getReportExtension(format)), rapor);
        }

        private static string getReportExtension(RaporFormats format)
        {
            switch (format)
            {
                case RaporFormats.EXCEL:
                    return "xls";
                case RaporFormats.PDF:
                    return "pdf";
                case RaporFormats.IMAGE:
                    return "tiff";
                case RaporFormats.XML:
                    return "xml";
            }

            return "Taniyamadim";
        }

    }
}
