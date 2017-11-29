using System;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AccessToken.Api.JwtBearer.Models;
using AccessToken.Api.JwtBearer.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class JwtBearerAuthenticationServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtBearerAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            var authOptions = new JwtBearerAuthenticationOptions
            {
                Issuer = configuration["Issuer"],
                Audience = configuration["Audience"],
                LifeTime = int.Parse(configuration["LifeTime"]),
                SigningKey = configuration["SigningKey"]
            };

            services.Configure<JwtBearerAuthenticationOptions>(options => 
            {
                options.Issuer = authOptions.Issuer;
                options.Audience = authOptions.Audience;
                options.LifeTime = authOptions.LifeTime;
                options.SigningKey = authOptions.SigningKey;
            });

            services.AddSingleton<UserAccountService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = authOptions.IssuerSigningKey,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }
    }
}
