using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Category : ICategory
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
