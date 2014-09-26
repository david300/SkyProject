using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SkyFramework.Facade;
using System.Configuration;
using System.Web.UI;

namespace SkyFramework.Facade
{
    public class Facade
    {
        private decimal intUserId;

        public Facade()
        {
            intUserId = 0;
        }

        private Facade(int UserId)
        {
            intUserId = UserId;
        }
        
        
        public Facade(HttpContext context)
        {
            //Controlaría el acceso a toda la mierda
            SessionBean s = (SessionBean)context.Session["sessionBean"];
            if ((s == null) || (s.Usuario == null))
            {
                context.Session.Abandon();
                context.Response.Redirect("Login.aspx");
            }
            else
            {
                intUserId = s.Usuario.Id_Usuario;
            }

        }

        public SkyFramework.Entities.Mensaje InvoqueService(string method, object[] arguments)
        {
            try
            {
                Dispatcher disp = Dispatcher.GetInstance(intUserId);
                return (SkyFramework.Entities.Mensaje)disp.SendService(method, arguments);
            }
            catch (Exceptions.ServiceNotFound ex)
            {
                throw ex;
            }
        }
    }
}
