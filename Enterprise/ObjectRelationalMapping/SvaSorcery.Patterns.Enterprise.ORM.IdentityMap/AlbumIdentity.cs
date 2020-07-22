using SvaSorcery.Patterns.Enterprise.ORM.IdentityMap.Types;

namespace SvaSorcery.Patterns.Enterprise.ORM.IdentityMap
{
    public class AlbumIdentity : DomainObject
    {
        public string Title { get; }
        public string Artist { get; }

        public AlbumIdentity(int id, string title, string artist)
        {
            Id = id;
            Title = title;
            Artist = artist;
        }
    }
}
