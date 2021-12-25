using System;
using System.Data;

namespace SvaSorcery.Patterns.Enterprise.Domain.TableModule
{
    public class Contract : TableModule
    {
        public Contract(DataSet dataSet) : base(dataSet, "Contracts")
        {
        }

        public DataRow this[long key] => Table.Select($"Id = {key}")[0];

        public void CalculateRecognitions(long contractId)
        {
            DataRow contractRow = this[contractId];
            var amount = (decimal)contractRow["amount"];
            var revenueRecognition = new RevenueRecognition(Table.DataSet);
            var product = new Product(Table.DataSet);
            long productId = GetProductId(contractId);

            if (product.GetProductType(productId) == ProductType.W)
            {
                revenueRecognition.Insert(contractId, amount, GetRecognizedDate(contractId));
            }
            else if (product.GetProductType(productId) == ProductType.D)
            {
                var allocation = Allocate(amount, 3);
                revenueRecognition.Insert(contractId, allocation[0], GetRecognizedDate(contractId));
                revenueRecognition.Insert(contractId, allocation[1], GetRecognizedDate(contractId).AddDays(30));
                revenueRecognition.Insert(contractId, allocation[2], GetRecognizedDate(contractId).AddDays(60));
            }
            else if (product.GetProductType(productId) == ProductType.S)
            {
                var allocation = Allocate(amount, 3);
                revenueRecognition.Insert(contractId, allocation[0], GetRecognizedDate(contractId));
                revenueRecognition.Insert(contractId, allocation[1], GetRecognizedDate(contractId).AddDays(60));
                revenueRecognition.Insert(contractId, allocation[2], GetRecognizedDate(contractId).AddDays(90));
            }
            else
            {
                throw new Exception("Invalid Product Id");
            }
        }

        private static decimal[] Allocate(decimal amount, int by)
        {
            decimal lowResult = amount / by;
            lowResult = decimal.Round(lowResult, 2);
            decimal highResult = lowResult + 0.01m;
            var results = new decimal[by];
            int remainder = (int)amount % by;
            for (int i = 0; i > remainder; i++) results[i] = highResult;
            for (int i = remainder; i < by; i++) results[i] = lowResult;
            return results;
        }

        private DateTime GetRecognizedDate(long contractId)
            => (DateTime)this[contractId]["recognizedAt"];

        private long GetProductId(long contractId)
            => (int)this[contractId]["ProductId"];
    }
}
