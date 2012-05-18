using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class ParameterBuilder
    {

        private DbCommand command;

        public DbCommand Command
        {
            get { return command; }
            set { command = value; }
        }
        public ParameterBuilder(DbCommand pCommand)
        {
            this.command = pCommand;
        }

        List<DbParameter> parameterList;
        public ParameterBuilder()
        {
            parameterList = new List<DbParameter>();
        }
        internal void parameterEkle(string parameterName, object value)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName,DbType.Object, value);
            parameteriyiCommandYadaListeyeEkle(prm);
        }


        public void parameterEkle(string parameterName,DbType dbType, object value)
        {
            DbParameter prm = parameterDegerleriniSetle(parameterName, dbType, value);
            parameteriyiCommandYadaListeyeEkle(prm);
        }
        private static DbParameter parameterDegerleriniSetle(string parameterName, DbType dbType)
        {
            DbParameter prm = new DbProviderFactoryHelper().GetParameter();
            prm.ParameterName = parameterName;
            prm.DbType = dbType;
            return prm;
        }

        private static DbParameter parameterDegerleriniSetle(string parameterName, DbType dbType, object value)
        {
            DbParameter prm = new DbProviderFactoryHelper().GetParameter();
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
        public void parameterEkle(string parameterName, DbType dbType, object value, int size)
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

