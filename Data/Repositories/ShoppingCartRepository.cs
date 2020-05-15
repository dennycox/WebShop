using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Context;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IWebShopContext webShopContext;

        public ShoppingCartRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public List<ProductViewModel> GetShoppingCartProductsById(int id)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            return productViewModels;
        }
    }
}
