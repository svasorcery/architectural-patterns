using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SvaSorcery.Patterns.Enterprise.Resource.ResourcePool
{
    public class SqlConnectionPool : IResourcePool<DatabaseResource<SqlConnection>>, IDisposable
    {
        private readonly string _connectionString;
        private readonly ICollection<DatabaseResource<SqlConnection>> _availableConnections;
        private readonly ICollection<DatabaseResource<SqlConnection>> _usedConnections;

        public SqlConnectionPool(string connectionString, int initCount)
        {
            _connectionString = connectionString;
            _availableConnections = new List<DatabaseResource<SqlConnection>>();
            _usedConnections = new List<DatabaseResource<SqlConnection>>();

            for (int i = 0; i < initCount; i++)
            {
                _availableConnections.Add(CreateConnection());
            }
        }

        private DatabaseResource<SqlConnection> CreateConnection()
        {
            try
            {
                var db = new SqlConnection(_connectionString);
                var conn = new DatabaseResource<SqlConnection>(db);
                conn.Open();
                return conn;
            }
            catch
            {
                throw;
            }
        }

        public int AvailableCount => _availableConnections.Count;

        public DatabaseResource<SqlConnection> GetResource()
        {
            DatabaseResource<SqlConnection> conn;
            if (AvailableCount == 0)
            {
                conn = CreateConnection();
            }
            else
            {
                conn = _availableConnections.Last();
                _availableConnections.Remove(conn);
            }

            _usedConnections.Add(conn);

            return conn;
        }

        public void PutResource(DatabaseResource<SqlConnection> conn)
        {
            if (conn == null)
                return;

            if (_usedConnections.Remove(conn))
            {
                _availableConnections.Add(conn);
            }
            else
            {
                throw new NullReferenceException("Connection not in the usedConnections array");
            }
        }

        public void Dispose()
        {
            foreach (var conn in _usedConnections)
            {
                PutResource(conn);
            }

            foreach (var conn in _availableConnections)
            {
                conn.Close();
            }
        }
    }
}
