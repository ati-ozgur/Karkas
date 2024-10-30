
global using Microsoft.Data.Sqlite;
global using Karkas.Data.Sqlite;


namespace Karkas.Examples
{
    public class ConnectionHelper
    {
        public static AdoTemplateSqlite GetAdoTemplate()
        {
            return new AdoTemplateSqlite();
        }        

        public static void SetupDatabaseConnection()
        {
            string dbConnectionString = "Data Source=Chinook.sqlite;Mode=ReadWrite;";
            string dbProviderName = "Microsoft.Data.Sqlite";
            DbProviderFactories.RegisterFactory(dbProviderName, Microsoft.Data.Sqlite.SqliteFactory.Instance);
            ConnectionSingleton.Instance.AddConnection("Main", dbProviderName, dbConnectionString);

        }

    }

}
