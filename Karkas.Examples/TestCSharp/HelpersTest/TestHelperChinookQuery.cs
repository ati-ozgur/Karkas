namespace Karkas.Examples;

public partial class TestHelper
{

	public static void TestQuery_QueryDetailTable1()
	{
		CustomerBs bs = new CustomerBs(ConnectionHelper.CreateConnection());

		var list = bs.QueryDetailTable<Invoice>(56);

		if (list.Count > 0)
		{
			Console.WriteLine("QueryDetailTable works");
		}
		else
		{
			throw new Exception("QueryDetailTable DOES NOT work");
		}

	}


	public static void TestQueryUsingColumnName_StringDateTimeColumns()
	{

		EmployeeDal dal = new EmployeeDal(ConnectionHelper.CreateConnection());
		var liste = dal.QueryUsingColumnName(
			new string[] { Employee.ColumnNames.FirstName, Employee.ColumnNames.HireDate },
			new object[] { "A%", new DateTime(2002, 8, 14) },
			new WhereOperatorEnum[] { WhereOperatorEnum.Like, WhereOperatorEnum.Equals }
			);

		if (liste.Count == 1)
		{
			Console.WriteLine("QueryUsing string + datetime columns works");
		}
		else
		{
			throw new Exception("QueryUsing string + datetime columns DOES NOT work");
		}

	}

	public static void TestQueryUsingColumnName_TwoStringColumnsWithLike()
	{

		EmployeeDal dal = new EmployeeDal(ConnectionHelper.CreateConnection());
		var liste = dal.QueryUsingColumnName(
			new string[] { Employee.ColumnNames.FirstName, Employee.ColumnNames.LastName },
			new object[] { "A%", "A%" },
			new WhereOperatorEnum[] { WhereOperatorEnum.Like, WhereOperatorEnum.Like }
			);

		if (liste.Count == 1)
		{
			Console.WriteLine("QueryUsing simple two string columns with LIKE works");
		}
		else
		{
			throw new Exception("QueryUsing simple two string columns with LIKE  DOES NOT work");
		}

	}


	public static void TestQueryUsingColumnName_TwoStringColumns()
	{

		EmployeeDal dal = new EmployeeDal(ConnectionHelper.CreateConnection());
		var liste = dal.QueryUsingColumnName(
			new string[] { Employee.ColumnNames.City, Employee.ColumnNames.Country },
			new object[] { "Calgary", "Canada" }
			);

		if (liste.Count == 5)
		{
			Console.WriteLine("QueryUsing simple two string columns works");
		}
		else
		{
			throw new Exception("QueryUsing simple two string columns DOES NOT work");
		}

	}

	public static void TestQueryAll()
	{

		CustomerDal dal = new CustomerDal(ConnectionHelper.CreateConnection());
		var allCustomers = dal.QueryAll();
		if (allCustomers.Count > 0)
		{
			Console.WriteLine("QueryAll works");
		}
		else
		{
			throw new Exception("QueryAll DOES NOT work");
		}
		int maxRowCount = 10;
		var list = dal.QueryAll(10);
		assertEquals(list.Count, maxRowCount, "QueryAll works");
	}

	public static void TestQueryAllOrderBy()
	{
		CustomerBs bs = new CustomerBs(ConnectionHelper.CreateConnection());
		// numeric sort keys so the check does not depend on database string collation
		string rep = Customer.ColumnNames.SupportRepId;
		string id = Customer.ColumnNames.CustomerId;

		// bare columns default to ASC
		var listBare = bs.QueryAllOrderBy(rep, id);
		// direction strings, case-insensitive
		var listDirection = bs.QueryAllOrderBy(rep, "asc", id, "DESC");
		// OrderBy overload
		var listObjects = bs.QueryAllOrderBy(new OrderBy(rep, OrderByEnum.DESC), new OrderBy(id));

		int total = bs.QueryAll().Count;
		assertEquals(listBare.Count, total, "QueryAllOrderBy bare columns row count");
		assertEquals(listDirection.Count, total, "QueryAllOrderBy with direction row count");
		assertEquals(listObjects.Count, total, "QueryAllOrderBy OrderBy objects row count");

		assertSortedBy(listBare, 1, 1, "QueryAllOrderBy bare columns DOES NOT sort ASC, ASC");
		assertSortedBy(listDirection, 1, -1, "QueryAllOrderBy with direction DOES NOT sort ASC, DESC");
		assertSortedBy(listObjects, -1, 1, "QueryAllOrderBy OrderBy objects DOES NOT sort DESC, ASC");
		Console.WriteLine("QueryAllOrderBy works");
	}

	// repSign/idSign: 1 = ascending, -1 = descending; Convert because id types differ per database
	private static void assertSortedBy(List<Customer> list, int repSign, int idSign, string message)
	{
		for (int i = 1; i < list.Count; i++)
		{
			int repCompare = Convert.ToDecimal(list[i - 1].SupportRepId).CompareTo(Convert.ToDecimal(list[i].SupportRepId)) * repSign;
			int idCompare = Convert.ToDecimal(list[i - 1].CustomerId).CompareTo(Convert.ToDecimal(list[i].CustomerId)) * idSign;
			if (repCompare > 0 || (repCompare == 0 && idCompare > 0))
			{
				throw new Exception(message);
			}
		}
	}

	public static void TestQueryUsingWrongColumnName()
	{

		try
		{
			AlbumDal dal = new AlbumDal(ConnectionHelper.CreateConnection());
			var list = dal.Template.GetRows(@"SELECT X FROM ""Album""");
			PrintHelper.printList(list);
		}
		catch (WrongSQLQueryException ex)
		{
			Console.WriteLine("Query with Wrong column name throws exception works");
		}
	}

	public static void TestQueryByForeignKey1()
	{
		AlbumBs albumBs = new AlbumBs(ConnectionHelper.CreateConnection());

		var listAlbums1 = albumBs.QueryByArtistId(2);
		if (listAlbums1.Count > 0)
		{
			Console.WriteLine("Query by ForeignKey works");
		}

	}


	public static void TestQueryByColumnNameWhereOperators()
	{
		CustomerBs customerBs = new CustomerBs(ConnectionHelper.CreateConnection());

		var customers1 = customerBs.QueryUsingColumnName(Customer.ColumnNames.CustomerId
				, 10, WhereOperatorEnum.LesserAndEquals);
		if (customers1.Count == 10)
		{
			Console.WriteLine("WhereOperatorEnum.LesserAndEquals works");
		}
		else
		{
			throw new Exception("WhereOperatorEnum.LesserAndEquals DOES NOT works");
		}

		var customers2 = customerBs.QueryUsingColumnName(Customer.ColumnNames.FirstName
				, "A%", WhereOperatorEnum.Like);
		if (customers2.Count == 3)
		{
			Console.WriteLine("WhereOperatorEnum.Like works");
		}
		else
		{
			Console.WriteLine("WhereOperatorEnum.Like DOES NOT works");

		}
	}
	
	public static void TestGetOneRowGenericVersion()
	{
		AlbumDal dal = new AlbumDal(ConnectionHelper.CreateConnection());
		int a = dal.GetMaxAlbumId();
		Console.WriteLine("Max Album Id : " + a);

		EmployeeDal employeeDal = new EmployeeDal(ConnectionHelper.CreateConnection());
		DateTime birthDate = employeeDal.GetBirthDate(1);
		Console.WriteLine("Birth Date : " + birthDate.ToString("yyyy-MM-dd"));
	}

}
