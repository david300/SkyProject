using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Exceptions
{
    public class XmlConfiguration : FacadeException
    {
        public XmlConfiguration()
        {

        }

        public XmlConfiguration(string message)
            : base(message)
        {
        }


        public XmlConfiguration(string message, Exception innerExeption)
            : base(message, innerExeption)
        {
        }

    }
}
