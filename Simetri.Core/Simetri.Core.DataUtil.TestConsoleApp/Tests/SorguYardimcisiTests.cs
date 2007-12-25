using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.DataUtil.SorguYardimcisiSiniflari;

namespace Simetri.Core.DataUtil.TestConsoleApp.Tests
{
    public class SorguYardimcisiTests
    {
        public void NormalArama()
        {

            SorguYardimcisi yardimci = new SorguYardimcisi();
//            emps.Query.AddOrderBy(Employees.ColumnNames.LastName, WhereParameter.Dir.ASC);
            string pKolonIsmi = "SonTamUnvan";
            string pParameterIsmi = "@Unvan";
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


        }

    }
}
