using System;
using System.Collections.Generic;
using System.Linq;
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
            if (blUser)
                return Ok(blUser);
            else

                return BadRequest("User not created");
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

            return Ok("you will get data soon");
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
        public async Task<IActionResult> CreateUser([FromBody] UserModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.CreateUser(objInput);
            if (blUser)
                return Ok(blUser);
            else

            return BadRequest("User not created");
        }



    
        [HttpPut("update")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blUser = await _userManager.UpdateUser(objInput);
            if (blUser)
                return Ok(blUser);
            else

                return BadRequest("User not updated");
        }


        #endregion

        #region Claims

        #endregion
        #endregion
    }
}