using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Core.Onaylama
{
    [Serializable]
    public class OnaylamaHatasi : Exception
    {

        public OnaylamaHatasi()
            : base()
        {

        }
        public OnaylamaHatasi(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public OnaylamaHatasi(string pMessage)
            : base(pMessage)
        {

        }
        public OnaylamaHatasi(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }


    }
}
