using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpenseTracker.App.Helpers.Attributes;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public string ActionName { get; set; } = string.Empty;
    public string ControllerName { get; set; } = string.Empty;
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                if(string.IsNullOrEmpty(ActionName))
                    context.Result = controller.View(context.ActionArguments["model"]);
                else
                    context.Result = controller.RedirectToAction(ActionName, ControllerName, context.ActionArguments["model"]);
            }
        }
    }
}