using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.Core.Validation.ForPonos
{
    public class EmailValidator : RegExValidator
    {
        // Fields
        protected const string REGEX_ONLY_CHARACTER = @"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$";

        // Methods
        public EmailValidator(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName, @"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$", RegexOptions.None)
        {
        }

        public EmailValidator(object pUzerindeCalisilacakNesne, string pPropertyName, string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, @"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$", RegexOptions.None, pErrorMessage)
        {
        }

        protected override string BuildErrorMessage()
        {
            return string.Format("{0} düzgün bir email deðildir.", base.Property.Name);
        }
    }

 

}
