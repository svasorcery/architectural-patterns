using System;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models
{
    public record RevenueContract(string Type, Money TotalRevenue, DateTime RecognizedAt);
}
