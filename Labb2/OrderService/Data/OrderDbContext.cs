using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Models;
namespace OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Set integrity

            builder.Entity<Order>()
                .ToTable("Orders");


            //builder.Entity<Order>(entity =>
            //{
            //    entity.Property(x => x.).HasMaxLength(500).IsRequired();
            //    entity.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            //});


        }
    }
}
