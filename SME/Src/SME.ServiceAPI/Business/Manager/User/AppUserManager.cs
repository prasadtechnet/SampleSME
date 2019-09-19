using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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

        public async Task SaveChangesAsync()
        {
            await _unitofWork.SaveChangesAsync();
        }

        public Task UpdateClaimMaster()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(AppUser appUser)
        {
            throw new NotImplementedException();
        }
        public Task AddRoleClaim()
        {
            throw new NotImplementedException();
        }

        public Task AddUserClaim()
        {
            throw new NotImplementedException();
        }

        public Task AssignRole(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public Task CreateClaimMaster()
        {
            throw new NotImplementedException();
        }

        public Task CreateUser(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClaimMaster()
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoleClaim()
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserClaim()
        {
            throw new NotImplementedException();
        }

        public Task GetUserRoleClaims(AppUser appUser)
        {
            throw new NotImplementedException();
        }

       
    }
}
