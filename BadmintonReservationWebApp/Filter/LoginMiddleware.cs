

using Microsoft.AspNetCore.Http.Extensions;

namespace BadmintonReservationWebApp.Filter;

public class LoginMiddleware
{
    private readonly RequestDelegate _next;

    public LoginMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var url = httpContext.Request.GetEncodedUrl().ToLower();
        if (!url.Contains("login"))
        {
            var userString = httpContext.Session.GetString("CREDENTIAL");
            if (userString == null)
            {
                httpContext.Response.Redirect("/Login");
                return;
            }
        }
        await _next(httpContext);
    }
}
public static class LoginMiddlewareExtensions
{
    public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoginMiddleware>();
    }
}