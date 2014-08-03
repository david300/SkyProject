using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SkyFramework.Facade;
using System.Web;
using System.Web.UI;

namespace SkyFramework.Facade
{
    public class Facade
    {
        private int intUserId;

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
            //SessionBean s = (SessionBean)context.Session["sessionBean"];
            //if ((s == null) || (s.Usuario == null) || ((s.Usuario.Id_Usuario == null))
            //{
            //    context.Session.Abandon();
            //    FormsAuthentication.SignOut();
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            //else
            //{
            //    intUserId = s.Usuario.Usuario.UsuID;
            //}

        }

        public Object InvoqueService(string method, object[] arguments)
        {
            try
            {
                Dispatcher disp = Dispatcher.GetInstance(intUserId);
                return disp.SendService(method, arguments);

            }
            catch (Exceptions.ServiceNotFound ex)
            {
                throw ex;
            }
        }
    }
}
