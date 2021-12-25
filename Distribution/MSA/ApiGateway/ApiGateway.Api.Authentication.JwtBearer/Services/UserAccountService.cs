using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ApiGateway.Api.Authentication.JwtBearer.Services
{
    using ApiGateway.Api.Authentication.JwtBearer.Models;

    public class UserAccountService
    {
        private readonly List<UserAccount> _users = new()
        {
            new() { Username = "svasorcery", Password = "gfhjkm123", Role = "admin" },
            new() { Username = "user", Password = "user", Role = "user" }
        };

        public Task<UserAccount> FindAsync(UserCredentials credentials)
        {
            var result = _users.FirstOrDefault(x => x.Username == credentials.Username && x.Password == credentials.Password);

            return Task.FromResult(result);
        }
    }
}
