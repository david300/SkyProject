using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Entities
{
    public class Accion
    {
        #region CONSTRUCTORS
            public Accion()
            {
            }
        #endregion

        #region PROPERTIES

            private decimal _IdAccion;
            public decimal IdAccion
            {
                get { return _IdAccion; }
                set { _IdAccion = value; }
            }

            private string _Codigo;
            public string Codigo
            {
                get { return _Codigo; }
                set { _Codigo = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }
        #endregion
    }
}
