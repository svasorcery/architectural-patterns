using System.Linq;
using System.Collections.Generic;
using SvaSorcery.Patterns.Enterprise.Cache.Common.Types;
using SvaSorcery.Patterns.Enterprise.Presentation.AppController.Models;

namespace SvaSorcery.Patterns.Enterprise.Presentation.AppController.Services
{
    public class PersonsRepository : IRepository<Person>
    {
        private readonly HashSet<Person> _personsDatabaseTable = new()
        {
            new() { Id = 1, FirstName = "Alice", LastName = "Sender", Email = "alice@personcached.io" },
            new() { Id = 2, FirstName = "Bob", LastName = "Receipient", Email = "bob@personcached.io" },
            new() { Id = 3, FirstName = "Carol", LastName = "Middleman", Email = "carol@personcached.io" },
            new() { Id = 4, FirstName = "Eve", LastName = "Eavesdropper", Email = "eve@personcached.io" },
            new() { Id = 5, FirstName = "Mallory", LastName = "Malicious", Email = "mallory@personcached.io" },
        };

        public void CreateOrUpdate(Person item) => _personsDatabaseTable.Add(item);

        public IEnumerable<Person> GetAll() => _personsDatabaseTable;

        public Person GetById(int id) => _personsDatabaseTable.FirstOrDefault(x => x.Id == id);

        public void RemoveById(int id) => _personsDatabaseTable.Remove(GetById(id));
    }
}
