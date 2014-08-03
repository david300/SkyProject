using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Entities
{
    public class Mensaje
    {
        #region ###.Enumerados.###

        public enum eTipo { OK, ERR_CUSTOM, ERR_INESPERADO }

        #endregion

        #region ###.Variables Privadas.###

        private eTipo _eID;
        private string _sDescripcion = string.Empty;          // Cadena para guardar un mensaje o cualquier otra info en forma de cadena.
        private object _oObj = null;                  // Para cualquier objeto asociado
        private Exception _exException = null;                  // Exepcion devulta en caso de Errores Ineperado

        #endregion

        #region ###.Atributos.###
        public eTipo ID
        {
            get { return _eID; }
            set { _eID = value; }
        }

        public string Descripcion
        {
            get { return _sDescripcion; }
            set { _sDescripcion = value; }
        }

        public object Obj
        {
            get { return _oObj; }
            set { _oObj = value; }
        }

        public Exception Exception
        {
            get { return _exException; }
            set { _exException = value; }

        }

        #endregion

        #region ###.Constructores.###

        public Mensaje()
        {
            // default
        }
        public Mensaje(eTipo peTipo)
        {
            _eID = peTipo;
            _sDescripcion = string.Empty;
            _oObj = null;
            _exException = null;
        }

        public Mensaje(eTipo peTipo, string psDescripcion)
        {
            _eID = peTipo;
            _sDescripcion = psDescripcion;
            _oObj = null;
            _exException = null;
        }

        public Mensaje(eTipo peTipo, string psDescripcion, object poObj)
        {
            _eID = peTipo;
            _sDescripcion = psDescripcion;
            _oObj = poObj;
            _exException = null;
        }

        public Mensaje(eTipo peTipo, string psDescripcion, object poObj, Exception pexException)
        {
            _eID = peTipo;
            _sDescripcion = psDescripcion;
            _oObj = poObj;
            _exException = pexException;
        }



        #endregion
    }
}
