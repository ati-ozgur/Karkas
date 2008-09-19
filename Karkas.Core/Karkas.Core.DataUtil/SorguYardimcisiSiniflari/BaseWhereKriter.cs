using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.SorguYardimcisiSiniflari
{
    public abstract class BaseWhereKriter
    {
        protected LikeYeriEnum likeYeri = LikeYeriEnum.Yok;

        public LikeYeriEnum LikeYeri
        {
            get { return likeYeri; }
            set { likeYeri = value; }
        }


        protected string parameterIsmi;

        public string ParameterIsmi
        {
            get { return parameterIsmi; }
            set { parameterIsmi = value; }
        }


        protected WhereOperatorEnum whereOperator;

        public WhereOperatorEnum WhereOperator
        {
            get { return whereOperator; }
            set { whereOperator = value; }
        }



        protected string kolonIsmi;

        public string KolonIsmi
        {
            get { return kolonIsmi; }
            set { kolonIsmi = value; }
        }

        public abstract string SqlHali
        {
            get;
        }

        public string whereOperatorDegeriniAl()
        {
            string s = "";
            switch (whereOperator)
            {
                case WhereOperatorEnum.BuyukEsittir:
                    s = " >= ";
                    break;
                case WhereOperatorEnum.Buyuktur:
                    s = ">";
                    break;
                case WhereOperatorEnum.EsitDegildir:
                    s = "<>";
                    break;
                case WhereOperatorEnum.Esittir:
                    s = "=";
                    break;
                case WhereOperatorEnum.KucukEsittir:
                    s = "<=";
                    break;
                case WhereOperatorEnum.Kucuktur:
                    s = "<";
                    break;
                case WhereOperatorEnum.Like:
                    s = " LIKE ";
                    break;
            }
            return s;
        }
    }
}
