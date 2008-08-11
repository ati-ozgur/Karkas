using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.Core.Validation.ForPonos
{
    [Serializable]
    public class OnlyCharacterValidator : RegExValidator
    {
        protected const string REGEX_ONLY_CHARACTER = "^[a-zA-ZüðiþçöýÜÐÝÞÇÖI ]*$";
        public OnlyCharacterValidator(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_CHARACTER, RegexOptions.None)
        {
        }
        public OnlyCharacterValidator(object pUzerindeCalisilacakNesne, string pPropertyName,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_CHARACTER, RegexOptions.None,pErrorMessage)
        {
        }


        protected override string BuildErrorMessage()
        {
            return string.Format("{0} sadace harf girilmelidir",this.Property.Name);
        }

    }
}
