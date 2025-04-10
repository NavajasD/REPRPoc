using Microsoft.EntityFrameworkCore;
using REPRPoc.Contracts.Persistance.Repositories;
using REPRPoc.Persistance;
using REPRPoc.Persistance.Repositories;

namespace REPRPoc.Api.Configurations
{
    public static class Persistence
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(op =>
            {
                op.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            return services;
        }
    }
}
