
ConnectionHelper.SetupDatabaseConnection();


DecimalTablesBs bs1 = new DecimalTablesBs();

int rowCount = 10;
var resultList = bs1.QueryAll(rowCount);


AssertEquals(resultList.Count,rowCount);

foreach (var row in resultList)
{
	Console.WriteLine(row.DecimalTablesKey);
	Console.WriteLine(row.DecimalTablesKey);
}


static void AssertEquals(object p1, object p2, string message = "should be equal")
{
    if (p1 != p2)
    {
        throw new Exception($"Assertion error, {p1} != {p2} {message}");
    }
}
