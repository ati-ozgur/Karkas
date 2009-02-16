using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.Onaylama.ForPonos;
using System.Data;
using System.Xml.Serialization;

namespace Karkas.Core.TypeLibrary
{
    [Serializable]
    public abstract class BaseTypeLibrary
    {
        private Onaylayici validator;


        public BaseTypeLibrary()
        {
            rowState = DataRowState.Added;
        }
        public Onaylayici Onaylayici
        {
            get
            {
                if (validator == null)
                {
                    onaylamaListeleriniOlustur();
                }
                return validator;
            }
        }
        protected abstract void OnaylamaListesiniOlusturCodeGeneration();

        protected virtual void OnaylamaListesiniOlustur()
        {
        }

        public bool Onayla()
        {
            if (validator == null)
            {
                onaylamaListeleriniOlustur();
            }
            return Onaylayici.Onayla();
        }

        private void onaylamaListeleriniOlustur()
        {
            validator = new Onaylayici(this);
            OnaylamaListesiniOlusturCodeGeneration();
            OnaylamaListesiniOlustur();
        }
        
        [XmlIgnore, SoapIgnore]
        private DataRowState rowState;

        [XmlIgnore, SoapIgnore]
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
        /// Bu nesnenin onaylama sırasında daima hatalı olarak davranmasını sağlar. 
        /// Mesela sayı girilmesi gereken bir yere yazi girildi. Ornek: (sadv)
        /// Bu degeri Convert.ToInt32 kullanarak alamayız. Bu durumda hata göstermek istiyorsak.
        /// Asağıdaki gibi bir kod yazarız.
        /// <code>
        ///try
        ///{
        ///   f.SayiOlacak  = Convert.ToInt32(SayiOlacakTextBox.Text);

        ///}
        ///catch
        ///{
        ///    f.HataliOlarakIsaretle("SayiOlacak","Sayi Olacak degeri sayı olmalıdır");
        ///}
        /// </code>
        /// Mesajınız yazın.
        /// </summary>
        /// <param name="pMessage"></param>
        public void HataliOlarakIsaretle(string pPropertyName,string pErrorMessage)
        {
            this.Onaylayici.HataSetle(pPropertyName, pErrorMessage);
        }

        public void HataliOlarakIsaretle(string pErrorMessage)
        {
            this.Onaylayici.HataSetle("", pErrorMessage);
        }

        public String Hatalar
        {
            get
            {
                return Onaylayici.Hatalar;
            }
        }



    }
}

