using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AccessToken.Api.JwtBearer.Controllers
{
    using AccessToken.Api.JwtBearer.Models;
    using AccessToken.Api.JwtBearer.Services;
    
    [Route("api/token/[controller]")]
    public class JwtBearerController : Controller
    {
        private readonly JwtBearerAuthenticationOptions _authOptions;
        private readonly UserAccountService _users;
        private readonly ILogger _logger;

        public JwtBearerController(
            IOptions<JwtBearerAuthenticationOptions> optionsAccessor,
            UserAccountService users,
            ILogger<JwtBearerController> logger
            )
        {
            _authOptions = optionsAccessor.Value;
            _users = users;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> AccessToken([FromBody]UserCredentials credentials)
        {
            var identity = await GetIdentityAsync(credentials);

            if (identity == null)
            {
                _logger.LogInformation($"Invalid username '{credentials.Username}' or password '{credentials.Password}'");
                return BadRequest("Could not verify username and password");
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    claims: identity.Claims,
                    notBefore: _authOptions.NotBefore,
                    expires: _authOptions.Expiration,
                    signingCredentials: _authOptions.SigningCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                subject = identity.Name,
                expires_in = (int)_authOptions.ValidFor.TotalSeconds,
                access_token = encodedJwt
            });
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(UserCredentials credentials)
        {
            var person = await _users.FindAsync(credentials);

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
