namespace Karkas.Web.Helpers.HelperClasses
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Text;
    using System.Web.Security;
    using System.Web.UI.WebControls;


    public static class Utils
    {
        public static int? IntAsNullable(this String str)
        {
            int sonuc;
            if (int.TryParse(str, out sonuc))
            {
                return sonuc;
            }
            else
            {
                return null;
            }
        }
        public static byte? ByteAsNullable(this String str)
        {
            byte sonuc;
            if (byte.TryParse(str, out sonuc))
            {
                return sonuc;
            }
            else
            {
                return null;
            }
        }
        public static short? ShortAsNullable(this String str)
        {
            short sonuc;
            if (short.TryParse(str, out sonuc))
            {
                return sonuc;
            }
            else
            {
                return null;
            }
        }

        public static long? LongAsNullable(this String str)
        {
            long sonuc;
            if (long.TryParse(str, out sonuc))
            {
                return sonuc;
            }
            else
            {
                return null;
            }
        }
        public static Guid? GuidAsNullable(this String str)
        {
            Guid sonuc;
            try
            {
                return new Guid(str);
            }
            catch
            {
                return null;
            }
        }


        public static string VerilenKarakterYaDaKelimeleriCikar(string pGercekCumleYaDaKelime, string[] pCikarilacakKarakterYaDaKelimeler)
        {
            string cikarilmisCumleYaDaKelime = pGercekCumleYaDaKelime;
            for (int i = 0; i < pCikarilacakKarakterYaDaKelimeler.Length; i++)
            {
                cikarilmisCumleYaDaKelime = cikarilmisCumleYaDaKelime.Replace(pCikarilacakKarakterYaDaKelimeler[i], string.Empty);
            }
            return cikarilmisCumleYaDaKelime;
        }

        public static string VerilenListeyiVirgulleAyir(ListItemCollection pListe)
        {
            string virgulluListe = string.Empty;
            foreach (ListItem listeNode in pListe)
            {
                if (listeNode.Selected)
                {
                    if (!virgulluListe.Equals(string.Empty))
                    {
                        virgulluListe = virgulluListe + ',';
                    }
                    virgulluListe = virgulluListe + listeNode.Value;
                }
            }
            return virgulluListe;
        }
    }
}


