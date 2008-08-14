using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.BsWrapper.Ornekler;
using Karkas.Ornek.Dal.Ornekler;

namespace Karkas.Ornek.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Musteri m = new Musteri();
            m.MusteriKey = Guid.NewGuid();
            m.Adi = "Deneme";
            m.Soyadi = "Deneme" + DateTime.Now.ToShortTimeString();

            MusteriBsWrapper wrapper = new MusteriBsWrapper();
            wrapper.Ekle(m);


            MusteriDal dal = new MusteriDal();
        }
    }
}
