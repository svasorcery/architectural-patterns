using System;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands
{
    public class CreateRecognition : ICommand
    {
        public long ContractId { get; }
        public DateTime RecognizedAt { get; }
        public Money Money { get; set; }

        protected CreateRecognition()
        {
        }

        public CreateRecognition(long contractId, DateTime recognizedAt, Money money)
        {
            ContractId = contractId;
            RecognizedAt = recognizedAt;
            Money = money;
        }
    }
}
