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
    public class BasitTabloIdentityTest
    {

        [TestFixtureSetUp]
        public void herseyiSil()
        {
            BasitTabloIdentityDal dal = new BasitTabloIdentityDal();
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.BASIT_TABLO_IDENTITY");
        }

        [Test]
        public void Ekle()
        {
            BasitTabloIdentity bt = ornekBasitTabloIdentityGetir();
            BasitTabloIdentityDal dal = new BasitTabloIdentityDal();
            dal.Ekle(bt);

        }
        [Test]
        public void Guncelle()
        {
            BasitTabloIdentityDal dal = new BasitTabloIdentityDal();
            List<BasitTabloIdentity> liste = dal.SorgulaHepsiniGetir();
            if (liste.Count > 0)
            {
                BasitTabloIdentity m = liste[0];
                int pk = m.BasitTabloIdentityKey;
                m.Soyadi = m.Soyadi + "D";
                dal.Guncelle(m);

                BasitTabloIdentity veritabanindakiRow = dal.SorgulaBasitTabloIdentityKeyIle(pk);
                BasitTabloIdentityKolonlariEsitMi(m, veritabanindakiRow);
            }

        }

        private static void BasitTabloIdentityKolonlariEsitMi(BasitTabloIdentity m, BasitTabloIdentity veritabanindakiRow)
        {
            Assert.AreEqual(m.BasitTabloIdentityKey, veritabanindakiRow.BasitTabloIdentityKey);
            Assert.AreEqual(m.Soyadi, veritabanindakiRow.Soyadi);
            Assert.AreEqual(m.Adi, veritabanindakiRow.Adi);
        }
        [Test]
        public void ornekMusteriEkleGuncelleSil()
        {
            BasitTabloIdentityDal dal = new BasitTabloIdentityDal();
            BasitTabloIdentity bt = ornekBasitTabloIdentityGetir();
            dal.Ekle(bt);

            BasitTabloIdentity veritabanindakiRow = dal.SorgulaBasitTabloIdentityKeyIle(bt.BasitTabloIdentityKey);

            BasitTabloIdentityKolonlariEsitMi(bt, veritabanindakiRow);

            bt.Adi = bt.Adi + "d";
            dal.Guncelle(bt);
            veritabanindakiRow = dal.SorgulaBasitTabloIdentityKeyIle(bt.BasitTabloIdentityKey);
            BasitTabloIdentityKolonlariEsitMi(bt, veritabanindakiRow);

            dal.Sil(bt);
            veritabanindakiRow = dal.SorgulaBasitTabloIdentityKeyIle(bt.BasitTabloIdentityKey);
            Assert.IsNull(veritabanindakiRow);


        }



        private BasitTabloIdentity ornekBasitTabloIdentityGetir()
        {
            BasitTabloIdentity bt = new BasitTabloIdentity();
            bt.Adi = "DenemeAdi";
            bt.Soyadi = "DenemeSoyadi";
            return bt;
        }
    }
}
