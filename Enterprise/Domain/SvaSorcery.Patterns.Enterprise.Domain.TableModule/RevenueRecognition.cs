using System;
using System.Data;
using System.Linq;

namespace SvaSorcery.Patterns.Enterprise.Domain.TableModule
{
    public class RevenueRecognition : TableModule
    {
        public RevenueRecognition(DataSet ds) : base(ds, "RevenueRecognitions")
        {
        }

        public void Insert(long contractId, decimal amount, DateTime recognizedAt)
        {
            DataRow newRow = Table.NewRow();
            newRow["contractId"] = contractId;
            newRow["amount"] = amount;
            newRow["recognizedAt"] = string.Format("{0:s}", recognizedAt);
            Table.Rows.Add(newRow);
        }

        public decimal RecognizedRevenue(long contractId, DateTime recognizedAt)
        {
            string filter = string.Format("contractId = {0} AND recognizedAt <= #{1:d}#", contractId, recognizedAt);
            var rows = Table.Select(filter);
            return rows.Sum(row => (decimal)row["amount"]);
        }
    }
}
