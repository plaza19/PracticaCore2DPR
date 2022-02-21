using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Filters
{
    public class AuthorizeUsersAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user.Identity.IsAuthenticated == false)
            {
                context.Result = this.GetRedirectRoute("Manage", "Login");
            }
        }
        private RedirectToRouteResult GetRedirectRoute
           (string controller, string action)
        {
            RouteValueDictionary route =
                new RouteValueDictionary(new
                {
                    controller = controller,
                    action = action
                });
            RedirectToRouteResult result = new RedirectToRouteResult(route);
            return result;
        }

    }
}
