// See https://aka.ms/new-console-template for more information

using System;
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




AlbumDal dal = new AlbumDal();


string albumTitle = "Deneme";

Album a = new Album();
a.Title = albumTitle;
a.ArtistId = 2;

long albumId = dal.Insert(a);

var albumList = dal.QueryUsingColumnName(Album.PropertyIsimleri.Title,albumTitle);

Album b = albumList[albumList.Count-1];
if(
albumId == a.AlbumId
&& albumId == b.AlbumId
&& a.AlbumId == b.AlbumId
&& a.Title ==b.Title
&& a.ArtistId == b.ArtistId
)
{
    Console.WriteLine("Insert for Identity works");
}




void printAlbums()
{
    AlbumDal dal = new AlbumDal();

    var liste = dal.QueryAll();

    foreach (var item in liste)
    {
        Console.WriteLine(item.Title);
    }

}

void assertEquals(object p1, object p2)
{
    if (p1!=p2)
    {

        throw new Exception($"Assertion error, {p1} != {p2}");
    }
}