using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
        }
    }
}
