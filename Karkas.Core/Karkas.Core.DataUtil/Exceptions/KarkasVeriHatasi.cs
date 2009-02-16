using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Core.DataUtil.Exceptions
{
    [Serializable]
    public class KarkasVeriHatasi : Exception
    {
        public KarkasVeriHatasi()
            : base()
        {

        }
        public KarkasVeriHatasi(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public KarkasVeriHatasi(string pMessage)
            : base(pMessage)
        {

        }
        public KarkasVeriHatasi(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }

    }
}

