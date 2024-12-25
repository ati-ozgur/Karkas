using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Data.Exceptions
{
    [Serializable]
    public class KarkasDataException : Exception
    {
        public KarkasDataException()
            : base()
        {

        }

        public KarkasDataException(string pMessage)
            : base(pMessage)
        {

        }
        public KarkasDataException(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }

    }
}

