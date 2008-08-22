using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.Onaylama.ForPonos
{
    [Serializable]
    public class Onaylayici
    {
        private object uzerindeCalisilacakNesne;
        public Onaylayici(Object pUzerindeCalisilacakNesne)
        {
            uzerindeCalisilacakNesne = pUzerindeCalisilacakNesne;
        }

        protected List<string> hataListesi = new List<string>();

        /// <summary>
        /// Validate Ýþlemi sonucunda oluþan hatalar bir liste halinde alýnabilir
        /// </summary>
        public List<string> HataListesi
        {
            get { return hataListesi; }
            set { hataListesi = value; }
        }

        private bool isValid = false;

        /// <summary>
        /// Onaylama testleri nesne uzerinde calistirir.
        /// </summary>
        /// <returns>onaylama testlerinden herhangi bir yanlis ise false, hepsi dogru ise true dondurur.</returns>
        public bool Onayla()
        {
            isValid = true;
            hataListesi = new List<string>();
            foreach (BaseOnaylayici v in onaylayiciListesi)
            {
                bool onaySonucu =v.IslemYap(uzerindeCalisilacakNesne);
                isValid = onaySonucu && isValid;
                if (!onaySonucu)
                {
                    hataListesi.Add(v.HataMesaji);
                }
                
            }
            return isValid;
        }
        /// <summary>
        /// Uzerinde calisan nesnenin onaylama testlerine gore sonucunu verir. Validate cagrilmadi ise
        /// default olarak false alirsiniz.
        /// </summary>
        public bool DogruMu
        {
            get 
            {
                return isValid; 
            }
        }



        private List<BaseOnaylayici> onaylayiciListesi = new List<BaseOnaylayici>();

        public List<BaseOnaylayici> OnaylayiciListesi
        {
            get { return onaylayiciListesi; }
            set { onaylayiciListesi = value; }
        }

        public override string ToString()
        {
            if (hataListesi.Count > 1)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in hataListesi)
                {
                    sb.Append(s);
                    sb.Append(Environment.NewLine);
                }
                return sb.ToString();
            }
            else if (hataListesi.Count == 1)
            {
                return hataListesi[0];
            }
            else
            {
                return "";
            }

        }
        public string Hatalar
        {
            get
            {
                return ToString();
            }
        }

        public void HataSetle(string pPropertyIsmi, string pHataMesaji)
        {
            this.OnaylayiciListesi.Add(new DaimaBasarisiz(null, pPropertyIsmi, pHataMesaji));
        }
    }
}
