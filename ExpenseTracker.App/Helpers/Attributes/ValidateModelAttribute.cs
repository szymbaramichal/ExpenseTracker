using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpenseTracker.App.Helpers.Attributes;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                context.Result = controller.View(context.ActionArguments["model"]);
            }
        }
    }
}