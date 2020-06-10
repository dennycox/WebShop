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

        private decimal _price { get; set; }

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else
                {
                    _price = 0;
                }
            }
        }

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
