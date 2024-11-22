using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.Helper.Exceptions
{
    public class DuplicateDataException : Exception
    {
        public DuplicateDataException() { }
        public DuplicateDataException(string message) : base(message) { }
        public DuplicateDataException(string message, Exception innerException) : base(message, innerException) { }
    }
}
