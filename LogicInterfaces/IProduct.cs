using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IProduct
    {
        int ProductID { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        decimal Price { get; set; }

        string ImagePath { get; set; }

        int CategoryId { get; set; }

        ICategory Category { get; set; }
    }
}
