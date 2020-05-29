using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Models
{
    public interface IShoppingCartDto
    {
        int ProductID { get; set; }

        int ProfileID { get; set; }

        int Amount { get; set; }
    }
}
