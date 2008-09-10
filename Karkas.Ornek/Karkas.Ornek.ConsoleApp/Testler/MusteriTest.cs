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
    public class MusteriTest
    {
        [TestFixtureSetUp]
        public void herseyiSil()
        {
            MusteriDal dal = new MusteriDal();
            dal.Template.SorguHariciKomutCalistir("TRUNCATE TABLE ORNEKLER.MUSTERI");
        }

        [Test]
        public void Ekle()
        {
            MusteriDal dal = new MusteriDal();
            Musteri m = new Musteri();
            m.Adi = "atilla";
            m.MusteriKey = Guid.NewGuid();
            m.Soyadi = "ozgur";
            dal.Ekle(m);
        }
        [Test]
        public void Guncelle()
        {
            MusteriDal dal = new MusteriDal();
            List<Musteri> musteriList = dal.SorgulaHepsiniGetir();
            if (musteriList.Count > 0)
            {
                Musteri m = musteriList[0];
                Guid pk = m.MusteriKey;
                m.Soyadi = "deneme";
                dal.Guncelle(m);

                Musteri veritabanindakiRow = dal.SorgulaMusteriKeyIle(pk);
                Assert.AreEqual(m.Soyadi, veritabanindakiRow.Soyadi);
                Assert.AreEqual(m.Adi, veritabanindakiRow.Adi);
            }

        }
        [Test]
        public void ornekMusteriEkleGuncelleSil()
        {
            MusteriDal dal = new MusteriDal();
            Musteri m = ornekMusteriGetir();
            dal.Ekle(m);

            Musteri veritabanindakiRow = dal.SorgulaMusteriKeyIle(m.MusteriKey);

            MusteriKolonlariEsitMi(m, veritabanindakiRow);

            m.Adi = m.Adi + "d";
            dal.Guncelle(m);
            veritabanindakiRow = dal.SorgulaMusteriKeyIle(m.MusteriKey);
            MusteriKolonlariEsitMi(m, veritabanindakiRow);

            dal.Sil(m);
            veritabanindakiRow = dal.SorgulaMusteriKeyIle(m.MusteriKey);
            Assert.IsNull(veritabanindakiRow);
            

        }

        private static void MusteriKolonlariEsitMi(Musteri m, Musteri veritabanindakiRow)
        {
            Assert.AreEqual(m.MusteriKey, veritabanindakiRow.MusteriKey);
            Assert.AreEqual(m.Adi, veritabanindakiRow.Adi);
            Assert.AreEqual(m.Soyadi, veritabanindakiRow.Soyadi);
            Assert.AreEqual(m.IkinciAdi, veritabanindakiRow.IkinciAdi);
            Assert.AreEqual(m.DogumTarihi, veritabanindakiRow.DogumTarihi);
        }

        private Musteri ornekMusteriGetir()
        {
            Musteri m = new Musteri();
            m.MusteriKey = new Guid("480CF22C-10DE-43f7-88D4-1CCD5318D4F0");
            m.Adi = "DenemeDenemeAdi";
            m.Soyadi = "DenemeDenemeSoyadi";
            return m;
        }
    }
}