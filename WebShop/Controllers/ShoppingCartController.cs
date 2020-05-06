using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ShoppingCartController : BaseController
    {
        public IActionResult Index()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            return View();
        }
    }
}