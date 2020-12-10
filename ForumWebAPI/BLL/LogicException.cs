using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    class LogicException : Exception
    {
        public LogicException() : base() { }
        public LogicException(string message) : base(message) { }
        public LogicException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
