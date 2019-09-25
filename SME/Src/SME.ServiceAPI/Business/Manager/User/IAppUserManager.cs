using Microsoft.AspNetCore.Identity;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
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
        //4.User(Role+Claims)
        //4.1 RoleCreate
        //4.2 UserCreate
        //4.3 ClaimCreate
        //4.4 ClaimUpdate
        //4.5 RoleClaimAssign
        //4.6 UserRoleAssign
        //4.7 UserClaimAssign
        //4.8 UserProfileEdit(UserUpdate)

        Task<bool> CreateRole(string roleName);

        Task<bool> CreateUser(UserModel appUser);
        Task<bool> UpdateUser(UserModel appUser);

        Task<UserModel> GetUserById(string userId);
        Task<AppUser> GetUserByIdOrEmailorUserNameOrMobile(string user_name_email_mobile);

        Task UserRoleAssign(UserRoleModel userRole);

        Task<bool> CreateClaim(ClaimModel claim);
  
        Task<bool> UpdateClaim(ClaimModel claim);

        Task<List<ClaimModel>> GetClaims();
        Task<ClaimModel> GetClaimById(int Id);

        Task<bool> UserClaimAssign();
        Task<bool> DeleteUserClaim();
        Task<bool> RoleClaimAssign();
        Task<bool> DeleteRoleClaim();

        Task<List<UserClaimModel>> GetUserAssignedClaims(string userId);
        Task<List<RoleClaimModel>> GetRoleAssignedClaims(string roleId);

        Task<List<UserClaimModel>> GetUserPermittedClaims(string userId);
        Task<List<int>> GetUserPermittedClaimsWithMapping(string userId);

        Task SaveChangesAsync();

        //  Task DeleteUser(AppUser appUser);
        //  Task<bool> DeleteClaim(ClaimModel claim);
    }
}
