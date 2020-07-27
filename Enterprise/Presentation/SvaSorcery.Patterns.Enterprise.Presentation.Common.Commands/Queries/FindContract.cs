using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries
{
    public class FindContract : IQuery<RevenueContract>
    {
        public long ContractId { get; }

        protected FindContract()
        {
        }

        public FindContract(long contractId)
        {
            ContractId = contractId;
        }
    }
}
