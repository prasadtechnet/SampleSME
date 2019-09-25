using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Common.Idenitity;
using SME.ServiceAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.User
{
    public class AppUserManager:IAppUserManager
    {
        #region Varaibles
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitofWork;
        private ILogger<AppUserManager> _logger;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManger;
        #endregion

        #region Constructor
        public AppUserManager(IRepository repository, IUnitOfWork unitofWork, ILogger<AppUserManager> logger,UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManger)
        {
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;
            _userManager = userManager;
            _roleManger = roleManger;           
        }




        #endregion
               
        #region Role
        public async Task<bool> CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RoleClaimAssign()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteRoleClaim()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region User
        public async Task<bool> CreateUser(UserModel appUser)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateUser(UserModel appUser)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UserClaimAssign()
        {
            throw new NotImplementedException();
        }

        public async Task UserRoleAssign(UserRoleModel userRole)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteUserClaim()
        {
            throw new NotImplementedException();
        }
        public async Task<List<UserClaimModel>> GetUserAssignedClaims(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserClaimModel>> GetUserPermittedClaims(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<int>> GetUserPermittedClaimsWithMapping(string userId)
        {
            throw new NotImplementedException();
        }
        public async Task<UserModel> GetUserById(string userId)
        {
            throw new NotImplementedException();
        }
        public async Task<AppUser> GetUserByIdOrEmailorUserNameOrMobile(string user_name_email_mobile)
        {

            throw new NotImplementedException();
        }
        #endregion

        #region  CliamMaster
        public async Task<bool> CreateClaim(ClaimModel claim)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateClaim(ClaimModel claim)
        {
            throw new NotImplementedException();
        }

        public async Task<ClaimModel> GetClaimById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ClaimModel>> GetClaims()
        {
            throw new NotImplementedException();
        }
        public async Task<List<RoleClaimModel>> GetRoleAssignedClaims(string roleId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region SaveChanges commit
        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
