using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyFramework.Entities;
using System.Data;

namespace SkyFramework.Services
{
    public static class UsuarioServices
    {
        #region Private Static Methods
            private static Usuario LoadFromRow(DataRow row){
                Usuario u = new Usuario();

                u.Id_Usuario = (decimal)row["Id_Usuario"];
                u.Apellido = row["Apellido"].ToString();
                u.Nombre = row["Nombre"].ToString();

                return u;
            }
        #endregion

        #region Public Static Mothods
            public static Mensaje GetById(decimal Id, SkyFramework.Connection.SkyConnection conn) 
            {
                conn.ExecuteDataSet("EE");
                return new Mensaje(Mensaje.eTipo.OK, "Le paso una conexión!");
            }

            public static Mensaje GetById0(decimal Id)
            {
                return new Mensaje(Mensaje.eTipo.OK, "No le paso una mierda!");
            }
        #endregion
    }
}
