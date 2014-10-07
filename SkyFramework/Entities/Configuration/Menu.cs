using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyFramework.Entities;

namespace SkyFramework.Entities
{
    public class Menu
    {
        #region CONSTRUCTORS

            public Menu()
            {

            }

        #endregion

        #region PROPERTIES

            private decimal _IdMenu;
            public decimal IdMenu
            {
                get { return _IdMenu; }
                set { _IdMenu = value; }
            }

            private Modulo _Modulo;
            public Modulo Modulo
            {
                get { return _Modulo; }
                set { _Modulo = value; }
            }
            
            

            private Menu _MenuPadre;
            public Menu MenuPadre
            {
                get { return _MenuPadre; }
                set { _MenuPadre = value; }
            }

            private TipoMenu _TipoMenu;
            public TipoMenu TipoMenu
            {
                get { return _TipoMenu; }
                set { _TipoMenu = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private int? _Orden;
            public int? Orden
            {
                get { return _Orden; }
                set { _Orden = value; }
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

            private Pagina _Pagina;
            public Pagina Pagina
            {
                get { return _Pagina; }
                set { _Pagina = value; }
            }

        #endregion
    }
}
