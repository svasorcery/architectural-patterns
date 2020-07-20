using System.Data.SqlClient;

namespace SvaSorcery.Patterns.Enterprise.Resource.ResourcePool
{
    public class ConcreteSqlDatabaseConnection : DatabaseResource<SqlConnection>
    {
        public ConcreteSqlDatabaseConnection(string connectionString)
            : base(new SqlConnection(connectionString))
        {
        }
    }
}
