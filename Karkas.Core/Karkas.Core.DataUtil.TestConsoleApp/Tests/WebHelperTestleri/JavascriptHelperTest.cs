using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Karkas.Web.Helpers.HelperClasses;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.WebHelperTestleri
{
    [TestFixture]
    public class JavascriptHelperTest
    {
        [Test]
        public void alertIcinDuzgunMesajOlusturTest()
        {
            string mesaj = @"1111
                    22223
3333                   
444
    aaaa
";
            string sonuc = KarkasWebHelper.JavascriptHelper.alertIcinDuzgunMesajOlustur(mesaj);
            Console.WriteLine(sonuc);
        }
    }
}
