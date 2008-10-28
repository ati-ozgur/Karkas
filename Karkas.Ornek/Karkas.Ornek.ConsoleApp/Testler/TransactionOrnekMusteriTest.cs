using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Karkas.Ornek.Bs.Ornekler;
using Karkas.Ornek.Dal.Ornekler;

namespace Karkas.Ornek.ConsoleApp.Testler
{
    [TestFixture]
    public class TransactionOrnekMusteriTest
    {
        public void herseyiSil()
        {
            
            MusteriDal dal = new MusteriDal();
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.MUSTERI");
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.ACIKLAMA");
        }


        [Test]
        public void TransactionRollBackBekliyoruz()
        {
            herseyiSil();
            MusteriBs bs = new MusteriBs();

            try
            {
                bs.TransactionRollBackBekliyoruz();
                Assert.Fail("buraya gelmemeliydi, veritabaninda Aciklama kolonu not null olmali");
            }
            catch
            {
            }
            Assert.AreEqual(0, bs.TablodakiSatirSayisi);
        }

        [Test]
        public void TransactionBasarili()
        {
            herseyiSil();
            MusteriBs bs = new MusteriBs();
            bs.TransactionBasarili();
            Assert.Greater(bs.TablodakiSatirSayisi,0 );
        }

    }
}
