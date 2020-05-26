using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        private ICategory _category;

        public ICategory Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                CategoryId = _category.CategoryId;
            }
        }
    }
}
