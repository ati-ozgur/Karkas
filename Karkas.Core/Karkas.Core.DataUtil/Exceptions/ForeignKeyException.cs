using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Core.DataUtil.Exceptions
{
    [Serializable]
    public class ForeignKeyException : KarkasDataException
    {
        public ForeignKeyException()
            : base()
        {

        }
        public ForeignKeyException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public ForeignKeyException(string pMessage)
            : base(pMessage)
        {

        }
        public ForeignKeyException(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }

    }
}

