using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ShoppingCart : IShoppingCart
    {
        public int ProductID { get; set; }

        public int ProfileID { get; set; }

        public int Amount { get; set; }
    }
}
