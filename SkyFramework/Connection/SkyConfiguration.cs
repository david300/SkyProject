using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Connection
{
    public class SkyConfiguration
    {
        private static string _connectionString = "";
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }

            set
            {
                if (SkyConfiguration.GetInstance().ConnectionString != (string)value)
                {
                    SkyConfiguration.GetInstance().Renew();
                }

                _connectionString = value;
            }
        }

        private static SkyConfiguration _instance;
        private SkyConfiguration() { }

        public static SkyConfiguration GetInstance() 
        {
            if (_instance == null) {
                _instance = new SkyConfiguration();
            }

            return _instance;
        }

        internal void Renew() {
            _instance = null;
        }

    }
}
