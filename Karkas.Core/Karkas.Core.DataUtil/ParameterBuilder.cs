using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class ParameterBuilder
    {

        private DbCommand command;
        List<DbParameter> parameterList;
        private string dbProviderName;
        private DbProviderFactoryHelper dbProviderFactoryHelper;

        public DbCommand Command
        {
            get { return command; }
            set { command = value; }
        }

        public ParameterBuilder(string providerName)
        {
            this.dbProviderName = providerName;
            parameterList = new List<DbParameter>();
            setDbProviderFactoryHelper();
        }


        private void setDbProviderFactoryHelper()
        {
            
            if (string.IsNullOrEmpty(dbProviderName))
            {
                dbProviderFactoryHelper =  DbProviderFactoryHelper.Create(DbProviderFactoryHelper.DbProviderSqlServer);
            }
            else
            {
                dbProviderFactoryHelper =  DbProviderFactoryHelper.Create(dbProviderName);
            }
        }



        private DbParameter setParameterValue(string parameterName, DbType dbType)
        {
            DbParameter prm = getGenericDbParamater();
            prm.ParameterName = parameterName;
            prm.DbType = dbType;
            return prm;
        }

        private DbParameter getGenericDbParamater()
        {
            DbParameter prm  = dbProviderFactoryHelper.Factory.CreateParameter();

            
            return prm;
        }

        //private DbParameter parameterDegerleriniSetle(string parameterName, SqlDbType dbType, object value)
        //{
        //    SqlParameter prm = getSqlParameter();
        //    prm.ParameterName = parameterName;
        //    prm.SqlDbType = dbType;
        //    if (value == null)
        //    {
        //        prm.Value = DBNull.Value;
        //    }
        //    else
        //    {
        //        prm.Value = value;
        //    }
        //    return prm;
        //}

        //private SqlParameter getSqlParameter()
        //{
        //    SqlParameter prm = new SqlParameter();
        //    return prm;
        //}

        private DbParameter setParameterValue(string parameterName, DbType dbType, object value)
        {
            DbParameter prm = getGenericDbParamater();
            prm.ParameterName = parameterName;
            prm.DbType = dbType;
            if (value == null)
            {
                prm.Value = DBNull.Value;
            }
            else
            {
                prm.Value = value;
            }
            return prm;
        }

        internal void addParameter(string parameterName, object value)
        {
            DbParameter prm = null;
            if (value is Int32)
            {
                prm = setParameterValue(parameterName, DbType.Int32, value);
            }
            else if (value is string)
            {
                prm = setParameterValue(parameterName, DbType.AnsiString, value);
            }
            else if (value is Int16)
            {
                prm = setParameterValue(parameterName, DbType.Int16, value);
            }
            else if (value is Int64)
            {
                prm = setParameterValue(parameterName, DbType.Int64, value);
            }
            else if (value is Int64)
            {
                prm = setParameterValue(parameterName, DbType.Int64, value);
            }
            else
            {
                prm = setParameterValue(parameterName, DbType.Object, value);
            }
            addParameterToCommandOrList(prm);
        }


        public void addParameter(string parameterName, DbType dbType, object value)
        {
            DbParameter prm = setParameterValue(parameterName, dbType, value);
            addParameterToCommandOrList(prm);
        }
        //public void parameterEkle(string parameterName, SqlDbType dbType, object value)
        //{
        //    DbParameter prm = parameterDegerleriniSetle(parameterName, dbType, value);
        //    parameteriyiCommandYadaListeyeEkle(prm);
        //}


        public void addParameter(string parameterName, DbType dbType, object value, int size)
        {
            DbParameter prm = setParameterValue(parameterName, dbType, value);
            prm.Size = size;
            addParameterToCommandOrList(prm);
        }

        //public void parameterEkle(string parameterName, SqlDbType dbType, object value, int size)
        //{
        //    DbParameter prm = parameterDegerleriniSetle(parameterName, dbType, value);
        //    prm.Size = size;
        //    parameteriyiCommandYadaListeyeEkle(prm);
        //}

        public void addParameterReturn(string parameterName, DbType dbType)
        {
            DbParameter prm = setParameterValue(parameterName, dbType);
            prm.Direction = ParameterDirection.ReturnValue;
            addParameterToCommandOrList(prm);
        }
        public void addParameterOutput(string parameterName, DbType dbType)
        {
            DbParameter prm = setParameterValue(parameterName, dbType);
            prm.Direction = ParameterDirection.Output;
            addParameterToCommandOrList(prm);
        }
        public void addParameterOutput(string parameterName, DbType dbType, int size)
        {
            DbParameter prm = setParameterValue(parameterName, dbType);
            prm.Direction = ParameterDirection.Output;
            prm.Size = size;
            addParameterToCommandOrList(prm);
        }
        public void addParameterInputOutput(string parameterName, DbType dbType)
        {
            DbParameter prm = setParameterValue(parameterName, dbType);
            prm.Direction = ParameterDirection.InputOutput;
            addParameterToCommandOrList(prm);
        }

        private void addParameterToCommandOrList(DbParameter prm)
        {
            if (command != null)
            {
                command.Parameters.Add(prm);
            }
            else
            {
                parameterList.Add(prm);
            }
        }

        public DbParameter[] GetParameterArray()
        {
            return parameterList.ToArray();
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (DbParameter param in parameterList)
            {
                sb.Append(string.Format("DECLARE {0} {1} = {2}"
                    , param.ParameterName
                    ,param.DbType
                    , param.Value));
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }



    }
}

