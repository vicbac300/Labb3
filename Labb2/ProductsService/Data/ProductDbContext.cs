using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsService.Models;

namespace ProductsService.Data
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Set integrity

            builder.Entity<Product>()
                .ToTable("Products");

            //builder.Entity<Product>(entity =>
            //{
            //    entity.Property(x => x.Name).HasMaxLength(500).IsRequired();
            //    entity.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            //});

            //// Set index on product name for faster searching
            //builder.Entity<Product>().HasIndex(x => x.Name);
        }
    }
}
