using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IShoppingCartCollection
    {
        IShoppingCart GetShoppingCartById(int id);
    }
}
