using System;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries
{
    public class GetRecognizedRevenue : IQuery<Money>
    {
        public long ContractId { get; }
        public DateTime RecognizedAt { get; }

        protected GetRecognizedRevenue()
        {
        }

        public GetRecognizedRevenue(long contractId, DateTime recognizedAt)
        {
            ContractId = contractId;
            RecognizedAt = recognizedAt;
        }
    }
}
