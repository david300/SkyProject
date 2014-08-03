using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Exceptions
{
    public class FacadeException : BusinessLogicException
    {
        public FacadeException()
        {

        }

        public FacadeException(string message)
            : base(message)
        {
        }

        public FacadeException(string message, Exception innerExeption)
            : base(message, innerExeption)
        {
        }
    }
}
