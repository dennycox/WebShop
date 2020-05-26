using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.ViewModels.Product
{
    public class ProductSearchViewModel
    {
        public List<IProduct> Products { get; set; }
    }
}
