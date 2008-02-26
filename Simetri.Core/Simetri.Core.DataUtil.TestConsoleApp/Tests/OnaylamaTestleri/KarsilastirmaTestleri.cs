using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Simetri.Core.DataUtil.TestConsoleApp.TypeLibrary;
using Simetri.Core.Validation;
using Simetri.Core.Validation.ForPonos;

namespace Simetri.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri
{
    [TestFixture]
    public class KarsilastirmaTestleri
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
            Assert.IsTrue(a.Validate());
        }

        [Test]
        public void TestEsittir()
        {
            OrnekA a = TestEsittirIcinOrnekOlustur();
            a.ShortDegisken = Deger1;
            Assert.IsTrue(a.Validate());
            a.ShortDegisken = (short)(Deger1 + 1);
            Assert.IsFalse(a.Validate());
        }

        [Test]
        public void TestEsitDegildir()
        {
            OrnekA a = TestEsitDegildirIcinOrnekOlustur();
            a.ShortDegisken = Deger1;
            Assert.IsFalse(a.Validate());
            a.ShortDegisken = (short)(Deger1 + 1);
            Assert.IsTrue(a.Validate());
        }


        private OrnekA TestEsitDegildirIcinOrnekOlustur()
        {
            OrnekA a = ValidatorTemizAOlustur();
            a.Validator.ValidatorList.Add(new CompareValidator(a, "ShortDegisken", Deger1, CompareOperator.NotEqual));
            return a;
        }

        private OrnekA TestEsittirIcinOrnekOlustur()
        {
            OrnekA a = ValidatorTemizAOlustur();
            a.Validator.ValidatorList.Add(new CompareValidator(a, "ShortDegisken", Deger1, CompareOperator.Equal));
            return a;
        }




        private static OrnekA ValidatorTemizAOlustur()
        {
            OrnekA a = new OrnekA();
            a.Validator.ValidatorList.Clear();
            a.Validator.ValidatorList = new List<BaseValidator>();
            return a;
        }

    }
}
