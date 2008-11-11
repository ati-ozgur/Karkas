using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Karkas.Ornek.Dal.Ornekler;
using Karkas.Ornek.Bs.Ornekler;

namespace Karkas.Ornek.ConsoleApp.Testler
{
    [TestFixture]
    public class TransactionTemplateTest
    {
        public void herseyiSil()
        {

            BasitTabloDal dal = new BasitTabloDal();
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.BASIT_TABLO");
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.ACIKLAMA");
        }

        [Test]
        public void TransactionBasarili()
        {
            herseyiSil();
            BasitTabloBs bs = new BasitTabloBs();
            bs.TemplateTransactionOrnek();

            Assert.Greater(bs.TablodakiSatirSayisi, 0);
        }
    }
}
