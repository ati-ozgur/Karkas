using System;
using System.Data.Common;
using Karkas.Core.DataUtil;

using Karkas.Examples;
using Karkas.Examples.Chinook.Bs;
using Karkas.Examples.Chinook.Dal;
using Karkas.Examples.Chinook.TypeLibrary;

ConnectionHelper.SetupDatabaseConnection();


AlbumBs albumBs = new AlbumBs();

var listAlbums1 = albumBs.SelectByArtistId(2);
if(listAlbums1.Count > 0)
{
    Console.WriteLine("Select by ForeignKey works");
}



string albumTitle = Guid.NewGuid().ToString();

Album a = new Album();
a.Title = albumTitle;
a.ArtistId = 2;

var albumId = albumBs.Insert(a);

var albumList = albumBs.QueryUsingColumnName(Album.ColumnNames.Title,albumTitle);

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
else
{
    throw new Exception("Insert for Identity does NOT work");
}

Customer c1 = new Customer();
c1.FirstName = "Atilla";
c1.Address = "MG Germany";
c1.Company = "University";
c1.Country = "Türkiye";
c1.Email = "ati.ozgur@gmail.com";
c1.Fax = "None";
c1.LastName = "Özgür";
c1.Phone = "123456";

CustomerBs customerBs = new CustomerBs();

var customerRowCountBefore = customerBs.TableRowCount;
Console.WriteLine($"customerRowCountBefore: {customerRowCountBefore}");

var newCustomerId = customerBs.Insert(c1);

var customerRowCountAfter = customerBs.TableRowCount;
Console.WriteLine($"customerRowCountAfter: {customerRowCountAfter}");


if(customerRowCountAfter == customerRowCountBefore+1)
{
    Console.WriteLine("Insert to customer works");
}
else
{
    throw new Exception("Insert to customer DOES NOT works");
}

Customer fromDb = customerBs.QueryByCustomerId(newCustomerId);

if(c1.CustomerId == fromDb.CustomerId
&& c1.FirstName == fromDb.FirstName
&& c1.Address == fromDb.Address
&& c1.Company == fromDb.Company
&& c1.Country == fromDb.Country
&& c1.Email == fromDb.Email
&& c1.Fax == fromDb.Fax
&& c1.LastName == fromDb.LastName
&& c1.Phone == fromDb.Phone
)
{
    Console.WriteLine("Read from Customer table works");
}
else
{
    throw new Exception("Read from Customer table DOES NOT works");
}

fromDb.LastName = "Oezguer";

customerBs.Update(fromDb);
Customer fromDb2 = customerBs.QueryByCustomerId(newCustomerId);

if (fromDb2.CustomerId == fromDb.CustomerId
&& fromDb2.FirstName == fromDb.FirstName
&& fromDb2.Address == fromDb.Address
&& fromDb2.Company == fromDb.Company
&& fromDb2.Country == fromDb.Country
&& fromDb2.Email == fromDb.Email
&& fromDb2.Fax == fromDb.Fax
&& fromDb2.LastName == fromDb.LastName
&& fromDb2.Phone == fromDb.Phone
)
{
    Console.WriteLine("Update to Customer table works");
}
else
{
    throw new Exception("Update to Customer table DOES NOT works");
}


var customerRowCountBeforeDelete = customerBs.TableRowCount;

Console.WriteLine($"customerRowCountBeforeDelete: {customerRowCountBeforeDelete}");

customerBs.Delete(newCustomerId);

var customerRowCountAfterDelete = customerBs.TableRowCount;

Console.WriteLine($"customerRowCountAfterDelete: {customerRowCountAfterDelete}");

if (customerRowCountAfterDelete == customerRowCountBeforeDelete - 1)
{
    Console.WriteLine("delete to customer works");
}
else
{
    throw new Exception("delete to customer DOES NOT works");
}

string artistName = "Atilla";
string titleToInsert = $"{artistName}'s new Title" + Guid.NewGuid().ToString();

albumBs.InsertNewArtistAndAlbum(artistName, titleToInsert);

var result = albumBs.QueryUsingColumnName(Album.ColumnNames.Title,titleToInsert);

if(result !=null && result.Count == 1 && result[0].Title == titleToInsert)
{
    var artistId = result[0].ArtistId;
    var artist = new ArtistBs().QueryByArtistId(artistId);
    if(artist.Name == artistName)
    {
        Console.WriteLine("Simple Transaction works");
    }
}





bool exists = albumBs.IsTitleExists("Fireball");
if(exists)
{
    Console.WriteLine("exists usage works");    
}

var template = ConnectionHelper.GetAdoTemplate();

int count = 5;
string testSqlForTop = "SELECT * FROM \"Album\"";
List<Dictionary<string,object>> lAlbums = template.GetTopRows(testSqlForTop,count);

if(lAlbums.Count == count)
{
    System.Console.WriteLine("GetTopRows works");
}

var d1 = template.GetOneRow(testSqlForTop);
foreach(string key in d1.Keys)
{
    object value = d1[key];
    Console.WriteLine($"{key} {value}");
}

if(d1 != null)
{
    Console.WriteLine("GetOneRow works");
}
