using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ProductsService.Models;
using ProductsService.Repositories;
using System.Threading.Tasks;
using System.Net;

namespace ProductsService.Tests
{
	public class ProductsServiceTests
	{
		[Fact]
		public async Task GetAllProducts_Returns_Ok()
		{
			using (var client = new TestClientProvider().Client)
			{
				var response = await client.GetAsync("/api/products/getall");
				response.EnsureSuccessStatusCode();

				Assert.Equal(HttpStatusCode.OK, response.StatusCode);
			}
		}

		[Fact]
		public async Task GetProductById_Returns_NotFound()
		{
			using (var client = new TestClientProvider().Client)
			{
				var response = await client.GetAsync("/api/products/getbyid?id=" + 0);
				string strResponse = await response.Content.ReadAsStringAsync();

				Assert.Equal("", strResponse);
			}
		}

		[Fact]
		public async Task GetProductById_Returns_Found()
		{
			using (var client = new TestClientProvider().Client)
			{
				var response = await client.GetAsync("/api/products/getbyid?id=" + 1);
				string strResponse = await response.Content.ReadAsStringAsync();

				Assert.False(string.IsNullOrWhiteSpace(strResponse));
			}
		}
	}
}
