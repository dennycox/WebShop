using DataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ShoppingCartDto : IShoppingCartDto
    {
        public int ProductID { get; set; }

        public int ProfileID { get; set; }

        public int Amount { get; set; }
    }
}
