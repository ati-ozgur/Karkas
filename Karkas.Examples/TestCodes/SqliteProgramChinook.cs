// See https://aka.ms/new-console-template for more information

using Microsoft.Data.Sqlite;
using Karkas.Examples.Chinook.Dal.ChinookSqlite;
using System.Data.Common;
using Karkas.Core.DataUtil;


string dbConnectionString = "Data Source=Chinook.db;";
string dbProviderName = "Microsoft.Data.Sqlite";
string dbName = "ChinookSqlite";

DbProviderFactories.RegisterFactory(dbProviderName, Microsoft.Data.Sqlite.SqliteFactory.Instance);

ConnectionSingleton.Instance.AddConnection(dbName, dbProviderName, dbConnectionString);
ConnectionSingleton.Instance.AddConnection("Main", dbProviderName, dbConnectionString);



Console.WriteLine("Hello, World!");



AlbumDal dal = new AlbumDal();

var liste = dal.QueryAll();

foreach (var item in liste)
{
    Console.WriteLine(item.Title);
}
