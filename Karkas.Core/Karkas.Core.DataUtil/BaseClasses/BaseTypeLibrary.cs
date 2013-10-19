using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml.Serialization;

namespace Karkas.Core.TypeLibrary
{
    [Serializable]
    public abstract class BaseTypeLibrary
    {

        public BaseTypeLibrary()
        {
            rowState = DataRowState.Added;
        }


        protected const string CEVIRI_YAZISI = "{0} kolonu için, girilen değer {1}'e çevrilemedi. Girilmemiş olabilir ";


        
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




    }
}

