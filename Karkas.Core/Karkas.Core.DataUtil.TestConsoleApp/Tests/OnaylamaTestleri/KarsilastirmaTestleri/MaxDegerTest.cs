using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Karkas.Core.DataUtil.TestConsoleApp.TypeLibrary;
using Karkas.Core.Validation.ForPonos;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri.KarsilastirmaTestleri
{
    [TestFixture]
    public class MaxDegerTest
    {
        [Test]
        public void TestMaxDeger5()
        {
            OrnekA a = ornekAOlustur(5);
            a.ShortDegisken = 6;
            Assert.IsFalse(a.Onayla());
            a.ShortDegisken = 5;
            Assert.IsTrue(a.Onayla());
            a.ShortDegisken = 4;
            Assert.IsTrue(a.Onayla());
        }
        [Test]
        public void TestMaxDeger()
        {
            for (short deger = -10; deger < 10; deger++)
            {
                OrnekA a = ornekAOlustur(deger);
                a.ShortDegisken = (short)(deger + 1);
                Assert.IsFalse(a.Onayla());
                a.ShortDegisken = deger;
                Assert.IsTrue(a.Onayla());
                a.ShortDegisken = (short)(deger - 1);
                Assert.IsTrue(a.Onayla());
            }
        }

        private OrnekA ornekAOlustur(short pDeger)
        {
            OrnekA a = new OrnekA();
            a.Onaylayici.OnaylayiciListesi = new List<BaseOnaylayici>();
            a.Onaylayici.OnaylayiciListesi.Add(new MaxDegerOnaylayici(a, "ShortDegisken", pDeger));
            return a;
        }
    }
}
