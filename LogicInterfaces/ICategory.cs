using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface ICategory
    {
        int CategoryId { get; set; }

        string CategoryName { get; set; }
    }
}
