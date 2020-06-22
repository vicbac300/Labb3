using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb1.Models;
using OrderService.Models;
namespace Labb1.Services
{
	public class OrderService : IOrderService
	{
		private readonly ApiService apiService;

		public OrderService(ApiService apiService)
		{
			this.apiService = apiService;
		}

		public Guid Add(Order order)
		{
			Guid id = apiService.Post<Order, Guid>(order, "api/orders/add", ApiService.ORDER_SERVICE_DOMAIN);
			return id;
		}
	}
}
