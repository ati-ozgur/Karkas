using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;

namespace Karkas.Ornek.ConsoleApp.Testler
{
    [TestFixture]
    public class IsimlendirmeBozukTest
    {
        [TestFixtureSetUp]
        public void herseyiSil()
        {
            IsimlendirmeBozukDal dal = new IsimlendirmeBozukDal();
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.ISIMLENDIRME_BOZUK");
        }

        [Test]
        public void Ekle()
        {
            IsimlendirmeBozukDal dal = new IsimlendirmeBozukDal();
            IsimlendirmeBozuk m = new IsimlendirmeBozuk();
            m.Adi = "atilla";
            m.KisiOid = 1;
            m.Soyadi = "ozgur";
            dal.Ekle(m);
        }
    }
}

