using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SME.ServiceAPI.Business.Security.JWT.Models;
using SME.ServiceAPI.Common.Idenitity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Security.JWT
{
    public class JWTManager: IJWTManager
    {
        private JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        SignInManager<AppUser> _SignInManager;
        public JWTManager(JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters, SignInManager<AppUser> SignInManager)
        {
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _SignInManager = SignInManager;
        }

        public async Task<JwtResponse> GenerateRefreshToken(string token, string refreshToken)
        {
            var validateToken = GetClaimsPrincipal(token);
            if (validateToken == null)
            {
                return new JwtResponse{Errors=new[] {"Invalid Token" } };
            }

            if (!validateToken.HasClaim(x => x.Type == JwtRegisteredClaimNames.Exp))
            {
                return new JwtResponse { Errors = new[] { "Invalid Token" } };
            }
              var expTime= long.Parse(validateToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(expTime)
                    .Subtract(_jwtSettings.TokenLifetime);


                if (expiryDate > DateTime.UtcNow)
                {
                return new JwtResponse { Errors = new[] { "Token has not expired yet" } };
               }

            var jti = validateToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                //verify in db that token is valid or not (RefreshToken tab)


            return null;
        }

        public async Task<JwtResponse> GenerateToken(string userrId, string userRole, string lsPermissions = "")
        {
            var jwtTokenHndlr = new JwtSecurityTokenHandler();

            var secretKey = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            //Default Claims
            var lsClaims = new List<Claim>{
                                    new Claim(JwtRegisteredClaimNames.Sub, userrId),
                                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                                    new Claim(JwtRegisteredClaimNames.Email, userrId),
                                    new Claim(type:"role", value:userRole)
                                    };

            //Permission Cliams
            if (String.IsNullOrEmpty(lsPermissions))
                lsClaims.Add(new Claim(type: "permission", value: lsPermissions));

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(lsClaims.ToArray()),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHndlr.CreateToken(tokenDesc);

            return new JwtResponse
            {
                Success = true,
                Token = jwtTokenHndlr.WriteToken(token)
            };
        }
        public async Task<JwtResponse> GenerateToken(AppUser user)
        {
            var jwtTokenHndlr = new JwtSecurityTokenHandler();

            var secretKey = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            //Default Claims
            var lsClaims = await GetUserClaims(user);

            //Permission Cliams need to add
            //if (String.IsNullOrEmpty(lsPermissions))
            //    lsClaims.Add(new Claim(type: "permission", value: lsPermissions));

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(lsClaims.ToArray()),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHndlr.CreateToken(tokenDesc);

            return new JwtResponse
            {
                Success = true,
                Token = jwtTokenHndlr.WriteToken(token)
            };
        }

        private ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var securityToken);
                if (!IsJwtWithValidSecurityAlgorithem(securityToken))
                    return null;

                return principal;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithem(SecurityToken validationToken)
        {
            return (validationToken is JwtSecurityToken jwtSecurityToken) && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }



        private async Task<List<Claim>> GetUserClaims(AppUser user)
        {

            var lsClaims = new List<Claim>{
                                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                                    };
           
            var identity = await _SignInManager.CreateUserPrincipalAsync(user);
            identity.Claims.ToList();

           var roles=_SignInManager.UserManager.GetRolesAsync(user);

            

            return lsClaims;
        }

        public bool VerifyJWTToken(string strToken)
        {

            return false;
        }
    }
}
