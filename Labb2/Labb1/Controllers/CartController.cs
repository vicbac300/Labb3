﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Labb1.Services;
using Labb1.ViewModels;
using Labb1.Models;
using OrderService.Models;
namespace Labb1.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly UserManager<ApplicationUser> userManager;

        public CartController(UserManager<ApplicationUser> userManager, IProductService productService, IOrderService orderService)
        {
            this.userManager = userManager;
            this.productService = productService;
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            var cart = Request.Cookies.SingleOrDefault(cookie => cookie.Key == "cart");
            string[] cartIds = new string[0];
            if (cart.Key != null && cart.Value != null)
            {
                cartIds = cart.Value.Split(',');
            }

            var products = productService.GetAll();

            CartViewModel vm = new CartViewModel();
            vm.CreatedTicks = DateTime.Now.Ticks;
            vm.Test = 101;

            Dictionary<int, CartItem> cartItemDict = new Dictionary<int, CartItem>();
            foreach (string idStr in cartIds)
            {
                int id = int.Parse(idStr);

                if (cartItemDict.ContainsKey(id))
                    cartItemDict[id].Amount++;
                else
                {
                    cartItemDict.Add(id,
                        new CartItem() { Product = productService.GetByID(id), Amount = 1 });
                }

            }

            vm.Products = cartItemDict.Values.ToList();

            // Totalpris.
            decimal total = 0m;
            foreach (var item in vm.Products)
            {
                total += (item.Product.Price * item.Amount);
            }
            vm.TotalPrice = total;
            ///

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([Bind("TotalPrice,Products,Test")]CartViewModel vm)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            Order order = new Order();
            order.TotalPrice = vm.TotalPrice;
            order.Date = DateTime.Now;
            order.OrderRows = vm.Products.ToOrderRowList();

            
            order.UserID = Guid.Parse(userManager.GetUserId(User));

            Guid orderGuid = orderService.Add(order);
            order.ID = orderGuid;

            if (order.ID == Guid.Empty)
            {
                throw new Exception("Fel");
            }

            orderViewModel.Order = order;
            orderViewModel.User = await userManager.GetUserAsync(User);


            orderViewModel.AllProducts = new Dictionary<int, ProductsService.Models.Product>();
            foreach (var product in productService.GetAll())
            {
                orderViewModel.AllProducts.Add(product.ID, product);
            }

            return View("OrderSuccess", orderViewModel);
        }

    }
}