using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IShoppingCart
    {
        int ProductID { get; set; }

        int ProfileID { get; set; }

        int Amount { get; set; }
    }
}
