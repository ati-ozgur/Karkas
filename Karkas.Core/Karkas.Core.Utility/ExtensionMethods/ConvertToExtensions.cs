using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.ExtensionMethods
{
    public static class ConvertToExtensions
    {
        public static int? IntAsNullable(this String str)
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
        public static byte? ByteAsNullable(this String str)
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
        public static short? ShortAsNullable(this String str)
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

        public static long? LongAsNullable(this String str)
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
        public static Guid? GuidAsNullable(this String str)
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
