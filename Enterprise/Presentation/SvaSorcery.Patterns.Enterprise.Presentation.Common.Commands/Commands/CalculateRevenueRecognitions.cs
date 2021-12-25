using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands
{
    public record CalculateRevenueRecognitions(long ContractId) : ICommand;
}
