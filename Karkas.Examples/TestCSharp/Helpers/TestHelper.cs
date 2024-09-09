
namespace Karkas.Examples
{
    public class TestHelper
    {

        public static void assertEquals(object p1, object p2, string message)
        {
            if (p1 != p2)
            {
                throw new Exception($"Assertion error, {p1} != {p2} {message}");
            }
        }
    }

}
