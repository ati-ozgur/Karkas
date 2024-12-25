using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Data.Exceptions
{
    [Serializable]
    public class ForeignKeyException : KarkasDataException
    {
        public ForeignKeyException()
            : base()
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

