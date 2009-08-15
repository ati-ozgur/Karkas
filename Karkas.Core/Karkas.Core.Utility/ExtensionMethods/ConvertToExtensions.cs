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
            decimal sonuc;
            if (decimal.TryParse(str, out sonuc))
            {
                return sonuc;
            }
            else
            {
                return null;
            }
        }

        public static int? ToIntAsNullable(this String str)
        {
            int sonuc;
            if (int.TryParse(str, out sonuc))
            {
                return sonuc;
            }
            else
            {
                return null;
            }
        }
        public static byte? ToByteAsNullable(this String str)
        {
            byte sonuc;
            if (byte.TryParse(str, out sonuc))
            {
                return sonuc;
            }
            else
            {
                return null;
            }
        }
        public static short? ToShortAsNullable(this String str)
        {
            short sonuc;
            if (short.TryParse(str, out sonuc))
            {
                return sonuc;
            }
            else
            {
                return null;
            }
        }

        public static long? ToLongAsNullable(this String str)
        {
            long sonuc;
            if (long.TryParse(str, out sonuc))
            {
                return sonuc;
            }
            else
            {
                return null;
            }
        }
        public static Guid? ToGuidAsNullable(this String str)
        {
            Guid sonuc;
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
