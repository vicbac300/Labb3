﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsService.Models
{
	public class Product
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}
