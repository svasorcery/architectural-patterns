using SvaSorcery.Patterns.Enterprise.ORM.IdentityMap.Types;

namespace SvaSorcery.Patterns.Enterprise.ORM.IdentityMap
{
    public record AlbumIdentity(int Id, string Title, string Artist) : DomainObject(Id);
}
