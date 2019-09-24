using SME.ServiceAPI.Business.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.Auth
{
   public interface IAuthManager
    {
        Task<AuthLoginReponse> Authenticate(string user, string password);

        Task<string> GetKey(string keyType);
    }
}
