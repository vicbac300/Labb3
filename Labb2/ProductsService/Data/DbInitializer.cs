using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsService.Models;
namespace ProductsService.Data
{
	public static class DbInitializer
	{
		public static void Init(ProductDbContext context)
		{
			//context.Database.EnsureDeleted(); // Tar bort först. Bäst så medan vi testar.
			bool a = context.Database.EnsureCreated();

			if (context.Products.Count() > 0)
			{
				// Finns redan objekt i databasen.
				return;
			}

			int id = 1;
			Product[] products = new Product[]
			{
				new Product() { Name = $"Produkt {id}", Price = 100 + id++},
				new Product() { Name = $"Produkt {id}", Price = 100 + id++},
				new Product() { Name = $"Produkt {id}", Price = 100 + id++},
				new Product() { Name = $"Produkt {id}", Price = 100 + id++},
				new Product() { Name = $"Produkt {id}", Price = 100 + id++},
				new Product() { Name = $"Produkt {id}", Price = 100 + id++}
			};

			context.Products.AddRange(products);
			context.SaveChanges();
		}
	}
}
