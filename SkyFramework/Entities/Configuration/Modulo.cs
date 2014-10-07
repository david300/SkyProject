using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyFramework.Entities
{
    public class Modulo
    {
        #region CONSTRUCTORS
            public Modulo()
            {
            }
        #endregion

        #region PROPERTIES

            private decimal _IdModulo;
            public decimal IdModulo
            {
                get { return _IdModulo; }
                set { _IdModulo = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private string _Codigo;
            public string Codigo
            {
                get { return _Codigo; }
                set { _Codigo = value; }
            }

            private string _Path;
            public string Path
            {
                get { return _Path; }
                set { _Path = value; }
            }

            private DateTime _TimeStamp;
            public DateTime TimeStamp
            {
                get { return _TimeStamp; }
                set { _TimeStamp = value; }
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
