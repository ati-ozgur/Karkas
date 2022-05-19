using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Karkas.Core.TypeLibrary;
using System.Data.Common;

namespace Karkas.Core.DataUtil.BaseClasses
{
    /// <summary>
    /// TYPE_LIBRARY_TYPE TypeLibrary Class
    /// PRIMARY_KEY Type of Primary Key of TYPE_LIBRARY_TYPE
    /// </summary>
    /// <typeparam name="TYPE_LIBRARY_TYPE"></typeparam>
    /// <typeparam name="PRIMARY_KEY"></typeparam>
    public abstract class BaseDalForIdentity<TYPE_LIBRARY_TYPE, PRIMARY_KEY, ADOTEMPLATE_DB_TYPE> 
            : BaseDal<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE> 
            where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
            where ADOTEMPLATE_DB_TYPE : AdoTemplate, new()
    {

        public BaseDalForIdentity()
        {

        }

        protected abstract void setIdentityColumnValue(TYPE_LIBRARY_TYPE pTypeLibrary, PRIMARY_KEY pIdentityKolonValue);

        public new PRIMARY_KEY Insert(TYPE_LIBRARY_TYPE row)
        {
            PRIMARY_KEY result = default(PRIMARY_KEY);
            DbCommand cmd = Template.getDatabaseCommand(InsertString, Connection);
            InsertCommandParametersAdd(cmd, row);


            //rowstate'i unchanged yapiyoruz
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
                ExceptionChanger.Change(ex, new LoggingInfo(cmd).ToString());
            }
            catch (Exception ex)
            {
                new LoggingInfo(cmd).LogInfo(this.GetType(),ex);
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

