global using Microsoft.Data.SqlClient;
global using Karkas.Data.SqlServer;


namespace Karkas.Examples
{
    public class ConnectionHelper
    {
        private const string DbProviderName = "Microsoft.Data.SqlClient";
        private const string DbConnectionString = "User Id=sa;Password=Karkas@Passw0rd;Persist Security Info=False;Initial Catalog=DataTypes;Data Source=localhost,1434;encrypt=False;";

        /// <summary>Creates a new, unopened connection to the test database.</summary>
        public static DbConnection CreateConnection()
        {
            return DbProviderFactoryHelper.CreateConnection(DbProviderName, DbConnectionString);
        }

        public static AdoTemplateSqlServer GetAdoTemplate()
        {
            return new AdoTemplateSqlServer(CreateConnection());
        }

        public static void SetupDatabaseConnection()
        {
            DbProviderFactories.RegisterFactory(DbProviderName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
        }

    }

}
