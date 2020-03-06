using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1.Lib
{
    class SqlDataHelper : IDisposable
    {
        IDbTransaction _transaction;

        SqlConnection _connection;

        public SqlDataHelper(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
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

        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                    if (_transaction != null)
                        _transaction.Rollback();

                    _transaction = null;

                    _connection.Dispose();
                    _connection = null;
                }

                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.

                disposedValue = true;
            }
        }

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~SqlDataHelper()
        // {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
