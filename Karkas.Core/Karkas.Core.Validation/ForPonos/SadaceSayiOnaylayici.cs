using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.Core.Onaylama.ForPonos
{
    [Serializable]
    public class SadaceSayiOnaylayici : RegExOnaylayici
    {
        private const string REGEX_ONLY_NUMBER = "^[0-9]*$";
        public SadaceSayiOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_NUMBER, RegexOptions.None)
        {

        }
        public SadaceSayiOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_NUMBER, RegexOptions.None,pErrorMessage)
        {

        }


        protected override string HataMesajlariniOlustur()
        {
            return string.Format("{0} sadace sayı girilmelidir", this.Property.Name);
        }

    }
}

