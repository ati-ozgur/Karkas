using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;
using NUnit.Framework;

namespace Karkas.Ornek.ConsoleApp.Testler
{
    [TestFixture]
    public class DenemeGuidIdentityTest
    {
        [Test]
        public void Ekle()
        {
            DenemeGuidIdentity dgi = new DenemeGuidIdentity();
            dgi.DenemeKey = Guid.NewGuid();
            dgi.DenemeKolon = "addd";
            DenemeGuidIdentityDal dal = new DenemeGuidIdentityDal();
            long sonuc = dal.Ekle(dgi);
        }
        [Test]
        public void Guncelle()
        {
            DenemeGuidIdentity dgi = new DenemeGuidIdentity();
            DenemeGuidIdentityDal dal = new DenemeGuidIdentityDal();
            List<DenemeGuidIdentity> list = dal.SorgulaHepsiniGetir();
            dgi.DenemeKey = list.ElementAt(0).DenemeKey;
            dgi.DenemeNo = 11;
            dgi.DenemeKolon = "addd";
            dal.Guncelle(dgi);
        }

    }
}
