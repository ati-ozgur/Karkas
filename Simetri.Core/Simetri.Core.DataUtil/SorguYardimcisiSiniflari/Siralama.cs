using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.DataUtil.SorguYardimcisiSiniflari
{
    internal class Siralama
    {
        public Siralama(string pKolonIsmi, SiralamaEnum pSiralamaTuru)
        {
            siralamaTuru = pSiralamaTuru;
            kolonIsmi = pKolonIsmi;
        }

        private SiralamaEnum siralamaTuru;

        public SiralamaEnum SiralamaTuru
        {
            get { return siralamaTuru; }
            set { siralamaTuru = value; }
        }



        private string kolonIsmi;

        public string KolonIsmi
        {
            get { return kolonIsmi; }
            set { kolonIsmi = value; }
        }

        public string SqlHali
        {
            get
            {
                string s = "";
                switch (siralamaTuru)
                {
                    case SiralamaEnum.ASC:
                        s = "ASC";
                        break;
                    case SiralamaEnum.Azalarak:
                        s = "DESC";
                        break;
                }
                return kolonIsmi + " " + s;
            }
        }
    }

}
