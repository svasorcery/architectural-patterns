using System.Data.SqlClient;

namespace SvaSorcery.Patterns.Enterprise.Resource.ResourcePool
{
    public class PooledSqlDatabaseConnection : DatabaseResource<SqlConnection>
    {
        private readonly IResourcePool<DatabaseResource<SqlConnection>> _connectionPool;
        private DatabaseResource<SqlConnection> _resource;

        public PooledSqlDatabaseConnection(IResourcePool<DatabaseResource<SqlConnection>> connectionPool)
        {
            _connectionPool = connectionPool;
        }

        public override void Open() => _resource = _connectionPool.GetResource();

        public override void Close() => _connectionPool.PutResource(_resource);
    }
}
