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
    public class TransactionOrnekBasitTabloIdentity
    {
        public void herseyiSil()
        {

            BasitTabloIdentityDal dal = new BasitTabloIdentityDal();
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.BASIT_TABLO_IDENTITY");
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.ACIKLAMA");
        }

        [Test]
        public void TransactionBasarili()
        {
            herseyiSil();
            BasitTabloIdentityBs bs = new BasitTabloIdentityBs();
            bs.TransactionBasarili();
            Assert.Greater(bs.TablodakiSatirSayisi, 0);
        }
    }
}

