using JwtRsaAPI.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts.Response;
using SME.ServiceAPI.Business.Manager.User;
using SME.ServiceAPI.Common.Idenitity;
using SME.ServiceAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.Auth
{
    public class AuthManager : IAuthManager
    {
        #region Varaibles
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitofWork;
        private ILogger<AuthManager> _logger;
        private IJWTHandler _jwtManager;
        private SignInManager<AppUser> _userManager;
        #endregion

        #region Constructor
        public AuthManager(IJWTHandler jwtManager,SignInManager<AppUser> userManager,IRepository repository, IUnitOfWork unitofWork, ILogger<AuthManager> logger)
        {
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;
            _jwtManager = jwtManager;
            _userManager = userManager;
        }
        #endregion
        public async Task<AuthLoginReponse> Authenticate(string user,string password)
        {
            var resp= new AuthLoginReponse { };

            AppUser appUser = null;
            appUser = await _userManager.UserManager.FindByNameAsync(user);

            var objSignIn = await _userManager.CheckPasswordSignInAsync(appUser, password, false);


            if (objSignIn.IsNotAllowed)
                return new AuthLoginReponse { Errors = new[] { "user not allowed to signin" } };

            if (objSignIn.IsLockedOut)
                return new AuthLoginReponse { Errors = new[] { "user locked out" } };

            if (objSignIn.RequiresTwoFactor)
                return new AuthLoginReponse { Errors = new[] { "requires two factor login" } };

            if (!objSignIn.Succeeded)
                return new AuthLoginReponse {Errors=new[] {"Invalid credentials"} };

                  

            var jwtResp=await _jwtManager.GenerateToken1(appUser.Email);
            if (jwtResp.Success)
            {
                resp.Token = jwtResp.Token;
            }
            else
            {
                resp.Errors = jwtResp.Errors;
            }

            return resp;
        }

        public async Task<string> GetKey(string keyType)
        {

            return await _repository.GetKey("TDO");

        }

        public Task<AuthLoginReponse> RefreshToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
