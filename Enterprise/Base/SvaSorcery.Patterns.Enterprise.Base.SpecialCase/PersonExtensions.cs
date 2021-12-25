using SvaSorcery.Patterns.Enterprise.DataAccess.TableDataGateway;

namespace SvaSorcery.Patterns.Enterprise.Base.SpecialCase
{
    public class PersonExtensions : IPersonExtensions
    {
        public Person NullPerson() => new()
        {
            FirstName = "",
            LastName = "",
            Email = ""
        };

        public Person RepositoryOwner() => new()
        {
            FirstName = "Vladimir",
            LastName = "Sva",
            Email = "vladimir@example.io"
        };
    }
}
