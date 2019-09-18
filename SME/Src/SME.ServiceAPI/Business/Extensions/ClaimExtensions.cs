using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Extensions
{
    public static class ClaimExtensions
    {
        public static string GetUserRole(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return String.Empty;
            }

            return httpContext.User.Claims.Single(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
        }

        public static string GetUserPermissions(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return String.Empty;
            }

            return httpContext.User.Claims.Single(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/permission").Value;
        }
    }
}
