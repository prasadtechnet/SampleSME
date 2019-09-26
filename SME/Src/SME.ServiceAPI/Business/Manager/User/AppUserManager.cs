using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Common.Idenitity;
using SME.ServiceAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.User
{
    public class AppUserManager:IAppUserManager
    {
        #region Varaibles
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitofWork;
        private ILogger<AppUserManager> _logger;
        private IUserStore<AppUser> _useStore;
        public UserManager<AppUser> _userManager;
        public RoleManager<AppRole> _roleManager;
       // private IRoleStore<AppRole> _roleManger;
        private IUserClaimStore<AppUser> _userClaimStore;
        private IRoleClaimStore<AppRole> _rolerClaimStore;
        private SignInManager<AppUser> _signInManager;
        private IMapper _mapper;
        #endregion

        #region Constructor
        public AppUserManager(IRepository repository, IUnitOfWork unitofWork, ILogger<AppUserManager> logger, IMapper mapper, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            //, IUserStore<AppUser> userStore, IRoleStore<AppRole> roleStore, IUserClaimStore<AppUser> userClaimStore,IRoleClaimStore<AppRole> roleClaimStore
            _repository = repository;
            _unitofWork = unitofWork;
            _logger = logger;
          //  _useStore = userStore;
           // _roleManger = roleStore;
            _mapper = mapper;
           // _userClaimStore = userClaimStore;
          //  _rolerClaimStore = roleClaimStore;
            _signInManager = signInManager;
            _userManager = _signInManager.UserManager;
            _roleManager = roleManager;
        }




        #endregion
               
        #region Role
        public async Task<bool> CreateRole(string roleName)
        {
           var res= await _roleManager.CreateAsync(new AppRole { Name=roleName});

            //  await _unitofWork.SaveChangesAsync();
            if (res.Succeeded)
                return true;
            else
                return false;

        }

     
        #endregion

        #region User
        public async Task<bool> CreateUser(UserModel appUser)
        {
           // await _userManager.CreateAsync(new AppUser {UserName=appUser.UserName,Email=appUser.Email,PhoneNumber=appUser.Phone,LockoutEnabled=false,PhoneNumberConfirmed=true,TwoFactorEnabled=false },appUser.Password);

            await _unitofWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUser(UserModel appUser)
        {
            await _userManager.UpdateAsync(new AppUser { UserName = appUser.UserName, Email = appUser.Email, PhoneNumber = appUser.Phone });

            await _unitofWork.SaveChangesAsync();
            return true;
        }
     
        public async Task<UserModel> GetUserById(string userId)
        {
          var appUser= await _userManager.FindByIdAsync(userId);

          return _mapper.Map<UserModel>(appUser);
        }
        public async Task<AppUser> GetUserByIdOrEmailorUserNameOrMobile(string user_name_email_mobile)
        {
            AppUser appUser = null;
            appUser = await _userManager.FindByIdAsync(user_name_email_mobile);

            if(appUser==null)
             appUser = await _userManager.FindByNameAsync(user_name_email_mobile);

            if (appUser == null)
                appUser = await _userManager.FindByEmailAsync(user_name_email_mobile);

            return appUser;
        }
        #endregion

        #region  CliamMaster
        public async Task<bool> CreateClaim(ClaimModel claim)
        {
            await _repository.Create<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(_mapper.Map<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(claim));

            await _unitofWork.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateClaim(ClaimModel claim)
        {
            await _repository.Update<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(_mapper.Map<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(claim));

            await _unitofWork.SaveChangesAsync();

            return true;
        }

        public async Task<ClaimModel> GetClaimById(int Id)
        {
            var objClaim =  await _repository.Find<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(x => x.Id == Id);
            if (objClaim != null)
            {
                return _mapper.Map<ClaimModel>(objClaim);
            }

            return null;
           
        }

        public async Task<List<ClaimModel>> GetClaims()
        {
            var objClaims = await _repository.All<SME.ServiceAPI.Common.Idenitity.ClaimMaster>();
            if (objClaims != null)
            {
                 return objClaims.Select(x => _mapper.Map<ClaimModel>(x)).ToList();
            }

            return null;
        }
        //Role

        public async Task<bool> RoleClaimAssign()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteRoleClaim()
        {
            throw new NotImplementedException();
        }
        //User
        public async Task<List<RoleClaimModel>> GetRoleAssignedClaims(string roleId)
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
        #endregion

        #region SaveChanges commit
        //public async Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

    }
}
