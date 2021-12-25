using System;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;
using SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Types;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Commands
{
    public record CreateRecognition(long ContractId, DateTime RecognizedAt, Money Money) : ICommand;
}
