using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Data;
using OrderService.Models;
namespace OrderService.Data
{
	public static class DbInitializer
	{
		public static void Init(OrderDbContext context)
		{
			//context.Database.EnsureDeleted(); // Tar bort först. Bäst så medan vi testar.
			context.Database.EnsureCreated();
			//context.SaveChanges();
		}
	}
}
