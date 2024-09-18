using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;

using Karkas.Core.DataUtil;

namespace Karkas.Examples
{
    public class ConnectionHelper
    {

        public static void SetupDatabaseConnection()
        {
            string dbConnectionString = "Data Source=Chinook.db;Mode=ReadWrite;";
            string dbProviderName = "Microsoft.Data.Sqlite";
            DbProviderFactories.RegisterFactory(dbProviderName, Microsoft.Data.Sqlite.SqliteFactory.Instance);
            ConnectionSingleton.Instance.AddConnection("Main", dbProviderName, dbConnectionString);

        }

    }

}
