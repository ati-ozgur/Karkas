using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Simetri.Core.DataUtil.Exceptions
{
    [Serializable]
    public class VeritabaniBaglantiHatasi : Exception
    {
        public VeritabaniBaglantiHatasi()
            : base()
        {

        }
        public VeritabaniBaglantiHatasi(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public VeritabaniBaglantiHatasi(string pMessage)
            : base(pMessage)
        {

        }
        public VeritabaniBaglantiHatasi(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }

    }
}
