using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace LMSSupportProject.Attributes
{
    [Route("api/Configuration")]
    public class APIAuthFilter : Attribute, IAuthorizationFilter
    {
        private IConfiguration _config;

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            _config = context.HttpContext.RequestServices.GetService<IConfiguration>();


            string APIKey = context.HttpContext.Request.Headers["APIKey"];
            string APISecret = context.HttpContext.Request.Headers["APISecret"];

            if (string.IsNullOrEmpty(APIKey) || string.IsNullOrEmpty(APISecret))
            {
                context.Result = new BadRequestResult();
            }
            else if (APIKey != _config.GetSection("Authentication").GetSection("APIKey").Value || APISecret != _config.GetSection("Authentication").GetSection("APISecret").Value)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
