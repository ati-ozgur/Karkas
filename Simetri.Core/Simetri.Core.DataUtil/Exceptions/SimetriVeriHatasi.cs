using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Simetri.Core.DataUtil.Exceptions
{
    [Serializable]
    public class SimetriVeriHatasi : Exception
    {
        public SimetriVeriHatasi()
            : base()
        {

        }
        public SimetriVeriHatasi(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public SimetriVeriHatasi(string pMessage)
            : base(pMessage)
        {

        }
        public SimetriVeriHatasi(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }

    }
}
