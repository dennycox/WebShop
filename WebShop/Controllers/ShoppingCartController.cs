using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class ShoppingCartController : BaseController
    {
        public IActionResult Index()
        {
            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
            return View();
        }
    }
}