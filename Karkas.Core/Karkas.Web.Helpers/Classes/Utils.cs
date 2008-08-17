namespace Karkas.Web.Helpers.Classes
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Text;
    using System.Web.Security;
    using System.Web.UI.WebControls;

    public class Utils
    {
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

