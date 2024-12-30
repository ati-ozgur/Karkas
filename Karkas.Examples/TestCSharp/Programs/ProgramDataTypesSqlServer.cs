ConnectionHelper.SetupDatabaseConnection();






Deneme d1= new Deneme();
d1.BitColumn = false;


var pk = bs.Insert(d1);
Console.WriteLine("pk" + pk);
Console.WriteLine("Simple Insert works");

DenemeBs bs = new DenemeBs();
var l1 = bs.QueryAll();

Console.WriteLine(l1);
