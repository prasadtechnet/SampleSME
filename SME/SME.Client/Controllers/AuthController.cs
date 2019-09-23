using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.Client.Models.Auth;
using SME.Client.Services;

namespace SME.Client.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService, IHttpContextAccessor httpContext)
        {
            _authService = authService;
        }
        public async Task<IActionResult> Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel objInput)
        {

            var resp=await _authService.Authenticate(objInput);
            if (resp != null)
            {
                HttpContext.Session.SetString("token", resp.token);
                return RedirectToAction("Index", "Home");
            }

            return View(objInput);
        }
    }
}