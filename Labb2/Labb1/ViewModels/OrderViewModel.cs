using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb1.Models;
using OrderService.Models;
using ProductsService.Models;
namespace Labb1.ViewModels
{
	public class OrderViewModel
	{
		public Order Order { get; set; }
		public ApplicationUser User { get; set; }

		public Dictionary<int, Product> AllProducts { get; set; } // Key = ID, Value = Product

		public Product GetProduct(OrderRow orderRow)
		{
			return AllProducts[orderRow.ProductID];
		}
	}
}
