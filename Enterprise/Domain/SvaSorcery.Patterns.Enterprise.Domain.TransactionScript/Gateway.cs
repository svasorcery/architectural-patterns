using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SvaSorcery.Patterns.Enterprise.Domain.TransactionScript
{
    public class Gateway
    {
        internal readonly string _connectionString;

        public Gateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal Task<int> ExecuteCommandAsync(string sqlExpression, params SqlParameter[] args)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(args);
                command.Connection.Open();
                return command.ExecuteNonQueryAsync();
            }
        }

        internal Task<SqlDataReader> ExecuteQueryAsync(string sqlExpression, params SqlParameter[] args)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(args);
                command.Connection.Open();
                return command.ExecuteReaderAsync();
            }
        }

        internal async Task<IEnumerable<IDictionary<string, object>>> ReadQueryResultAsync(
            string sqlExpression,
            IReadOnlyDictionary<int, string> columnsMap,
            params SqlParameter[] args)
        {
            try
            {
                var results = new List<IDictionary<string, object>>();

                using (var reader = await ExecuteQueryAsync(sqlExpression, args))
                {
                    while (reader.Read())
                    {
                        var item = new Dictionary<string, object>();
                        foreach (var col in columnsMap)
                            item.Add(col.Value, reader[col.Key]);
                        results.Add(item);
                    }
                }

                return results;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message, e);
            }
        }

        public Task<IEnumerable<IDictionary<string, object>>> FindRecognitionsForAsync(long contractId, DateTime recognizedAt)
            => ReadQueryResultAsync("SELECT amount FROM RevenueRecognitions WHERE contract = @contractId AND recognizedAt = @recognizedAt",
                new Dictionary<int, string> { { 0, "@amount" } },
                new SqlParameter("@contract", SqlDbType.BigInt) { Value = contractId },
                new SqlParameter("@recognizedAt", SqlDbType.Date) { Value = recognizedAt.ToShortDateString() });

        public Task<IEnumerable<IDictionary<string, object>>> FindContractAsync(long contractId)
            => ReadQueryResultAsync("SELECT * FROM Contracts AS c, Products AS p WHERE c.Id = @contractId AND c.ProductoId = p.Id",
                new Dictionary<int, string> { { 0, "@amount" }, { 1, "@recognizedAt" }, { 2, "@type" } },
                new SqlParameter("@contractId", SqlDbType.BigInt) { Value = contractId });

        public Task InsertRecognitionAsync(long contractId, Money money, DateTime recognizedAt)
            => ExecuteCommandAsync("INSERT INTO RevenueRecognitions VALUES (@contractId, @amount, @recognizedAt)",
                new SqlParameter("@contractId", SqlDbType.BigInt) { Value = contractId },
                new SqlParameter("@amount", SqlDbType.Decimal) { Value = money.Amount },
                new SqlParameter("@recognizedAt", SqlDbType.Date) { Value = recognizedAt.ToShortDateString() });
    }
}
