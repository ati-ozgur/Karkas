using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.Core.Onaylama.ForPonos
{
    [Serializable]
    public class SadaceBuKarakterler : RegExOnaylayici
    {
        private const string REGEX_ONLY_THESECHARACTERS = "^[{0}]*$";
        public SadaceBuKarakterler(object pUzerindeCalisilacakNesne, string pPropertyName,char[] pCharList)
            : base(pUzerindeCalisilacakNesne, pPropertyName, getRegexString(pCharList)
            , RegexOptions.None)
        {

        }
        public SadaceBuKarakterler(object pUzerindeCalisilacakNesne, string pPropertyName, char[] pCharList,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, getRegexString(pCharList)
            , RegexOptions.None,pErrorMessage)
        {

        }


        private static string getRegexString(char[] pCharlist)
        {
            StringBuilder sb = new StringBuilder(pCharlist.Length);
            foreach (char c in pCharlist)
            {
                sb.Append(c);
            }
            return string.Format(REGEX_ONLY_THESECHARACTERS, sb.ToString());
        }

    }
}

