using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1
{
    public class SqlDataHelper : IDisposable
    {
        IDbTransaction _transaction;

        SqlConnection _connection;

        public SqlDataHelper(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Rollback();

            _transaction = null;

            _connection.Dispose();
            _connection = null;
        }

        public void BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            _transaction = _connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
            _transaction = null;

            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
            _transaction = null;

            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        public DataTable GetDataTable(string sql, object paramObj = null)
        {
            using (var cmd = new SqlCommand(sql, _connection))
            {
                if (_transaction == null)
                    _connection.Open();

                if (paramObj != null)
                {
                    foreach (var prop in paramObj.GetType().GetProperties())
                    {
                        cmd.Parameters.Add(new SqlParameter(prop.Name, prop.GetValue(paramObj)));
                    }
                }

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                if (_transaction == null)
                    _connection.Close();

                return dt;
            }
        }
        public int Execute(string sql, object paramObj = null)
        {
            using (var cmd = new SqlCommand(sql, _connection))
            {
                if (_transaction == null)
                    _connection.Open();

                if (paramObj != null)
                {
                    foreach (var prop in paramObj.GetType().GetProperties())
                    {
                        cmd.Parameters.Add(new SqlParameter(prop.Name, prop.GetValue(paramObj)));
                    }
                }

                if (_transaction == null)
                    _connection.Close();

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
