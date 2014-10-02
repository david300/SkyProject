using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFramework.Facade
{
    public class Command
    {
        #region Properties
            private string _assembly;
            public string Assembly
            {
                get { return _assembly; }
                set { _assembly = value; }
            }

            private string _namespace;
            public string Namespace
            {
                get { return _namespace; }
                set { _namespace = value; }
            }

            private string _actionName;
            public string ActionName
            {
                get { return _actionName; }
                set { _actionName = value; }
            }

            private string _serviceMethod;
            public string ServiceMethod
            {
                get { return _serviceMethod; }
                set { _serviceMethod = value; }
            }

            private string _serviceClass;
            public string ServiceClass
            {
                get { return _serviceClass; }
                set { _serviceClass = value; }
            }

            private bool _requireSecurity;
            public bool RequireSecurity
            {
                get { return _requireSecurity; }
                set { _requireSecurity = value; }
            }

            private string _errorLog;
            public string ErrorLog
            {
                get { return _errorLog; }
                set { _errorLog = value; }
            }

            private string _successfulLog;
            public string SuccessfullLog
            {
                get { return _successfulLog; }
                set { _successfulLog = value; }
            }

            private string _noPermisionLog;
            public string NotPermisionLog
            {
                get { return _noPermisionLog; }
                set { _noPermisionLog = value; }
            }

            private bool openedConnection;
            public bool OpenedConnection
            {
                get { return openedConnection; }
                set { openedConnection = value; }
            }

            private bool _closeTransaction;
            public bool CloseTransaction
            {
                get { return _closeTransaction; }
                set { _closeTransaction = value; }
            }

            private bool _makeLog;
            public bool makeLog
            {
                get { return _makeLog; }
                set { _makeLog = value; }
            }
        #endregion
    }
}
