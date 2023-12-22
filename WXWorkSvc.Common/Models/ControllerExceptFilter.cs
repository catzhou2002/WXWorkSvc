using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WXWork7;
/// <summary>
/// [TypeFilter(typeof(ExceptFilterService))]
/// </summary>
public class ControllerExceptFilter : Attribute, IExceptionFilter
{
    private readonly ILogger<ControllerExceptFilter> _Logger;
    public ControllerExceptFilter(ILogger<ControllerExceptFilter> logger)
    {
        _Logger = logger;
    }
    public void OnException(ExceptionContext context)
    {
        context.Result = new BadRequestResult();// new NotFoundResult();
        _Logger.LogError($"{context.Exception.Message}\r\n{context.Exception.InnerException?.Message}\r\n{context.Exception.StackTrace}");
        context.ExceptionHandled = true;
    }
}
