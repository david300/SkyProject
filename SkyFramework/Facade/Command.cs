using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Facade
{
    public class Command
    {
        private string assembly;
        private string _namespace;

        private string actionName;
        private string serviceMethod;
        private string serviceClass;
        private bool requireSecurity;
        private string errorLog;
        private string succefullLog;
        private string notPermisionLog;

        private bool openedConnection;
        public bool OpenedConnection
        {
            get { return openedConnection; }
            set { openedConnection = value; }
        }

        private bool closeTransaction;
        public bool CloseTransaction
        {
            get { return closeTransaction; }
            set { closeTransaction = value; }
        }

        private bool _makeLog;

        public bool makeLog
        {
            get { return _makeLog; }
            set { _makeLog = value; }
        }


        public string ErrorLog
        {
            get { return errorLog; }
            set { errorLog = value; }
        }

        public string ActionName
        {
            get { return actionName; }
            set { actionName = value; }
        }

        public bool RequireSecurity
        {
            get { return requireSecurity; }
            set { requireSecurity = value; }
        }

        public string ServiceClass
        {
            get { return serviceClass; }
            set { serviceClass = value; }
        }

        public string ServiceMethod
        {
            get { return serviceMethod; }
            set { serviceMethod = value; }
        }

        public string SuccefullLog
        {
            get { return succefullLog; }
            set { succefullLog = value; }
        }

        public string NotPermisionLog
        {
            get { return notPermisionLog; }
            set { notPermisionLog = value; }
        }

        public string Assembly
        {
            get { return assembly; }
            set { assembly = value; }
        }

        public string Namespace
        {
            get { return _namespace; }
            set { _namespace = value; }
        }
    }
}
