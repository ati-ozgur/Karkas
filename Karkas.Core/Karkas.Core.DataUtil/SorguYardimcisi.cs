using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.DataUtil.SorguYardimcisiSiniflari;

namespace Karkas.Core.DataUtil
{
    public class SorguYardimcisi
    {
        List<Siralama> siralamaListesi = new List<Siralama>();
        List<WhereKriter> whereListesi = new List<WhereKriter>();
        List<WhereKriterTercihli> whereTercihliListesi = new List<WhereKriterTercihli>();
        List<WhereKriterTercihliNullDegeri> whereTercihliNullDegeriListesi = new List<WhereKriterTercihliNullDegeri>();


        public void OrderByEkle(string pKolonIsmi, SiralamaEnum pSiralamaTuru)
        {
            Siralama s = new Siralama(pKolonIsmi, pSiralamaTuru);
            if (!siralamaListesi.Contains(s))
            {
                siralamaListesi.Add(s);
            }
        }
        public void OrderByEkle(string pKolonIsmi)
        {
            Siralama s = new Siralama(pKolonIsmi);
            if (!siralamaListesi.Contains(s))
            {
                siralamaListesi.Add(s);
            }
        }
        public void OrderByEkle(string pKolonIsmi, String pSiralamaTuru)
        {
            Siralama s = new Siralama(pKolonIsmi, pSiralamaTuru);
            if (!siralamaListesi.Contains(s))
            {
                siralamaListesi.Add(s);
            }
        }

        public string KriterSonucunuGetir()
        {
            string sonuc = "";
            sonuc += whereKriterlerininSonucunuGetir();
            sonuc += OrderBylarinSonucunuGetir();
            return sonuc;
        }
        public string KriterSonucunuWhereOlmadanGetir()
        {
            string sonuc = KriterSonucunuGetir();
            return sonuc.Replace("WHERE", "");

        }


        private string OrderBylarinSonucunuGetir()
        {
            if (siralamaListesi.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append("ORDER BY ");
            foreach (Siralama s in siralamaListesi)
            {
                sb.Append(s.SqlHali + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public void WhereKriterineEkle(string pKolonIsmi)
        {
            WhereKriter wk = new WhereKriter(pKolonIsmi,WhereOperatorEnum.Esittir , "@" + pKolonIsmi);
            whereListesi.Add(wk);
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
            if ((whereListesi.Count == 0) && (whereTercihliListesi.Count == 0)
                && (whereTercihliNullDegeriListesi.Count == 0))
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append("WHERE ");
            foreach (WhereKriter s in whereListesi)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            foreach (WhereKriterTercihli s in whereTercihliListesi)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            foreach (WhereKriterTercihliNullDegeri s in whereTercihliNullDegeriListesi)
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
        public void WhereKriterineTercihliEkle(string pKolonIsmi)
        {
            WhereKriterineTercihliEkle(pKolonIsmi, WhereOperatorEnum.Esittir, "@" + pKolonIsmi);
        }

        public void WhereKriterineTercihliEkle(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum)
        {
            WhereKriterineTercihliEkle(pKolonIsmi, pWhereOperatorEnum, "@" + pKolonIsmi);
        }

        public void WhereKriterineTercihliEkle(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum, string pParameterIsmi, LikeYeriEnum pLikeYeriEnum)
        {
            WhereKriterTercihli wk = new WhereKriterTercihli(pKolonIsmi, pWhereOperatorEnum, pParameterIsmi, pLikeYeriEnum);
            whereTercihliListesi.Add(wk);
        }
        public void WhereKriterineArasindaEkle(string pKolonIsmi, string pParameterIsmi1, string pParameterIsmi2)
        {

            WhereKriter wk1 = new WhereKriter(pKolonIsmi, WhereOperatorEnum.BuyukEsittir, pParameterIsmi1);
            whereListesi.Add(wk1);
            WhereKriter wk2 = new WhereKriter(pKolonIsmi, WhereOperatorEnum.KucukEsittir, pParameterIsmi2);
            whereListesi.Add(wk2);
        }

        public void WhereKriterineArasindaTercihliEkle(string pKolonIsmi, string pParameterIsmi1, string pParameterIsmi2)
        {
            WhereKriterTercihli wk1 = new WhereKriterTercihli(pKolonIsmi, WhereOperatorEnum.BuyukEsittir, pParameterIsmi1);
            whereTercihliListesi.Add(wk1);
            WhereKriterTercihli wk2 = new WhereKriterTercihli(pKolonIsmi, WhereOperatorEnum.KucukEsittir, pParameterIsmi2);
            whereTercihliListesi.Add(wk2);
        }

        public void WhereKriterineArasindaTercihliEkleNullDegeriVer(string pKolonIsmi, string pParameterIsmi1, string pParameterIsmi2, string pNullDegeri)
        {
            WhereKriterTercihliNullDegeri wk1 = new WhereKriterTercihliNullDegeri(pKolonIsmi, WhereOperatorEnum.BuyukEsittir, pParameterIsmi1, pNullDegeri);
            whereTercihliNullDegeriListesi.Add(wk1);
            WhereKriterTercihliNullDegeri wk2 = new WhereKriterTercihliNullDegeri(pKolonIsmi, WhereOperatorEnum.KucukEsittir, pParameterIsmi2, pNullDegeri);
            whereTercihliNullDegeriListesi.Add(wk2);
        }


        public void WhereKriterineTercihliEkleNullDegeriVer(
            string pKolonIsmi
            , WhereOperatorEnum pWhereOperatorEnum
            , string pParameterIsmi, string pNullDegeri
            )
        {
            WhereKriterTercihliNullDegeri wk = new WhereKriterTercihliNullDegeri(pKolonIsmi, pWhereOperatorEnum, pParameterIsmi, pNullDegeri);
            whereTercihliNullDegeriListesi.Add(wk);
        }


        public void WhereKriterineTercihliEkleNullDegeriVer(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum, string pParameterIsmi, LikeYeriEnum pLikeYeriEnum, string pNullDegeri)
        {
            WhereKriterTercihliNullDegeri wk = new WhereKriterTercihliNullDegeri(pKolonIsmi, pWhereOperatorEnum, pParameterIsmi, pNullDegeri, pLikeYeriEnum);
            whereTercihliNullDegeriListesi.Add(wk);
        }
    }
}





