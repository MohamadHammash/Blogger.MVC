//TODO GitFix
using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blogger.Ui.Filters
{
    public class ModelValid : Attribute
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ViewResult
                {
                    StatusCode = 400,
                    ViewData = ((Controller)context.Controller).ViewData,
                    TempData = ((Controller)context.Controller).TempData,
                };
            }
        }
    }
}