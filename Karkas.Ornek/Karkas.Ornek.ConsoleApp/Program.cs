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
            DenemeGuidIdentity dgi = new DenemeGuidIdentity();
            dgi.DenemeKey = Guid.NewGuid();
            dgi.DenemeKolon = "addd";
            DenemeGuidIdentityDal dal = new DenemeGuidIdentityDal();
            int sonuc = dal.Ekle(dgi);
            Console.WriteLine(sonuc);
        }
    }
}
