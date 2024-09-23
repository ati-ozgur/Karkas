global using System;
global using System.Data.Common;
global using Oracle.ManagedDataAccess.Client;

global using Karkas.Data;
global using Karkas.Core.Data.Oracle;



namespace Karkas.Examples
{
    public class ConnectionHelper
    {

        public static AdoTemplateOracle GetAdoTemplate()
        {
            return new AdoTemplateOracle();
        }

        public static void SetupDatabaseConnection()
        {
            string dbConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=chinook;Password=chinook;";
            string dbProviderName = "Oracle.ManagedDataAccess.Client";
            string dbName = "ChinookOracle";

            DbProviderFactories.RegisterFactory(dbProviderName, Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance);
            ConnectionSingleton.Instance.AddConnection(dbName, dbProviderName, dbConnectionString);
            ConnectionSingleton.Instance.AddConnection("Main", dbProviderName, dbConnectionString);

        }

    }

}
