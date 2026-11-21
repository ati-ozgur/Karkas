using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Karkas.Data.Exceptions;
using Karkas.Data.Tracing;

namespace Karkas.Data;

public abstract class BaseDalWithoutEntity<ADOTEMPLATE_DB_TYPE,PARAMETER_BUILDER>
    where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
    where PARAMETER_BUILDER : IParameterBuilder, new()
{

    /// <summary>
    /// Creates a DAL without a connection. The parameterless path is required by the
    /// new() generic constraints used throughout Karkas (e.g. BaseBs, GetDalInstance),
    /// which assign <see cref="Connection"/> right after construction.
    /// If you create a DAL yourself, prefer the constructor that takes a DbConnection.
    /// </summary>
    public BaseDalWithoutEntity(ExceptionChanger pExceptionChanger)
    {
		_currentExceptionChanger = pExceptionChanger;
    }

    public BaseDalWithoutEntity(ExceptionChanger pExceptionChanger, DbConnection connection)
		: this(pExceptionChanger)
    {
		this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }


    private bool automaticConnectionManagement = true;
    /// <summary>
    /// Eger varsayılan deger, true bırakılırsa, connection yonetimi
    /// BaseDal tarafından yapılır. Komutlar cagrılmadan once, connection getirme
    /// Connection'u acma ve kapama BaseDal kontrolundedir.
    /// Eger false ise connection olusturma, acma Kapama Kullanıcıya aittir.
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
            this.Template.AutomaticConnectionManagement = value;
        }
    }



    private ADOTEMPLATE_DB_TYPE template;
    public virtual ADOTEMPLATE_DB_TYPE Template
    {
        get
        {
            template = getNewAdoTemplate();
            return template;
        }
    }

    protected ADOTEMPLATE_DB_TYPE getNewAdoTemplate()
    {
        ADOTEMPLATE_DB_TYPE t = new ADOTEMPLATE_DB_TYPE();
        t.Connection = Connection;
        t.CurrentTransaction = currentTransaction;
        t.AutomaticConnectionManagement = automaticConnectionManagement;
        t.DbProviderName = DbProviderName;
        return t;
    }

    /// <summary>
    /// This is the class name for database provider.
    /// It is normally overridden in the corresponding Karkas.Data.X as most used provider,
    /// such as System.Data.SqlClient,Oracle.DataAccess.Client or Microsoft.Data.Sqlite.
    /// But you can use custom data providers in the code generation.
    /// </summary>
    public abstract string DbProviderName
    {
        get;
    }

    private DbConnection connection = null;

    public DbConnection Connection
    {
        get
        {
            if (connection == null)
            {
                throw new InvalidOperationException(string.Format(
                    "{0} has no DbConnection. Pass one to the constructor or set the Connection property.",
                    GetType().Name));
            }
            return connection;
        }
        set { connection = value; }
    }


    private DbTransaction currentTransaction;

    public DbTransaction CurrentTransaction
    {
        get { return currentTransaction; }
        set { currentTransaction = value; }
    }

    /// <summary>
    /// Runs the command with ExecuteNonQuery.
    /// </summary>
    /// <param name="cmd">command to run</param>
    /// <param name="queryId">name used in tracing as DalName.queryId; defaults to the calling method name</param>
    protected int ExecuteNonQueryCommandInternal(DbCommand cmd, [CallerMemberName] string queryId = null)
    {
        int resultRowCount = 0;
        using (QueryTrace trace = QueryTrace.Start(cmd, QueryIdFor(queryId), DbProviderName))
        {
            try
            {
                if (ShouldOpenConnection())
                {
                    Connection.Open();
                }
                else if (currentTransaction != null)
                {
                    cmd.Transaction = currentTransaction;
                }

                resultRowCount = cmd.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Rollback();
                }
                trace.ChangeException(CurrentExceptionChanger, ex, new LoggingInfo(cmd).ToString());
            }
            finally
            {
                if (ShouldCloseConnection())
                {
                    Connection.Close();
                }
            }
        }
        return resultRowCount;
    }

    /// <summary>
    /// Query id used for tracing: DalClassName.operation, for example CustomerDal.QueryByCustomerId.
    /// </summary>
    protected string QueryIdFor(string operation)
    {
        return string.IsNullOrEmpty(operation) ? GetType().Name : GetType().Name + "." + operation;
    }

    protected bool ShouldCloseConnection()
    {
        return Connection.State != ConnectionState.Closed && AutomaticConnectionManagement;
    }

    protected bool ShouldOpenConnection()
    {
        return (Connection.State != ConnectionState.Open) && (AutomaticConnectionManagement);
    }



    public IParameterBuilder getParameterBuilder()
    {
        return new PARAMETER_BUILDER();
    }


    private bool isInTransaction = false;

    public bool IsInTransaction
    {
        get { return isInTransaction; }
        set { isInTransaction = value; }
    }

    public virtual string ParameterSymbol
    {
        get { return "@"; }
    }

	private ExceptionChanger _currentExceptionChanger;

	protected virtual ExceptionChanger CurrentExceptionChanger
	{
		get
		{
			return _currentExceptionChanger;
		}
		set
		{
			_currentExceptionChanger = value;
		}
	}

}

