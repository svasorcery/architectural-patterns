using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries
{
    public record FindContract(long ContractId) : IQuery<RevenueContract>;
}
