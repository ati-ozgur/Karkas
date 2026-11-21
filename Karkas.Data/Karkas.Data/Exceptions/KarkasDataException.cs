using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Karkas.Data.Tracing;

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

        /// <summary>Query id of the failed query (see KarkasTracing), or null.</summary>
        public string QueryId
        {
            get { return KarkasTracing.GetQueryId(this); }
        }

        /// <summary>Execution id of the failed query run (see KarkasTracing), or null.</summary>
        public string ExecutionId
        {
            get { return KarkasTracing.GetExecutionId(this); }
        }

        /// <summary>The message, followed by the query and execution ids when they are known.</summary>
        public override string Message
        {
            get
            {
                string queryId = QueryId;
                if (queryId == null)
                {
                    return base.Message;
                }
                return string.Format("{0} [QueryId: {1}, ExecutionId: {2}]", base.Message, queryId, ExecutionId);
            }
        }

    }
}

