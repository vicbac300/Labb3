using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb1.Models;
using Labb1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Labb2.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductService productService;

        public CartController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult AddToCart(int id)
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

            return Ok();
        }
    }
}