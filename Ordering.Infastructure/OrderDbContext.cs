using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;

namespace Ordering.Infastructure
{
    public class OrderDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "ordering";

        public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders", DEFAULT_SCHEMA);
            modelBuilder.Entity<Order>().Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Order>().Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");
            base.OnModelCreating(modelBuilder);
        }

    }
}
