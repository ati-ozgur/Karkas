global using Oracle.ManagedDataAccess.Client;
global using Karkas.Data.Oracle;




namespace Karkas.Examples
{
    public class ConnectionHelper
    {
        private const string DbProviderName = "Oracle.ManagedDataAccess.Client";
        private const string DbConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=chinook;Password=chinook;";

        /// <summary>Creates a new, unopened connection to the test database.</summary>
        public static DbConnection CreateConnection()
        {
            return DbProviderFactoryHelper.CreateConnection(DbProviderName, DbConnectionString);
        }


        public static AdoTemplateOracle GetAdoTemplate()
        {
            return new AdoTemplateOracle(CreateConnection());
        }

        public static void SetupDatabaseConnection()
        {
            DbProviderFactories.RegisterFactory(DbProviderName, Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance);
        }

    }

}
