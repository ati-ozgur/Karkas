ConnectionHelper.SetupDatabaseConnection();


CustomersBs bsCustomers = new CustomersBs();

Customers c1 = new Customers();
c1.FirstName = "Atilla";
c1.LastName = "Özgür";
c1.Email = "deneme@karkas.com.tr";

var pkCustomer = bsCustomers.Insert(c1);

var list = bsCustomers.QueryByFirstNameLastName("Atilla", "Özgür");

if(list.Count > 0)
{
	Console.WriteLine("QueryByIndex generation works");
}

foreach (var c in list)
{
	Console.WriteLine(c.FirstName + " " + c.LastName);
}

var c2 = bsCustomers.QueryByEmail(c1.Email);
if(c1.FirstName == c2.FirstName)
{
	Console.WriteLine("QueryByIndex UNIQUE generation works");
}


DenemeBs bsDeneme = new DenemeBs();


Deneme d1= new Deneme();
d1.BitColumn = false;


var pk = bsDeneme.Insert(d1);
Console.WriteLine("pk" + pk);
Console.WriteLine("Simple Insert works");

var l1 = bsDeneme.QueryAll();

Console.WriteLine(l1);
