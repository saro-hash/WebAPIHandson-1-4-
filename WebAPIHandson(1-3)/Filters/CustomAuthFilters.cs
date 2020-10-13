using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIHandson_1_3_.Filters
{
    public class CustomAuthFilters:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var req = context.HttpContext.Request;
            var hasHeader = req.Headers.ContainsKey("Authorization");
            if (!hasHeader)
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
            else
            {
                var head = req.Headers["Authorization"].ToString();
                if (!head.StartsWith("bearer"))
                    context.Result =
                        new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
            }
        }

    }
}
