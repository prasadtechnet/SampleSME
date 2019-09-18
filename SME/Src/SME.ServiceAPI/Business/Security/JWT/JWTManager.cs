using Microsoft.IdentityModel.Tokens;
using SME.ServiceAPI.Business.Security.JWT.Models;
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
        public JWTManager(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public JwtResponse GenerateToken(string userrId, string userRole, string lsPermissions = "")
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

        public bool VerifyJWTToken(string strToken)
        {

            return false;
        }
    }
}
