using SvaSorcery.Patterns.Enterprise.ORM.IdentityMap.Types;

namespace SvaSorcery.Patterns.Enterprise.ORM.IdentityMap
{
    public record PersonIdentity(int Id, string FirstName, string LastName, string Email) : DomainObject(Id);
}
