using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Karkas.Web.Helpers.HelperClasses;
using Karkas.Web.Helpers.BaseClasses;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.WebHelperTestleri
{
    [TestFixture]
    public class JavascriptHelperTest : KarkasBasePage
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

        [Test]
        public void javascriptPopUpWindowTest()
        {
            string[] sayfaListesi = {"/Personel/YeniKadro/KadroCalisma/KadroTenkisDagitimListesi.aspx"
                                        ,"~/Personel/YeniKadro/KadroCalisma/KadroTenkisDagitimListesi.aspx"
                                        ,"~/Ornekler/atilla.aspx"
                                        ,"/Ornekler/atilla.aspx"
                                    };
            foreach (var sayfa in sayfaListesi)
            {
                this.JavascriptHelper.PopUpWindowBaslangictaAc(sayfa);
                
            }
        }

    }
}
