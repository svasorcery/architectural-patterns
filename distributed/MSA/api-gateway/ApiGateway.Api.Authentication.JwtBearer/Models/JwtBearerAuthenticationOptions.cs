using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ApiGateway.Api.Authentication.JwtBearer.Models
{
    public class JwtBearerAuthenticationOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigningKey { get; set; }
        public int LifeTime { get; set; }

        public SymmetricSecurityKey IssuerSigningKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SigningKey));
        public SigningCredentials SigningCredentials => new SigningCredentials(this.IssuerSigningKey, SecurityAlgorithms.HmacSha256);

        public DateTime NotBefore => DateTime.UtcNow;
        public DateTime IssuedAt => DateTime.UtcNow;
        public TimeSpan ValidFor => TimeSpan.FromSeconds(this.LifeTime);
        public DateTime Expiration => this.IssuedAt.Add(this.ValidFor);
    }
}
