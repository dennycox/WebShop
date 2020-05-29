using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IProductCollection
    {
        List<IProduct> GetAllProducts();

        IProduct GetProductById(int id);

        void AddProduct(IProduct product);

        void UpdateProduct(IProduct product);

        void DeleteProduct(int id);

        List<IProduct> SearchProduct(string productName);

        List<IProduct> GetProductsByCategoryID(int categoryID);
    }
}
