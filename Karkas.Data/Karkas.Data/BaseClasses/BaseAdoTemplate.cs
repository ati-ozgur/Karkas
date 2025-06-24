using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Data.Common;
using Karkas.Data.Exceptions;

namespace Karkas.Data;

public abstract class BaseAdoTemplate<PARAMETER_BUILDER> : IAdoTemplate<IParameterBuilder>
    where PARAMETER_BUILDER : IParameterBuilder, new()
{
    private string dbProviderName;
    private string connectionString;
    private bool useConnectionSingleton = true;



    public BaseAdoTemplate(string dbProviderName)
    {
        this.dbProviderName = dbProviderName;
    }
    public BaseAdoTemplate(string connectionString, string dbProviderName)
    {
        this.connectionString = connectionString;
        this.dbProviderName = dbProviderName;
        this.useConnectionSingleton = false;
    }




    public virtual DbDataAdapter getDatabaseAdapter(DbCommand cmd)
    {
        DbDataAdapter adapter = DbProviderFactoryHelper.Create(dbProviderName).Factory.CreateDataAdapter();
        adapter.SelectCommand = cmd;
        return adapter;
    }




    public DbCommand getDatabaseCommand(string sql, DbConnection conn)
    {
        DbCommand command = getDatabaseCommand(conn);
        command.CommandText = sql;
        return command;
    }


    public virtual DbCommand getDatabaseCommand(DbConnection conn)
    {
        DbCommand command = conn.CreateCommand();
        return command;
    }



    public String DbProviderName
    {
        get
        {
            return dbProviderName;
        }
        set
        {
            dbProviderName = value;
        }
    }

    private bool automaticConnectionManagement = true;
    /// <summary>
    /// If Default true value is preserved, connections are managed by BaseDal.
    /// Before queries, connections are automatically, opened and closed by BaseDal.
    /// Otherwise, if  AutomaticConnectionManagement is false, User have to open and close connections.
    /// </summary>
    public bool AutomaticConnectionManagement
    {
        get
        {
            return automaticConnectionManagement;
        }
        set
        {
            automaticConnectionManagement = value;
            this.helper.AutomaticConnectionManagement = value;
        }
    }

    private bool ShouldCloseConnection()
    {
        return Connection.State != ConnectionState.Closed && AutomaticConnectionManagement;
    }

    private bool ShouldOpenConnection()
    {
        return (Connection.State != ConnectionState.Open) && (AutomaticConnectionManagement);
    }

    private DbTransaction currentTransaction;

    public DbTransaction CurrentTransaction
    {
        get
        {
            return currentTransaction;
        }
        set
        {
            currentTransaction = value;
            _helper = null;
            _pagingHelper = null;

        }
    }


    private DbConnection connection = null;
    public DbConnection Connection
    {
        get
        {
            if (this.useConnectionSingleton && connection == null)
            {
                connection = ConnectionSingleton.Instance.getConnection("Main");
            }
            else if (connectionString != null && dbProviderName != null)
            {
                connection = DbProviderFactoryHelper.Create(dbProviderName).Factory.CreateConnection();
                connection.ConnectionString = connectionString;
            }
            return connection;
        }
        set { connection = value; }
    }


    public string ConnectionString
    {
        get
        {
            return connectionString;
        }
        set
        {
            this.connectionString = value;
            this.useConnectionSingleton = false;
        }
    }



    private HelperFunctions _helper;
    private HelperFunctions helper
    {
        get
        {
            if (_helper == null)
            {
                _helper = new HelperFunctions(this);
                _helper.AutomaticConnectionManagement = AutomaticConnectionManagement;
            }
            return _helper;
        }
    }

    private PagingHelper _pagingHelper;

    private PagingHelper pagingHelper
    {
        get
        {
            if (_pagingHelper == null)
            {
                _pagingHelper = new PagingHelper(this);
            }
            return _pagingHelper;
        }
    }

    private object ExecuteNonQueryCommandBringResultInternal(DbCommand cmd)
    {
        object result = 0;
        try
        {
            new LoggingInfo(cmd).LogInfo(this.GetType());
            if (ShouldOpenConnection())
            {
                Connection.Open();
            }
            else if (currentTransaction != null)
            {
                cmd.Transaction = currentTransaction;
            }
            result = cmd.ExecuteScalar();
        }
        catch (DbException ex)
        {
            CurrentExceptionChanger.Change(ex, new LoggingInfo(cmd).ToString());
        }
        finally
        {
            if (AutomaticConnectionManagement)
            {
                Connection.Close();
            }
        }
        return result;
    }
	private int ExecuteNonQueryCommandInternal(DbCommand cmd)
	{
		int rowCount = 0;
		try
		{
			new LoggingInfo(cmd).LogInfo(this.GetType());
			if (ShouldOpenConnection())
			{
				Connection.Open();
			}
			else if (currentTransaction != null)
			{
				cmd.Transaction = currentTransaction;
			}

			rowCount = cmd.ExecuteNonQuery();
		}
		catch (DbException ex)
		{
			CurrentExceptionChanger.Change(ex, new LoggingInfo(cmd).ToString());
		}
		finally
		{
			if (AutomaticConnectionManagement)
			{
				Connection.Close();
			}
		}
		return rowCount;
    }



    [Obsolete("BringOneValue is deprecated, please use GetOneValue instead.")]
    public object BringOneValue(DbCommand cmd)
    {
        return GetOneValue(cmd);
    }

    /// <summary>
    /// Wrapper for ADO.NET ExecuteScalar
    /// If you expect only one result from your query, you could use this command.
    /// example SELECT COUNT(*) FROM COMMON.USERS
    /// return type of ExecuteScalar is object therefore you need to cast it,
    /// for example (int) for above query.
    /// </summary>
    /// <example>
    ///
    ///
    /// </example>
    /// <param name="cmd"></param>
    /// <returns></returns>
    ///
    public object GetOneValue(DbCommand cmd)
    {
        cmd.Connection = Connection;
        object result = 0;
        result = ExecuteNonQueryCommandBringResultInternal(cmd);
        return result;
    }

	public T GetOneValue<T>(DbCommand cmd) where T : struct
	{
		cmd.Connection = Connection;
		object objResult = ExecuteNonQueryCommandBringResultInternal(cmd);
		var oChanged = Convert.ChangeType(objResult, typeof(T));
		return (T)oChanged;
	}


	[Obsolete("BringOneValue is deprecated, please use GetOneValue instead.")]
    public Object BringOneValue(string cmdText)
    {
        return GetOneValue(cmdText);
    }
    public Object GetOneValue(string cmdText)
    {
        DbCommand cmd = getDatabaseCommand(cmdText, Connection);
        object result;
        result = ExecuteNonQueryCommandBringResultInternal(cmd);
        return result;
    }

	public T GetOneValue<T>(string cmdText) where T : struct
	{
		DbCommand cmd = getDatabaseCommand(cmdText, Connection);
		object objResult = ExecuteNonQueryCommandBringResultInternal(cmd);
		var oChanged = Convert.ChangeType(objResult, typeof(T));
		return (T)oChanged;
	}


	[Obsolete("BringOneValue is deprecated, please use GetOneValue instead.")]
    public Object BringOneValue(string cmdText, CommandType cmdType, DbParameter[] parameters)
    {
        return GetOneValue(cmdText,cmdType,parameters);
    }
    public Object GetOneValue(string cmdText, CommandType cmdType, DbParameter[] parameters)
    {
        DbCommand cmd = getDatabaseCommand(cmdText, Connection);
        cmd.CommandType = cmdType;
        foreach (DbParameter p in parameters)
        {
            cmd.Parameters.Add(p);
        }

        object result = ExecuteNonQueryCommandBringResultInternal(cmd);
        return result;
    }


    [Obsolete("BringOneValue is deprecated, please use GetOneValue instead.")]
    public Object BringOneValue(string cmdText, DbParameter[] parameters)
    {
        return GetOneValue(cmdText, parameters);
    }

    public Object GetOneValue(string cmdText, DbParameter[] parameters)
    {
        DbCommand cmd = getDatabaseCommand(cmdText, Connection);
        foreach (DbParameter p in parameters)
        {
            cmd.Parameters.Add(p);
        }

        object result = ExecuteNonQueryCommandBringResultInternal(cmd);
        return result;
    }

	public T GetOneValue<T>(string cmdText, DbParameter[] parameters) where T : struct
	{
		DbCommand cmd = getDatabaseCommand(cmdText, Connection);
		foreach (DbParameter p in parameters)
		{
			cmd.Parameters.Add(p);
		}

		object objResult = ExecuteNonQueryCommandBringResultInternal(cmd);
		if(typeof(T) == typeof(Guid)) // TODO: check this one for SQL Server
		{
			Guid g;
			if (objResult == null)
			{
				g = Guid.Empty;
			}
			else
			{
				g = new Guid(objResult.ToString());
			}
			return (T) ((object)g);
		}
		var oChanged = Convert.ChangeType(objResult, typeof(T));
		return (T)oChanged;
	}

	public int ExecuteNonQueryCommand(String cmdText)
	{
		DbCommand cmd = getDatabaseCommand(cmdText, Connection);
		int rowCount = ExecuteNonQueryCommandInternal(cmd);
		return rowCount;
	}



	public int ExecuteNonQueryCommand(DbCommand cmd)
	{
		cmd.Connection = Connection;
		int rowCount = ExecuteNonQueryCommandInternal(cmd);
		return rowCount;
    }



	public int ExecuteNonQueryCommand(string sql, DbParameter[] prmListesi)
	{
		DbCommand cmd = getDatabaseCommand(sql, Connection);
		cmd.CommandType = CommandType.Text;
		foreach (DbParameter p in prmListesi)
		{
			cmd.Parameters.Add(p);
		}

		int rowCount = ExecuteNonQueryCommandInternal(cmd);
		return rowCount;

    }

	/// <summary>
	/// Execute given sql statement inside IF EXISTS
	/// If we have value, it return true otherwise false
	/// </summary>
	/// <param name="sql"></param>
	/// <param name="pParamList"></param>
	/// <returns></returns>
	///
	public abstract bool ExecuteAsExists(String sql, DbParameter[] pParamList);

    public abstract bool ExecuteAsExists(string pSql);


    //public PARAMETER_BUILDER getParameterBuilder()
    //{
    //    return new PARAMETER_BUILDER();
    //}

    public IParameterBuilder getParameterBuilder()
    {
        return new PARAMETER_BUILDER();
    }



    #region "List of Dictionaries Creation"


    protected virtual string getSqlForTopRows(string pSql, int count)
    {
        string sqlToExecute = string.Format(@"SELECT * FROM
                                    (
                                    {0}
                                    )
                                    FETCH FIRST {1} ROWS ONLY", pSql,count);
        return sqlToExecute;
    }


    public virtual List<Dictionary<string, object>> GetTopRows(string sql, int count)
    {
        string sqlToExecute = getSqlForTopRows(sql,count);
        return GetRows(sqlToExecute);
    }
    public virtual List<Dictionary<string, object>> GetTopRows(string sql, DbParameter[] parameters, int count)
    {
        string sqlToExecute = getSqlForTopRows(sql, count);
        return GetRows(sqlToExecute,parameters);
    }


    public Dictionary<string, object> GetOneRow(string sql)
    {
        Dictionary<string, object> d = null;
        List<Dictionary<string, object>> l1 = GetTopRows(sql,1);
        if(l1.Count == 1)
        {
            d = l1[0];
        }
        return d;
    }
    public Dictionary<string, object> GetOneRow(string sql, DbParameter[] parameters)
    {
        Dictionary<string, object> d = null;
        List<Dictionary<string, object>> l1 = GetTopRows(sql,parameters, 1);
        if (l1.Count == 1)
        {
            d = l1[0];
        }
        return d;
    }


    [Obsolete("GetListOfDictionary is deprecated, please use GetRows instead.")]
    public List<Dictionary<String, Object>> GetListOfDictionary(DbCommand cmd)
    {
        return GetRows(cmd);
    }

    public List<Dictionary<String, Object>> GetRows(DbCommand cmd)
    {
        List<Dictionary<string, Object>> liste = new List<Dictionary<string, object>>();
        DbDataReader reader = null;
        try
        {

            if (ShouldOpenConnection())
            {
                cmd.Connection.Open();
            }
            if (CurrentTransaction != null)
            {
                cmd.Transaction = CurrentTransaction;
            }
            reader = cmd.ExecuteReader();

            Dictionary<string, Object> row;
            while (reader.Read())
            {
                row = new Dictionary<string, object>();
                ProcessRow(reader, row);
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

        return liste;
    }

    private void ProcessRow(DbDataReader reader, Dictionary<string, object> row)
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            string columnName = reader.GetName(i);
            row.Add(columnName, reader.GetValue(i));
        }
    }
    [Obsolete("GetListOfDictionary is deprecated, please use GetRows instead.")]
    public List<Dictionary<String, Object>> GetListOfDictionary(string sql)
    {
        return GetRows(sql);
    }
    public List<Dictionary<String, Object>> GetRows(string sql)
    {
        DbCommand cmd = getDatabaseCommand(sql, Connection);
        return GetRows(cmd);
    }

    [Obsolete("GetListOfDictionary is deprecated, please use GetRows instead.")]
    public List<Dictionary<String, Object>> GetListOfDictionary(string sql, CommandType commandType)
    {
        return GetRows(sql,commandType);
    }

    public List<Dictionary<String, Object>> GetRows(string sql, CommandType commandType)
    {
        DbCommand cmd = getDatabaseCommand(sql, Connection);
        cmd.CommandType = commandType;
        return GetRows(cmd);
    }

    [Obsolete("GetListOfDictionary is deprecated, please use GetRows instead.")]
    public List<Dictionary<String, Object>> GetListOfDictionary(string sql, CommandType commandType, DbParameter[] parameters)
    {
        return GetRows(sql,commandType,parameters);
    }
    public List<Dictionary<String, Object>> GetRows(string sql, CommandType commandType, DbParameter[] parameters)
    {
        DbCommand cmd = getDatabaseCommand(sql, Connection);
        cmd.CommandType = commandType;
        foreach (var param in parameters)
        {
            cmd.Parameters.Add(param);
        }
        return GetRows(cmd);
    }

    [Obsolete("GetListOfDictionary is deprecated, please use GetRows instead.")]
    public List<Dictionary<String, Object>> GetListOfDictionary(string sql, DbParameter[] parameters, int? timeOut = null)
    {
        return GetRows(sql,parameters,timeOut);
    }

	/// <summary>
	/// GetRows method is used to get rows from database and return them as a list of dictionaries.
	/// Each dictionary represents a row, and the keys are the column names in sql statement.
	/// It is especially useful for dynamic queries.
	/// It is also useful for json rest services since ASP.NET automatically converts dictionaries to json.
	/// </summary>
	/// <param name="sql"> your sql statement</param>
	/// <param name="parameters"> parameters used in the sql @ or : according to database syntax</param>
	/// <param name="timeOut">optional timeout value for long running queries. This parameter should be used for only some queries. Default timeout set in connection string normally.</param>
	/// <returns></returns>
	public List<Dictionary<String, Object>> GetRows(string sql, DbParameter[] parameters, int? timeOut = null)
	{
		DbCommand cmd = getDatabaseCommand(sql, Connection);
		if(timeOut.HasValue)
		{
			cmd.CommandTimeout = timeOut.Value;
		}
		foreach (var param in parameters)
		{
			cmd.Parameters.Add(param);
		}
		return GetRows(cmd);
	}





    #endregion



    #region "CreateDataTable Methods"
    public DataTable CreateDataTable(DbCommand cmd)
    {
        DataTable dataTable = CreateDataTable();
        cmd.Connection = Connection;
        if (currentTransaction != null)
        {
            cmd.Transaction = currentTransaction;
        }
        helper.ExecuteQuery(dataTable, cmd);
        return dataTable;
    }



    public DataTable CreateDataTable(string sql, CommandType commandType)
    {
        DataTable dataTable = CreateDataTable();
        FillDataTable(dataTable, sql, commandType);
        return dataTable;
    }
    public DataTable CreateDataTable(string sql)
    {
        DataTable dataTable = CreateDataTable();
        FillDataTable(dataTable, sql, CommandType.Text);
        return dataTable;
    }

    public DataTable CreateDataTable(string sql, CommandType commandType, DbParameter[] parameters)
    {
        DataTable dataTable = CreateDataTable();
        FillDataTable(dataTable, sql, commandType, parameters);
        return dataTable;
    }
    public DataTable CreateDataTable(string sql, DbParameter[] parameters)
    {
        DataTable dataTable = CreateDataTable();
        FillDataTable(dataTable, sql, CommandType.Text, parameters);
        return dataTable;
    }





    #endregion

    #region "DataTable Fill Methods"
    public void FillDataTable(DataTable dataTable, string sql, CommandType commandType)
    {
        helper.ValidateFillArguments(dataTable, sql);
        helper.ExecuteQuery(dataTable, sql, commandType);
    }
    public void FillDataTable(DataTable dataTable, string sql)
    {
        helper.ValidateFillArguments(dataTable, sql);
        helper.ExecuteQuery(dataTable, sql, CommandType.Text);
    }
    public void FillDataTable(DataTable dataTable, string sql, CommandType commandType
            , DbParameter[] parameters)
    {
        helper.ValidateFillArguments(dataTable, sql);
        helper.ExecuteQuery(dataTable, sql, commandType, parameters);
    }
    public void FillDataTable(DataTable dataTable, string sql
            , DbParameter[] parameters)
    {
        helper.ValidateFillArguments(dataTable, sql);
        helper.ExecuteQuery(dataTable, sql, CommandType.Text, parameters);
    }

    #endregion

    #region "CreateDataTableWithPaging"

    public DataTable CreateDataTableWithPaging(string sql, int pPageSize, int pStartRowIndex, string pOrderBy, DbParameter[] parameters)
    {
        return pagingHelper.DataTableOlusturSayfalamaYap(sql, pPageSize, pStartRowIndex, pOrderBy, parameters);
    }


    public DataTable CreateDataTableWithPaging(string sql, int pPageSize, int pStartRowIndex, string pOrderBy)
    {
        return pagingHelper.CreateDataTableWithPaging(sql, pPageSize, pStartRowIndex, pOrderBy);
    }




    #endregion

    #region "FillDataTableWithPaging"

    public void FillDataTableWithPaging(DataTable dataTable, string sql
    , int pPageSize, int pStartRowIndex, string pOrderBy, DbParameter[] parameters)
    {
        pagingHelper.DataTableDoldurSayfalamaYap(dataTable, sql, pPageSize, pStartRowIndex, pOrderBy, parameters);
    }


    public void FillDataTableWithPaging(DataTable dataTable, string sql
            , int pPageSize, int pStartRowIndex, string pOrderBy)
    {
        pagingHelper.DataTableDoldurSayfalamaYap(dataTable, sql, pPageSize, pStartRowIndex, pOrderBy);
    }



    #endregion


    #region "Helpers"


    protected virtual DataTable CreateDataTable()
    {
        DataTable dataTable = new DataTable();
        dataTable.Locale = CultureInfo.InvariantCulture;
        return dataTable;
    }

    protected virtual DataSet CreateDataSet()
    {
        DataSet dataSet = new DataSet();
        dataSet.Locale = CultureInfo.InvariantCulture;
        return dataSet;
    }





    #endregion

    public virtual string ParameterSymbol
    {
        get { return "@"; }
    }


	protected abstract ExceptionChanger CurrentExceptionChanger
	{
		get;
	}


}


