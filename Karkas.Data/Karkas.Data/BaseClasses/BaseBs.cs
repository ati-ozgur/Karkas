using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Karkas.Data.Base;

public abstract class BaseBs<TYPE_LIBRARY_TYPE, DAL_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> : BaseBsWithoutEntity<ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
    where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
    where ADOTEMPLATE_DB_TYPE: IAdoTemplate<IParameterBuilder>, new()
    where DAL_TYPE : BaseDal<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>, new()
    where PARAMETER_BUILDER : IParameterBuilder, new()
{




    public DIGER_DAL_TIPI GetDalInstance<DIGER_DAL_TIPI, DIGER_TYPE_LIBRARY_TIPI>()
        where DIGER_TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
        where DIGER_DAL_TIPI : BaseDal<DIGER_TYPE_LIBRARY_TIPI, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>, new()
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
        dal = new DAL_TYPE();
        dal.Connection = Connection;
    }




    protected DAL_TYPE dal = new DAL_TYPE();

    protected override BaseDalWithoutEntity<ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> Dal
    {
        get { return dal; }
    }

    public virtual long Insert(TYPE_LIBRARY_TYPE k)
    {
        return dal.Insert(k);
    }
    public void Update(TYPE_LIBRARY_TYPE k)
    {
        dal.Update(k);
    }
    public void Delete(TYPE_LIBRARY_TYPE k)
    {
        dal.Delete(k);
    }
    public void InsertUpdateDeleteAccordingToState(TYPE_LIBRARY_TYPE k)
    {
        dal.InsertUpdateDeleteAccordingToState(k);
    }
    public List<TYPE_LIBRARY_TYPE> QueryAll()
    {
        return dal.QueryAll();
    }

    public List<TYPE_LIBRARY_TYPE> QueryAll(int maxRowCount)
    {
        return dal.QueryAll(maxRowCount);
    }



    public List<TYPE_LIBRARY_TYPE> QueryAllOrderBy(params string[] pSiraListesi)
    {
        return dal.QueryAllOrderBy(pSiraListesi);
    }
    public void BatchInsertUpdateDelete(List<TYPE_LIBRARY_TYPE> liste)
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
    public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(string filter, object value)
    {
        return dal.QueryUsingColumnName(filter, value);
    }

    public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(List<string> filterList, List<object> valueList)
    {
        return dal.QueryUsingColumnName(filterList, valueList);
    }
    public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(string[] filterList, object[] valueList)
    {
        return dal.QueryUsingColumnName(filterList, valueList);
    }



}



