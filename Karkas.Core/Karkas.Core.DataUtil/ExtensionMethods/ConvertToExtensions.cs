using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.ExtensionMethods
{
    public static class ConvertToExtensions
    {
        public static decimal? ToDecimalAsNullable(this String str)
        {

            decimal result;
            if (!string.IsNullOrEmpty(str) && decimal.TryParse(str, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static int? ToIntAsNullable(this String str)
        {
            int result;
            if (int.TryParse(str, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public static byte? ToByteAsNullable(this String str)
        {
            byte result;
            if (byte.TryParse(str, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public static short? ToShortAsNullable(this String str)
        {
            short result;
            if (short.TryParse(str, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static long? ToLongAsNullable(this String str)
        {
            long result;
            if (long.TryParse(str, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public static Guid? ToGuidAsNullable(this String str)
        {
            try
            {
                return new Guid(str);
            }
            catch
            {
                return null;
            }
        }


    }
}
