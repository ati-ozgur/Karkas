using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Karkas.Data.Exceptions;
using System.Reflection;
using System.Runtime.Remoting;
using System.Data.Common;

namespace Karkas.Data;

/// <summary>
/// Base class for all Data Access Layer classes.
/// This class is used for all operations like insert, update, delete, query etc.
/// </summary>
/// <typeparam name="TYPE_LIBRARY_TYPE"></typeparam>
/// <typeparam name="ADOTEMPLATE_DB_TYPE"></typeparam>
/// <typeparam name="PARAMETER_BUILDER"></typeparam>
public abstract class BaseDal<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> : BaseDalWithoutEntity<ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
        where ADOTEMPLATE_DB_TYPE: IAdoTemplate<IParameterBuilder>, new()
        where PARAMETER_BUILDER : IParameterBuilder, new()
{
	public BaseDal(ExceptionChanger pExceptionChanger) : base(pExceptionChanger)
	{
	}








    public DIGER_DAL_TIPI GetDalInstance<DIGER_DAL_TIPI, DIGER_TYPE_LIBRARY_TIPI, DIGER_PARAMETER_BUILDER>()
        where DIGER_TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
        where DIGER_DAL_TIPI : BaseDal<DIGER_TYPE_LIBRARY_TIPI,ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>, new()
        where DIGER_PARAMETER_BUILDER : IParameterBuilder, new()
    {
        DIGER_DAL_TIPI di = new DIGER_DAL_TIPI();
        di.Connection = Connection;
        di.IsInTransaction = IsInTransaction;
        if (IsInTransaction)
        {
            di.AutomaticConnectionManagement = false;
            di.CurrentTransaction = CurrentTransaction;
        }
        return di;
    }


    public virtual int TableRowCount
    {
        get
        {
            object o = getNewAdoTemplate().GetOneValue(SelectCountString);
            return Convert.ToInt32(o);
        }
    }


    public virtual void Update(TYPE_LIBRARY_TYPE row)
    {
        ExecuteNonQueryUpdate(UpdateString, row);

        row.RowState = DataRowState.Unchanged;
    }
    public virtual void Delete(TYPE_LIBRARY_TYPE row)
    {
        ExecuteNonQueryDelete(DeleteString, row);
        row.RowState = DataRowState.Unchanged;
    }


    public virtual void BatchInsertUpdateDelete(List<TYPE_LIBRARY_TYPE> liste)
    {
        if (liste == null)
        {
            return;
        }
        foreach (TYPE_LIBRARY_TYPE t in liste)
        {
            InsertUpdateDeleteAccordingToState(t);
        }
    }

    public virtual void InsertUpdateDeleteAccordingToState(TYPE_LIBRARY_TYPE t)
    {
        switch (t.RowState)
        {
            case DataRowState.Added:
                Insert(t);
                break;
            case DataRowState.Deleted:
                Delete(t);
                break;
            case DataRowState.Modified:
                Update(t);
                break;
        }
    }


	/// <summary>
	/// Runs
	/// SELECT * FROM TYPE_LIBRARY_TYPE
	/// </summary>
	/// <returns>List of TYPE_LIBRARY_TYPE </returns>
	public virtual List<TYPE_LIBRARY_TYPE> QueryAll()
    {
        List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
        ExecuteQuery(liste);
        return liste;
    }



    /// <summary>
    /// Query using Column Name.
    /// Example: Given Customer table
    /// CustomerDal and Customer are generated. &#60;br /&#62;
    /// List&#60;Customer&#62; l1 = QueryUsingColumnName(Customer.ColumnNames.Email,"example@example.com")
    /// &#60;br /&#62;This will bring Customers with a given email.
    /// </summary>
    /// <param name="pFilter">ColumnName to filter.
    /// Instead of writing the column name as string like "Email", please use
    /// TypeLibraryName.ColumnNames.PropertyName </param>
    /// <param name="pValue"> value of the filter</param>
    /// <returns></returns>
    public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(string pFilter, object pValue)
    {
        return QueryUsingColumnName(new String[] { pFilter }
                , new Object[] { pValue }
                , new WhereOperatorEnum[] { WhereOperatorEnum.Equals}
                );
    }

    public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(string pFilter, object pValue, WhereOperatorEnum pWhereOperator)
    {
        return QueryUsingColumnName(new String[] { pFilter }
            , new Object[] { pValue }
            , new WhereOperatorEnum[] {pWhereOperator}
            );
    }

    public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(List<string> pFilterList, List<object> degerListesi)
    {
        return QueryUsingColumnName(pFilterList.ToArray(), degerListesi.ToArray(), null);
    }
    public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(string[] pListFilterColumnNames, object[] pListValues)
    {
        return QueryUsingColumnName(pListFilterColumnNames, pListValues, null);
    }
    public virtual List<TYPE_LIBRARY_TYPE> QueryUsingColumnName(string[] pListFilterColumnNames, object[] pListValues, WhereOperatorEnum[] pWhereOperators)
    {
        List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
        QueryHelper sy = GetNewQueryHelper();
        IParameterBuilder builder = getParameterBuilder();
        for (int i = 0; i < pListFilterColumnNames.Length; i++)
        {

            string filtreColumnName = pListFilterColumnNames[i];
			filtreColumnName = filtreColumnName.Replace("\"", "");
            WhereOperatorEnum wOp = WhereOperatorEnum.Equals;
            if(pWhereOperators != null)
            {
                wOp = pWhereOperators[i];
            }
            string pParameterName = ParameterCharacter + filtreColumnName;
            sy.AddWhereCriteria(filtreColumnName,wOp,pParameterName);
            builder.AddParameter(pParameterName, pListValues[i]);
        }
        ExecuteQuery(liste, sy.GetCriteriaResultsWithoutWhere(), builder.GetParameterArray());
        return liste;
    }


    public virtual QueryHelper GetNewQueryHelper()
    {
            return new QueryHelper(this.ParameterCharacter);
    }


    public virtual List<TYPE_LIBRARY_TYPE> QueryAllOrderBy(params string[] pListOrderBy)
    {
        List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
        QueryHelper sy = GetNewQueryHelper();
        int listeUzunluk = pListOrderBy.Length;
        for (int i = 0; i < listeUzunluk; i++)
        {
            if (i + 1 < listeUzunluk)
            {
                sy.AddOrderBy(pListOrderBy[i], pListOrderBy[i + 1]);
                i++;
            }
            else
            {
                sy.AddOrderBy(pListOrderBy[i]);
            }
        }
        // HACK Should find better solution to this;
        ExecuteQuery(liste, " 1 = 1 " + sy.GetCriteriaResultsWithoutWhere());
        return liste;
    }





    public long Insert(TYPE_LIBRARY_TYPE row)
    {
        return InsertNormal(row);
    }


    private long InsertNormal(TYPE_LIBRARY_TYPE row)
    {
        DbCommand cmd = Template.getDatabaseCommand(InsertString, Connection);
        InsertCommandParametersAdd(cmd, row);
        int result = ExecuteNonQueryCommandInternal(cmd);

        row.RowState = DataRowState.Unchanged;
        return result;
    }
    protected void ExecuteNonQueryUpdate(string cmdText, TYPE_LIBRARY_TYPE row)
    {
        DbCommand cmd = Template.getDatabaseCommand(cmdText, Connection);
        UpdateCommandParametersAdd(cmd, row);
        int rowCount = ExecuteNonQueryCommandInternal(cmd);

        bool updateResultuBasarisiz = (rowCount == 0);

        // This code will blow in BatchInsertUpdateDelete
        // Developers should write their own custom logic for this purpose

        if (updateResultuBasarisiz)
        {
            throw new UniqueKeyConstraintException("The row is updated by another user");
        }
    }

    protected void ExecuteNonQueryDelete(string cmdText, TYPE_LIBRARY_TYPE row)
    {
        DbCommand cmd = Template.getDatabaseCommand(cmdText, Connection);
        DeleteCommandParametersAdd(cmd, row);
        ExecuteNonQueryCommandInternal(cmd);
    }
    public TYPE_LIBRARY_TYPE ExecuteQueryBringOneRow(String pFilterString)
    {
        List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
        ExecuteQuery(liste, pFilterString);
        if (liste.Count > 0)
        {
            return liste[0];
        }
        else
        {
            return null;
        }
    }
    public TYPE_LIBRARY_TYPE ExecuteQueryBringOneRow(String pFilterString, DbParameter[] parameterArray)
    {
        List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
        ExecuteQuery(liste, pFilterString, parameterArray);
        if (liste.Count > 0)
        {
            return liste[0];
        }
        else
        {
            return null;
        }
    }

    public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste)
    {
        ExecuteQuery(liste, "");
    }
    public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste, String pFilterString, DbParameter[] parameterArray)
    {
        ExecuteQuery(liste, pFilterString, parameterArray, true);
    }
    public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste, String pFilterString, DbParameter[] parameterArray, bool otomatikWhereEkle)
    {
        DbCommand cmd = Template.getDatabaseCommand(Connection);
		cmd.CommandText = getFilterString(pFilterString, otomatikWhereEkle);
        foreach (DbParameter prm in parameterArray)
        {
            cmd.Parameters.Add(prm);
        }
        ExecuteQueryInternal(liste, cmd);
    }

    public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste, String pFilterString, bool otomatikWhereEkle)
    {
        DbCommand cmd = Template.getDatabaseCommand(Connection);
		cmd.CommandText = getFilterString(pFilterString, otomatikWhereEkle);
        ExecuteQueryInternal(liste, cmd);
    }

    private string getFilterString(String pFilterString, bool otomatikWhereEkle)
    {
		string cmdCommandText;

		if (String.IsNullOrEmpty(pFilterString))
        {
            cmdCommandText = SelectString;
        }
        else
        {
            if (otomatikWhereEkle)
            {
                cmdCommandText = $"{SelectString}  WHERE  {pFilterString}";
            }
            else
            {
                cmdCommandText = $"{SelectString} {pFilterString}";
            }
        }
		return cmdCommandText;
    }

    public void ExecuteQuery(List<TYPE_LIBRARY_TYPE> liste, String pFilterString)
    {
        ExecuteQuery(liste, pFilterString, true);
    }

    protected void ExecuteQueryInternal(List<TYPE_LIBRARY_TYPE> liste, DbCommand cmd)
    {
        DbDataReader reader = null;
        try
        {

            if (ShouldOpenConnection())
            {
                Connection.Open();
            }
            if (CurrentTransaction != null)
            {
                cmd.Transaction = CurrentTransaction;
            }
            reader = cmd.ExecuteReader();

            TYPE_LIBRARY_TYPE row = default(TYPE_LIBRARY_TYPE);
            while (reader.Read())
            {
                row = new TYPE_LIBRARY_TYPE();
                ProcessRow(reader, row);
                row.RowState = DataRowState.Unchanged;
                liste.Add(row);
            }

        }
        catch (DbException ex)
        {
			CurrentExceptionChanger.Change(ex,cmd.CommandText);
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
            if (ShouldCloseConnection())
            {
                Connection.Close();
            }
        }
        return;
    }




	/// <summary>
	/// Runs
	/// SELECT * FROM TYPE_LIBRARY_TYPE
	/// but limits the result to maxRowCount according to database specific syntax
	/// </summary>
	/// <param name="maxRowCount"></param>
	/// <returns>List of TYPE_LIBRARY_TYPE </returns>
	public List<TYPE_LIBRARY_TYPE> QueryAll(int maxRowCount)
	{
		DbCommand cmd = Template.getDatabaseCommand(Connection);
		cmd.CommandText = SelectStringWithLimit;
		DbParameter prm = cmd.CreateParameter();
		prm.ParameterName = ParameterCharacter + "maxRowCount";
		prm.Value = maxRowCount;
		prm.DbType = DbType.Int32;
		cmd.Parameters.Add(prm);
		List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
		ExecuteQueryInternal(liste, cmd);
		return liste;
	}
	public List<T1> QueryDetailTable<T1>(object value) where T1 : new()
    {
        T1 t = new T1();

        string typeLibraryName = t.GetType().ToString();
        string dalName = typeLibraryName.Replace("TypeLibrary", "Dal") + "Dal";
		Type type = Type.GetType(dalName);
		if( type == null)
		{
			type = Assembly.GetEntryAssembly().GetType(dalName);
		}
		if (type == null)
		{
			string assemblyName = dalName.Remove(dalName.IndexOf("Dal") + 3);
			type = Type.GetType(dalName + "," + assemblyName);
		}
		if (type == null)
		{
			throw new Exception("Cannot find the type " + dalName);
		}


		//MethodInfo methodInfo = type.GetMethod("QueryUsingColumnName");
        dynamic oh = Activator.CreateInstance(type);

        object result = oh.QueryUsingColumnName(PrimaryKey, value);
        return (List<T1>)result;
    }
    public virtual string PrimaryKey
    {
        get
        {
            return "";
        }
    }

	#region "Abstract"
	protected abstract string SelectStringWithLimit
	{
		get;
	}
	protected abstract string SelectString
	{
		get;
	}
	protected abstract string InsertString
	{
		get;
	}
	protected abstract string UpdateString
	{
		get;
	}
	protected abstract string DeleteString
	{
		get;
	}
	protected abstract string SelectCountString
	{
		get;
	}
	protected abstract bool IdentityExists
	{
		get;
	}

	protected abstract bool IsPkGuid
	{
		get;
	}
	public abstract string ParameterCharacter { get; }

	protected abstract void ProcessRow(IDataReader dr, TYPE_LIBRARY_TYPE row);
	protected abstract void InsertCommandParametersAdd(DbCommand Cmd, TYPE_LIBRARY_TYPE row);
	protected abstract void UpdateCommandParametersAdd(DbCommand Cmd, TYPE_LIBRARY_TYPE row);
	protected abstract void DeleteCommandParametersAdd(DbCommand Cmd, TYPE_LIBRARY_TYPE row);



	#endregion





}


