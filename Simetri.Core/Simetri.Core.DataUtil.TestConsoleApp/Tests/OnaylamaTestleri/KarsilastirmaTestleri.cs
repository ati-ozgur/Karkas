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
            OrnekA a = TestEsittirIcinOrneklustur();
            a.ShortDegisken = Deger1;
            Assert.IsTrue(a.Validate());
            Deger1 = (short) (Deger1 + 1);
            a.ShortDegisken =Deger1;
            Assert.IsFalse(a.Validate());
        }

        [Test]
        public void TestEsitDegildir()
        {
            OrnekA a = TestEsitDegildirIcinOrneklustur();
            a.ShortDegisken = Deger1;
            Assert.IsFalse(a.Validate());
            Deger1 = (short)(Deger1 + 1);
            a.ShortDegisken = Deger1;
            Assert.IsTrue(a.Validate());
        }

        
        private OrnekA TestEsitDegildirIcinOrneklustur()
        {
            OrnekA a = ValidatorTemizAOlustur();
            a.Validator.ValidatorList.Add(new CompareValidator(a, "ShortDegisken", Deger1, CompareOperator.NotEqual));
            return a;
        }

        private OrnekA TestEsittirIcinOrneklustur()
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
