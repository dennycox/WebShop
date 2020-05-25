using DataInterfaces;
using DataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ProductDto : IProductDto
    {
        public int ProductID { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public int CategoryID { get; set; }
    }
}
