
using System;
using System.Data.Common;

using Karkas.Core.DataUtil;

namespace Karkas.Examples
{
    public class ConnectionHelper
    {

        public static void SetupDatabaseConnection()
        {
            string dbConnectionString = "User Id=sa;Password=Karkas@Passw0rd;Persist Security Info=False;Initial Catalog=Chinook_AutoIncrement;Data Source=localhost;encrypt=False;";
            string dbProviderName = "Microsoft.Data.SqlClient";
            string dbName = "Chinook";

            DbProviderFactories.RegisterFactory(dbProviderName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            ConnectionSingleton.Instance.AddConnection(dbName, dbProviderName, dbConnectionString);
            ConnectionSingleton.Instance.AddConnection("Main", dbProviderName, dbConnectionString);

        }

    }

}
