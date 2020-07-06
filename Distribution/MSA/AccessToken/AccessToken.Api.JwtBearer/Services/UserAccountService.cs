using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AccessToken.Api.JwtBearer.Services
{
    using AccessToken.Api.JwtBearer.Models;

    public class UserAccountService
    {
        private readonly List<UserAccount> _users = new List<UserAccount>
        {
            new UserAccount { Username = "svasorcery", Password = "gfhjkm123", Role = "admin" },
            new UserAccount { Username = "user", Password = "user", Role = "user" }
        };

        public Task<UserAccount> FindAsync(UserCredentials credentials)
        {
            var result = _users.FirstOrDefault(x => x.Username == credentials.Username && x.Password == credentials.Password);

            return Task.FromResult(result);
        }
    }
}
