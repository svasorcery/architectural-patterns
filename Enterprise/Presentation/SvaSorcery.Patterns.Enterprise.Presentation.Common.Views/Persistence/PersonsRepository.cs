using SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Models;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Persistence
{
    public static class PersonsRepository
    {
        public static Person[] GetAll() => new Person[]
        {
            new(1, "Alice", "Sender", "alice@personcached.io"),
            new(2, "Bob", "Receipient", "bob@personcached.io"),
            new(3, "Carol", "Middleman", "carol@personcached.io"),
            new(4, "Eve", "Eavesdropper", "eve@personcached.io"),
            new(5, "Mallory", "Malicious", "mallory@personcached.io"),
        };
    }
}
