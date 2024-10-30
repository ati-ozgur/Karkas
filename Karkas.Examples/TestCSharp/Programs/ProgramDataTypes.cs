

ConnectionHelper.SetupDatabaseConnection();

int pk = 1;

Deneme d = new Deneme();



d.CInt = 100;
d.CInteger = 100;

d.PkId = pk;


StringBuilder sb = new StringBuilder();
for (int i = 0; i < 1000; i++)
{
    sb.Append("1234567890");
    sb.Append("1234567890");
}

string value = sb.ToString();
Console.WriteLine("length:" + value.Length);

Console.WriteLine(value);

d.CClob = value;

DenemeDal dal = new DenemeDal();

dal.Insert(d);

Deneme d2 = dal.QueryByPkId(pk);
if(d2.CClob == d.CClob)
{
    Console.WriteLine("Clob insert works");
}
else
{
    throw new Exception("Clob insert DOES NOT work");    
}





