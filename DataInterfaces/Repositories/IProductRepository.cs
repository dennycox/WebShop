using DataInterfaces;
using DataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInterfaces.Repositories
{
    public interface IProductRepository
    {
        List<IProductDto> GetAllProducts();
        IProductDto GetProductById(int id);
        void AddProduct(IProductDto product);
        void UpdateProduct(IProductDto product);
        void DeleteProduct(int id);
        List<IProductDto> SearchProduct(string productName);
    }
}
