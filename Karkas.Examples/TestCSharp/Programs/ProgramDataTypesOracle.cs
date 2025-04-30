
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


BlobExample1 b1 = new BlobExample1();
b1.Url = "http://localhost:5000/api/BlobExample1";
b1.Username = "admin";
b1.RequestJson = new UTF8Encoding().GetBytes("{\"key\":1}");
b1.ResponseJson = new UTF8Encoding().GetBytes("{\"key\":1}");

BlobExample1Bs bs2 = new BlobExample1Bs();
bs2.Insert(b1);
Console.WriteLine("BlobExample1 insert works");


static void AssertEquals(object p1, object p2, string message)
{
    if (!p1.Equals(p2))
    {
        throw new Exception($"Assertion error, {p1} != {p2} {message}");
    }
}

