using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Karkas.Ornek.Dal.Ornekler;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.BsWrapper.Ornekler;

namespace Karkas.Ornek.ConsoleApp.Testler
{
    [TestFixture]
    public class AciklamaBsWrapperTest
    {
        [TestFixtureSetUp]
        public void herseyiSil()
        {
            AciklamaDal dal = new AciklamaDal();
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.ACIKLAMA");
        }

        [Test]
        public void Ekle()
        {
            Aciklama a = new Aciklama();
            AciklamaBsWrapper bs = new AciklamaBsWrapper();
            a.AciklamaKey = Guid.NewGuid();
            a.AciklamaProperty = "Deneme";

            bs.Ekle(a);
        }

        [Test]
        public void Guncelle()
        {
            AciklamaBsWrapper bsWrapper = new AciklamaBsWrapper();
            List<Aciklama> liste = bsWrapper.SorgulaHepsiniGetir();
            if (liste.Count > 0)
            {
                Aciklama m = liste[0];
                Guid pk = m.AciklamaKey;
                m.AciklamaProperty = m.AciklamaProperty + "D";
                bsWrapper.Guncelle(m);

                Aciklama veritabanindakiRow = bsWrapper.SorgulaAciklamaKeyIle(pk);
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
        private void AciklamaKolonlariEsitMi(Aciklama p1, Aciklama p2)
        {
            Assert.AreEqual(p1.AciklamaKey, p2.AciklamaKey);
            Assert.AreEqual(p1.AciklamaProperty, p2.AciklamaProperty);
        }
        [Test]
        public void ornekMusteriEkleGuncelleSil()
        {
            AciklamaBsWrapper wrapper = new AciklamaBsWrapper();
            Aciklama a = ornekAciklamaGetir();
            wrapper.Ekle(a);

            Aciklama veritabanindakiRow = wrapper.SorgulaAciklamaKeyIle(a.AciklamaKey);

            AciklamaKolonlariEsitMi(a, veritabanindakiRow);

            a.AciklamaProperty = a.AciklamaProperty + "d";
            wrapper.Guncelle(a);
            veritabanindakiRow = wrapper.SorgulaAciklamaKeyIle(a.AciklamaKey);
            AciklamaKolonlariEsitMi(a, veritabanindakiRow);

            wrapper.Sil(a);
            veritabanindakiRow = wrapper.SorgulaAciklamaKeyIle(a.AciklamaKey);
            Assert.IsNull(veritabanindakiRow);


        }
    }
}
