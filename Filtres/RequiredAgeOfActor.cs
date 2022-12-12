using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class RequiredAgeOfActor : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var age = DateTime.Parse(context.HttpContext.Request.Form["DateOfBirth"]).Year;
        if (DateTime.Now.Year - age < 7 || DateTime.Now.Year - age > 99) 
            context.Result = new BadRequestResult();
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}
