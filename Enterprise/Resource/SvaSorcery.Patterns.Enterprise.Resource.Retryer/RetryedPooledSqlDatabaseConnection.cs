using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.Resource.ResourcePool;

namespace SvaSorcery.Patterns.Enterprise.Resource.Retryer
{
    public class RetryedPooledSqlDatabaseConnection : DatabaseResource<SqlConnection>
    {
        private readonly IResourcePool<DatabaseResource<SqlConnection>> _connectionPool;
        private DatabaseResource<SqlConnection> _resource;
        private readonly DatabaseConnectionRetryer _retryer;
        private readonly int _attemptsCount;

        public RetryedPooledSqlDatabaseConnection(IResourcePool<DatabaseResource<SqlConnection>> connectionPool, int attemptsCount = 3)
        {
            _connectionPool = connectionPool;
            _retryer = new DatabaseConnectionRetryer();
            _attemptsCount = attemptsCount;
        }

        public override void Open()
            => _resource = _connectionPool.GetResource();

        public override void Close()
            => _connectionPool.PutResource(_resource);

        public override void Execute(string expression, IReadOnlyDictionary<string, string> param = null)
        {
            void aCommand() => _resource.Execute(expression, param);
            Open();
            _retryer.Do(aCommand, new TimeSpan(0, 0, 1), _attemptsCount);
        }

        public override void Execute<T>(string expression, T[] param = null)
        {
            void aCommand() => _resource.Execute(expression, param);
            Open();
            _retryer.Do(aCommand, new TimeSpan(0, 0, 1), _attemptsCount);
        }
    }
}
