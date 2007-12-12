using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using Simetri.Core.Utility.ReportingServicesHelper;
using Simetri.Core.Utility.ReportingServicesHelper.Generated;
using log4net;
using System.IO;

namespace Simetri.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            log4net.Config.XmlConfigurator.Configure(new FileInfo("Development.log4net"));


            AdoTemplate template = new AdoTemplate();
            template.KisiKey = new Guid("488B1F2F-0DC7-4534-96DE-5FA0FAC35B71");

            int sonuc = (int) template.TekDegerGetir("SELECT COUNT(*) FROM ORTAK.KISI");
            Console.WriteLine(sonuc);

            Console.ReadLine();
        }

        private static void disardanDegerleriSetleyerekRaporAl()
        {
            AritRapor oAritRapor = new AritRapor("/MtkTsmRaporlar/IsYeriBilgileriMtk");
            oAritRapor.UseDefaultCredentials = false;
            oAritRapor.RaporUser = "builduser";
            oAritRapor.RaporPassword = "123";
            oAritRapor.RaporCredentialsDomain = "ATILLA";
            oAritRapor.WebServiceSecurityModel = AritRapor.WebServiceSecurityModelConstants.NTLM;
            Byte[] rapor = oAritRapor.RaporAl();
        }

        //public static void raporKurulusBildirimFormuAlUserNamePassword()
        //{
        //    AritRapor oAritRapor = new AritRapor("/MtkTsmRaporlar/IsYeriBilgileriMtk");
        //    oAritRapor.RaporDosyaAd = "IsYeriBilgileriMtk ";
        //    oAritRapor.RaporFormat = RaporFormats.PDF;
        //    oAritRapor.UseDefaultCredentials = false;
        //    oAritRapor.RaporUser = "builduser";
        //    oAritRapor.RaporPassword = "123";
        //    //oAritRapor.RaporSunucuUrl = "http://localhost/Reports/";
        //    Byte[] rapor = oAritRapor.RaporAl();
        //}



    }
}
