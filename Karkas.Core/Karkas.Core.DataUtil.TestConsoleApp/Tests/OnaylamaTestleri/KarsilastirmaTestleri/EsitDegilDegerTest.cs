using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Karkas.Core.DataUtil.TestConsoleApp.TypeLibrary;
using Karkas.Core.Onaylama.ForPonos;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri.KarsilastirmaTestleri
{
    [TestFixture]
    public class EsitDegilDegerTest
    {

        [Test]
        public void Test1()
        {
            OrnekA a = ornekAOlustur(5);
            a.ShortDegisken = 6;
            Assert.IsTrue(a.Onayla());
            a.ShortDegisken = 5;
            Assert.IsFalse(a.Onayla());
            a.ShortDegisken = 4;
            Assert.IsTrue(a.Onayla());
        }

        private OrnekA ornekAOlustur(int pDeger)
        {
            OrnekA a = new OrnekA();
            a.Onaylayici.OnaylayiciListesi = new List<BaseOnaylayici>();
            a.Onaylayici.OnaylayiciListesi.Add(new EsitDegilDegerOnaylayici(a, "ShortDegisken", pDeger));
            return a;
        }

    }
}
