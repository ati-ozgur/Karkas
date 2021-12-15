using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Core.DataUtil.Exceptions
{
    [Serializable]
    public class WrongSQLQueryException : KarkasDataException
    {
        public WrongSQLQueryException()
            : base()
        {

        }
        public WrongSQLQueryException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public WrongSQLQueryException(string pMessage)
            : base(pMessage)
        {

        }
        public WrongSQLQueryException(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }

    }
}

