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
            public SkyConnection()
            {
                this._connection = new SqlConnection(SkyConfiguration.GetInstance().ConnectionString);
            }

            public SkyConnection(bool openConnection)
            {
                this._connection = new SqlConnection(SkyConfiguration.GetInstance().ConnectionString);
                if (openConnection)
                {
                    this.OpenConnection();
                }
            }

            public SkyConnection(string connString) 
            {
                this._connection = new SqlConnection(this._connectionString = connString);
            }

            public SkyConnection(string connString, bool openConnection)
            {
                this._connection = new SqlConnection(this._connectionString = connString);
                if (openConnection)
                {
                    this.OpenConnection();
                }
            }
        #endregion

        #region Public Methods

            internal static DbTransaction GetTransaction()
            {
                string strConnectionString = ""; // VerifyConection(null);
                SqlConnection connection = new SqlConnection(strConnectionString);
                connection.Open();
                return connection.BeginTransaction();
            }

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

            internal DataTable ExecuteDataSet(string sql) 
            {
                try
                {
                    SqlCommand oComm = new SqlCommand(sql, this._connection);
                    SqlDataAdapter oDataAdapter = new SqlDataAdapter(oComm);

                    DataTable ds = new DataTable();
                    oDataAdapter.Fill(ds);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
            }

            internal DataTable ExecuteDataSet(string sql, List<SqlParameter> parameters)
            {
                try
                {
                    SqlCommand oComm = new SqlCommand(sql, this._connection);
                    oComm.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parameters)
                    {
                        oComm.Parameters.Add(item);
                    }

                    SqlDataAdapter oDataAdapter = new SqlDataAdapter(oComm);

                    DataTable ds = new DataTable();
                    oDataAdapter.Fill(ds);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            internal DataTable ExecuteDataSet(string sql, List<SqlParameter> parameters, CommandType type)
            {
                try
                {
                    SqlCommand oComm = new SqlCommand(sql, this._connection);
                    oComm.CommandType = type;
                    foreach (SqlParameter item in parameters)
                    {
                        oComm.Parameters.Add(item);
                    }

                    SqlDataAdapter oDataAdapter = new SqlDataAdapter(oComm);

                    DataTable ds = new DataTable();
                    oDataAdapter.Fill(ds);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            internal void ExecuteNonQuery(string sql) 
            {
                try
                {
                    SqlCommand oComm = new SqlCommand(sql, this._connection);
                    oComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            internal void ExecuteNonQuery(string sql, List<SqlParameter> parameters)
            {
                try
                {
                    SqlCommand oComm = new SqlCommand(sql, this._connection);
                    oComm.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parameters)
                    {
                        oComm.Parameters.Add(item);
                    }

                    oComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            internal void ExecuteNonQuery(string sql, List<SqlParameter> parameters, CommandType type)
            {
                try
                {
                    SqlCommand oComm = new SqlCommand(sql, this._connection);
                    oComm.CommandType = type;
                    foreach (SqlParameter item in parameters)
                    {
                        oComm.Parameters.Add(item);
                    }

                    oComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            internal string ExecuteEscalar(string sql)
            {
                try
                {
                    SqlCommand oComm = new SqlCommand(sql, this._connection);
                    return (string)oComm.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            internal string ExecuteEscalar(string sql, List<SqlParameter> parameters)
            {
                try
                {
                    SqlCommand oComm = new SqlCommand(sql, this._connection);
                    oComm.CommandType = CommandType.Text;

                    foreach (SqlParameter item in parameters)
                    {
                        oComm.Parameters.Add(item);
                    }

                    return (string)oComm.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            internal string ExecuteEscalar(string sql, List<SqlParameter> parameters, CommandType type)
            {
                try
                {
                    SqlCommand oComm = new SqlCommand(sql, this._connection);
                    oComm.CommandType = type;

                    foreach (SqlParameter item in parameters)
                    {
                        oComm.Parameters.Add(item);
                    }

                    return (string)oComm.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            internal void CloseConnection()
            {
                if (this.GetStatus() == State.Open)
                {
                    this._connection.Close();
                }
            }

            internal void OpenConnection() {
                if (this.GetStatus() != State.Open)
                {
                    this._connection.Open();
                }
            }

        #endregion
    }
}
