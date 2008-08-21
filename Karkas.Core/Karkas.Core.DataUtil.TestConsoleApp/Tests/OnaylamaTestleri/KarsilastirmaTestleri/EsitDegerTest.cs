using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Karkas.Core.DataUtil.TestConsoleApp.TypeLibrary;
using Karkas.Core.Onaylama.ForPonos;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri.KarsilastirmaTestleri
{
    [TestFixture]
    public class EsitDegerTest
    {

        [Test]
        public void Test1()
        {
            OrnekA a = ornekAOlustur(5);
            a.ShortDegisken = 6;
            Assert.IsFalse(a.Onayla());
            a.ShortDegisken = 5;
            Assert.IsTrue(a.Onayla());
            a.ShortDegisken = 4;
            Assert.IsFalse(a.Onayla());
        }




        private OrnekA ornekAOlustur(short pDeger)
        {
            OrnekA a = new OrnekA();
            a.Onaylayici.OnaylayiciListesi = new List<BaseOnaylayici>();
            a.Onaylayici.OnaylayiciListesi.Add(new EsitDegerOnaylayici(a, "ShortDegisken", pDeger));
            return a;
        }

    }
}
