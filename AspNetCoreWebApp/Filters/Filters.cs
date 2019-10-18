using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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
}
