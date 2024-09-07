// See https://aka.ms/new-console-template for more information

using System.Data.Common;
using Microsoft.Data.Sqlite;

using Karkas.Core.DataUtil;

using Karkas.Examples.Chinook.Dal.ChinookSqlite;
using Karkas.Examples.Chinook.TypeLibrary.ChinookSqlite;


string dbConnectionString = "Data Source=Chinook.db;Mode=ReadWrite;";
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

Album a = new Album();
a.Title = "Deneme";
a.ArtistId = 2;

dal.Insert(a);