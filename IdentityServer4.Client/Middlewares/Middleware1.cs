namespace IdentityServer4.Client.Middlewares
{
    public class Middleware1
    {
        RequestDelegate _next;
        public Middleware1(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await _next.Invoke(httpContext);
        }
    }
}
