using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Repositories
{
    public interface IShoppingCartRepository
    {
        public List<Product> GetShoppingCartProductsById(int id);
    }
}
