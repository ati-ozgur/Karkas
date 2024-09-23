using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Data.Exceptions
{
    public class UniqueKeyConstraintException : KarkasDataException
    {
        public UniqueKeyConstraintException()
            : base()
        {

        }
        public UniqueKeyConstraintException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public UniqueKeyConstraintException(string pMessage)
            : base(pMessage)
        {

        }
        public UniqueKeyConstraintException(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }
    }
}

