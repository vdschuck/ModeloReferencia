using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DAL
{
    public abstract class MyConnection : IDisposable
    {
        private IDbConnection _customConnection;
        private IDbTransaction _customTransaction;

        public IDbConnection OpenConnection()
        {
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public IDbConnection OpenConnection(string connectionString)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MyConnection"].ToString();
            }
        }

        public IDbConnection Connection
        {
            get
            {
                if (_customTransaction == null || (_customConnection.State == ConnectionState.Closed || _customConnection.State == ConnectionState.Broken))
                    _customConnection = OpenConnection();

                return _customConnection;
            }
        }

        public void CreateTransaction()
        {
            if (_customTransaction == null)
                _customTransaction = Connection.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public IDbTransaction GetTransaction()
        {
            if (_customTransaction != null)
                return _customTransaction;

            return _internalTransaction ??
                   (_internalTransaction =
                       _customConnection.BeginTransaction(IsolationLevel.ReadUncommitted));
        } 

        public void Dispose()
        {
            CloseConnection();
        }
        
        public int Execute(string sql, object param = null)
        {
            int dataReturn;

            try
            {
                dataReturn = Connection.Execute(sql, param, GetTransaction(), 30);

                if (_customTransaction == null)
                    CloseConnection();
            }
            catch (Exception)
            {
                if (_customTransaction == null)
                    CloseConnection();

                throw;
            }
            return dataReturn;
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            IEnumerable<T> dataResult;
            try
            {
                dataResult = Connection.Query<T>(sql, param, GetTransaction());

                if (_customTransaction == null)
                    CloseConnection();

            }
            catch (Exception)
            {
                if (_customTransaction == null)
                    CloseConnection();
                throw;
            }
            return dataResult;
        }

        private void CloseConnection()
        {
            if (_customConnection != null)
            {
                if (_customConnection.State != ConnectionState.Closed ||
                    _customConnection.State != ConnectionState.Broken)
                    _customConnection.Close();
            }
        }

        public IDbTransaction _internalTransaction { get; set; }

    }

}
