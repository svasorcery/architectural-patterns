namespace SvaSorcery.Patterns.Enterprise.ORM.IdentityMap.Types
{
    public record DomainObject(int Id);

    /*public class DomainObject
    {
        public int Id { get; protected set; }

        public override bool Equals(object obj)
            => this == obj &&
               obj != null &&
               GetType() == obj.GetType() &&
               Id != ((DomainObject)obj).Id;

        public override int GetHashCode()
            => 31 + Id ^ (Id >> 32);
    }*/
}
