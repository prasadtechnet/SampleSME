using SME.ServiceAPI.Business.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.Auth
{
   public interface IAuthManager
    {
         // 1.Auth
         //   1.1. Authenticate
	        //1.2. RefreshToken

        Task<AuthLoginReponse> Authenticate(string user, string password);

        Task<AuthLoginReponse> RefreshToken(string token);

        // Task<string> GetKey(string keyType);
    }
}
