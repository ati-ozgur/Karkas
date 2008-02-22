using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.DataUtil.TestConsoleApp.TypeLibrary;
using Simetri.Core.Validation.ForPonos;
using Simetri.Core.Validation;
using NUnit.Framework;

namespace Simetri.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri
{

    [TestFixture]
    public class CompareTest
    {

        [Test]
        public void TestDogumTarihi()
        {
            OrnekKarsilastirma k = testIcinOrnekKarsilastirmaOlustur();
            k.DogumTarihi = DateTime.Now;
            Assert.IsTrue(k.Validate());

        }

        private OrnekKarsilastirma testIcinOrnekKarsilastirmaOlustur()
        {
            OrnekKarsilastirma a = new OrnekKarsilastirma();
            a.Validator.ValidatorList.Clear();
            a.Validator.ValidatorList = new List<BaseValidator>();
            a.Validator.ValidatorList.Add(new CompareValidator(a, "DogumTarihi",DateTime.Now.AddYears(-18),CompareOperator.LessThanEqual,"Kisi 18 yaþýndan büyük olmalýdýr"));
            return a;



        }

    }
}
