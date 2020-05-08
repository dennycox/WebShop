using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.ViewModels;

namespace WebShop.Repositories
{
    public interface IShoppingCartRepository
    {
        public List<ProductViewModel> GetShoppingCartProductsById(int id);
    }
}
