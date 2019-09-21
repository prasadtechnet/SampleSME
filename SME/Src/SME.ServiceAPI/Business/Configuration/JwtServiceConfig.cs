using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtRsaAPI.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace SME.ServiceAPI.Business.Configuration
{
    public class JwtServiceConfig : IServiceConfig
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new Security.JWT.Models.JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            var tokenValidationParams = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateAudience = false,
                ValidateIssuer = false,
                RequireExpirationTime = false,
                ValidateLifetime = true

            }; ;
            services.AddSingleton(tokenValidationParams);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(cog => {
                cog.SaveToken = true;
                cog.TokenValidationParameters = tokenValidationParams;
            });

            services.AddSingleton<IJWTHandler,JWTHandler>();
        }
    }
}
