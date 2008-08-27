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


            MusteriDal mDal = new MusteriDal();
            List<Musteri> liste1 = mDal.SorgulaHepsiniGetirSirali(Musteri.PropertyIsimleri.Adi, "ASC" , Musteri.PropertyIsimleri.Soyadi, "DESC");
            List<Musteri> liste2 = mDal.SorgulaHepsiniGetirSirali(Musteri.PropertyIsimleri.Adi, "", Musteri.PropertyIsimleri.Soyadi, "ASC");
            List<Musteri> liste3 = mDal.SorgulaHepsiniGetirSirali(Musteri.PropertyIsimleri.Adi, MusteriDal.Siralama.Azalarak, Musteri.PropertyIsimleri.Soyadi, "DESC");
            List<Musteri> liste4 = mDal.SorgulaHepsiniGetirSirali(Musteri.PropertyIsimleri.Adi);
        }

    }
}
