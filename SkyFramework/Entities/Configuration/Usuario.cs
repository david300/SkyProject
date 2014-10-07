using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Entities
{
    public class Usuario
    {
        #region CONSTRUCTORS

        public Usuario()
        {

        }

        #endregion

        #region PROPERTIES

        private decimal _IdUsuario;
        public decimal IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
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

        private DateTime _TimeStamp;
        public DateTime TimeStamp
        {
            get { return _TimeStamp; }
            set { _TimeStamp = value; }
        }

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private List<Perfil> _Perfiles;
        public List<Perfil> Perfiles
        {
            get { return _Perfiles; }
            set { _Perfiles = value; }
        }

        #endregion

    }
}
