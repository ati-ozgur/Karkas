using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.BsWrapper.Ornekler;
using Karkas.Ornek.Dal.Ornekler;
using System.Transactions;
using Karkas.Ornek.ConsoleApp.Testler;
using System.Xml.Serialization;
using System.IO;

namespace Karkas.Ornek.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            MusteriDal dal = new MusteriDal();
            List<Musteri> liste = dal.SorgulaHepsiniGetir();
            foreach (var item in liste)
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


            Console.WriteLine(m.IkinciAdiAsString);
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
                MusteriDal dal = new MusteriDal();
                BasitTabloDal btDal = new BasitTabloDal();

                dal.Ekle(pMusteri);
                btDal.Ekle(pBasitTablo);
                scope.Complete();

            }
        }



    }
}
