using System;
using System.Linq;
using System.Threading.Tasks;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Handlers
{
    public class FindContractHandler : IQueryHandler<FindContract, RevenueContract>
    {
        private readonly Gateway _gateway;

        public FindContractHandler(Gateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<RevenueContract> HandleAsync(FindContract query)
        {
            var contract = (await _gateway.FindContractAsync(query.ContractId)).First();

            return new RevenueContract(
                Convert.ToString(contract["@type"]),
                Money.Dollars(Convert.ToDecimal(contract["@amount"])),
                Convert.ToDateTime(contract["@recognizedAt"]));
        }
    }
}
