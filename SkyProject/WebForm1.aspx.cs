﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyFramework.Entities;

namespace SkyProject
{
    public partial class WebForm1 : Config.Base.SkyBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                Message mensaje = Facade.InvoqueService("Usuario.Security.GetBy Id", new object[] { (decimal)1000 });
                
                Response.Write(mensaje.Descripcion);
            }
        }
    }
}