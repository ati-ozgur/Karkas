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
    public class TransactionDataTableDondurTest
    {
        [TestFixtureSetUp]
        public void herseyiSil()
        {
            DenemeGuidIdentityDal dal = new DenemeGuidIdentityDal();
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.DENEME_GUID_IDENTITY");
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.ACIKLAMA");
        }

        [Test]
        public void TransactionOrnekEkle()
        {
            DenemeGuidIdentityBs bs = new DenemeGuidIdentityBs();
            bs.OrnekTransactionDataTableDondur();
        }
    }
}

