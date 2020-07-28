using SvaSorcery.Patterns.Enterprise.Cache.Common.Types;

namespace SvaSorcery.Patterns.Enterprise.Presentation.AppController.Models
{
    public class Person : IIdentifiable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
