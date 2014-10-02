using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyFramework.Entities;
using System.Data;

namespace SkyFramework.Services
{
    internal static class UsuarioServices
    {
        #region Private Static Methods
            private static Usuario LoadFromRow(DataRow row)
            {
                Usuario u = new Usuario();
                u.Id_Usuario = (decimal)row["Id_Usuario"];
                u.Apellido = row["Apellido"].ToString();
                u.Nombre = row["Nombre"].ToString();
                return u;
            }
        #endregion

        #region Public Static Mothods
            public static Message VerificarPermiso(decimal IdUsuario, string ActionName, SkyFramework.Connection.SkyConnection conn)
            {
                try
                {
                    return new Message(Message.eType.OK, true);
                }
                catch (Exception ex)
                {   
                    throw ex;
                }
            }
            public static Message GetById(decimal Id, SkyFramework.Connection.SkyConnection conn) 
            {
                try
                {
                    DataSet ds = conn.ExecuteDataSet("select * from DatosUsuarios where id = " + Id.ToString());
                    return new Message(Message.eType.OK, "ds count: " + ds.Tables[0].Rows.Count.ToString());
                }
                catch (Exception ex)
                {
                    return new Message(Message.eType.ERR_INESPERADO, ex);
                }
                
            }

            public static Message GetById0(decimal Id)
            {
                //Nestor puto
                return new Message(Message.eType.OK, "No le paso una mierda!");
            }
        #endregion
    }
}
