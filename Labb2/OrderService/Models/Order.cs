using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
	public class Order
	{
		public Guid ID { get; set; }
		public DateTime Date { get; set; }
		public Guid UserID { get; set; }
		public List<OrderRow> OrderRows { get; set; }
		public decimal TotalPrice { get; set; }
	}

	public class OrderRow
	{
		public Guid ID { get; set; }
		public int ProductID { get; set; }
		public int Amount { get; set; }
	}
}
