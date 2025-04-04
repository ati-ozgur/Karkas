using Karkas.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Karkas.Data.Oracle
{

	public abstract class BaseDalForIdentityOracle<TYPE_LIBRARY_TYPE,PRIMARY_KEY, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> :
        BaseDalForIdentity<TYPE_LIBRARY_TYPE, PRIMARY_KEY, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
        where PRIMARY_KEY : struct
        where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
        where PARAMETER_BUILDER : IParameterBuilder, new()
    {

		public BaseDalForIdentityOracle() : base(new ExceptionChangerOracle())
		{
		}

		readonly Type TYPE_PrimaryKey = typeof(PRIMARY_KEY);
		readonly Type TYPE_OracleDecimal = typeof(OracleDecimal);


		public override string DbProviderName
        {
            get { return "Oracle.DataAccess.Client"; }
        }

        public override string ParameterCharacter
        {
            get
            {
                return ":";
            }
        }



        public abstract string IdentityParameterName { get;  }

        public override PRIMARY_KEY Insert(TYPE_LIBRARY_TYPE row)
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
                    cmd.ExecuteNonQuery();
					object o = null;
					if (TYPE_PrimaryKey == TYPE_OracleDecimal)
					{
						o = (cmd as OracleCommand).Parameters[IdentityParameterName].Value;
						result = (PRIMARY_KEY) o ;
					}
					else
					{
						o = cmd.Parameters[IdentityParameterName].Value;
						result = (PRIMARY_KEY)Convert.ChangeType(o, result.GetType());
					}

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
				throw;
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
		protected override string SelectStringWithLimit
		{
			get
			{
				return SelectString + " WHERE ROWNUM <= :maxRowCount";
			}
		}


	}
}
