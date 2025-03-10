namespace Karkas.Examples;

public partial class TestHelper
{

	public static void assertEquals(object p1, object p2, string message)
    {
        if (!p1.Equals(p2))
        {
            throw new Exception($"Assertion error, {p1} != {p2} {message}");
        }
    }



    public static void TestExits()
    {
        AlbumBs albumBs = new AlbumBs();

        bool exists = albumBs.IsTitleExists("Fireball");
        if(exists)
        {
            Console.WriteLine("exists usage works");
        }
    }


}


