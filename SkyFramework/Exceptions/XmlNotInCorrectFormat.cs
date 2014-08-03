using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Exceptions
{
    public class XmlNotInCorrectFormat : FacadeException
    {
        public XmlNotInCorrectFormat()
        {

        }

        public XmlNotInCorrectFormat(string message)
            : base(message)
        {
        }


        public XmlNotInCorrectFormat(string message, Exception innerExeption)
            : base(message, innerExeption)
        {
        }

    }
}
