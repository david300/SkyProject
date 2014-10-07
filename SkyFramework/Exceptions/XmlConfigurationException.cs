using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Exceptions
{
    public class XmlConfigurationException : FacadeException
    {
        public XmlConfigurationException()
        {

        }

        public XmlConfigurationException(string message)
            : base(message)
        {
        }


        public XmlConfigurationException(string message, Exception innerExeption)
            : base(message, innerExeption)
        {
        }

    }
}
