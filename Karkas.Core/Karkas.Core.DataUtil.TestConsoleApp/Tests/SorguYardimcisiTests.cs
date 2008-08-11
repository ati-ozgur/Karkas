using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.DataUtil.SorguYardimcisiSiniflari;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests
{
    public class SorguYardimcisiTests
    {
        public void NormalArama()
        {

            SorguYardimcisi yardimci = new SorguYardimcisi();
//            emps.Query.AddOrderBy(Employees.ColumnNames.LastName, WhereParameter.Dir.ASC);
            string pKolonIsmi = "SonTamUnvan";
            string pParameterIsmi = "@Unvan";
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("TSM.FIRMA.SonTamUnvan", WhereOperatorEnum.Like, "@SonTamUnvan", LikeYeriEnum.Basinda, "");
            yardimci.WhereKriterineTercihliEkle(pKolonIsmi, WhereOperatorEnum.Like,pParameterIsmi,LikeYeriEnum.Sonunda);
            yardimci.WhereKriterineTercihliEkle("FirmaNeviTipNo", WhereOperatorEnum.Esittir);
            yardimci.WhereKriterineTercihliEkle("BagliOlduguTsmTipNo", WhereOperatorEnum.Esittir);
            yardimci.WhereKriterineTercihliEkle("SicilNo", WhereOperatorEnum.Esittir);
            yardimci.WhereKriterineTercihliEkle("MTKNo", WhereOperatorEnum.Esittir);
            yardimci.WhereKriterineTercihliEkle("VergiNo", WhereOperatorEnum.Esittir);
            yardimci.WhereKriterineTercihliEkle("IlTipNo", WhereOperatorEnum.Esittir);
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("IlTipNo", WhereOperatorEnum.Esittir,"@IlTipNo","0");
            yardimci.WhereKriterineArasindaTercihliEkle("TescilTarihi", "@TescilTarihiBaslangic", "@TescilTarihiBitis");

            //yardimci.OrderByEkle(pKolonIsmi, SiralamaEnum.Artarak);
            //yardimci.OrderByEkle("MTKNo", SiralamaEnum.Azalarak);
            string sqlSonuc = yardimci.KriterSonucunuGetir();

            Console.WriteLine(sqlSonuc);

            yardimci = new SorguYardimcisi();
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("TSM.FIRMA.SonTamUnvan", WhereOperatorEnum.Like, "@SonTamUnvan", LikeYeriEnum.Basinda, "");
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("TSM.FIRMA.SonTamUnvan", WhereOperatorEnum.Like, "@IcindeGecen", LikeYeriEnum.Icinde, "");
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("TSM.FIRMA.SonTamUnvan", WhereOperatorEnum.Like, "@SektorAdi", LikeYeriEnum.Icinde, "0");
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("ADRES.IlTipNo", WhereOperatorEnum.Esittir, "@IlTipNo", "0");
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("TSM.FIRMA.BagliOlduguTSMTipNo", WhereOperatorEnum.Esittir, "@BagliOlduguTSMTipNo", "0");
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("TSM.FIRMA.FirmaNeviTipNo", WhereOperatorEnum.Esittir, "@FirmaNeviTipNo", "0");
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("TSM.FIRMA.SicilNo", WhereOperatorEnum.Esittir, "@SicilNo", "");
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("TSM.FIRMA.MTKNo", WhereOperatorEnum.Esittir, "@MTKNo", "");
            yardimci.WhereKriterineTercihliEkleNullDegeriVer("TSM.FIRMA.VergiNo", WhereOperatorEnum.Esittir, "@VergiNo", "");
            yardimci.WhereKriterineEkle("TSM.FIRMA.TescilDurumu", WhereOperatorEnum.BuyukEsittir, "2");
            yardimci.WhereKriterineEkle("TSM.FIRMA.AktifMi", WhereOperatorEnum.Esittir, "1");

            sqlSonuc = yardimci.KriterSonucunuGetir();

            Console.WriteLine(sqlSonuc);

        }

    }
}
