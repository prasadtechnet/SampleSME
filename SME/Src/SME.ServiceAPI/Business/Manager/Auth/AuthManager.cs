using JwtRsaAPI.JWT;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts.Response;
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
        #endregion

        #region Constructor
        public AuthManager(IJWTHandler jwtManager, IRepository repository, IUnitOfWork unitofWork, ILogger<AuthManager> logger)
        {
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;
            _jwtManager = jwtManager;
        }
        #endregion
        public async Task<AuthLoginReponse> Authenticate(string user,string password)
        {
            var resp= new AuthLoginReponse { };
          var jwtResp=await _jwtManager.GenerateToken1(user);
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
    }
}
