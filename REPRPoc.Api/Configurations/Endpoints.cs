using FastEndpoints;
using REPRPoc.Endpoints;
using REPRPoc.Endpoints.Test.Get.V0;

namespace REPRPoc.Api.Configurations
{
    public static class Endpoints
    {
        public static IServiceCollection ConfigureFastEndpoints(this IServiceCollection services)
        {
            services.AddFastEndpoints(o => o.Assemblies = new[]
            { 
                typeof(EndpointHandler).Assembly 
            });

            return services;
        }

        public static IApplicationBuilder UseFastEndpoints(this IApplicationBuilder app)
        {
            app.UseFastEndpoints(o =>
            {
                o.Endpoints.RoutePrefix = "api";
                o.Versioning.Prefix = "v";
            });
            return app;
        }
    }
}
