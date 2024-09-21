global using System;
global using System.Data.Common;
global using System.Data.SqlClient;

global using Karkas.Core.DataUtil;
global using Karkas.Core.Data.SqlServer;

using Karkas.Core.Data.SqlServer;

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
            string dbConnectionString = "User Id=sa;Password=Karkas@Passw0rd;Persist Security Info=False;Initial Catalog=Chinook_AutoIncrement;Data Source=localhost;encrypt=False;";
            string dbProviderName = "System.Data.SqlClient";
            string dbName = "ChinookSqlServerAutoIncrement";

            DbProviderFactories.RegisterFactory(dbProviderName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            ConnectionSingleton.Instance.AddConnection(dbName, dbProviderName, dbConnectionString);
            ConnectionSingleton.Instance.AddConnection("Main", dbProviderName, dbConnectionString);

        }

    }

}
