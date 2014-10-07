using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyFramework.Entities
{
    public class Pagina
    {
        #region CONSTRUCTORS

            public Pagina()
            {

            }

        #endregion

        #region PROPERTIES

            private decimal _IdPagina;
            public decimal IdPagina
            {
                get { return _IdPagina; }
                set { _IdPagina = value; }
            }

            private decimal _IdMenu;
            public decimal IdMenu
            {
                get { return _IdMenu; }
                set { _IdMenu = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private string _URL;
            public string URL
            {
                get { return _URL; }
                set { _URL = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            private List<Menu> _Menues;
            public List<Menu> Menues
            {
                get { return _Menues; }
                set { _Menues = value; }
            }
            

        #endregion
    }
}
