using System;
using SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Persistence;

namespace SvaSorcery.Patterns.Enterprise.Session.DatabaseSession.Session
{
    public class QueryObject : IIdentifiable
    {
        public long ContractId { get; set; }
        public DateTime? RecognizedAt { get; set; }
        public Guid Id { get; set; }

        public QueryObject(long contractId, DateTime? recognizedAt = null)
        {
            ContractId = contractId;
            RecognizedAt = recognizedAt;
        }
    }
}
