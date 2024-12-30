global using Microsoft.Data.SqlClient;
global using Karkas.Data.SqlServer;


namespace Karkas.Examples
{
    public class ConnectionHelper
    {
        public static AdoTemplateSqlServer GetAdoTemplate()
        {
            return new AdoTemplateSqlServer();
        }

        public static void SetupDatabaseConnection()
        {
            string dbConnectionString = "User Id=sa;Password=Karkas@Passw0rd;Persist Security Info=False;Initial Catalog=Chinook_AutoIncrement;Data Source=localhost,1434;encrypt=False;";
            string dbProviderName = "Microsoft.Data.SqlClient";
            string dbName = "DataTypes";

            DbProviderFactories.RegisterFactory(dbProviderName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            ConnectionSingleton.Instance.AddConnection(dbName, dbProviderName, dbConnectionString);
            ConnectionSingleton.Instance.AddConnection("Main", dbProviderName, dbConnectionString);

        }

    }

}
