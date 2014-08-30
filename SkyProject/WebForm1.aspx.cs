using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkyProject
{
    public partial class WebForm1 : Config.Base.SkyBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                SkyFramework.Entities.Mensaje mensaje = f.InvoqueService("Usuario.Security.GetById", new object[] { (decimal)1 });
                Response.Write(mensaje.Descripcion);
            }
        }
    }
}