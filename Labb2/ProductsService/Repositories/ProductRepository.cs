using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsService.Models;
using ProductsService.Data;
using Microsoft.AspNetCore.Mvc;

namespace ProductsService.Repositories
{
	[Route("api/products")]
	[ApiController]
	public class ProductRepository : IProductRepository
	{
		private readonly ProductDbContext context;

		public ProductRepository(ProductDbContext context)
		{
			this.context = context;
		}

		[HttpGet("getbyid")]
		public Product GetById(int id)
		{
			return context.Products.FirstOrDefault(product => product.ID == id);
		}

		[HttpGet("getall")]
		public IEnumerable<Product> GetAll()
		{
			return context.Products.ToList();
		}
	}
}
