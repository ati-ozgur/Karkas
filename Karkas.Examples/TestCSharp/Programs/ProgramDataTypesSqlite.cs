

ConnectionHelper.SetupDatabaseConnection();

int pk = 1;

CustomersDal dal = new CustomersDal();

Customers c1 = new Customers();
c1.CustomerId = pk++;
c1.FirstName = "Atilla";
c1.LastName = "Özgür";

dal.Insert(c1);

var list = dal.QueryByFirstNameLastName("Atilla", "Özgür");

if(list.Count > 0)
{
	Console.WriteLine("QueryByIndex generation works");
}

foreach (var c in list)
{
	Console.WriteLine(c.CustomerId + " " + c.FirstName + " " + c.LastName);
}


