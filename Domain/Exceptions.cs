using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class InvalidAttributeLengthException : Exception
    {
        public InvalidAttributeLengthException(string message) : base(message) { }
    }

    public class InvalidRegisterDateException : Exception
    {
        public InvalidRegisterDateException(string message) : base(message) { }
    }
}
