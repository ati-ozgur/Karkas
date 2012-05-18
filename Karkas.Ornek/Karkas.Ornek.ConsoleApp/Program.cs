﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Ornek.TypeLibrary.Ornekler;
using System.Transactions;
using Karkas.Ornek.ConsoleApp.Testler;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.SorguYardimcisiSiniflari;
using System.Globalization;
using Karkas.Ornek.Bs.Ornekler;
using Karkas.Ornek.ConsoleApp.DataUtilOrnekleri;
using Karkas.Ornek.Dal.Ornekler;
using Karkas.Ornek.BsWrapper.Ornekler;

namespace Karkas.Ornek.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Aciklama a = new Aciklama();
            a.AciklamaKey = Guid.NewGuid();
            a.AciklamaProperty = "Deneme";

            AciklamaBsWrapper wrapper = new AciklamaBsWrapper();
            wrapper.Ekle(a);


            AdoTemplate template = new AdoTemplate();
            DataTable dt = template.DataTableOlustur("SELECT * FROM ORNEKLER.ACIKLAMA");




            //AciklamaBsWrapper wrapper = new AciklamaBsWrapper();
            //Aciklama a = new Aciklama();
            //a.AciklamaKey = Guid.NewGuid();
            //a.AciklamaProperty = "Deneme Atilladan";
            //wrapper.Ekle(a);
        }

        private static void MasterDetayOrnek()
        {
            MusteriDal dal = new MusteriDal();
            List<Musteri> musteriListesi = dal.SorgulaHepsiniGetir();
            foreach (Musteri m in musteriListesi)
            {
                Console.WriteLine(m.Adi + " " + m.Soyadi);
                Console.WriteLine("SIPARISLERI");
                List<MusteriSiparis> siparisler = dal.SorgulaDetayTabloGetir<MusteriSiparis>(m.MusteriKey);
                foreach (MusteriSiparis ms in siparisler)
                {
                    Console.WriteLine(ms.MusteriSiparisKey);
                }
            }
        }

        private static void concurrenyDeneme()
        {
            ConcurrencyOrnekDal dal = new ConcurrencyOrnekDal();
            List<ConcurrencyOrnek> listeFatih = dal.SorgulaHepsiniGetir();
            List<ConcurrencyOrnek> listeErkan = dal.SorgulaHepsiniGetir();

            ConcurrencyOrnek ornekFatih = listeFatih[0];

            ConcurrencyOrnek ornekErkan = listeErkan[0];


            ornekFatih.Adi = ornekFatih.Adi + "_";

            dal.Guncelle(ornekFatih);

            ornekErkan.Adi = ornekErkan.Adi + "2";

            dal.Guncelle(ornekErkan);
        }

        private static void listeHepsiniGetir()
        {
            MusteriDal dal = new MusteriDal();
            List<Musteri> liste = dal.SorgulaHepsiniGetir();

            var sonuc = from m in liste
                        where ((m.Adi.Contains("a")) && (m.Soyadi.Contains("Ö")))
                        orderby m.MusteriKey
                        select m;

            IEnumerable<Musteri> sonucListesi = liste
                                            .Where(m => m.Adi.Contains("a"))
                                            .OrderBy(m => m.Adi)
                                            .Select(m => m);

            Musteri[] mList = sonucListesi.ToArray();

            foreach (var item in sonuc)
            {
                Console.WriteLine(item.Adi + " " + item.Soyadi);
            }


        }

        private static void SerializeDene()
        {
            Musteri m = new Musteri();
            m.Adi = "Atilla";
            m.Soyadi = "Ozgur";
            m.DogumTarihiAsString = "19/08/1977";


            Console.WriteLine(m.IkinciAdi);
            try
            {
                XmlSerializer serializer = new
                XmlSerializer(typeof(Musteri));
                // To write to a file, create a StreamWriter object.
                StreamWriter writer = new StreamWriter("musteri.xml");
                serializer.Serialize(writer, m);
                writer.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex); ;
            }
        }





        public void TransactionOrnek(Musteri pMusteri, BasitTablo pBasitTablo)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                MusteriDal musteriDal = new MusteriDal();
                BasitTabloDal basitTabloDal = new BasitTabloDal();

                musteriDal.Ekle(pMusteri);
                basitTabloDal.Ekle(pBasitTablo);
                scope.Complete();

            }
        }



    }
}

