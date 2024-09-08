using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;
using System.Runtime.Remoting;
using System.Data.Common;

using Microsoft.Data.Sqlite;

namespace Karkas.CodeGeneration.Helpers
{
    public class ConnectionHelper
    {
        public static string RemoveProviderFromConnectionString(string connectionString)
        {
            if (connectionString.Contains("Provider"))
            {
                int providerBaslangic = connectionString.IndexOf("Provider");
                int providerBitis = connectionString.IndexOf(';', providerBaslangic + 1);
                connectionString = connectionString.Remove(providerBaslangic, providerBitis + 1);
            }
            return connectionString;
        }


        public static SqliteConnection TestSqlite(string connectionString)
        {
            try
            {
                var connection = new SqliteConnection(connectionString);
                connection.Open();
                connection.Close();
                return connection;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

    }
}

