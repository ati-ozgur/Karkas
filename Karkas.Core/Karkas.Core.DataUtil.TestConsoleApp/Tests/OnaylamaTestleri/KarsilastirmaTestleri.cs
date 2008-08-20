using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Karkas.Core.DataUtil.TestConsoleApp.TypeLibrary;
using Karkas.Core.Validation;
using Karkas.Core.Validation.ForPonos;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri
{
    [TestFixture]
    public class KarsilastirmaTestleri1
    {
        private short Deger1 = 18;


        /// <summary>
        /// Bu test, 1,2 gibi yazilan sayilarin
        /// int32 olarak dusunulmesi yuzunden cikan sorun icin yazilmistir.
        /// </summary>
        [Test]
        public void TestCastIntToShort()
        {
            OrnekA a = new OrnekA();
            a.ShortDegisken = Deger1;
            Assert.IsTrue(a.Onayla());
        }

        [Test]
        public void TestEsittir()
        {
            OrnekA a = TestEsittirIcinOrnekOlustur();
            a.ShortDegisken = Deger1;
            Assert.IsTrue(a.Onayla());
            a.ShortDegisken = (short)(Deger1 + 1);
            Assert.IsFalse(a.Onayla());
        }

        [Test]
        public void TestEsitDegildir()
        {
            OrnekA a = TestEsitDegildirIcinOrnekOlustur();
            a.ShortDegisken = Deger1;
            Assert.IsFalse(a.Onayla());
            a.ShortDegisken = (short)(Deger1 + 1);
            Assert.IsTrue(a.Onayla());
        }


        private OrnekA TestEsitDegildirIcinOrnekOlustur()
        {
            OrnekA a = ValidatorTemizAOlustur();
            a.Onaylayici.OnaylayiciListesi.Add(new KarsilastirmaOnaylayici(a, "ShortDegisken", Deger1, KarsilastirmaOperatoru.NotEqual));
            return a;
        }

        private OrnekA TestEsittirIcinOrnekOlustur()
        {
            OrnekA a = ValidatorTemizAOlustur();
            a.Onaylayici.OnaylayiciListesi.Add(new KarsilastirmaOnaylayici(a, "ShortDegisken", Deger1, KarsilastirmaOperatoru.Equal));
            return a;
        }

        private OrnekA TestKucukturIcinOrnekOlustur()
        {
            OrnekA a = ValidatorTemizAOlustur();
            a.Onaylayici.OnaylayiciListesi.Add(new KarsilastirmaOnaylayici(a, "ShortDegisken", Deger1, KarsilastirmaOperatoru.LessThanEqual));
            return a;
        }





        private static OrnekA ValidatorTemizAOlustur()
        {
            OrnekA a = new OrnekA();
            a.Onaylayici.OnaylayiciListesi.Clear();
            a.Onaylayici.OnaylayiciListesi = new List<BaseOnaylayici>();
            return a;
        }

    }
}
