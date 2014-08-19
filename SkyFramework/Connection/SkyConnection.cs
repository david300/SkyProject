using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace SkyFramework.Connection
{
    public class SkyConnection
    {
        #region Enums
        public enum State 
        {
            NoConnection,
            Open,
            Closed
        }
        #endregion

        #region Properties
        private SqlConnection _connection = null;
        private DbTransaction _transaction;

        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }        
        #endregion

        #region Constructors
        public SkyConnection(string connString) 
        {
            this._connectionString = connString;
        }
        #endregion

        #region Public Methods
        public SkyConnection.State GetStatus() 
        {
            if (_connection == null) {
                return State.NoConnection;
            }
            else
            {
                if (_connection.State == ConnectionState.Open) 
                {
                    return State.Open;
                }
                else
                {
                    return State.Closed;
                }
            }
        }

        internal DataSet ExecuteDataSet(string sql) 
        {
            return null;
        }
        #endregion
    }
}
