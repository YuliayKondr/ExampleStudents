using ExampleDomen.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleInfrastructure.DbContexts
{
    public class ExampleContext : DbContext, IDataContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public ExampleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}