
ConnectionHelper.SetupDatabaseConnection();

DecimalTablesBs bs1 = new DecimalTablesBs();

int rowCount = 10;
var resultList = bs1.QueryAll(rowCount);
AssertEquals(resultList.Count,rowCount,"QueryAll rowCount works");
Console.WriteLine("QueryAll maxRowCount works");

foreach (var row in resultList)
{
    Console.WriteLine(row.DecimalTablesKey);
}


static void AssertEquals(object p1, object p2, string message)
{
    if (!p1.Equals(p2))
    {
        throw new Exception($"Assertion error, {p1} != {p2} {message}");
    }
}

