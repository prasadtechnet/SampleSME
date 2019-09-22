
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SME.Client.Models.Auth;
using SME.Client.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Client.Services
{
    public interface IAuthService
    {
        Task<AuthResponseModel> Authenticate(LoginModel objInput);
    }
    public class AuthService:BaseService, IAuthService
    {
        public AuthService(ClientAPI options, IHttpContextAccessor httpContext):base(options.baseUrl, httpContext)
        {
        }
        public async Task<AuthResponseModel> Authenticate(LoginModel objInput)
        {
          var resp= await PostAsync<AuthResponseModel, LoginModel>("Auth/login", objInput,false);
            return resp;
        }
    }
}
