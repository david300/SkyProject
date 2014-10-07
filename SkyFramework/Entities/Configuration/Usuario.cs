using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Entities
{
    public class Usuario
    {
        #region Private Properties
            private decimal _Id_Usuario;
            public decimal Id_Usuario
            {
                get { return _Id_Usuario; }
                set { _Id_Usuario = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _Apellido;
            public string Apellido
            {
                get { return _Apellido; }
                set { _Apellido = value; }
            }
        #endregion

        #region Contructors
            public Usuario() { }
        #endregion

    }
}
