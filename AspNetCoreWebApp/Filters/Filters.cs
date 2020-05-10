using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApp.DbModels.CalculatorDbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace AspNetCoreWebApp.Filters
{

    public class CustomerFilterAttribute : ActionFilterAttribute
    {
        private bool _canContinue;

        public CustomerFilterAttribute(bool canContinue)
        {
            _canContinue = canContinue;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            context.ActionArguments["isContinue"] = true;
            if (!_canContinue)
            {
                context.ActionArguments["isContinue"] = false;
                context.Result = new EmptyResult();
            }
        }


    }


    public class CustomAuthorizationAttribute:TypeFilterAttribute
    {
        public CustomAuthorizationAttribute():base(typeof(CustomAuthorizationFilter))
        {

        }





        private class CustomAuthorizationFilter : IAsyncAuthorizationFilter
        {
            private readonly UserManager<AspNetUsers> _userManager;

            public CustomAuthorizationFilter(UserManager<AspNetUsers> userManager)
            {
                _userManager = userManager;
            }

            //public void OnAuthorization(AuthorizationFilterContext context)
            //{
            //    var user=_userManager.getus
            //}

            public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
            {
                if (context.HttpContext.User != null)
                {
                    var user = await _userManager.GetUserAsync(context.HttpContext.User);
                    if (user!=null&&user.LockoutEnabled && user.LockoutEnd.HasValue)
                    {
                        var lockOutFromDate = user.LockoutEnd.Value;
                        var remainingValidDays = (DateTime.Now - lockOutFromDate).TotalDays;
                        var isLockedOut = false;
                        if (remainingValidDays > 0)
                        {
                            isLockedOut = true;
                        }
                        if (isLockedOut)
                            context.Result = new RedirectToActionResult("Lockout", "Account", new { @area = "Identity" });
                    }
                    else
                    {

                        context.Result = new RedirectToActionResult("Login", "Account", new { @area = "Identity" });
                        //context.Result = new ViewResult(new RouteValueDictionary( new { area = "Identity", controller = "Account", action = "Login" });
                    }
                }

            }
        }
    }
}
