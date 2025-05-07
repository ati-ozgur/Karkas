

ConnectionHelper.SetupDatabaseConnection();

int pk = 1;

CustomersBs bs = new CustomersBs();

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
