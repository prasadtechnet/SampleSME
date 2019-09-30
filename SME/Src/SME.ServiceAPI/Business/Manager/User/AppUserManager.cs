using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Contracts.Response;
using SME.ServiceAPI.Common.Idenitity;
using SME.ServiceAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
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
        public async Task<ResponseModel> CreateRole(string roleName)
        {
            try
            {
                var res = await _roleManager.CreateAsync(new AppRole { Name = roleName });

                //  await _unitofWork.SaveChangesAsync();
                if (res.Succeeded)
                    return new ResponseModel { Status = HttpStatusCode.OK, Success = "Role has created" };
                else
                    return new ResponseModel { Status = HttpStatusCode.BadRequest, Errors = res.Errors.Select(x => x.Code + "-" + x.Description) };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
          

        }

        public async Task<List<RoleModel>> Roles()
        {
            try
            {
                var lsRoles = _roleManager.Roles.Select(x => _mapper.Map<RoleModel>(x)).ToList();
                return lsRoles;
            }
            catch (System.Exception ex)
            {
            }

            return null;
        }

        public async Task<ResponseModel> RoleClaimAssign(RoleClaimAssignModel roleClaim)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleClaim.RoleId);
                if (role == null)
                    return new ResponseModel { Status = HttpStatusCode.BadRequest, Errors = new[] { "Role not found" } };

                var res = await _roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(roleClaim.ClaimType, roleClaim.ClaimValue));
                if (res.Succeeded)
                    return new ResponseModel { Status = HttpStatusCode.OK, Success = "Claim has assigned to role" };
                else
                    return new ResponseModel { Status = HttpStatusCode.BadRequest, Errors = res.Errors.Select(x => x.Code + "-" + x.Description) };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:"+ex.Message } };
            }
          

        }
        public async Task<ResponseModel> DeleteRoleClaim(RoleClaimAssignModel roleClaim)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
          
        }
        public async Task<List<RoleClaimModel>> GetRoleAssignedClaims(string roleId)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null)
                    return null;

                var res = await _roleManager.GetClaimsAsync(role);
                if (res != null)
                {
                    return res.Select(x => new RoleClaimModel {ClaimType=x.Type,ClaimValue=x.Value,RoleId=roleId }).ToList();
                }

            }
            catch (System.Exception)
            {

            }
           

            return null;
        }
        #endregion

        #region User
        public async Task<ResponseModel> CreateUser(UserNewModel appUser)
        {
            try
            {
                var resp = await _userManager.CreateAsync(new AppUser { UserName = appUser.UserName, Email = appUser.Email, PhoneNumber = appUser.Phone, LockoutEnabled = false, PhoneNumberConfirmed = true, TwoFactorEnabled = false }, appUser.Password);
                if (resp.Succeeded)
                    return new ResponseModel { Status = HttpStatusCode.OK, Success = "User has created" };
                else
                    return new ResponseModel { Status = HttpStatusCode.BadRequest, Errors = resp.Errors.Select(x => x.Code + "-" + x.Description) };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
          
        }
        public async Task<ResponseModel> UpdateUser(UserEditModel appUser)
        {
            try
            {
                var appUserData = await _userManager.FindByIdAsync(appUser.Id);
                if (appUserData != null)
                {
                    appUserData.UserName = appUser.UserName;
                    appUserData.PhoneNumber = appUser.Phone;

                    var resp = await _userManager.UpdateAsync(appUserData);
                    if (resp.Succeeded)
                        return new ResponseModel { Status = HttpStatusCode.OK, Success = "User has updated" };
                    else
                        return new ResponseModel { Status = HttpStatusCode.BadRequest, Errors = resp.Errors.Select(x => x.Code + "-" + x.Description) };
                }
                // await _unitofWork.SaveChangesAsync();
                return new ResponseModel { Status = HttpStatusCode.BadRequest, Errors = new[] { "Got error while updating" } };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
          
        }
     
        public async Task<UserModel> GetUserById(string userId)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(userId);

                return _mapper.Map<UserModel>(appUser);
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }
        public async Task<UserModel> GetUserByIdOrEmailorUserNameOrMobile(string user_name_email)
        {
            try
            {
                AppUser appUser = null;
                appUser = await _userManager.FindByIdAsync(user_name_email);

                if (appUser == null)
                    appUser = await _userManager.FindByNameAsync(user_name_email);

                if (appUser == null)
                    appUser = await _userManager.FindByEmailAsync(user_name_email);

                return _mapper.Map<UserModel>(appUser);
            }
            catch (System.Exception ex)
            {   
            }
            return null;
        }
        public async Task<List<UserModel>> Users()
        {
            try
            {
                var lsUser = _userManager.Users.Select(x => _mapper.Map<UserModel>(x)).ToList();

                return lsUser;
            }
            catch (System.Exception ex)
            {
            }
            return null;
        }

        public async Task<ResponseModel> UserRoleAssign(UserRoleAssignModel userRole)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(userRole.UserId);
                var res = await _userManager.AddToRoleAsync(appUser, userRole.RoleName);
                if (res.Succeeded)
                    return new ResponseModel { Status = HttpStatusCode.OK, Success = "Role has assigned to user" };
                else
                    return new ResponseModel { Status = HttpStatusCode.BadRequest, Errors = res.Errors.Select(x => x.Code + "-" + x.Description) };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }

        public async Task<ResponseModel> UserClaimAssign(UserClaimAssignModel userClaim)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(userClaim.UserId);
                var res = await _userManager.AddClaimAsync(appUser, new System.Security.Claims.Claim(userClaim.ClaimType, userClaim.ClaimValue));
                if (res.Succeeded)
                    return new ResponseModel { Status = HttpStatusCode.OK, Success = "claim has assigned to user" };
                else
                    return new ResponseModel { Status = HttpStatusCode.BadRequest, Errors = res.Errors.Select(x => x.Code + "-" + x.Description) };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }
        public async Task<ResponseModel> UserClaimListAssign(UserClaimsAssignModel userClaim)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(userClaim.UserId);

                var res = await _userManager.AddClaimsAsync(appUser, userClaim.Claims.Select(x=> new System.Security.Claims.Claim(x.ClaimType, x.ClaimValue)));
                if (res.Succeeded)
                    return new ResponseModel { Status = HttpStatusCode.OK, Success = "claim has assigned to user" };
                else
                    return new ResponseModel { Status = HttpStatusCode.BadRequest, Errors = res.Errors.Select(x => x.Code + "-" + x.Description) };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
        }

        public async Task<ResponseModel> DeleteUserClaim(UserClaimAssignModel userClaim)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
            throw new NotImplementedException();
        }
        public async Task<List<UserClaimModel>> GetUserAssignedClaims(string userId)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(userId);

               var lsClaims=await _userManager.GetClaimsAsync(appUser);
                return lsClaims.Select(x => new UserClaimModel {UserId=userId,ClaimType=x.Type,ClaimValue=x.Value }).ToList();
            }
            catch (System.Exception ex)
            {
            }
            return null;
        }

        public async Task<List<UserClaimModel>> GetUserPermittedClaims(string userId)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(userId);

                var lsUserClaims = new List<Claim>();
                var lsRoleClaims = new List<Claim>();
                //Get Roles & RoleClaims
                var userRoles = (await _userManager.GetRolesAsync(appUser));
                if (userRoles != null)
                {
                    foreach (var roleName in userRoles)
                    {
                        var role = await _roleManager.FindByIdAsync(roleName);
                        var lsRClaim = await _roleManager.GetClaimsAsync(role);

                        lsRoleClaims.AddRange(lsRClaim);
                    }

                }

                //GetUser Claims
                lsUserClaims = (await _userManager.GetClaimsAsync(appUser)).ToList();


                //common claims

               
            }
            catch (System.Exception ex)
            {
            }
            return null;
        }

        public async Task<List<int>> GetUserPermittedClaimsWithMapping(string userId)
        {
            try
            {
                var lsClaimIds = new List<int>();
                var appUser = await _userManager.FindByIdAsync(userId);

               var lsUserClaims = (await _userManager.GetClaimsAsync(appUser)).ToList();

               var lsClaimMaster = (await _repository.All<ClaimMaster>()).ToList();
                foreach (var uc in lsUserClaims)
                {
                   var cm= lsClaimMaster.Find(x => x.Category == uc.Type && x.ClaimValue == uc.Value);
                    if (cm != null)
                    {
                        lsClaimIds.Add(cm.Id);
                    }
                }

                return lsClaimIds;

            }
            catch (System.Exception ex)
            {
            }

            return null;
        }

        #endregion

        #region  CliamMaster
        public async Task<ResponseModel> CreateClaim(ClaimNewModel claim)
        {
            try
            {
                await _repository.Create<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(_mapper.Map<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(claim));

                await _unitofWork.SaveChangesAsync();
                //if(res>0)
                return new ResponseModel { Status = HttpStatusCode.OK, Success = "Claim has created" };
                //else
                //    return new ResponseModel { Status = false, Errors = res.Errors.Select(x => x.Code + "-" + x.Description) };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
          
        }
        public async Task<ResponseModel> UpdateClaim(ClaimModel claim)
        {
            try
            {

          
            await _repository.Update<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(_mapper.Map<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(claim));

            await _unitofWork.SaveChangesAsync();

            return new ResponseModel { Status = HttpStatusCode.OK, Success = "Claim has updated" };
                //else
                //    return new ResponseModel { Status = false, Errors = res.Errors.Select(x => x.Code + "-" + x.Description) }; 
            }
            catch (System.Exception ex)
            {
                return new ResponseModel { Status = HttpStatusCode.InternalServerError, Errors = new[] { "Exception:" + ex.Message } };
            }
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

        public async Task<List<ClaimModel>> GetClaimByCategory(string Category)
        {
            var objClaims = await _repository.Filter<SME.ServiceAPI.Common.Idenitity.ClaimMaster>(x => x.Category == Category);
            if (objClaims != null)
            {
                return objClaims.Select(x => _mapper.Map<ClaimModel>(x)).ToList();
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
            
        #endregion

        #region SaveChanges commit
        //public async Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

    }
}
