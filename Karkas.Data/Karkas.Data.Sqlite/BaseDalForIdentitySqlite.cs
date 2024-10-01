using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karkas.Data.Base;
using System.Data;
using System.Data.Common;


using Microsoft.Data.Sqlite;
using Karkas.Data.Exceptions;


namespace Karkas.Data.Sqlite
{
	public abstract class BaseDalForIdentitySqlite<TYPE_LIBRARY_TYPE,PRIMARY_KEY, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> :
        BaseDalForIdentity<TYPE_LIBRARY_TYPE, PRIMARY_KEY, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
        where PRIMARY_KEY : struct
        where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
        where PARAMETER_BUILDER : IParameterBuilder, new()
    {

		public BaseDalForIdentitySqlite() : base(new ExceptionChangerSqlite())
		{
			
		}
		public override string DbProviderName
        {
            get 
                { 
                    return "Microsoft.Data.Sqlite"; 
                }
        }

        public override string ParameterCharacter
        {
            get
            {
                return ":";
            }
        }



        public abstract string IdentityParameterName { get;  }

        public new PRIMARY_KEY Insert(TYPE_LIBRARY_TYPE row)
        {
            PRIMARY_KEY result = default(PRIMARY_KEY);
            DbCommand cmd = Template.getDatabaseCommand(InsertString, Connection);
            InsertCommandParametersAdd(cmd, row);


            row.RowState = DataRowState.Unchanged;

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
                    new LoggingInfo(cmd).LogInfo(this.GetType());
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
                CurrentExceptionChanger.Change(ex, new LoggingInfo(cmd).ToString());
            }
            catch (Exception ex)
            {
                new LoggingInfo(cmd).LogInfo(this.GetType(), ex.ToString());
            }

            finally
            {
                if (ShouldCloseConnection())
                {
                    Connection.Close();
                }
            }

            return result;
        }




    }
}
