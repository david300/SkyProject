using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Exceptions
{
    public class SecurityExceptions : BusinessLogicException
    {
        public SecurityExceptions()
        {

        }

        public SecurityExceptions(string message)
            : base(message)
        {
        }

        public SecurityExceptions(string message, Exception innerExeption)
            : base(message, innerExeption)
        {
        }

    }
}
