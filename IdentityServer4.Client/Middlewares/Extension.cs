using System.Runtime.CompilerServices;

namespace IdentityServer4.Client.Middlewares
{
    public static class Extension
    {
        public static IApplicationBuilder MiddlewareExtension(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CookieAuthMiddleware>();
        }
    }
}
