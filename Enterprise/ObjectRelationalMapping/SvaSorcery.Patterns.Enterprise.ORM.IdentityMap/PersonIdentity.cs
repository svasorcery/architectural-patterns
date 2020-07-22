using SvaSorcery.Patterns.Enterprise.ORM.IdentityMap.Types;

namespace SvaSorcery.Patterns.Enterprise.ORM.IdentityMap
{
    public class PersonIdentity : DomainObject
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public PersonIdentity(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
