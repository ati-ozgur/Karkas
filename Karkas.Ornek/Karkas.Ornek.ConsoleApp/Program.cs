using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.BsWrapper.Ornekler;
using Karkas.Ornek.Dal.Ornekler;
using System.Transactions;

namespace Karkas.Ornek.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MusteriDal dal = new MusteriDal();
            List<Musteri> liste =  dal.SorgulaAdiVeSoyadiIle("ati", "");

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
