
ConnectionHelper.SetupDatabaseConnection();

EmployeeBs bsEmployee = new EmployeeBs();

Employee c1 = new Employee();
c1.FirstName = "Atilla";
c1.LastName = "Özgür";
c1.Email = "deneme" + Guid.NewGuid().ToString();

var pk = bsEmployee.Insert(c1);

var list = bsEmployee.QueryByFirstNameLastName("Atilla", "Özgür");

if(list.Count > 0)
{
    Console.WriteLine("QueryByIndex generation works");
}

foreach (var c in list)
{
    Console.WriteLine(c.EmployeeId + " " + c.FirstName + " " + c.LastName);
}

var c2 = bsEmployee.QueryByEmail(c1.Email);
if (c2 != null && c1.FirstName == c2.FirstName)
{
    Console.WriteLine("QueryByIndex UNIQUE generation works");
}
else
{
    Console.WriteLine("QueryByIndex UNIQUE generation does not work");
    throw new Exception("QueryByIndex UNIQUE generation does not work");
}

Deneme d1 = new Deneme();
d1.CInt = 1;
d1.CInteger = 2;
d1.CClob = "test";

DenemeBs bsDeneme = new DenemeBs();
pk = bsDeneme.Insert(d1);

Deneme d2 = bsDeneme.QueryByPkId(pk);
AssertEquals(d1.CInt, d2.CInt, "CInt works");
AssertEquals(d1.CInteger, d2.CInteger, "CInteger works");
AssertEquals(d1.CClob, d2.CClob, "CClob works");

Console.WriteLine("Deneme table insert works");

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

