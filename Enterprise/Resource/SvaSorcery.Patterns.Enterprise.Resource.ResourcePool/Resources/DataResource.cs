using System.Linq;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace SvaSorcery.Patterns.Enterprise.Resource.ResourcePool
{
    public class DatabaseResource<T> where T : DbConnection
    {
        private readonly T _connection;

        public DatabaseResource()
        {
        }

        public DatabaseResource(T connection)
        {
            _connection = connection;
        }

        public bool IsAvailable => _connection?.State > ConnectionState.Closed;

        public virtual void Open() => _connection.Open();

        public virtual void Close() => _connection.Close();

        public virtual void Execute(string expression, IReadOnlyDictionary<string, string> param = null)
        {
            var command = _connection.CreateCommand();
            command.CommandText = expression;

            if (param != null)
            {
                var parameters = param.Select(kv =>
                {
                    var p = command.CreateParameter();
                    p.ParameterName = kv.Key;
                    p.Value = kv.Value;
                    return p;
                }).ToArray();

                command.Parameters.AddRange(parameters);
            }

            Open();
            command.ExecuteNonQuery();
        }

        public virtual void Execute<TParam>(string expression, params TParam[] param) where TParam : DbParameter
        {
            var command = _connection.CreateCommand();
            command.CommandText = expression;
            if (param != null)
                command.Parameters.AddRange(param);
            Open();
            command.ExecuteNonQuery();
        }
    }
}
