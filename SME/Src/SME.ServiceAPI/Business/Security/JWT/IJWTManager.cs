using SME.ServiceAPI.Business.Security.JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Security.JWT
{
    public interface IJWTManager
    {
        JwtResponse GenerateToken(string userrId, string userRole, string lsPermissions = "");
    }
}
