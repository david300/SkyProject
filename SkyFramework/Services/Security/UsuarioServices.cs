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
            public static Mensaje VerificarPermiso(decimal IdUsuario, string ActionName, SkyFramework.Connection.SkyConnection conn)
            {
                try
                {
                    return new Mensaje(Mensaje.eTipo.OK, true);
                }
                catch (Exception ex)
                {   
                    throw ex;
                }
            }
            public static Mensaje GetById(decimal Id, SkyFramework.Connection.SkyConnection conn) 
            {
                try
                {
                    DataSet ds = conn.ExecuteDataSet("select * ferom DatosUsuarios where id = " + Id.ToString());
                    return new Mensaje(Mensaje.eTipo.OK, "ds count: " + ds.Tables[0].Rows.Count.ToString());
                }
                catch (Exception ex)
                {
                    return new Mensaje(Mensaje.eTipo.ERR_INESPERADO, ex);
                }
                
            }

            public static Mensaje GetById0(decimal Id)
            {
                //Nestor puto
                return new Mensaje(Mensaje.eTipo.OK, "No le paso una mierda!");
            }
        #endregion
    }
}
