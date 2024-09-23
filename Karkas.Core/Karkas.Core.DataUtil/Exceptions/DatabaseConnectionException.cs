using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Data.Exceptions
{
    [Serializable]
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException()
            : base()
        {

        }
        public DatabaseConnectionException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public DatabaseConnectionException(string pMessage)
            : base(pMessage)
        {

        }
        public DatabaseConnectionException(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }

    }
}

