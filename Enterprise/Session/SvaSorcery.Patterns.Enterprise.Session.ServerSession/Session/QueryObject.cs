using System;

namespace SvaSorcery.Patterns.Enterprise.Session.ServerSession.Session
{
    public class QueryObject
    {
        public long ContractId { get; set; }
        public DateTime? RecognizedAt { get; set; }

        public QueryObject(long contractId, DateTime? recognizedAt = null)
        {
            ContractId = contractId;
            RecognizedAt = recognizedAt;
        }
    }
}
