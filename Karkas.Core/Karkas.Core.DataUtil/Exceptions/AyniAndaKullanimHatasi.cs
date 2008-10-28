using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Core.DataUtil.Exceptions
{
    public class AyniAndaKullanimHatasi : KarkasVeriHatasi
    {
        public AyniAndaKullanimHatasi()
            : base()
        {

        }
        public AyniAndaKullanimHatasi(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public AyniAndaKullanimHatasi(string pMessage)
            : base(pMessage)
        {

        }
        public AyniAndaKullanimHatasi(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }
    }
}
