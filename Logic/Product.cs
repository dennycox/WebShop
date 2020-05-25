using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Logic
{
    public class Product : IProduct
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
    }
}
