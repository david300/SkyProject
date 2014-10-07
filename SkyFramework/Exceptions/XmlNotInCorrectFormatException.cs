using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Exceptions
{
    public class XmlNotInCorrectFormatException : FacadeException
    {
        public XmlNotInCorrectFormatException()
        {

        }

        public XmlNotInCorrectFormatException(string message)
            : base(message)
        {
        }


        public XmlNotInCorrectFormatException(string message, Exception innerExeption)
            : base(message, innerExeption)
        {
        }

    }
}
