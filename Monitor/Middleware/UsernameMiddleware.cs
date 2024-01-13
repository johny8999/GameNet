namespace Template.Middleware;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class UsernameMiddleware
{
    private readonly RequestDelegate _next;

    public UsernameMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
      //  httpContext.Request.Headers["username"]= httpContext.Request.Headers["username"].ToString().ToUpper();
        return _next(httpContext);
    }
}

