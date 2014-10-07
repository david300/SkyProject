using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Entities
{
    public class Perfil
    {
        #region CONSTRUCTORS
            public Perfil()
            {

            }
        #endregion

        #region PROPERTIES
            private decimal _IdPerfil;
            public decimal IdPerfil
            {
                get { return _IdPerfil; }
                set { _IdPerfil = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            private List<Accion> _Acciones;
            public List<Accion> Acciones
            {
                get { return _Acciones; }
                set { _Acciones = value; }
            }
        #endregion
    }
}
