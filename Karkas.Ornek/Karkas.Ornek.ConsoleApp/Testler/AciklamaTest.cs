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
    public class AciklamaTest
    {
        [TestFixtureSetUp]
        public void herseyiSil()
        {
            BasitTabloIdentityDal dal = new BasitTabloIdentityDal();
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.ACIKLAMA");
        }

        [Test]
        public void Ekle()
        {
            Aciklama a = new Aciklama();
            AciklamaDal dal = new AciklamaDal();
            a.AciklamaKey = Guid.NewGuid();
            a.AciklamaProperty = "Deneme";

            dal.Ekle(a);
        }

        [Test]
        public void Guncelle()
        {
            AciklamaDal dal = new AciklamaDal();
            List<Aciklama> liste = dal.SorgulaHepsiniGetir();
            if (liste.Count > 0)
            {
                Aciklama m = liste[0];
                Guid pk = m.AciklamaKey;
                m.AciklamaProperty = m.AciklamaProperty + "D";
                dal.Guncelle(m);

                Aciklama veritabanindakiRow = dal.SorgulaAciklamaKeyIle(pk);
                Assert.AreEqual(veritabanindakiRow.AciklamaProperty, m.AciklamaProperty);
            }

        }

        private Aciklama ornekAciklamaGetir()
        {
            Aciklama a = new Aciklama();
            a.AciklamaKey = Guid.NewGuid();
            a.AciklamaProperty = "Ornek Aciklama";
            return a;
        }
        private void AciklamaKolonlariEsitMi(Aciklama p1,Aciklama p2)
        {
            Assert.AreEqual(p1.AciklamaKey, p2.AciklamaKey);
            Assert.AreEqual(p1.AciklamaProperty, p2.AciklamaProperty);
        }
        [Test]
        public void ornekMusteriEkleGuncelleSil()
        {
            AciklamaDal dal = new AciklamaDal();
            Aciklama a = ornekAciklamaGetir();
            dal.Ekle(a);

            Aciklama veritabanindakiRow = dal.SorgulaAciklamaKeyIle(a.AciklamaKey);

            AciklamaKolonlariEsitMi(a, veritabanindakiRow);

            a.AciklamaProperty = a.AciklamaProperty + "d";
            dal.Guncelle(a);
            veritabanindakiRow = dal.SorgulaAciklamaKeyIle(a.AciklamaKey);
            AciklamaKolonlariEsitMi(a, veritabanindakiRow);

            dal.Sil(a);
            veritabanindakiRow = dal.SorgulaAciklamaKeyIle(a.AciklamaKey);
            Assert.IsNull(veritabanindakiRow);


        }
    }
}

