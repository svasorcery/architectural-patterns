using System;
using SvaSorcery.Patterns.Enterprise.Domain.TransactionScript;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Commands.Models
{
    public class RevenueContract
    {
        public string Type { get; }
        public Money TotalRevenue { get; }
        public DateTime RecognizedAt { get; }

        protected RevenueContract()
        {
        }

        public RevenueContract(string type, Money totalRevenue, DateTime recognizedAt)
        {
            Type = type;
            TotalRevenue = totalRevenue;
            RecognizedAt = recognizedAt;
        }
    }
}
