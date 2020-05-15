using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Models;

namespace LogicFactory
{
    public static class ProductFactory
    {
        public static IProduct GetProduct()
        {
            return new Product();
        }
    }
}
