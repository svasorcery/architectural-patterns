using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ApiGateway.Api.SampleValues.Controllers
{
    using ApiGateway.Api.SampleValues.Models.Authentication;

    public class AccountController : Controller
    {
        private readonly List<UserAccount> _users = new List<UserAccount>
        {
            new UserAccount { Username = "svasorcery", Password = "gfhjkm123", Role = "admin" },
            new UserAccount { Username = "user", Password = "user", Role = "user" }
        };

        private readonly JwtAuthenticationOptions _authOptions;

        public AccountController(IOptions<JwtAuthenticationOptions> optionsAccessor)
        {
            _authOptions = optionsAccessor.Value;
        }


        [HttpPost("/token")]
        public IActionResult Token([FromBody]UserCredentials credentials)
        {
            var identity = GetIdentity(credentials.Username, credentials.Password);

            if (identity == null)
            {
                return BadRequest("Could not verify username and password");
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromSeconds(_authOptions.LifeTime)),
                    claims: identity.Claims,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.SignInKey)), 
                        SecurityAlgorithms.HmacSha256
                    )
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return Ok(new
            {
                username = identity.Name,
                access_token = encodedJwt
            });
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var person = _users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }
            
            return null;
        }
    }
}
