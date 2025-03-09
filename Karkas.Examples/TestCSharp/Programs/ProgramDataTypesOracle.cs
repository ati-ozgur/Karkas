
ConnectionHelper.SetupDatabaseConnection();

DecimalTablesBs bs1 = new DecimalTablesBs();

int rowCount = 10;
var resultList = bs1.QueryAll(rowCount);
AssertEquals(resultList.Count,rowCount);
Console.WriteLine("QueryAll maxRowCount works");

foreach (var row in resultList)
{
    Console.WriteLine(row.DecimalTablesKey);
}


static void AssertEquals(int p1, int p2, string message = "should be equal")
{
    if (p1 != p2)
    {
        throw new Exception($"Assertion error, {p1} != {p2} {message}");
    }
}


