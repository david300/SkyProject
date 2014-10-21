using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkyFramework.Facade;

namespace SkyProject.Config.Base
{
    public class SkyBase : System.Web.UI.Page
    {
        private Facade _facade;
        public Facade Facade
        {
            get { return _facade; }
            set { _facade = value; }
        }


        protected override void OnPreInit(EventArgs e)
        {
            if (Session["sessionBean"] == null) {
                SessionBean session = new SessionBean();
                session.Usuario = new SkyFramework.Entities.Usuario();
                session.Usuario.IdUsuario = 1000;
                Session["sessionBean"] = session;
            }

            SkyFramework.Connection.SkyConfiguration.GetInstance().ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mainConnection"].ConnectionString;
            Facade = new Facade(this.Context);
        }
    }
}