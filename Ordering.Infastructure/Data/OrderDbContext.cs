using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "ordering";
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // bunları da ayrı bi sınıfa taşı configuration
            modelBuilder.Entity<Order>().ToTable("Orders", DEFAULT_SCHEMA);
            //modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().ToTable("OrderItems", DEFAULT_SCHEMA);

            //modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            //modelBuilder.Entity<Order>().OwnsOne(o => o.Address).WithOwner();

            base.OnModelCreating(modelBuilder);
        }

    }
}
