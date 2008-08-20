using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.Core.Validation.ForPonos
{
    [Serializable]
    public class SadaceKarekterOnaylayici : RegExOnaylayici
    {
        protected const string REGEX_ONLY_CHARACTER = "^[a-zA-Z��i����������I ]*$";
        public SadaceKarekterOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_CHARACTER, RegexOptions.None)
        {
        }
        public SadaceKarekterOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_CHARACTER, RegexOptions.None,pErrorMessage)
        {
        }


        protected override string HataMesajlariniOlustur()
        {
            return string.Format("{0} sadace harf girilmelidir",this.Property.Name);
        }

    }
}
