using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Extensions;
using SME.ServiceAPI.Business.Manager.User;

namespace SME.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Varaibles

        private IAppUserManager _userManager;
        private ILogger<UserController> _logger;

        #endregion

        #region Controller

        public UserController(IAppUserManager userManager,ILogger<UserController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        #endregion

        #region Endpoints

        #region Role      

        [HttpPost("createrole")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRole([FromBody] RoleNewModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.CreateRole(objInput.Name);
            if (blUser.Status== HttpStatusCode.OK)
                return Ok(blUser);

           else 
                return BadRequest(blUser);

        }

        [HttpGet("roles")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRoles()
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            var objRoles = await _userManager.Roles();
            if (objRoles != null)
                return Ok(objRoles);

            return NotFound("Roles not found");
        }


        //Claims
        [HttpGet("RoleClaims/{roleId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRoleAssignClaims([FromRoute] string roleId)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blRoleClaims = await _userManager.GetRoleAssignedClaims(roleId);
            if (blRoleClaims != null)
                return Ok(blRoleClaims);
            else

                return BadRequest("No Claims for requested role");
        }

        [HttpPost("RoleClaimAssign")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ClaimAssignToRole([FromBody] RoleClaimAssignModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blRole = await _userManager.RoleClaimAssign(objInput);
            if (blRole.Status == HttpStatusCode.OK)
                return Ok(blRole);
            else

                return BadRequest(blRole);
        }

        #endregion

        #region User

        [HttpGet("users")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsers()
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            var objUser = await _userManager.Users();
            if (objUser != null)
                return Ok(objUser);

            return NotFound("User not exisit");
        }

        [HttpGet("users/{nameMail}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByEmailOrName([FromRoute] string nameMail)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


         var objUser= await _userManager.GetUserByIdOrEmailorUserNameOrMobile(nameMail);
         if(objUser!=null)
               return Ok(objUser);

            return NotFound("User not exisit");
        }


        [HttpPost("create")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserNewModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.CreateUser(objInput);
            if (blUser.Status == HttpStatusCode.OK)
                return Ok(blUser);
            else

            return BadRequest(blUser);
        }
               
        
        [HttpPut("update")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] UserEditModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.UpdateUser(objInput);
            if (blUser.Status == HttpStatusCode.OK)
                return Ok(blUser);
            else

                return BadRequest(blUser);
        }


        //Role
        [HttpPost("AssignRole")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignRole([FromBody] UserRoleAssignModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.UserRoleAssign(objInput);
            if (blUser.Status == HttpStatusCode.OK)
                return Ok(blUser);
            else

                return BadRequest(blUser);
        }

        //Claim

        [HttpPost("UserClaimAssign")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ClaimAssignToUser([FromBody] UserClaimAssignModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.UserClaimAssign(objInput);
            if (blUser.Status == HttpStatusCode.OK)
                return Ok(blUser);
            else

                return BadRequest(blUser);
        }


        [HttpGet("UserClaims/{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserAssignClaims([FromRoute] string userId)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.GetUserAssignedClaims(userId);
            if (blUser!=null)
                return Ok(blUser);
            else

                return BadRequest("No Claims for requested user");
        }


       

        #endregion

        #region Claims

        [HttpPost("NewClaim")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateClaim([FromBody] ClaimNewModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.CreateClaim(objInput);
            if (blUser.Status == HttpStatusCode.OK)
                return Ok(blUser);
            else
                return BadRequest(blUser);
        }

        [HttpPost("UpdateClaim")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateClaim([FromBody] ClaimModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.UpdateClaim(objInput);
            if (blUser.Status == HttpStatusCode.OK)
                return Ok(blUser);
            else
                return BadRequest(blUser);
        }

        [HttpGet("cliams")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetClaims()
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            var objClaims = await _userManager.GetClaims();
            if (objClaims != null)
                return Ok(objClaims);

            return NotFound("Claims not found");
        }

        [HttpGet("cliam/{Id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetClaimById(int Id)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            var objClaims = await _userManager.GetClaimById(Id);
            if (objClaims != null)
                return Ok(objClaims);

            return NotFound("Claims not found");
        }
        [HttpGet("cliams/{Category}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetClaimsByCategory(string Category)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            var objClaims = await _userManager.GetClaimByCategory(Category);
            if (objClaims != null)
                return Ok(objClaims);

            return NotFound("Claims not found");
        }

        #endregion

        #endregion
    }
}