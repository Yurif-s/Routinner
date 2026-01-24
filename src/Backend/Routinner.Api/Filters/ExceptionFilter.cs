using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Routinner.Communication.Responses;
using Routinner.Exception;
using Routinner.Exception.ExceptionsBase;

namespace Routinner.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is RoutinnerException routinnerException)
            HandleProjectException(routinnerException, context);
        else
            ThrowUnknowError(context);
    }
    private static void HandleProjectException(RoutinnerException routinnerException, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = routinnerException.StatusCode;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson(routinnerException.GetErrors()));
    }
    private static void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson(ResourceMessagesException.UNKNOW_ERROR));
    }
}
