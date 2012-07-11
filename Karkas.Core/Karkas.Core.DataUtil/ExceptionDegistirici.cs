using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Karkas.Core.DataUtil.Exceptions;
using log4net;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class ExceptionDegistirici
    {

        public static void Degistir(DbException ex)
        {
            if (ex is SqlException)
            {
                DegistirPrivate((SqlException)ex, "SQL CUMLESI YOK");
            }
            else
            {
                DegistirPrivate(ex, "SQL CUMLESI YOK");
            }

        }

        public static void Degistir(DbException ex, string pMesaj)
        {
            if (ex is SqlException)
            {
                DegistirPrivate((SqlException)ex, pMesaj);
            }
            else
            {
                DegistirPrivate(ex, pMesaj);
            }
        }

        private static void DegistirPrivate(SqlException ex)
        {
            Degistir(ex, "SQL CUMLESI YOK");
        }

        private static void DegistirPrivate(DbException ex, string pMesaj)
        {
            Exception firlatilacakException = null;
            switch (ex.ErrorCode)
            {
                default:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Tanimlanamayan Veri Hatasi, Mesaji = {0}", ex.Message), ex);
                    break;
                case 137:
                    firlatilacakException = new YanlisSqlCumlesiHatasi(String.Format("sql cumlesi icindeki parametreler duzgun tanımlanmamış, sql cumles = {0}, orjinal hata Mesajı = {1}", pMesaj, ex.Message), ex);
                    break;
                case -1:
                    firlatilacakException = new VeritabaniBaglantiHatasi(String.Format("{0} connection string'i baglantisi ile sunucuya baglanilamiyor. Verilen Hata Mesaji = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message), ex);
                    break;
                case 102:
                case 207:
                    firlatilacakException = new YanlisSqlCumlesiHatasi(String.Format("{0} sql cumlesi hatalı yazılmıştır. Sunucudan gelen mesaj {1}", pMesaj, ex.Message), ex);
                    break;
                case 2627:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Primary Key olarak secilen kolonunda bu degeri alan satir zaten var."), ex);
                    break;
                case 109:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Veri eklerken belirtilen her kolon için bilgi girilmedi."), ex);
                    break;
                case 515:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Veri içermesi zorunlu olan bir kolona veri girilmedi."), ex);
                    break;
                case 110:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Veri girerken gerekenden fazla parametre yollandı."), ex);
                    break;
                case 245:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Kolonda belirtilen türden farklı bir tür eklenmeye çalışıldı."), ex);
                    break;
                case 2812:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Primary Key olarak secilen kolonunda bu degeri alan satir zaten var."), ex);
                    break;
                case 8144:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("{0} prosedürü için belirlenenden fazla parametre girildi.", ex.Data), ex);
                    break;
                case 201:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("{0} prosedürü için eksik parametre girildi. {1}", ex.Data), ex);
                    break;
                case 547:
                    firlatilacakException = new IkincilAnahtarHatasi(String.Format("Tablo ilişkileri ile ilgili hatalı bir işlem yapıldı."), ex);
                    break;
                case 208:
                    firlatilacakException = new VeritabaniBaglantiHatasi(String.Format("Veritabanina baglanilamadi lutfen connection string'in dogrulugunu ve veritabanininin calisip calismadigini kontrol ediniz, Kullanilan ConnectionString = {0}, verilen hata Mesaji = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message));
                    break;
            }
            new LoggingInfo().LogInfo(Type.GetType(" Karkas.Core.DataUtil.ExceptionDegistirici"), ex, pMesaj);
            throw firlatilacakException;
        }


        private static void DegistirPrivate(SqlException ex, string pMesaj)
        {
            Exception firlatilacakException = null;
            switch (ex.Number)
            {
                default:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Tanimlanamayan Veri Hatasi, Mesaji = {0}", ex.Message), ex);
                    break;
                case 137:
                    firlatilacakException = new YanlisSqlCumlesiHatasi(String.Format("sql cumlesi icindeki parametreler duzgun tanımlanmamış, sql cumles = {0}, orjinal hata Mesajı = {1}", pMesaj, ex.Message), ex);
                    break;
                case -1:
                    firlatilacakException = new VeritabaniBaglantiHatasi(String.Format("{0} connection string'i baglantisi ile sunucuya baglanilamiyor. Verilen Hata Mesaji = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message), ex);
                    break;
                case 102:
                case 207:
                    firlatilacakException = new YanlisSqlCumlesiHatasi(String.Format("{0} sql cumlesi hatalı yazılmıştır. Sunucudan gelen mesaj {1}", pMesaj, ex.Message), ex);
                    break;
                case 2627:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Primary Key olarak secilen kolonunda bu degeri alan satir zaten var."), ex);
                    break;
                case 109:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Veri eklerken belirtilen her kolon için bilgi girilmedi."), ex);
                    break;
                case 515:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Veri içermesi zorunlu olan bir kolona veri girilmedi."), ex);
                    break;
                case 110:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Veri girerken gerekenden fazla parametre yollandı."), ex);
                    break;
                case 245:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Kolonda belirtilen türden farklı bir tür eklenmeye çalışıldı."), ex);
                    break;
                case 2812:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Primary Key olarak secilen kolonunda bu degeri alan satir zaten var."), ex);
                    break;
                case 8144:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("{0} prosedürü için belirlenenden fazla parametre girildi.", ex.Procedure), ex);
                    break;
                case 201:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("{0} prosedürü için eksik parametre girildi. {1}", ex.Procedure), ex);
                    break;
                case 547:
                    firlatilacakException = new IkincilAnahtarHatasi(String.Format("Tablo ilişkileri ile ilgili hatalı bir işlem yapıldı."), ex);
                    break;
                case 208:
                    firlatilacakException = new VeritabaniBaglantiHatasi(String.Format("Veritabanina baglanilamadi lutfen connection string'in dogrulugunu ve veritabanininin calisip calismadigini kontrol ediniz, Kullanilan ConnectionString = {0}, verilen hata Mesaji = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message));
                    break;
            }
            new LoggingInfo().LogInfo(Type.GetType(" Karkas.Core.DataUtil.ExceptionDegistirici"), ex, pMesaj);
            throw firlatilacakException;
        }

    }
}

