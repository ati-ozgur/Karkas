// See https://aka.ms/new-console-template for more information

using System;
using System.Data.Common;

using Karkas.Core.DataUtil;


using Karkas.Examples;

using Karkas.Examples.Chinook.Dal;
using Karkas.Examples.Chinook.TypeLibrary;

ConnectionHelper.SetupDatabaseConnection();





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





