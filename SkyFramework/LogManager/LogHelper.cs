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

        public void SetLog(decimal UserId, string Menssage, eErrorLevel Level, int? OpcionalCodError)
        { 

        }
    }
}
