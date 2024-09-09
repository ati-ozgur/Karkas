
using System;
namespace Karkas.Examples
{
    public class PrintHelper
    {

        public static void printList(IEnumerable<object> liste)
        {
            foreach (var item in liste)
            {
                Console.WriteLine(item);
            }
        }

    }

}
