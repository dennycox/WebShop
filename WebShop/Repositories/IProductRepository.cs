using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
        public List<Product> SearchProduct(string productName);
        List<Product> GetProductsByCategory(string categoryName);
    }
}
