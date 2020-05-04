using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class BaseController : Controller
    {
        public override ViewResult View(object model)
        {
            AddCategories();
            return base.View(model);
        }

        public override ViewResult View()
        {
            AddCategories();
            return base.View();
        }

        private void AddCategories()
        {
            ViewBag.Categories = Enum.GetNames(typeof(Category)).ToList();
        }
    }
}