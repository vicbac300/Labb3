using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb1.Models;
using OrderService.Models;

namespace Labb1.Services
{
	public interface IOrderService
	{
		Guid Add(Order order);
	}
}
