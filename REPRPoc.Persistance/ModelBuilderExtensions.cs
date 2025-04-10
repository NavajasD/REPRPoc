using Microsoft.EntityFrameworkCore;
using REPRPoc.Entities;
using REPRPoc.EntitySeeds;
using REPRPoc.Persistance.EntityConfiguration;

namespace REPRPoc.Persistance
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ConfigureEntities(this ModelBuilder builder)
        {
            new CarConfiguration().Configure(builder.Entity<Car>());

            return builder;
        }

        public static ModelBuilder SeedEntities(this ModelBuilder builder)
        {
            builder.Entity<Car>().HasData(CarSeeds.InitialSeed);

            return builder;
        }
    }
}
