using Microsoft.AspNetCore.Identity;
using SME.ServiceAPI.Business.Manager.Core;
using SME.ServiceAPI.Common.Idenitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.User
{
   public interface IAppUserManager 
    {
        Task CreateUser(AppUser appUser);
        Task UpdateUser(AppUser appUser);
        Task DeleteUser(AppUser appUser);
        Task AssignRole(IdentityRole role);

        Task CreateClaimMaster();
        Task DeleteClaimMaster();
        Task UpdateClaimMaster();

        Task AddUserClaim();
        Task DeleteUserClaim();

        Task AddRoleClaim();
        Task DeleteRoleClaim();

        Task GetUserRoleClaims(AppUser appUser);
    }
}
