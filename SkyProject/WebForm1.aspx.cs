using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkyProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                SkyFramework.Facade.Facade f = new SkyFramework.Facade.Facade();
                Response.Write(f.InvoqueService("Usuario.Security.GetById", new object[]{ (decimal)1 }).Descripcion);
            }
        }
    }
}