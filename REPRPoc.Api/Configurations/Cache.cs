namespace REPRPoc.Api.Configurations
{
    public static class Cache
    {
        public static IServiceCollection ConfigureCache(this IServiceCollection services)
        {
            services.AddResponseCaching();

            return services;
        }

        public static IApplicationBuilder UseCache(this IApplicationBuilder app)
        {
            app.UseResponseCaching();

            return app;
        }
    }
}
