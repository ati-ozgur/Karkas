using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.Validation.ForPonos;
using System.Data;
using System.Xml.Serialization;

namespace Karkas.Core.TypeLibrary
{
    [Serializable]
    public abstract class BaseTypeLibrary
    {
        private Validator validator;


        public BaseTypeLibrary()
        {
            rowState = DataRowState.Added;
        }
        public Validator Validator
        {
            get
            {
                if (validator == null)
                {
                    validationListeleriniOlustur();
                }
                return validator;
            }
        }
        protected abstract void ValidationListesiniOlusturCodeGeneration();

        protected virtual void ValidationListesiniOlustur()
        {
        }

        public bool Validate()
        {
            if (validator == null)
            {
                validationListeleriniOlustur();
            }
            return Validator.Validate();
        }

        private void validationListeleriniOlustur()
        {
            validator = new Validator(this);
            ValidationListesiniOlusturCodeGeneration();
            ValidationListesiniOlustur();
        }
        
        [XmlIgnore]
        private DataRowState rowState;

        [XmlIgnore]
        public DataRowState RowState
        {
            get 
            {
                return rowState; 
            }
            set { rowState = value; }
        }

        public void SilinmesiIcinIsaretle()
        {
            rowState = DataRowState.Deleted;
        }
        public void EklenmesiIcinIsaretle()
        {
            rowState = DataRowState.Added;
        }
        public void GuncellenmesiIcinIsaretle()
        {
            rowState = DataRowState.Modified;
        }
        /// <summary>
        /// Bu nesnenin onaylama s�ras�nda daima hatal� olarak davranmas�n� sa�lar. 
        /// Mesela say� girilmesi gereken bir yere yazi girildi. Ornek: (sadv)
        /// Bu degeri Convert.ToInt32 kullanarak alamay�z. Bu durumda hata g�stermek istiyorsak.
        /// Asa��daki gibi bir kod yazar�z.
        /// <code>
        ///try
        ///{
        ///   f.SayiOlacak  = Convert.ToInt32(SayiOlacakTextBox.Text);

        ///}
        ///catch
        ///{
        ///    f.HataliOlarakIsaretle("SayiOlacak","Sayi Olacak degeri say� olmal�d�r");
        ///}
        /// </code>
        /// Mesaj�n�z yaz�n.
        /// </summary>
        /// <param name="pMessage"></param>
        public void HataliOlarakIsaretle(string pPropertyName,string pErrorMessage)
        {
            this.Validator.SetError(pPropertyName, pErrorMessage);
        }

        public void HataliOlarakIsaretle(string pErrorMessage)
        {
            this.Validator.SetError("", pErrorMessage);
        }

        public String Hatalar
        {
            get
            {
                return Validator.Hatalar;
            }
        }



    }
}
