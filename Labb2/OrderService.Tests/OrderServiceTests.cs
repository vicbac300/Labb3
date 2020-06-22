using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OrderService.Models;
using OrderService.Repositories;
using System.Threading.Tasks;
using System.Net;

namespace OrderService.Tests
{
	public class OrderServiceTests
	{
		[Fact]
		public async Task GetAllOrders_Returns_Ok()
		{
			using (var client = new TestClientProvider().Client)
			{
				var response = await client.GetAsync("/api/orders/getall");
				response.EnsureSuccessStatusCode();

				Assert.Equal(HttpStatusCode.OK, response.StatusCode);
			}
		}
	}
}
