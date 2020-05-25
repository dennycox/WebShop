using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Models
{
    public interface IProductDto
    {
        int ProductID { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        decimal Price { get; set; }

        string ImagePath { get; set; }

        int CategoryID { get; set; }
    }
}
