using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;


using Microsoft.Data.SqlClient;
using Karkas.Data.Exceptions;
using Karkas.Data.Tracing;


namespace Karkas.Data.SqlServer
{
	public abstract class BaseDalForIdentitySqlServer<TYPE_LIBRARY_TYPE,PRIMARY_KEY, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> :
        BaseDalForIdentity<TYPE_LIBRARY_TYPE, PRIMARY_KEY, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
        where PRIMARY_KEY : struct
        where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
        where PARAMETER_BUILDER : IParameterBuilder, new()
    {

		public BaseDalForIdentitySqlServer() : base(new ExceptionChangerSqlServer())
		{

		}

		public BaseDalForIdentitySqlServer(DbConnection connection) : base(new ExceptionChangerSqlServer(), connection)
		{
		}
		public override string DbProviderName
        {
            get
                {
                    return "Microsoft.Data.SqlClient";
                }
        }

        public override string ParameterCharacter
        {
            get
            {
                return "@";
            }
        }




        public new PRIMARY_KEY Insert(TYPE_LIBRARY_TYPE row)
        {
            PRIMARY_KEY result = default(PRIMARY_KEY);
            DbCommand cmd = Template.getDatabaseCommand(InsertString, Connection);
            InsertCommandParametersAdd(cmd, row);


            row.RowState = DataRowState.Unchanged;

            QueryTrace trace = QueryTrace.Start(cmd, QueryIdFor("Insert"), DbProviderName);
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
                if (IdentityExists)
                {
                    object o = cmd.ExecuteScalar();
                    result = (PRIMARY_KEY)Convert.ChangeType(o, result.GetType());
                    setIdentityColumnValue(row, result);
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (DbException ex)
            {
                trace.ChangeException(CurrentExceptionChanger, ex, new LoggingInfo(cmd).ToString());
            }
            catch (Exception ex)
            {
                // e.g. the identity value can not be converted to PRIMARY_KEY;
                // rethrow so the caller does not get a default key as if the insert worked
                trace.Fail(ex);
                throw;
            }

            finally
            {
                trace.Dispose();
                if (ShouldCloseConnection())
                {
                    Connection.Close();
                }
            }

            return result;
        }


		protected override string SelectStringWithLimit
		{
			get
			{
				return SelectString.Replace("SELECT", "SELECT TOP (@maxRowCount) ");
			}
		}

	}
}
