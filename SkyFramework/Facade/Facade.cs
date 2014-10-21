using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SkyFramework.Facade;
using System.Configuration;
using System.Web.UI;
using SkyFramework.Entities;

namespace SkyFramework.Facade
{
    public class Facade
    {
        #region Properties
            private decimal _IdUser;
            private string _connString = "";
        #endregion

        #region Contructors
            public Facade()
            {
                this._IdUser = 0;
            }

            private Facade(int UserId)
            {
                this._IdUser = UserId;
            }
        
            public Facade(HttpContext context)
            {
                VerifyContext(context);
            }

            public Facade(HttpContext context, string connString)
            {
                VerifyContext(context);
                SkyFramework.Connection.SkyConfiguration.GetInstance().ConnectionString = connString;
            }
        #endregion

        #region Private Methods
            private void VerifyContext(HttpContext context)
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
                    this._IdUser = s.Usuario.IdUsuario;
                }
            }

            private Message InvoqueThis(string methodName, List<Object> arguments) 
            {
                try
                {
                    Dispatcher dispatcher = Dispatcher.GetInstance(this._IdUser);
                    return (Message)dispatcher.SendService(methodName, arguments);
                }
                catch (Exceptions.TargetParameterCountException tpcEx)
                {
                    throw tpcEx;
                }
                catch (Exceptions.ServiceNotFoundException ex)
                {
                    throw ex;
                }
            }
        #endregion

        #region Public Methods
            public Message InvoqueService(string methodName, List<Object> arguments)
            {
                return this.InvoqueThis(methodName, arguments);
            }

            public Message InvoqueService(string methodName, object[] arguments)
            {
                return this.InvoqueThis(methodName, arguments.ToList());
            }
        #endregion
    }
}
