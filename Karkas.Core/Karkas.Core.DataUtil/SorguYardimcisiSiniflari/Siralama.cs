using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.SorguYardimcisiSiniflari
{
    internal class Siralama
    {

        public Siralama(string pKolonIsmi) : this(pKolonIsmi,"")
        {
        }
        public Siralama(string pKolonIsmi, SiralamaEnum pSiralamaTuru)
        {
            siralamaTuru = pSiralamaTuru;
            kolonIsmi = pKolonIsmi;
        }
        public Siralama(string pKolonIsmi, String pSiralamaTuru)
        {
            siralamaTuruAsString = pSiralamaTuru;
            kolonIsmi = pKolonIsmi;
        }

        private SiralamaEnum siralamaTuru;

        public SiralamaEnum SiralamaTuru
        {
            get { return siralamaTuru; }
            set { siralamaTuru = value; }
        }
        private string siralamaTuruAsString;

        public string SiralamaTuruAsString
        {
            get { return siralamaTuruAsString; }
            set { siralamaTuruAsString = value; }
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
                if (string.IsNullOrEmpty(siralamaTuruAsString))
                {
                    switch (siralamaTuru)
                    {
                        case SiralamaEnum.ASC:
                            s = "ASC";
                            break;
                        case SiralamaEnum.Azalarak:
                            s = "DESC";
                            break;
                    }
                }
                else
                {
                    s = siralamaTuruAsString;
                }
                return kolonIsmi + " " + s;
            }
        }
    }

}
