using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.Core.Utility
{
    public static  class StringHelper
    {
        public static string StringToBase64Encode(this string str)
        {
            byte[] arr = StringToByteArray(str);
            return Convert.ToBase64String(arr);
        }
        public static string StringToBase64Decode(this string str)
        {
            byte[] arr = Convert.FromBase64String(str);
            return ByteArrayToString(arr);
        }
        public static string ByteArrayToString(this byte[] arr)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(arr);
        }
        public static byte[] StringToByteArray(this string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }
    }
}
