using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Filters
{
    public class ValidatePermissionFilter :Attribute, IAsyncActionFilter
    {
        private string _proc;
        public ValidatePermissionFilter(string process)
        {
            _proc = process;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Do something before the action executes.

            var slms = context.HttpContext.User.Claims.ToList();

            if (String.IsNullOrEmpty(_proc))
                return;
            var permission= context.HttpContext.User.Claims.Single(x => x.Type == "permission").Value;
            if (String.IsNullOrEmpty(permission))
               throw new UnauthorizedAccessException("dont have permission") ;

            var blRes = permission.Split(',').ToList().Contains(_proc);

            if (!blRes)
                throw new UnauthorizedAccessException("dont have permission");
            // next() calls the action method.
            var resultContext = await next();
                    // resultContext.Result is set.
                    // Do something after the action executes.
               
                   
            
              
           


        }
    }
}
