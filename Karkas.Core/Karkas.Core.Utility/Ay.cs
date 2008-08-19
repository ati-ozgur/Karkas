using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.Utility
{
    public class Ay
    {
        private static Ay[] aylar = new Ay[12];
        static Ay()
        {
            AylariHazirla();
        }

        private static void AylariHazirla()
        {
            aylar[0] = new Ay(1, "Ocak");
            aylar[1] = new Ay(2, "Þubat");
            aylar[2] = new Ay(3, "Mart");
            aylar[3] = new Ay(4, "Nisan");
            aylar[4] = new Ay(5, "Mayýs");
            aylar[5] = new Ay(6, "Haziran");
            aylar[6] = new Ay(7, "Temmuz");
            aylar[7] = new Ay(8, "Agustos");
            aylar[8] = new Ay(9, "Eylül");
            aylar[9] = new Ay(10, "Ekim");
            aylar[10] = new Ay(11, "Kasým");
            aylar[11] = new Ay(12, "Aralýk");
        }
        public Ay()
        {

        }
        public Ay(int pAyDeger, string pAyIsmi)
        {
            this.ayDeger = pAyDeger;
            this.ayIsmi = pAyIsmi;
        }

        private int ayDeger;

        public int AyDeger
        {
            get { return ayDeger; }
            set { ayDeger = value; }
        }
        private string ayIsmi;

        public string AyIsmi
        {
            get { return ayIsmi; }
            set { ayIsmi = value; }
        }

        public static Ay[] AyListesi
        {
            get
            {
                return aylar;
            }
        }

        public string AyIsminiBul(int pAyDeger)
        {
            return AyListesi[pAyDeger + 1].AyIsmi;
        }


        public class PropertyIsimleri
        {
            public static string AyIsmi
            {
                get
                {
                    return "AyIsmi";
                }
            }
            public static string AyDeger
            {
                get
                {
                    return "AyDeger";
                }
            }
 
        }



    }
}
