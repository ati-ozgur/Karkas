using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using log4net;
using System.IO;
using Karkas.Core.DataUtil.TestConsoleApp.Tests;
using Karkas.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri.Email;
using Karkas.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri;
using Karkas.Core.Utility.ReportingServicesHelper;

namespace Karkas.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            SorguYardimcisiTests syt = new SorguYardimcisiTests();
            syt.NormalArama();

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
