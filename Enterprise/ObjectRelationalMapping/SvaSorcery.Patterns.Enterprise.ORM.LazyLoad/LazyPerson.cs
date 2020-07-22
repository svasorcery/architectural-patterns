using SvaSorcery.Patterns.Enterprise.DataAccess.DataMapper;

namespace SvaSorcery.Patterns.Enterprise.ORM.LazyLoad
{
    public class LazyPerson
    {
        private int _personId;
        private Person _person = null;

        public LazyPerson(int id)
        {
            _personId = id;
        }

        public Person Person
        {
            get
            {
                if (_person is null)
                    _person = Person.Find(_personId);

                return _person;
            }
        }
    }
}
