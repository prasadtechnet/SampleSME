using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JwtRsaAPI.JWT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SME.ServiceAPI.Business.Security.JWT.Models;

namespace JwtRsaAPI.JWT
{
    public interface IJWTHandler
    {
        JWTTokenModel Create(string userId);
        TokenValidationParameters Parameters { get; }
    }
    public class JWTHandler : IJWTHandler
    {
        #region Variables

        private readonly JwtSettings _settings;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private SecurityKey _issuerSigningKey;
        private SigningCredentials _signingCredentials;
        private JwtHeader _jwtHeader;
        public TokenValidationParameters Parameters { get; private set; }
        #endregion

        #region Constructor
        public JWTHandler(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;

            if (_settings.useRsa)
            {
                InititlizeRsa();
            }
            else
            {
                InititlizeHmac();
            }
            InititlizeParameters();
        }
        #endregion

        #region Intitlise 

        private void InititlizeRsa()
        {
            using(RSA publicRsa = RSA.Create())
            {
                var publicKeyXml = File.ReadAllText(_settings.rsaPublicKeyXml);//need to verify path in appsettings.json
                publicRsa.FromXmlString(publicKeyXml);
                _issuerSigningKey = new RsaSecurityKey(publicRsa);
            }

            if (String.IsNullOrWhiteSpace(_settings.rsaPrivateKeyXml))
            {
                return;
            }
            using(RSA privateRsa = RSA.Create())
            {
                var privateKeyXml = File.ReadAllText(_settings.rsaPrivateKeyXml);
                privateRsa.FromXmlString(privateKeyXml);
                var privateKey = new RsaSecurityKey(privateRsa);
                _signingCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.RsaSha256);
            }
        }
        private void InititlizeHmac()
        {
            _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.hmacSecretKey));
            _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
        }

        private void InititlizeParameters()
        {
            _jwtHeader = new JwtHeader(_signingCredentials);
            Parameters = new TokenValidationParameters {
                ValidateAudience=false,
                ValidIssuer=_settings.issuer,
                IssuerSigningKey=_issuerSigningKey
            };
        }

        #endregion

        public async Task<JwtResponse> GenerateToken(IdentityUser user)
        {
            var jwtTokenHndlr = new JwtSecurityTokenHandler();

            var secretKey = System.Text.Encoding.ASCII.GetBytes(_settings.Secret);
            //Default Claims
            var lsClaims = new List<Claim>{
                                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                                    };

            

            //Permission Cliams need to add
            //if (String.IsNullOrEmpty(lsPermissions))
            //    lsClaims.Add(new Claim(type: "permission", value: lsPermissions));

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(lsClaims.ToArray()),
                Expires = DateTime.UtcNow.Add(_settings.TokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHndlr.CreateToken(tokenDesc);

            return new JwtResponse
            {
                Success = true,
                Token = jwtTokenHndlr.WriteToken(token)
            };
        }


        public JWTTokenModel Create(string userId)
        {
            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddDays(_settings.expiryDays);
            var centuryBegin = new DateTime(1970, 1, 1);
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            var now = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            var issuer = _settings.issuer ?? string.Empty;
            var payload = new JwtPayload
            {
                {"sub",userId },
                {"unique_name",userId },
                {"iss",issuer },
                {"iat",now },
                { "nbf",now },
                { "exp",exp},
                { "jti",Guid.NewGuid().ToString("N")}
            };

            var jwt = new JwtSecurityToken(_jwtHeader, payload);
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JWTTokenModel
            {
                Token=token,
                Expires=exp
            };
        }
    }
}
