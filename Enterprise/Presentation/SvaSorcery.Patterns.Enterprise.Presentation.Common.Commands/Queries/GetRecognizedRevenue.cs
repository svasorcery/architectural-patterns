using System;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries
{
    public record GetRecognizedRevenue(long ContractId, DateTime RecognizedAt) : IQuery<Money>;
}
