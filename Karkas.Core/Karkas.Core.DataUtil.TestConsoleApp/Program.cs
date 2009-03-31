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
using Karkas.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri.KarsilastirmaTestleri;
using Karkas.Core.DataUtil.TestConsoleApp.Tests.WebHelperTestleri;
using Karkas.Core.DataUtil.TestConsoleApp.RaporCagirmaOrnekleri;
using Karkas.Core.Utility;

namespace Karkas.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string deger = @"( SELECT * FROM DENEME_TABLO ) AS DENEME SELECT * 0FROM1 DENEME";

            string degismis = deger.ReplaceLastOccurance("FROM", "FROM_DEGISMIS");
            Console.WriteLine(degismis);

        }




    }
}

