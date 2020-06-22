using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using System.Net.Http;
namespace OrderService.Repositories
{
	[Route("api/orders")]
	[ApiController]
	public class OrderRepository : ControllerBase, IOrderRepository
	{
		private readonly OrderDbContext context;

		public OrderRepository(OrderDbContext context)
		{
			this.context = context;
		}

		[HttpPost("add")]
		public IActionResult Add(Order order)
		{

			order.ID = Guid.NewGuid();
			context.Orders.Add(order);
			context.SaveChanges();

			


			return Ok(order.ID);
		}

		[HttpGet("getall")]
		public IEnumerable<Order> GetAll()
		{
			return context.Orders.ToList();
		}

		[HttpPost("test")]
		public IActionResult Test()
		{
			return Ok("SVAR!");
		}
	}
}
