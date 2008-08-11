using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Karkas.Core.DataUtil
{
    [Serializable]
    public class LoggingInfo
    {
        private Guid kisiKey;

        public Guid KisiKey
        {
            get { return kisiKey; }
            set { kisiKey = value; }
        }

        private SqlCommand sqlCommand;

        public SqlCommand SqlCommand
        {
            get { return sqlCommand; }
            set { sqlCommand = value; }
        }


        public LoggingInfo(Guid pKisiKey, SqlCommand sqlCommand)
        {
            this.kisiKey = pKisiKey;
            this.sqlCommand = sqlCommand;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("KisiKey = " + KisiKey);
            sb.Append(" SqlCumlesi = " + SqlCommand.CommandText);
            foreach (SqlParameter param in SqlCommand.Parameters)
            {
                sb.Append(param.ParameterName + " = " + param.Value);
            }
            return sb.ToString();
        }
    }
}
