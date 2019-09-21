using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Contracts.Request
{
    public class AuthLoginModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
