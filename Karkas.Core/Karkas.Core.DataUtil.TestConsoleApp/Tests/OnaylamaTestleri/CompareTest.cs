using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.DataUtil.TestConsoleApp.TypeLibrary;
using Karkas.Core.Validation.ForPonos;
using Karkas.Core.Validation;
using NUnit.Framework;
using NUnitExtension.RowTest;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri
{

    [TestFixture]
    public class CompareTest
    {

        private DateTime[] duzgunListe()
        {
            List<DateTime> liste = new List<DateTime>();
            liste.Add(DateTime.Now.AddYears(-20));
            liste.Add(new DateTime(1800, 1, 1));
            liste.Add(new DateTime(1900, 1, 1));
            return liste.ToArray();
        }

        [Test]
        public void TestDogumTarihi()
        {
            OrnekKarsilastirma k = testIcinOrnekKarsilastirmaOlustur();
            DateTime[] liste = duzgunListe();
            foreach (DateTime pDogumTarihi in liste)
            {
                k.DogumTarihi = pDogumTarihi;
                Assert.IsFalse(k.Validate());
            }
        }
        
        private OrnekKarsilastirma testIcinOrnekKarsilastirmaOlustur()
        {
            OrnekKarsilastirma a = new OrnekKarsilastirma();
            a.Validator.ValidatorList.Clear();
            a.Validator.ValidatorList = new List<BaseValidator>();
            a.Validator.ValidatorList.Add(new CompareValidator(a, "DogumTarihi",DateTime.Now.AddYears(-19),CompareOperator.GreatThanEqual,"Kisi 18 yaþýndan büyük olmalýdýr"));
            return a;




        }

    }
}
