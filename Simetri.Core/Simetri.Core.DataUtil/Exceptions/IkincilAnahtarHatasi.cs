using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Simetri.Core.DataUtil.Exceptions
{
    [Serializable]
    public class IkincilAnahtarHatasi : SimetriVeriHatasi
    {
        public IkincilAnahtarHatasi()
            : base()
        {

        }
        public IkincilAnahtarHatasi(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public IkincilAnahtarHatasi(string pMessage)
            : base(pMessage)
        {

        }
        public IkincilAnahtarHatasi(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }

    }
}
