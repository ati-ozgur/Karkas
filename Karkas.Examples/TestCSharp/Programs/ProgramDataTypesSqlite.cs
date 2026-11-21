

ConnectionHelper.SetupDatabaseConnection();

int pk = 1;

CustomersBs bs = new CustomersBs(ConnectionHelper.CreateConnection());

Customers c1 = new Customers();
c1.CustomerId = pk++;
c1.FirstName = "Atilla";
c1.LastName = "Özgür";
c1.Email = "deneme@karkas.com.tr";

bs.Insert(c1);

var list = bs.QueryByFirstNameLastName("Atilla", "Özgür");

if(list.Count > 0)
{
	Console.WriteLine("QueryByIndex generation works");
}

foreach (var c in list)
{
	Console.WriteLine(c.CustomerId + " " + c.FirstName + " " + c.LastName);
}

var c2 = bs.QueryByEmail(c1.Email);
if(c1.FirstName == c2.FirstName)
{
	Console.WriteLine("QueryByIndex UNIQUE generation works");
}

// QueryBy<Pk> must pass the key as a parameter, not format it into the SQL text.
// Countries has a TEXT primary key, so the old String.Format version could be injected.
CountriesBs countriesBs = new CountriesBs(ConnectionHelper.CreateConnection());

var turkey = countriesBs.QueryByCountryCode("TR");
if (turkey == null || turkey.CountryName != "Turkey")
{
	throw new Exception("QueryByPk with a string key does not find an existing row");
}
Console.WriteLine("QueryByPk with string key works");

var injected = countriesBs.QueryByCountryCode("x' OR '1'='1");
if (injected != null)
{
	throw new Exception("QueryByPk is open to SQL injection: it returned " + injected.CountryCode);
}
Console.WriteLine("QueryByPk is not open to SQL injection");

Countries quoted = new Countries();
quoted.CountryCode = "O'Q";
quoted.CountryName = "Quote Test";
countriesBs.Insert(quoted);
var quotedFromDb = countriesBs.QueryByCountryCode("O'Q");
if (quotedFromDb == null || quotedFromDb.CountryName != "Quote Test")
{
	throw new Exception("QueryByPk does not work with a key that contains a quote");
}
countriesBs.Delete(quoted);
if (countriesBs.QueryByCountryCode("O'Q") != null)
{
	throw new Exception("Row with a quoted key was not deleted");
}
Console.WriteLine("QueryByPk works with a key that contains a quote");
