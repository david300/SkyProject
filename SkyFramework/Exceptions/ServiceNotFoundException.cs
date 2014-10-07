using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Exceptions
{
    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException()
        {

        }

        public ServiceNotFoundException(string message)
            : base(message)
        {

        }


        public ServiceNotFoundException(string message, Exception innerExeption)
            : base(message, innerExeption)
        {

        }
    }
}
