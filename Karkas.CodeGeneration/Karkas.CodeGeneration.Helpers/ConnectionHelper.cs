using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;
using System.Runtime.Remoting;
using System.Data.Common;

using Microsoft.Data.Sqlite;
using Microsoft.Data.SqlClient;
using Karkas.Core.DataUtil;
using Karkas.Core.Data.Sqlite;
using Karkas.Core.Data.SqlServer;
using Karkas.Core.Data.Oracle;

using Oracle.ManagedDataAccess.Client;


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


        private static SqliteConnection testSqlite(string connectionString)
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

        private static SqlConnection testSqlserver(string connectionString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
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

        private static OracleConnection testOracle(string connectionString)
        {

            try
            {
                OracleConnection connection = new OracleConnection(connectionString);
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

        public static IAdoTemplate<IParameterBuilder> TestConnection(string connectionDatabaseType,string connectionString)
        {
            DbConnection connection;
            IAdoTemplate<IParameterBuilder> template;
            switch (connectionDatabaseType)
            {
                case "sqlite":
                    connection  = testSqlite(connectionString);
                    DbProviderFactories.RegisterFactory("Microsoft.Data.Sqlite", SqliteFactory.Instance);
                    template = new AdoTemplateSqlite();
                    template.Connection = connection; 
                    return template;                 
                    break;
                case "SqlServer":
                    connection  = testSqlserver(connectionString);
                    DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);
                    DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
                    template = new AdoTemplateSqlServer();
                    template.Connection = connection; 
                    return template;                 
                    break;
                case "Oracle":
                    connection  = testOracle(connectionString);
                    DbProviderFactories.RegisterFactory("Oracle.ManagedDataAccess.Client", OracleClientFactory.Instance);
                    //DbProviderFactories.RegisterFactory("System.Data.Oracle", OracleClientFactory.Instance);
                    template = new AdoTemplateOracle();
                    template.Connection = connection; 
                    return template;                 
                    break;

                default:
                    Console.WriteLine($"NOT Supported yet in commandline {connectionDatabaseType}");
                    return null;
                    break;
            }



        }

    }
}

