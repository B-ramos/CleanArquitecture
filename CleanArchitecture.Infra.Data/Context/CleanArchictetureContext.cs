using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Infra.Data.Context
{
    public class CleanArchictetureContext : DbContext
    {
        public CleanArchictetureContext(DbContextOptions<CleanArchictetureContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
