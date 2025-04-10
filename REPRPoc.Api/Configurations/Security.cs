using FastEndpoints.Security;
using REPRPoc.Contracts.Authentication;
using System.Text;

namespace REPRPoc.Api.Configurations
{
    public static class Security
    {
        public static IServiceCollection ConfigureSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.AddAuthenticationJwtBearer(s => s.SigningKey = configuration["JwtOptions:SecretKey"]);
            services.AddAuthorization();

            return services;
        }

        public static IApplicationBuilder UseSecurity(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
