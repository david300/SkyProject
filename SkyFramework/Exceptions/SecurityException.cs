using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Exceptions
{
    public class SecurityException : BusinessLogicException
    {
        public SecurityException()
        {

        }

        public SecurityException(string message)
            : base(message)
        {
        }

        public SecurityException(string message, Exception innerExeption)
            : base(message, innerExeption)
        {
        }

    }
}
