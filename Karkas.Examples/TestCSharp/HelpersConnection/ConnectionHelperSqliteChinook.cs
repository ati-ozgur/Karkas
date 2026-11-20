
global using Microsoft.Data.Sqlite;
global using Karkas.Data.Sqlite;


namespace Karkas.Examples
{
    public class ConnectionHelper
    {
        private const string DbProviderName = "Microsoft.Data.Sqlite";
        private const string DbConnectionString = "Data Source=Chinook.sqlite;Mode=ReadWrite;";

        /// <summary>Creates a new, unopened connection to the test database.</summary>
        public static DbConnection CreateConnection()
        {
            return DbProviderFactoryHelper.CreateConnection(DbProviderName, DbConnectionString);
        }

        public static AdoTemplateSqlite GetAdoTemplate()
        {
            return new AdoTemplateSqlite(CreateConnection());
        }        

        public static void SetupDatabaseConnection()
        {
            DbProviderFactories.RegisterFactory(DbProviderName, Microsoft.Data.Sqlite.SqliteFactory.Instance);
        }

    }

}
