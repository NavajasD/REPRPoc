using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NSwag;

namespace REPRPoc.Api.Configurations
{
    public static class Swagger
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.SwaggerDocument(o =>
            {
                o.DocumentSettings = s =>
                {
                    s.DocumentName = "Initial Release";
                    s.Title = "REPR with FastEndpoints Demo API";
                    s.Version = "v0";
                };
            });
            services.SwaggerDocument(o =>
            {
                o.MaxEndpointVersion = 1;
                o.DocumentSettings = s =>
                {
                    s.DocumentName = "Release 1";
                    s.Title = "REPR with FastEndpoints Demo API";
                    s.Version = "v1";
                };
            });
            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app)
        {
            app.UseSwaggerGen();

            return app;
        }
    }
}
