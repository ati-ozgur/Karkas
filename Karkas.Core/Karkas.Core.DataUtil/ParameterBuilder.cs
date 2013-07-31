using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

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



        private DbParameter parameterDegerleriniSetle(string parameterName, DbType dbType)
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

        private DbParameter parameterDegerleriniSetle(string parameterName, SqlDbType dbType, object value)
        {
            SqlParameter prm = getSqlParameter();
            prm.ParameterName = parameterName;
            prm.SqlDbType = dbType;
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

        private SqlParameter getSqlParameter()
        {
            SqlParameter prm = new SqlParameter();
            return prm;
        }

        private DbParameter parameterDegerleriniSetle(string parameterName, DbType dbType, object value)
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

        internal void parameterEkle(string parameterName, object value)
        {
            DbParameter prm = null;
            if (value is Int32)
            {
                prm = parameterDegerleriniSetle(parameterName, DbType.Int32, value);
            }
            else if (value is string)
            {
                prm = parameterDegerleriniSetle(parameterName, DbType.AnsiString, value);
            }
            else if (value is Int16)
            {
                prm = parameterDegerleriniSetle(parameterName, DbType.Int16, value);
            }
            else if (value is Int64)
            {
                prm = parameterDegerleriniSetle(parameterName, DbType.Int64, value);
            }
            else if (value is Int64)
            {
                prm = parameterDegerleriniSetle(parameterName, DbType.Int64, value);
            }
            else
            {
                prm = parameterDegerleriniSetle(parameterName, DbType.Object, value);
            }
            parameteriyiCommandYadaListeyeEkle(prm);
        }


        public void parameterEkle(string parameterName, DbType dbType, object value)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName, dbType, value);
            parameteriyiCommandYadaListeyeEkle(prm);
        }
        public void parameterEkle(string parameterName, SqlDbType dbType, object value)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName, dbType, value);
            parameteriyiCommandYadaListeyeEkle(prm);
        }


        public void parameterEkle(string parameterName, DbType dbType, object value, int size)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName, dbType, value);
            prm.Size = size;
            parameteriyiCommandYadaListeyeEkle(prm);
        }

        public void parameterEkle(string parameterName, SqlDbType dbType, object value, int size)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName, dbType, value);
            prm.Size = size;
            parameteriyiCommandYadaListeyeEkle(prm);
        }

        public void parameterEkleReturnValue(string parameterName, DbType dbType)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName, dbType);
            prm.Direction = ParameterDirection.ReturnValue;
            parameteriyiCommandYadaListeyeEkle(prm);
        }
        public void parameterEkleOutput(string parameterName, DbType dbType)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName, dbType);
            prm.Direction = ParameterDirection.Output;
            parameteriyiCommandYadaListeyeEkle(prm);
        }
        public void parameterEkleOutput(string parameterName, DbType dbType, int size)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName, dbType);
            prm.Direction = ParameterDirection.Output;
            prm.Size = size;
            parameteriyiCommandYadaListeyeEkle(prm);
        }
        public void parameterEkleInputOutput(string parameterName, DbType dbType)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName, dbType);
            prm.Direction = ParameterDirection.InputOutput;
            parameteriyiCommandYadaListeyeEkle(prm);
        }

        private void parameteriyiCommandYadaListeyeEkle(DbParameter prm)
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

