using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.Helper.Exceptions
{
    public class NotMatchException:Exception
    {
        public NotMatchException() 
        {

        }

        public NotMatchException(string message) : base(message) 
        {

        }

        public NotMatchException(string message, Exception innerException) : base(message, innerException) 
        {
        
        }

    }
}
