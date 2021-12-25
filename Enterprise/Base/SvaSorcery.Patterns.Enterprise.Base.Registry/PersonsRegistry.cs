using SvaSorcery.Patterns.Enterprise.DataAccess.TableDataGateway;
using PersonGateway = SvaSorcery.Patterns.Enterprise.Base.LayerSupertype.PersonGateway;

namespace SvaSorcery.Patterns.Enterprise.Base.Registry
{
    public class PersonsRegistry
    {
        public static readonly PersonGateway _persons = new(new System.Data.DataSet());

        public static Person GetPerson(int id)
            => _persons.Find(id);

        public static void CreatePerson(Person person)
            => _persons.Create(person);

        public static void RemovePerson(Person person)
            => _persons.Delete(person.Id);
    }
}
