using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.ViewModels;

namespace WebShop.Repositories
{
    public interface IProductRepository
    {
        public List<ProductViewModel> GetAllProducts();
        public ProductViewModel GetProductById(int id);
        public void AddProduct(ProductViewModel product);
        public void UpdateProduct(ProductViewModel product);
        public void DeleteProduct(int id);
        public List<ProductViewModel> SearchProduct(string productName);
        List<ProductViewModel> GetProductsByCategory(string categoryName);
    }
}
