using System;
using System.Data.Common;

using Karkas.Core.DataUtil;


using Karkas.Examples;
using Karkas.Examples.Chinook.Bs;
using Karkas.Examples.Chinook.Dal;
using Karkas.Examples.Chinook.TypeLibrary;

ConnectionHelper.SetupDatabaseConnection();


AlbumBs albumBs = new AlbumBs();



string albumTitle = "Deneme";

Album a = new Album();
a.Title = albumTitle;
a.ArtistId = 2;

long albumId = albumBs.Insert(a);

var albumList = albumBs.QueryUsingColumnName(Album.PropertyIsimleri.Title,albumTitle);

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


albumBs.InsertNewArtistAndAlbum("Atilla", "Atilla's new Title");
Console.WriteLine("Simple Transaction works");
