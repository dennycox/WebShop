using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICategoryCollection _categoryCollection;

        public BaseController(ICategoryCollection categoryCollection)
        {
            this._categoryCollection = categoryCollection;
        }

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
            ViewBag.Categories = _categoryCollection.GetAllCategories();
        }
    }
}