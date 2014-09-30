using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SkyFramework.Exceptions
{
    public class TargetParameterCountException : Exception
    {
        private List<ParameterInfo> _parameters;
        public List<ParameterInfo> Parameters
        {
            get { return _parameters; }
        }

        public TargetParameterCountException(List<ParameterInfo> parameters)
        {
            this._parameters = parameters;
        }

        public TargetParameterCountException(string message, List<ParameterInfo> parameters)
            : base(message)
        {
            this._parameters = parameters;
        }


        public TargetParameterCountException(string message, Exception innerExeption, List<ParameterInfo> parameters)
            : base(message, innerExeption)
        {
            this._parameters = parameters;
        }

        public static string GetParameters(List<ParameterInfo> _parameters) 
        {
            string _sParameters = "{ ";
            bool isComa = false;
            foreach (ParameterInfo item in _parameters)
            {
                _sParameters += (isComa ? ", " : "") + "("+ item.ParameterType.ToString() +") " + item.Name;
                isComa = true;
            }

            return _sParameters + " }";
        }
    }
}
