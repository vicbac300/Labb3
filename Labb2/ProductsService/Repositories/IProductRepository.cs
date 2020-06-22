using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsService.Models;
namespace ProductsService.Repositories
{
	public interface IProductRepository
	{
		Product GetById(int id);
		IEnumerable<Product> GetAll();
	}
}
