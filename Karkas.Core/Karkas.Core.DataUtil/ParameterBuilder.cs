using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Karkas.Core.DataUtil
{
    public class ParameterBuilder
    {

        private SqlCommand command;

        public SqlCommand Command
        {
            get { return command; }
            set { command = value; }
        }
        public ParameterBuilder(SqlCommand pCommand)
        {
            this.command = pCommand;
        }

        List<SqlParameter> parameterList;
        public ParameterBuilder()
        {
            parameterList = new List<SqlParameter>();
        }

        public void parameterEkle(string parameterName,SqlDbType dbType, object value)
        {
            SqlParameter prm = parameterDegerleriniSetle(parameterName, dbType, value);
            parameteriyiCommandYadaListeyeEkle(prm);
        }
        private static SqlParameter parameterDegerleriniSetle(string parameterName, SqlDbType dbType)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = parameterName;
            prm.SqlDbType = dbType;
            return prm;
        }

        private static SqlParameter parameterDegerleriniSetle(string parameterName, SqlDbType dbType, object value)
        {
            SqlParameter prm = new SqlParameter();
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
        public void parameterEkle(string parameterName, SqlDbType dbType, object value, int size)
        {
            SqlParameter prm = parameterDegerleriniSetle(parameterName, dbType, value);
            prm.Size = size;
            parameteriyiCommandYadaListeyeEkle(prm);
        }
        public void parameterEkleReturnValue(string parameterName, SqlDbType dbType)
        {
            SqlParameter prm = parameterDegerleriniSetle(parameterName, dbType);
            prm.Direction = ParameterDirection.ReturnValue;
            parameteriyiCommandYadaListeyeEkle(prm);
        }
        public void parameterEkleOutput(string parameterName, SqlDbType dbType)
        {
            SqlParameter prm = parameterDegerleriniSetle(parameterName, dbType);
            prm.Direction = ParameterDirection.Output;
            parameteriyiCommandYadaListeyeEkle(prm);
        }

        private void parameteriyiCommandYadaListeyeEkle(SqlParameter prm)
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

        public SqlParameter[] GetParameterArray()
        {
            return parameterList.ToArray();
        }




    }
}
