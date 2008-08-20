using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.Core.Validation.ForPonos
{
    [Serializable]
    public class OnlyCharacterAndNumberValidator : RegExValidator
    {
        private const string REGEX_ONLY_CHARACTER_NUMBER = "^[ a-zA-ZüðiþçöýÜÐÝÞÇÖI0-9]*$";
        public OnlyCharacterAndNumberValidator(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_CHARACTER_NUMBER, RegexOptions.None)
        {

        }
        public OnlyCharacterAndNumberValidator(object pUzerindeCalisilacakNesne, string pPropertyName,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_CHARACTER_NUMBER, RegexOptions.None,pErrorMessage)
        {

        }

        protected override string HataMesajlariniOlustur()
        {
            return string.Format("{0} sadace harf ve sayý girilmelidir", this.Property.Name);
        }

    
    }
}
