using SvaSorcery.Patterns.Enterprise.DataAccess.TableDataGateway;

namespace SvaSorcery.Patterns.Enterprise.Base.SpecialCase
{
    public interface IPersonExtensions
    {
        Person NullPerson();
        Person RepositoryOwner();
    }
}
