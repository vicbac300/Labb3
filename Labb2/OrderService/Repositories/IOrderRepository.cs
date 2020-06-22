using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
namespace OrderService.Repositories
{
	public interface IOrderRepository
	{
		IActionResult Add(Order order);
	}
}
