using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace Karkas.Core.DataUtil
{
    public class CommandFactory
    {
        public static SqlCommand getDatabaseCommand(string sql, DbConnection conn)
        {
            SqlConnection sqlConn = (SqlConnection)conn;
            return new SqlCommand(sql, sqlConn);
        }
        public static SqlCommand getDatabaseCommand(DbConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection sqlConn = (SqlConnection)conn;
            cmd.Connection = sqlConn;
            return cmd;
        }
        public static SqlCommand getDatabaseCommand()
        {
            SqlCommand cmd = new SqlCommand();
            return cmd;
        }
    }
}

