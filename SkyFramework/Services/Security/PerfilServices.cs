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
    public class PerfilServices
    {
        #region Private Static Methods
            private static Perfil LoadFromRow(DataRow row)
            {
                Perfil p = new Perfil();
                p.IdPerfil = (decimal)row["IdPerfil"];
                p.Descripcion = row["Descripcion"].ToString();
                p.Activo = (bool)row["Activo"];
                return p;
            }
        #endregion

        #region Public Static Mothods
            public static Message GetPerfilByUsuario(decimal idUsuario, SkyFramework.Connection.SkyConnection conn)
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    parameters.Add(new SqlParameter("@Action", "GetPerfilByUsuario"));
                    parameters.Add(new SqlParameter("@IdUsuario", idUsuario));

                    DataTable dt = conn.ExecuteDataSet("sp_Perfil", parameters, CommandType.StoredProcedure);

                    List<Perfil> perfiles = new List<Perfil>();
                    foreach (DataRow row in dt.Rows)
                    {
                        perfiles.Add(LoadFromRow(row));
                    }                           

                    return new Message(Message.eType.OK, perfiles);
                }
                catch (Exception ex)
                {
                    return new Message(Message.eType.ERR_INESPERADO, ex);
                }
            }
        #endregion
    }
}
