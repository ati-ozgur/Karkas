ConnectionHelper.SetupDatabaseConnection();




DenemeBs bs = new DenemeBs();


Deneme d1= new Deneme();
d1.BitColumn = false;


var pk = bs.Insert(d1);
Console.WriteLine("pk" + pk);
Console.WriteLine("Simple Insert works");

var l1 = bs.QueryAll();

Console.WriteLine(l1);
