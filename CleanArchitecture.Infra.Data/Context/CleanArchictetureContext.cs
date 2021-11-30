using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Infra.Data.Context
{
    public class CleanArchictetureContext : DbContext
    {
        public CleanArchictetureContext(DbContextOptions<CleanArchictetureContext> options) : base(options) { }

        // DbSet representa nossas tabelas no banco através dos nossos modelos de classes
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuração para usar na pasta configuration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
