namespace Karkas.Examples;
public partial class TestHelper
{
	public static void TestInsertAlbum()
	{
		AlbumBs albumBs = new AlbumBs();
		string albumTitle = Guid.NewGuid().ToString();

		Album a = new Album();
		a.Title = albumTitle;
		a.ArtistId = 2;

		var albumId = albumBs.Insert(a);

		var albumList = albumBs.QueryUsingColumnName(Album.ColumnNames.Title, albumTitle);

		Album b = albumList[albumList.Count - 1];
		if (
		albumId == a.AlbumId
		&& albumId == b.AlbumId
		&& a.AlbumId == b.AlbumId
		&& a.Title == b.Title
		&& a.ArtistId == b.ArtistId
		)
		{
			Console.WriteLine("Insert for Identity works");
		}
		else
		{
			throw new Exception("Insert for Identity does NOT work");
		}

	}

	public static void TestCrudNormalAlbum()
	{

		var template = ConnectionHelper.GetAdoTemplate();
		string sqlMaxAlbumId = @"SELECT MAX(""AlbumId"") FROM ""Album""";

		var maxAlbumId = template.GetOneValue(sqlMaxAlbumId);
		int newAlbumId = Convert.ToInt32(maxAlbumId) + 1;


		AlbumBs albumBs = new AlbumBs();



		string albumTitle = Guid.NewGuid().ToString();

		Album a = new Album();
		a.AlbumId = newAlbumId;
		a.Title = albumTitle;
		a.ArtistId = 2;

		albumBs.Insert(a);

		var albumList = albumBs.QueryUsingColumnName(Album.ColumnNames.Title, albumTitle);

		Album b = albumList[albumList.Count - 1];
		if (
		newAlbumId == a.AlbumId
		&& newAlbumId == b.AlbumId
		&& a.AlbumId == b.AlbumId
		&& a.Title == b.Title
		&& a.ArtistId == b.ArtistId
		)
		{
			Console.WriteLine("Insert to Album for Normal works");
		}
		else
		{
			throw new Exception("Insert to Album for Normal does NOT work");
		}

		Album c = albumBs.QueryByAlbumId(newAlbumId);
		if (
		newAlbumId == c.AlbumId
		&& a.AlbumId == c.AlbumId
		&& a.Title == c.Title
		&& a.ArtistId == c.ArtistId
		)
		{
			Console.WriteLine("Read QuerybyPK from Album Normal works");
		}
		else
		{
			throw new Exception("Read QuerybyPK from Album Normal does NOT work");
		}


		c.Title = Guid.NewGuid().ToString();
		albumBs.Update(c);

		var albumListOldTitle = albumBs.QueryUsingColumnName(Album.ColumnNames.Title, albumTitle);
		var albumListNewTitle = albumBs.QueryUsingColumnName(Album.ColumnNames.Title, c.Title);
		if (albumListOldTitle.Count == 0 && albumListNewTitle.Count == 1)
		{
			Console.WriteLine("Update to Album for Normal works");
		}
		else
		{
			throw new Exception("Update to Album for Normal does NOT work");
		}

		albumBs.Delete(newAlbumId);
		Album d = albumBs.QueryByAlbumId(newAlbumId);
		if (d == null)
		{
			Console.WriteLine("Delete from Album for Normal works");
		}
		else
		{
			throw new Exception("Delete from Album for Normal does NOT work");
		}

	}
	public static void TestCrudCustomer()
	{
		CustomerBs customerBs = new CustomerBs();

		Customer c1 = new Customer();
		c1.FirstName = "Atilla";
		c1.Address = "MG Germany";
		c1.Company = "University";
		c1.Country = "Türkiye";
		c1.Email = "ati.ozgur@gmail.com";
		c1.Fax = "None";
		c1.LastName = "Özgür";
		c1.Phone = "123456";


		var customerRowCountBefore = customerBs.TableRowCount;
		Console.WriteLine($"customerRowCountBefore: {customerRowCountBefore}");

		var newCustomerId = customerBs.Insert(c1);

		var customerRowCountAfter = customerBs.TableRowCount;
		Console.WriteLine($"customerRowCountAfter: {customerRowCountAfter}");


		if (customerRowCountAfter == customerRowCountBefore + 1)
		{
			Console.WriteLine("Insert to customer works");
		}
		else
		{
			throw new Exception("Insert to customer DOES NOT works");
		}

		Customer fromDb = customerBs.QueryByCustomerId(newCustomerId);

		if (c1.CustomerId == fromDb.CustomerId
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

	}
}
