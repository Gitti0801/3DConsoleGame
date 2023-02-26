using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ThreeDimensionalConsoleGame.Exceptions
{
    public class ObjectUngeneratableException : Exception
    {
        public ObjectUngeneratableException()
        {
        }

        public ObjectUngeneratableException(string message) : base(message)
        {
        }

        public ObjectUngeneratableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
