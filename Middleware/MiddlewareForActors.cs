using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace MoviesApp.Middleware;

public class MiddlewareForActors
{
    private readonly RequestDelegate _next;
    private readonly ILogger<MiddlewareForActors> _logger;

    public MiddlewareForActors(RequestDelegate next, ILogger<MiddlewareForActors> logger)
    {
        _next = next;
        _logger = logger;
    }

    public  Task InvokeAsync(HttpContext httpContext)
    {
        if (httpContext.Request.GetDisplayUrl().Contains("Actor"))
        {
            _logger.LogInformation(httpContext.Request.Method);
            _logger.LogInformation(httpContext.Request.Path);
            _logger.LogInformation(httpContext.Request.Protocol);
            _logger.LogInformation(httpContext.Request.ContentType);
            _logger.LogInformation(httpContext.Request.QueryString.Value);
        }

        return _next(httpContext);
    }
}

public static class CustomMiddlewareForActorsExtension
{
    public static IApplicationBuilder UseCustom(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MiddlewareForActors>();
    }
}