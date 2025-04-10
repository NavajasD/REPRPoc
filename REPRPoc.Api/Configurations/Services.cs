using REPRPoc.AuthenticationDummy;
using REPRPoc.Contracts.Authentication;

namespace REPRPoc.Api.Configurations
{
    public static class Services
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
        
    }
}
