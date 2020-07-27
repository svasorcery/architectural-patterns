using SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Models;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Persistence
{
    public static class PersonsRepository
    {
        public static Person[] GetAll()
        {
            return new Person[]
            {
                new Person(1, "Alice", "Sender", "alice@personcached.io"),
                new Person(2, "Bob", "Receipient", "bob@personcached.io"),
                new Person(3, "Carol", "Middleman", "carol@personcached.io"),
                new Person(4, "Eve", "Eavesdropper", "eve@personcached.io"),
                new Person(5, "Mallory", "Malicious", "mallory@personcached.io"),
            };
        }
    }
}
