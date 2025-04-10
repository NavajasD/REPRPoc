using Microsoft.EntityFrameworkCore;
using REPRPoc.Contracts.Persistance;
using REPRPoc.Entities;

namespace REPRPoc.Persistance
{
    public class DatabaseContext : DbContext, IUnitOfWork
    {
        public virtual DbSet<Car> Cars { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureEntities();
            modelBuilder.SeedEntities();
        }
    }
}
