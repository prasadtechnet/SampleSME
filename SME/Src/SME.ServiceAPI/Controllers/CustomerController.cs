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

namespace SME.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {

        }

        [HttpGet("customers")]
        // [ValidatePermissionFilter("6")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll()
        {
            var IsValidClaim = HttpContext.ValidatePermission("2");
            if (!IsValidClaim)
                return Unauthorized("you don't have permission");

            return Ok("you will get data soon");
        }
    }
}