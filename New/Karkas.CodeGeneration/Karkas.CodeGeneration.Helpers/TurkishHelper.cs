using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.CodeGenerationHelper
{
    public class TurkishHelper
    {
        Dictionary<string, string> liste = new Dictionary<string, string>();
        public TurkishHelper()
        {
            liste.Add("Adi", "Adı");
            liste.Add("Tur", "Tür");
            liste.Add("Kisi", "Kişi");
            liste.Add("Ogrenim", "Öğrenim");
            liste.Add("Bolum", "Bolüm");
            liste.Add("Giris", "Giriş");
            string a = @"
            Aciklama";
                
        }

        public string ReplaceTurkishChars(string str)
        {
            str = str.Replace('ğ', 'g');
            str = str.Replace('Ğ', 'G');

            str = str.Replace('ü', 'u');
            str = str.Replace('Ü', 'U');

            str = str.Replace('ş', 's');
            str = str.Replace('Ş', 'S');

            str = str.Replace('ı', 'i');
            str = str.Replace('İ', 'I');

            str = str.Replace('ö', 'o');
            str = str.Replace('Ö', 'O');

            str = str.Replace('ç', 'c');
            str = str.Replace('Ç', 'C');

            return str;
        }




        /// <summary>
        /// Ingilizce harfleri ile yazılmış bir kelimeyi türkçe harflere çevirir.
        /// </summary>
        /// <param name="cevirilecekKelime"></param>
        /// <returns></returns>
        public string TurkceyeCevir(string cevirilecekKelime)
        {
            if (liste.ContainsKey(cevirilecekKelime))
            {
                return liste[cevirilecekKelime];
            }
            else
            {
                foreach (string s in liste.Keys)
                {
                    Regex reg = new Regex(s, RegexOptions.IgnoreCase);
                    Match m = reg.Match(cevirilecekKelime);
                    if (m.Success)
                    {
                        return cevirilecekKelime.Replace(m.Value, liste[s].ToLower());
                    }
                }

                return cevirilecekKelime;
            }

        }
    }
}

