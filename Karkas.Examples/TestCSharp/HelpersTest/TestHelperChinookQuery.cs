namespace Karkas.Examples;

public partial class TestHelper
{

	public static void TestQuery_QueryDetailTable1()
	{
		CustomerBs bs = new CustomerBs();

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

		EmployeeDal dal = new EmployeeDal();
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

		EmployeeDal dal = new EmployeeDal();
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

		EmployeeDal dal = new EmployeeDal();
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

		CustomerDal dal = new CustomerDal();
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
	public static void TestQueryUsingWrongColumnName()
	{

		try
		{
			AlbumDal dal = new AlbumDal();
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
		AlbumBs albumBs = new AlbumBs();

		var listAlbums1 = albumBs.QueryByArtistId(2);
		if (listAlbums1.Count > 0)
		{
			Console.WriteLine("Query by ForeignKey works");
		}

	}


	public static void TestQueryByColumnNameWhereOperators()
	{
		CustomerBs customerBs = new CustomerBs();

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

}
