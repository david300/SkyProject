using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyFramework.Entities
{
    public class TipoMenu
    {
        #region CONSTRUCTORS

            public TipoMenu()
            {

            }

        #endregion

        #region PROPERTIES

            private decimal _IdTipoMenu;
            public decimal IdTipoMenu
            {
                get { return _IdTipoMenu; }
                set { _IdTipoMenu = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
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
