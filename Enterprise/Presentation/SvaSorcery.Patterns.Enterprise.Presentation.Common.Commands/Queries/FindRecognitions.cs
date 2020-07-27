using System;
using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries
{
    public class FindRecognitions : IQuery<IEnumerable<Money>>
    {
        public long ContractId { get; }
        public DateTime RecognizedAt { get; }

        protected FindRecognitions()
        {
        }

        public FindRecognitions(long contractId, DateTime recognizedAt)
        {
            ContractId = contractId;
            RecognizedAt = recognizedAt;
        }
    }
}
