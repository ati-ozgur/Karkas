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
        /// Validate İşlemi sonucunda oluşan hatalar bir liste halinde alınabilir
        /// </summary>
        public List<string> HataListesi
        {
            get { return hataListesi; }
            set { hataListesi = value; }
        }

        private bool dogruMu = false;

        /// <summary>
        /// Onaylama testleri nesne uzerinde calistirir.
        /// </summary>
        /// <returns>onaylama testlerinden herhangi bir yanlis ise false, hepsi dogru ise true dondurur.</returns>
        public bool Onayla()
        {
            dogruMu = true;
            hataListesi = new List<string>();
            foreach (BaseOnaylayici v in onaylayiciListesi)
            {
                bool onaySonucu =v.IslemYap(uzerindeCalisilacakNesne);
                dogruMu = onaySonucu && dogruMu;
                if (!onaySonucu)
                {
                    hataListesi.Add(v.HataMesaji);
                }
                
            }
            return dogruMu;
        }
        /// <summary>
        /// Uzerinde calisan nesnenin onaylama testlerine gore sonucunu verir. Validate cagrilmadi ise
        /// default olarak false alirsiniz.
        /// </summary>
        public bool DogruMu
        {
            get 
            {
                if (OnaylamayiTersCalistir)
                {
                    return !dogruMu;
                }
                else
                {
                    return dogruMu;
                }
            }
        }

        private bool onaylamayiTersCalistir = false;

        public bool OnaylamayiTersCalistir
        {
            get { return onaylamayiTersCalistir;  }
            set { onaylamayiTersCalistir =  value; }
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

