using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyFramework.Entities;
using System.Data;
using System.Data.SqlClient;

namespace SkyFramework.Services
{
    internal static class UsuarioServices
    {
        #region Private Static Methods
            private static Usuario LoadFromRow(DataRow row)
            {
                Usuario u = new Usuario();
                u.IdUsuario = (decimal)row["IdUsuario"];
                u.Apellido = row["Apellido"].ToString();
                u.Nombre = row["Nombre"].ToString();
                u.Password = row["Password"].ToString();
                u.Username = row["Username"].ToString();
                u.Perfiles = new List<Perfil>();
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

            public static Message Login(string username, string password, SkyFramework.Connection.SkyConnection conn) 
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    parameters.Add(new SqlParameter("@Username", username));
                    parameters.Add(new SqlParameter("@Password", password));

                    DataTable dt = conn.ExecuteDataSet("sp_Usuario_Login", parameters, CommandType.StoredProcedure);

                    if (dt.Rows.Count > 0) 
                    {
                        DataRow row = dt.Rows[0];
                        Usuario usuario = LoadFromRow(row);

                        Message mensajePerfiles = PerfilServices.GetPerfilByUsuario(usuario.IdUsuario, conn);

                        if (mensajePerfiles.ID == Message.eType.OK) 
                        {
                            List<Perfil> perfiles = (List<Perfil>)mensajePerfiles.Object;
                            foreach (Perfil perfil in perfiles)
                            {
                                usuario.Perfiles.Add(perfil);
                            }
                        }
                        else
                        {
                            throw new Exception(mensajePerfiles.Descripcion);
                        }

                        return new Message(Message.eType.OK, "Acceso Correcto", usuario);
                    }
                    else
                    {
                        return new Message(Message.eType.ERR_CUSTOM, "Usuario y/o Contraseña inexistente.");
                    }                    
                }
                catch (Exception ex)
                {
                    return new Message(Message.eType.ERR_INESPERADO, ex);
                }
            }
            
            public static Message GetById(decimal Id, SkyFramework.Connection.SkyConnection conn) 
            {
                try
                {
                    DataTable dt = conn.ExecuteDataSet("select * from DatosUsuarios where id = " + Id.ToString());
                    return new Message(Message.eType.OK, "ds count: " + dt.Rows.Count.ToString());
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
