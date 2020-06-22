using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Repositories;
using ProductsService.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProductsService.Controllers
{
    
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository repository;
        
        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }

        
        public Task AddToCartAsync(int id)
        {
            var cart = Request.Cookies.SingleOrDefault(cookie => cookie.Key == "cart");
            string cartContent = "";

            if (cart.Value != null)
            {
                cartContent = cart.Value;
                cartContent += "," + id;
            }
            else
            {
                cartContent = id.ToString();
            }

            Response.Cookies.Append("cart", cartContent);

            return null;
        }



    }
}