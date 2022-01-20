using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{
    internal class OrderBy
    {

        public OrderBy(string pColumnName) : this(pColumnName,"")
        {
        }
        public OrderBy(string pColumnName, OrderByEnum pOrderByType)
        {
            siralamaTuru = pOrderByType;
            kolonIsmi = pColumnName;
        }
        public OrderBy(string pColumnName, String pOrderByType)
        {
            siralamaTuruAsString = pOrderByType;
            kolonIsmi = pColumnName;
        }

        private OrderByEnum siralamaTuru;

        public OrderByEnum SiralamaTuru
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
                        case OrderByEnum.ASC:
                            s = "ASC";
                            break;
                        case OrderByEnum.Azalarak:
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

