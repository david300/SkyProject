using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Exceptions
{
    public class ServiceNotFound : Exception
    {
        public ServiceNotFound()
        {

        }

        public ServiceNotFound(string message)
            : base(message)
        {

        }


        public ServiceNotFound(string message, Exception innerExeption)
            : base(message, innerExeption)
        {

        }
    }
}
