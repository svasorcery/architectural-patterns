using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands
{
    public class CalculateRevenueRecognitions : ICommand
    {
        public long ContractId { get; }

        protected CalculateRevenueRecognitions()
        {
        }

        public CalculateRevenueRecognitions(long contractId)
        {
            ContractId = contractId;
        }
    }
}
