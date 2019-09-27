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
using SME.ServiceAPI.Business.Contracts.BusinessEntities;

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

        //#region Customer Authentication
        //[HttpPost("login")]
        //// [ValidatePermissionFilter("6")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> CustomerLogin([FromBody]CustomerAuthRequestModel objInput)
        //{
        //    //var IsValidClaim = HttpContext.ValidatePermission("2");
        //    //if (!IsValidClaim)
        //    //    return Unauthorized("you don't have permission");

        //    var objCust = await _customerManager.Authenticate(objInput);
        //    if (objCust != null)
        //        return Ok(objCust);

        //    return NotFound("Customer not found");

         
        //}

        //[HttpPost("passwordreset")]
        //// [ValidatePermissionFilter("6")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> PasswordReset([FromBody]CustomerResetRequestModel objInput)
        //{
        //    //var IsValidClaim = HttpContext.ValidatePermission("2");
        //    //if (!IsValidClaim)
        //    //    return Unauthorized("you don't have permission");

        //    var objCust = await _customerManager.ResetPassword(objInput);
        //    if (objCust != null)
        //        return Ok(objCust);

        //    return NotFound("Customer not found");
        //}

        //#endregion

        //#region Customer

        //[HttpGet("all")]
        //// [ValidatePermissionFilter("6")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> GetCustomers()
        //{
        //    //var IsValidClaim = HttpContext.ValidatePermission("2");
        //    //if (!IsValidClaim)
        //    //    return Unauthorized("you don't have permission");

        //    var objCust = await _customerManager.Customers();
        //    if (objCust != null)
        //        return Ok(objCust);

        //    return NotFound("Customer not found");
        //}

        //[HttpGet("customer/{Id}")]
        //// [ValidatePermissionFilter("6")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> GetCustomerById(string Id)
        //{
        //    //var IsValidClaim = HttpContext.ValidatePermission("2");
        //    //if (!IsValidClaim)
        //    //    return Unauthorized("you don't have permission");

        //    var objCust = await _customerManager.CustomerById(Id);
        //    if (objCust != null)
        //        return Ok(objCust);

        //    return NotFound("Customer not found");
        //}

        //[HttpGet("customer/{Name}")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetCustomerByName([FromRoute] string Name)
        //{
        //    //var IsValidClaim = HttpContext.ValidatePermission("2");
        //    //if (!IsValidClaim)
        //    //    return Unauthorized("you don't have permission");


        //    var objCust = await _customerManager.CustomerByName(Name);
        //    if (objCust != null)
        //        return Ok(objCust);

        //    return NotFound("Customer not found");
        //}
        //[HttpPost("create")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> CreateCustomer([FromBody] CustomerModel objInput)
        //{
        //    //var IsValidClaim = HttpContext.ValidatePermission("2");
        //    //if (!IsValidClaim)
        //    //    return Unauthorized("you don't have permission");


        //    var blPrd = await _customerManager.CreateCustomer(objInput);
        //    if (blPrd)
        //        return Ok(blPrd);
        //    else

        //        return BadRequest("Customer not created");
        //}

        //[HttpPut("update")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdateCustomer([FromBody] CustomerModel objInput)
        //{
        //    //var IsValidClaim = HttpContext.ValidatePermission("2");
        //    //if (!IsValidClaim)
        //    //    return Unauthorized("you don't have permission");


        //    var blPrd = await _customerManager.UpdateCustomer(objInput);
        //    if (blPrd)
        //        return Ok(blPrd);
        //    else

        //        return BadRequest("Customer not updated");
        //}

        //#endregion


        #endregion


    }
}