using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.ServiceAPI.Business.Filters;
using SME.ServiceAPI.Business.Extensions;
using System.Net;
using SME.ServiceAPI.Business.Manager.Customer;
using Microsoft.Extensions.Logging;

namespace SME.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        #region variables

        private ICustomerManager _customerManager;
        private ILogger<CustomerController> _logger;
        #endregion

        #region Controller
        public CustomerController(ICustomerManager customerManager, ILogger<CustomerController> logger)
        {
            _customerManager = customerManager;
            _logger = logger;
        }
        #endregion


        #region Endpoints

        #region Customer Authentication
        [HttpPost("login")]
        // [ValidatePermissionFilter("6")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CustomerLogin()
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            return Ok("you will get data soon");
        }

        [HttpPost("passwordreset")]
        // [ValidatePermissionFilter("6")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PasswordReset()
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            return Ok("you will get data soon");
        }

        #endregion

        #region Customer

        [HttpGet("all")]
        // [ValidatePermissionFilter("6")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCustomers()
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            return Ok("you will get data soon");
        }

        [HttpGet("customer/{Id}")]
        // [ValidatePermissionFilter("6")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCustomerById(string Id)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            return Ok("you will get data soon");
        }

        #endregion


        #endregion


    }
}