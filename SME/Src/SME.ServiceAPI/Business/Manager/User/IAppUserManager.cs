using Microsoft.AspNetCore.Identity;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Contracts.Response;
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

        Task<ResponseModel> CreateRole(string roleName);

        Task<List<RoleModel>> Roles();

        Task<ResponseModel> CreateUser(UserNewModel appUser);
        Task<ResponseModel> UpdateUser(UserEditModel appUser);

        Task<List<UserModel>> Users();
        Task<UserModel> GetUserById(string userId);
        Task<UserModel> GetUserByIdOrEmailorUserNameOrMobile(string user_name_email);

        Task<ResponseModel> UserRoleAssign(UserRoleAssignModel userRole);

        Task<ResponseModel> CreateClaim(ClaimNewModel claim);
  
        Task<ResponseModel> UpdateClaim(ClaimModel claim);

        Task<List<ClaimModel>> GetClaims();
        Task<ClaimModel> GetClaimById(int Id);
        Task<List<ClaimModel>> GetClaimByCategory(string Category);

        Task<ResponseModel> UserClaimAssign(UserClaimAssignModel userClaim);
        Task<ResponseModel> DeleteUserClaim(UserClaimAssignModel userClaim);
        Task<ResponseModel> RoleClaimAssign(RoleClaimAssignModel roleClaim);
        Task<ResponseModel> DeleteRoleClaim(RoleClaimAssignModel roleClaim);

        Task<List<UserClaimModel>> GetUserAssignedClaims(string userId);
        Task<List<RoleClaimModel>> GetRoleAssignedClaims(string roleId);

        Task<List<UserClaimModel>> GetUserPermittedClaims(string userId);
        Task<List<int>> GetUserPermittedClaimsWithMapping(string userId);

       // Task SaveChangesAsync();

        //  Task DeleteUser(AppUser appUser);
        //  Task<bool> DeleteClaim(ClaimModel claim);
    }
}
