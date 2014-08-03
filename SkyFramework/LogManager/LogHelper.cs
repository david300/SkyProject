using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.LogManager
{
    /*Clase que nos serviría para guardar logs*/
    public class LogHelper
    {
        private int SisId;
        private static string ConnString;
        
        public enum eErrorLevel
        {
            Debug = 0,
            Info,
            Warn,
            Error,
            Fatal
        }

        public LogHelper(int SisId)
        { 

        }

        public void SetLog(int UserId, string Menssage, eErrorLevel Level, int? OpcionalCodError)
        { 

        }
    }
}
