using System.Linq;
using Microsoft.AspNetCore.Http;
using SvaSorcery.Patterns.Enterprise.Base.SpecialCase;
using SvaSorcery.Patterns.Enterprise.DataAccess.TableDataGateway;

namespace SvaSorcery.Patterns.Enterprise.Base.Plugin
{
    public class HttpContextUserPersonPlugin : IPersonExtensions
    {
        private readonly HttpContext _httpContext;

        public HttpContextUserPersonPlugin(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public Person RepositoryOwner() => new()
        {
            Id = int.Parse(_httpContext.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value),
            FirstName = _httpContext.User.Identity.Name.Split(' ')[0],
            LastName = _httpContext.User.Identity.Name.Split(' ')[1],
            Email = _httpContext.User.Claims.FirstOrDefault(x => x.Type == "email")?.Value
        };

        public Person NullPerson() => new()
        {
            Id = 0,
            FirstName = null,
            LastName = null,
            Email = null
        };
    }
}
