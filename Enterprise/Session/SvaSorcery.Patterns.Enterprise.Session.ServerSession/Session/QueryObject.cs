using System;

namespace SvaSorcery.Patterns.Enterprise.Session.ServerSession.Session
{
    public record QueryObject(long ContractId, DateTime? RecognizedAt = null);
}
