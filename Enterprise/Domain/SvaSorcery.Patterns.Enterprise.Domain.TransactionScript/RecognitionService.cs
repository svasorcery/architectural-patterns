using System;
using System.Linq;
using System.Threading.Tasks;

namespace SvaSorcery.Patterns.Enterprise.Domain.TransactionScript
{
    public class RecognitionService
    {
        private readonly Gateway _gateway;

        public RecognitionService(Gateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<Money> GetRecognizedRevenueAsync(long contractId, DateTime recognizedAt)
        {
            var result = Money.Dollars(0);
            var recognitions = await _gateway.FindRecognitionsForAsync(contractId, recognizedAt);
            foreach (var recognition in recognitions)
            {
                result = result.Add(Money.Dollars(Convert.ToDecimal(recognition["@amount"])));
            }
            return result;
        }

        public async Task CalculateRevenueRecognitionsAsync(long contractId)
        {
            var contract = (await _gateway.FindContractAsync(contractId)).First();
            var totalRevenue = Money.Dollars(Convert.ToDecimal(contract["@amount"]));
            var recognizedAt = Convert.ToDateTime(contract["@recognizedAt"]);
            var type = Convert.ToString(contract["@type"]);

            if (type == "W")
            {
                await _gateway.InsertRecognitionAsync(contractId, totalRevenue, recognizedAt);
            }
            else if (type == "D")
            {
                var allocation = totalRevenue.Allocate(3);
                await _gateway.InsertRecognitionAsync(contractId, allocation[0], recognizedAt);
                await _gateway.InsertRecognitionAsync(contractId, allocation[1], recognizedAt.AddDays(30));
                await _gateway.InsertRecognitionAsync(contractId, allocation[2], recognizedAt.AddDays(60));
            }
            else if (type == "S")
            {
                var allocation = totalRevenue.Allocate(3);
                await _gateway.InsertRecognitionAsync(contractId, allocation[0], recognizedAt);
                await _gateway.InsertRecognitionAsync(contractId, allocation[1], recognizedAt.AddDays(60));
                await _gateway.InsertRecognitionAsync(contractId, allocation[2], recognizedAt.AddDays(90));
            }
        }
    }
}
