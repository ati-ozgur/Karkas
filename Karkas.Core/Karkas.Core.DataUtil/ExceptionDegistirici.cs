using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Karkas.Core.DataUtil.Exceptions;
using log4net;

namespace Karkas.Core.DataUtil
{
    public class ExceptionDegistirici
    {
        private static ILog logger = LogManager.GetLogger("Dal");

        public static void Degistir(SqlException ex)
        {
            Degistir(ex, "SQL CUMLESI YOK");
        }


        public static void Degistir(SqlException ex, string pMesaj)
        {
            Exception firlatilacakException = null;
            switch (ex.Number)
            {
                default:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Tanimlanamayan Veri Hatasi, Mesaji = {0}", ex.Message), ex);
                    break;
                case 137:
                    firlatilacakException = new YanlisSqlCumlesiHatasi(String.Format("sql cumlesi icindeki parametreler duzgun tan�mlanmam��, sql cumles = {0}, orjinal hata Mesaj� = {1}", pMesaj, ex.Message), ex);
                    break;
                case -1:
                    firlatilacakException = new VeritabaniBaglantiHatasi(String.Format("{0} connection string'i baglantisi ile sunucuya baglanilamiyor. Verilen Hata Mesaji = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message), ex);
                    break;
                case 102:
                case 207:
                    firlatilacakException = new YanlisSqlCumlesiHatasi(String.Format("{0} sql cumlesi hatal� yaz�lm��t�r. Sunucudan gelen mesaj {1}", pMesaj, ex.Message), ex);
                    break;
                case 2627:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Primary Key olarak secilen kolonunda bu degeri alan satir zaten var."), ex);
                    break;
                case 109:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Veri eklerken belirtilen her kolon i�in bilgi girilmedi."), ex);
                    break;
                case 515:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Veri i�ermesi zorunlu olan bir kolona veri girilmedi."), ex);
                    break;
                case 110:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Veri girerken gerekenden fazla parametre yolland�."), ex);
                    break;
                case 245:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Kolonda belirtilen t�rden farkl� bir t�r eklenmeye �al���ld�."), ex);
                    break;
                case 2812:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("Primary Key olarak secilen kolonunda bu degeri alan satir zaten var."), ex);
                    break;
                case 8144:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("{0} prosed�r� i�in belirlenenden fazla parametre girildi.", ex.Procedure), ex);
                    break;
                case 201:
                    firlatilacakException = new KarkasVeriHatasi(String.Format("{0} prosed�r� i�in eksik parametre girildi. {1}", ex.Procedure), ex);
                    break;
                case 547:
                    firlatilacakException = new IkincilAnahtarHatasi(String.Format("Tablo ili�kileri ile ilgili hatal� bir i�lem yap�ld�."), ex);
                    break;
                case 208:
                    firlatilacakException = new VeritabaniBaglantiHatasi(String.Format("Veritabanina baglanilamadi lutfen connection string'in dogrulugunu ve veritabanininin calisip calismadigini kontrol ediniz, Kullanilan ConnectionString = {0}, verilen hata Mesaji = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message));
                    break;
            }
            logger.Info(pMesaj, firlatilacakException);
            throw firlatilacakException;
        }

    }
}
