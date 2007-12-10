using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.Validation.ForPonos
{
    [Serializable]
    public class Validator
    {
        private object uzerindeCalisilacakNesne;
        public Validator(Object pUzerindeCalisilacakNesne)
        {
            uzerindeCalisilacakNesne = pUzerindeCalisilacakNesne;
        }

        protected List<string> errorList = new List<string>();

        /// <summary>
        /// Validate Ýþlemi sonucunda oluþan hatalar bir liste halinde alýnabilir
        /// </summary>
        public List<string> ErrorList
        {
            get { return errorList; }
            set { errorList = value; }
        }

        private bool isValid = false;

        /// <summary>
        /// Onaylama testleri nesne uzerinde calistirir.
        /// </summary>
        /// <returns>onaylama testlerinden herhangi bir yanlis ise false, hepsi dogru ise true dondurur.</returns>
        public bool Validate()
        {
            isValid = true;
            errorList = new List<string>();
            foreach (BaseValidator v in validatorList)
            {
                bool onaySonucu =v.Perform(uzerindeCalisilacakNesne);
                isValid = onaySonucu && isValid;
                if (!onaySonucu)
                {
                    errorList.Add(v.ErrorMessage);
                }
                
            }
            return isValid;
        }
        /// <summary>
        /// Uzerinde calisan nesnenin onaylama testlerine gore sonucunu verir. Validate cagrilmadi ise
        /// default olarak false alirsiniz.
        /// </summary>
        public bool IsValid
        {
            get 
            {
                return isValid; 
            }
        }



        private List<BaseValidator> validatorList = new List<BaseValidator>();

        public List<BaseValidator> ValidatorList
        {
            get { return validatorList; }
            set { validatorList = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in errorList)
            {
                sb.Append(s);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
        public string Hatalar
        {
            get
            {
                return ToString();
            }
        }

        public void SetError(string pPropertyName, string pErrorMessage)
        {
            this.ValidatorList.Add(new AlwaysFail(null, pPropertyName, pErrorMessage));
        }
    }
}
