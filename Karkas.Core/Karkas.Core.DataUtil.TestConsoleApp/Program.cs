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
using Karkas.Core.DataUtil.SqlBuilderSiniflari;
using Karkas.Extensions;

namespace Karkas.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            string StringToBeHashed = @"31234gl3p5uy9.95https://magazam.com.tr/odemesayfasihttps://magazam.com.tr/hatasayfasiAuth4yHK84HjUd0123456";


            string hashResult = StringToBeHashed.Sha1Hash();
            Console.WriteLine(hashResult);


        }




    }
}

