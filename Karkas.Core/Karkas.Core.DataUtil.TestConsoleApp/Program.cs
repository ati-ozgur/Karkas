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

            FtpYardimcisi fy = new FtpYardimcisi("ftp://www.manufacturingturkey.com/", "ftp_13568", "deniz");
            fy.CreateDirectory("anon_ftp/Eczane/20090817");
            fy.UpLoadWithFullFileName("anon_ftp/Eczane/20090817/deneme.txt", "deneme.txt");
            fy.UpLoadWithDirectoryName("anon_ftp/Eczane", "deneme2.txt");

        }




    }
}

