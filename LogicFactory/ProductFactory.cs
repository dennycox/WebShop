using Logic;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
