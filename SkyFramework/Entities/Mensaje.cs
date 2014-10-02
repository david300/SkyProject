using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Entities
{
    public class Message
    {
        #region Enums

            public enum eType { OK, ERR_CUSTOM, ERR_INESPERADO }

        #endregion

        #region Properties

            private eType _ID;
            public eType ID
            {
                get { return _ID; }
                set { _ID = value; }
            }

            private string _description = string.Empty;          // Cadena para guardar un mensaje o cualquier otra info en forma de cadena.
            public string Descripcion
            {
                get { return _description; }
                set { _description = value; }
            }

            private object _object = null;                  // Para cualquier objeto asociado
            public object Object
            {
                get { return _object; }
                set { _object = value; }
            }

            private Exception _exception = null;                  // Exepcion devulta en caso de Errores Ineperado
            public Exception Exception
            {
                get { return _exception; }
                set { _exception = value; }

            }

        #endregion

        #region Constructors

            public Message()
            {
                // default
            }
            public Message(eType type)
            {
                _ID = type;
                _description = string.Empty;
                _object = null;
                _exception = null;
            }

            public Message(eType type, string description)
            {
                _ID = type;
                _description = description;
                _object = null;
                _exception = null;
            }

            public Message(eType type, object obj)
            {
                _ID = type;
                _description = type.ToString();
                _object = obj;
                _exception = null;
            }

            public Message(eType type, Exception ex)
            {
                _ID = type;
                _description = ex.Message;
                _object = null;
                _exception = ex;
            }

            public Message(eType type, string description, object obj)
            {
                _ID = type;
                _description = description;
                _object = obj;
                _exception = null;
            }

            public Message(eType type, string description, object obj, Exception pexException)
            {
                _ID = type;
                _description = description;
                _object = obj;
                _exception = pexException;
            }
        #endregion
    }
}
