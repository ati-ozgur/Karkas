using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.DataUtil.SorguYardimcisiSiniflari
{

    internal class WhereKriterTercihliNullDegeri
    {
        public WhereKriterTercihliNullDegeri(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, string pNullDegeri)
        {
            whereOperator = pWhereOperator;
            kolonIsmi = pKolonIsmi;
            parameterIsmi = pParamaterIsmi;
            nullDegeri = pNullDegeri;
        }

        private string nullDegeri = "";
        public WhereKriterTercihliNullDegeri(
            string pKolonIsmi
            , WhereOperatorEnum pWhereOperator
            , string pParamaterIsmi
            , string pNullDegeri
            , LikeYeriEnum pLikeYeriEnum)
            : this(pKolonIsmi, pWhereOperator, pParamaterIsmi, pNullDegeri)
        {
            likeYeri = pLikeYeriEnum;
        }

        private LikeYeriEnum likeYeri = LikeYeriEnum.Yok;

        public LikeYeriEnum LikeYeri
        {
            get { return likeYeri; }
            set { likeYeri = value; }
        }

        private string parameterIsmi;

        public string ParameterIsmi
        {
            get { return parameterIsmi; }
            set { parameterIsmi = value; }
        }


        private WhereOperatorEnum whereOperator;

        public WhereOperatorEnum WhereOperator
        {
            get { return whereOperator; }
            set { whereOperator = value; }
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
                if (WhereOperator != WhereOperatorEnum.Like)
                {
                    return string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ({0} {1} {2}))", kolonIsmi, s, parameterIsmi, nullDegeri);
                }
                else
                {
                    string son = "";
                    switch (likeYeri)
                    {
                        case LikeYeriEnum.Yok:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} {2}))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                        case LikeYeriEnum.Basinda:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR( {0} {1} {2} + '%'))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                        case LikeYeriEnum.Sonunda:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} '%' + {2}))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                        case LikeYeriEnum.Icinde:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ({0} {1} '%' + {2} + '%'))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                    }
                    return son;
                }

            }
        }
    }


}
