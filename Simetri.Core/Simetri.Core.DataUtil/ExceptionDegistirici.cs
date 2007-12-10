using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Simetri.Core.DataUtil.Exceptions;

namespace Simetri.Core.DataUtil
{
    public class ExceptionDegistirici
    {
        public static void Degistir(SqlException ex)
        {
            Degistir(ex,"SQL CUMLESI YOK");
        }


        public static void Degistir(SqlException ex, string sql)
        {
            switch (ex.Number)
            {
                default:
                    throw new SimetriVeriHatasi(String.Format("Tanimlanamayan Veri Hatasi, Mesaji = {0}", ex.Message), ex);
                case 137:
                    throw new YanlisSqlCumlesiHatasi(String.Format("sql cumlesi icindeki parametreler duzgun tanýmlanmamýþ, sql cumles = {0}, orjinal hata Mesajý = {1}", sql, ex.Message), ex);
                case -1:
                    throw new VeritabaniBaglantiHatasi(String.Format("{0} connection string'i baglantisi ile sunucuya baglanilamiyor. Verilen Hata Mesaji = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message), ex);
                case 102:
                case 207:
                    throw new YanlisSqlCumlesiHatasi(String.Format("{0} sql cumlesi hatalý yazýlmýþtýr. Sunucudan gelen mesaj {1}", sql, ex.Message), ex);
                case 2627:
                    throw new SimetriVeriHatasi(String.Format("Primary Key olarak secilen kolonunda bu degeri alan satir zaten var."), ex);
                case 109:
                    throw new SimetriVeriHatasi(String.Format("Veri eklerken belirtilen her kolon için bilgi girilmedi."), ex);
                case 515:
                    throw new SimetriVeriHatasi(String.Format("Veri içermesi zorunlu olan bir kolona veri girilmedi."), ex);
                case 110:
                    throw new SimetriVeriHatasi(String.Format("Veri girerken gerekenden fazla parametre yollandý."), ex);
                case 245:
                    throw new SimetriVeriHatasi(String.Format("Kolonda belirtilen türden farklý bir tür eklenmeye çalýþýldý."), ex);
                case 2812:
                    throw new SimetriVeriHatasi(String.Format("Primary Key olarak secilen kolonunda bu degeri alan satir zaten var."), ex);
                case 8144:
                    throw new SimetriVeriHatasi(String.Format("{0} prosedürü için belirlenenden fazla parametre girildi.", ex.Procedure), ex);
                case 201:
                    throw new SimetriVeriHatasi(String.Format("{0} prosedürü için eksik parametre girildi. {1}", ex.Procedure), ex);
                case 547:
                    throw new IkincilAnahtarHatasi(String.Format("Tablo iliþkileri ile ilgili hatalý bir iþlem yapýldý."), ex);
                case 208:
                    throw new VeritabaniBaglantiHatasi(String.Format("Veritabanina baglanilamadi lutfen connection string'in dogrulugunu ve veritabanininin calisip calismadigini kontrol ediniz, Kullanilan ConnectionString = {0}, verilen hata Mesaji = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message));
            }
        }

    }
}
