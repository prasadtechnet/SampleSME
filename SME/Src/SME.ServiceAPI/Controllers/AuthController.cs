using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.ServiceAPI.Business.Contracts.Request;
using SME.ServiceAPI.Business.Manager.Auth;

namespace SME.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthManager _authManager;
        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }
        //[HttpPost("login")]
        //public async Task<IActionResult> Authenticate(AuthLoginModel authLogin)
        //{
        //    var resp= await _authManager.Authenticate(authLogin.email, authLogin.password);

        //    return Ok(resp);
        //}

        //[HttpPost("sp")]
        //public async Task<IActionResult> TestStoredprocedure()
        //{
        //    var resp = await _authManager.GetKey("TDO");

        //    return Ok(resp);
        //}
    }
}