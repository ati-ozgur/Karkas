using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.DataUtil
{
    public class SorguYardimcisi
    {
        List<Siralama> siralamaListesi = new List<Siralama>();
        List<WhereKriter> whereListesi = new List<WhereKriter>();
        List<WhereKriterTercihli> whereTercihliListesi = new List<WhereKriterTercihli>();


        public void OrderByEkle(string pKolonIsmi, SiralamaEnum pSiralamaTuru)
        {
            Siralama s = new Siralama(pKolonIsmi, pSiralamaTuru);
            if (!siralamaListesi.Contains(s))
            {
                siralamaListesi.Add(s);
            }
        }

        public string SorguSonucuGetir()
        {
            string sonuc = "";
            sonuc += whereKriterlerininSonucunuGetir();
            sonuc += OrderBylarinSonucunuGetir();
            return sonuc;
        }

        private string OrderBylarinSonucunuGetir()
        {
            if (siralamaListesi.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("ORDER BY ");
            foreach (Siralama s in siralamaListesi)
            {
                sb.Append(s.SqlHali + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
        public void WhereKriterineEkle(string pKolonIsmi, WhereOperatorEnum whereOperator)
        {
            WhereKriter wk = new WhereKriter(pKolonIsmi, whereOperator, "@" + pKolonIsmi);
            whereListesi.Add(wk);
        }

        public void WhereKriterineEkle(string pKolonIsmi, WhereOperatorEnum whereOperator, string pParameterIsmi)
        {
            WhereKriter wk = new WhereKriter(pKolonIsmi, whereOperator, pParameterIsmi);
            whereListesi.Add(wk);
        }

        private string whereKriterlerininSonucunuGetir()
        {
            if ((whereListesi.Count == 0) && (whereTercihliListesi.Count == 0))
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("WHERE ");
            foreach (WhereKriter s in whereListesi)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            foreach (WhereKriterTercihli s in whereTercihliListesi)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            sb.Remove(sb.Length - 5, 5);
            sb.Append(Environment.NewLine);
            return sb.ToString();

        }


        public void WhereKriterineTercihliEkle(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum, string pParameterIsmi)
        {
            WhereKriterTercihli wk = new WhereKriterTercihli(pKolonIsmi, pWhereOperatorEnum, pParameterIsmi);
            whereTercihliListesi.Add(wk);

        }

        public void WhereKriterineTercihliEkle(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum)
        {
            WhereKriterineTercihliEkle(pKolonIsmi, pWhereOperatorEnum, "@" + pKolonIsmi);
        }

        public void WhereKriterineTercihliEkle(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum, string pParameterIsmi, LikeYeriEnum pLikeYeriEnum)
        {
            WhereKriterTercihli wk = new WhereKriterTercihli(pKolonIsmi, pWhereOperatorEnum, pParameterIsmi,pLikeYeriEnum);
            whereTercihliListesi.Add(wk);
        }
    }


    internal class WhereKriterTercihli
    {
        public WhereKriterTercihli(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi)
        {
            whereOperator = pWhereOperator;
            kolonIsmi = pKolonIsmi;
            parameterIsmi = pParamaterIsmi;
        }
        public WhereKriterTercihli(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, LikeYeriEnum pLikeYeriEnum)
            : this(pKolonIsmi, pWhereOperator, pParamaterIsmi)
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
                    return string.Format("(({2} IS NULL) OR ({0} {1} {2}))", kolonIsmi, s, parameterIsmi);
                }
                else
                {
                    string son = "";
                    switch (likeYeri)
                    {
                        case LikeYeriEnum.Yok:
                            son = string.Format("(({2} IS NULL) OR ( {0} {1} {2}))", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikeYeriEnum.Basinda:
                            son = string.Format("(({2} IS NULL) OR ( {0} {1} {2} + '%'))", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikeYeriEnum.Sonunda:
                            son = string.Format("(({2} IS NULL) OR ( {0} {1} '%' + {2}))", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikeYeriEnum.Icinde:
                            son = string.Format("(({2} IS NULL) OR ({0} {1} '%' + {2} + '%'))", kolonIsmi, s, parameterIsmi);
                            break;
                    }
                    return son;
                }

            }
        }
    }

    public enum LikeYeriEnum
    {
        Yok = 1,
        Basinda = 2,
        Sonunda = 3,
        Icinde = 4
    }

    internal class WhereKriter
    {
        public WhereKriter(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi)
        {
            whereOperator = pWhereOperator;
            kolonIsmi = pKolonIsmi;
            parameterIsmi = pParamaterIsmi;

        }

        public WhereKriter(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, LikeYeriEnum pLikeYeriEnum)
            : this(pKolonIsmi, pWhereOperator, pParamaterIsmi)
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
                    return string.Format("{0} {1} {2}", kolonIsmi, s, parameterIsmi);
                }
                else
                {
                    string son = "";
                    switch (likeYeri)
                    {
                        case LikeYeriEnum.Yok:
                            son = string.Format("{0} {1} {2}", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikeYeriEnum.Basinda:
                            son = string.Format("{0} {1} {2} + '%'", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikeYeriEnum.Sonunda:
                            son = string.Format("{0} {1} '%' + {2}", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikeYeriEnum.Icinde:
                            son = string.Format("{0} {1} '%' + {2} + '%'", kolonIsmi, s, parameterIsmi);
                            break;
                    }
                    return son;
                }
            }
        }
    }


    public enum WhereOperatorEnum
    {
        Like = 1,
        Esittir = 2,
        EsitDegildir = 3,
        Kucuktur = 4,
        KucukEsittir = 5,
        Buyuktur = 6,
        BuyukEsittir = 7
    }



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


    public enum SiralamaEnum
    {
        ASC = 1,
        DESC = 2,
        Artarak = 1,
        Azalarak = 2
    }


}
