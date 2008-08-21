using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.Core.Onaylama.ForPonos
{
    [Serializable]
    public class SadaceKarekterVeSayiOnaylayici : RegExOnaylayici
    {
        private const string REGEX_ONLY_CHARACTER_NUMBER = "^[ a-zA-Z��i����������I0-9]*$";
        public SadaceKarekterVeSayiOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_CHARACTER_NUMBER, RegexOptions.None)
        {

        }
        public SadaceKarekterVeSayiOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_CHARACTER_NUMBER, RegexOptions.None,pErrorMessage)
        {

        }

        protected override string HataMesajlariniOlustur()
        {
            return string.Format("{0} sadace harf ve say� girilmelidir", this.Property.Name);
        }

    
    }
}
