using System;
using System.Runtime.Serialization;

namespace CM.Customers.Business
{
    public class CodeNotFoundException : Exception
    {
        public CodeNotFoundException()
        {
        }

        public CodeNotFoundException(string message) : base(message)
        {
        }

        public CodeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CodeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
