using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.TypeLibrary;
using System.Data;

namespace Karkas.Core.DataUtil.BaseClasses
{
    public abstract class BaseBs<TYPE_LIBRARY_TIPI, DAL_TIPI> : BaseBsWithoutEntity
        where TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
        where DAL_TIPI : BaseDal<TYPE_LIBRARY_TIPI>, new()
    {




        public DIGER_DAL_TIPI GetDalInstance<DIGER_DAL_TIPI, DIGER_TYPE_LIBRARY_TIPI>()
            where DIGER_TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
            where DIGER_DAL_TIPI : BaseDal<DIGER_TYPE_LIBRARY_TIPI>, new()
        {
            DIGER_DAL_TIPI di = new DIGER_DAL_TIPI();
            di.Connection = Connection;
            di.IsInTransaction = IsInTransaction;
            if (IsInTransaction)
            {
                di.AutomaticConnectionManagement = false;
                di.CurrentTransaction = transaction;
            }
            return di;
        }






        public BaseBs()
        {
            dal = new DAL_TIPI();
            dal.Connection = Connection;
        }




        protected DAL_TIPI dal = new DAL_TIPI();

        protected override BaseDalWithoutEntity Dal
        {
            get { return dal; }
        }

        public virtual long Insert(TYPE_LIBRARY_TIPI k)
        {
            return dal.Insert(k);
        }
        public void Update(TYPE_LIBRARY_TIPI k)
        {
            dal.Update(k);
        }
        public void Delete(TYPE_LIBRARY_TIPI k)
        {
            dal.Delete(k);
        }
        public void InsertUpdateDeleteAccordingToState(TYPE_LIBRARY_TIPI k)
        {
            dal.InsertUpdateDeleteAccordingToState(k);
        }
        public List<TYPE_LIBRARY_TIPI> QueryAll()
        {
            return dal.QueryAll();
        }

        public List<TYPE_LIBRARY_TIPI> QueryAll(int maxRowCount)
        {
            return dal.QueryAll(maxRowCount);
        }



        public List<TYPE_LIBRARY_TIPI> QueryAllOrderBy(params string[] pSiraListesi)
        {
            return dal.QueryAllOrderBy(pSiraListesi);
        }
        public void TopluEkleGuncelleVeyaSil(List<TYPE_LIBRARY_TIPI> liste)
        {
            dal.BatchInsertUpdateDelete(liste);
        }
        public int TableRowCount
        {
            get
            {
                return dal.TableRowCount;
            }
        }

        public List<T1> QueryDetailTable<T1>(object degeri) where T1 : new()
        {
            return dal.QueryDetailTable<T1>(degeri);
        }
        public virtual List<TYPE_LIBRARY_TIPI> QueryUsingColumnName(string filtre, object oDegeri)
        {
            return dal.QueryUsingColumnName(filtre, oDegeri);
        }

        public virtual List<TYPE_LIBRARY_TIPI> QueryUsingColumnName(List<string> filtreListesi, List<object> degerListesi)
        {
            return dal.QueryUsingColumnName(filtreListesi, degerListesi);
        }
        public virtual List<TYPE_LIBRARY_TIPI> QueryUsingColumnName(string[] filtreListesi, object[] degerListesi)
        {
            return dal.QueryUsingColumnName(filtreListesi, degerListesi);
        }



    }

}

