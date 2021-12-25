using System;
using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Queries
{
    public record FindRecognitions(long ContractId, DateTime RecognizedAt) : IQuery<IEnumerable<Money>>;
}
