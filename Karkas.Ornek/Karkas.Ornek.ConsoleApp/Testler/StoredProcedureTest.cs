using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Karkas.Ornek.Dal.Ornekler;
using Karkas.Ornek.TypeLibrary.Ornekler;
using System.Data;

namespace Karkas.Ornek.ConsoleApp.Testler
{
    [TestFixture]
    public class StoredProcedureTest
    {
        [Test]
        public void usp_YaziDegeriniBulTest()
        {
            string sonuc;
            StoredProcedures.YaziDegeriniBul(1, out sonuc);
            Assert.AreEqual("bir",sonuc);
        }


        [Test]
        public void usp_BasitTabloIdentityEkleTest()
        {
            string ad = "DenemeAd";
            string soyad = "DenemeSoyad";
            int sonuc = StoredProcedures.BasitTabloIdentityEkle(ad, soyad);
            Assert.Greater(sonuc, 0);

            BasitTabloIdentityDal dal = new BasitTabloIdentityDal();
            BasitTabloIdentity bti = dal.SorgulaBasitTabloIdentityKeyIle((int)sonuc);
            Assert.AreEqual(ad, bti.Adi);
            Assert.AreEqual(soyad, bti.Soyadi);
        }
        [Test]
        public void usp_MusteriEkleTest()
        {
            string ad = "DenemeAd ati";
            string soyad = "DenemeSoyad ati";
            int sonuc = StoredProcedures.MusteriEkle(ad, soyad,null,null,null);

            MusteriDal dal = new MusteriDal();
            List<Musteri> liste = dal.SorgulaAdiVeSoyadiIle(ad, soyad);
            Assert.Greater(liste.Count, 0);
        }
        [Test]
        public void usp_MusteriSorgulaHepsiniGetirTest()
        {
            DataTable dt = StoredProcedures.MusteriSorgulaHepsiniGetir();
            Assert.Greater(dt.Rows.Count, 0);
        }
        [Test]
        public void usp_MusteriSorgulaMusteriKeyIleTest()
        {
            Guid pk = Guid.NewGuid();
            MusteriDal dal = new MusteriDal();
            string ad = "DenemeAd";
            string soyad = "DenemeSoyad";
            Musteri m = new Musteri();
            m.MusteriKey = pk;
            m.Adi = ad;
            m.Soyadi = soyad;
            dal.Ekle(m);

            DataTable dt = StoredProcedures.MusteriSorgulaMusteriKeyIle(pk);
            Assert.AreEqual(dt.Rows[0][Musteri.PropertyIsimleri.Adi].ToString(), ad);
            Assert.AreEqual(dt.Rows[0][Musteri.PropertyIsimleri.Soyadi].ToString(), soyad);
        }
        [Test]
        public void usp_ToplaOutputParamTest()
        {
            int sayi1 = 10;
            int sayi2 = 15;
            int toplam;

            StoredProcedures.ToplaOutputParam(sayi1, sayi2, out toplam);
            Assert.AreEqual(toplam, sayi1 + sayi2);

        }

    }
}

