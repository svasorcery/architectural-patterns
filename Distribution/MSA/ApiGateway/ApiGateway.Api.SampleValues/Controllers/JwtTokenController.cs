using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiGateway.Api.SampleValues.Controllers
{
    using ApiGateway.Api.Authentication.JwtBearer.Models;
    using ApiGateway.Api.Authentication.JwtBearer.Services;

    public class JwtTokenController : Controller
    {
        private readonly JwtBearerAuthenticationOptions _authOptions;
        private readonly UserAccountService _users;
        private readonly ILogger _logger;

        public JwtTokenController(
            IOptions<JwtBearerAuthenticationOptions> optionsAccessor, 
            UserAccountService users,
            ILogger<JwtTokenController> logger
            )
        {
            _authOptions = optionsAccessor.Value;
            _users = users;
            _logger = logger;
        }


        [HttpPost("/access-token")]
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

                return new (claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            }
            
            return null;
        }
    }
}
