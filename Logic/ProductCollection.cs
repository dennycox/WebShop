using DataFactory;
using DataInterfaces;
using DataInterfaces.Models;
using DataInterfaces.Repositories;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ProductCollection : IProductCollection
    {
        private IProductRepository _productRepository;

        public ProductCollection(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<IProduct> GetAllProducts()
        {
            return _productRepository.GetAllProducts().Select(p => ProductDtoToProduct(p)).ToList();
        }

        public IProduct GetProductById(int id)
        {
            return ProductDtoToProduct(_productRepository.GetProductById(id));
        }

        public void AddProduct(IProduct product)
        {
            _productRepository.AddProduct(ProductToProductDto(product));
        }

        public void UpdateProduct(IProduct product)
        {
            _productRepository.UpdateProduct(ProductToProductDto(product));
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public List<IProduct> SearchProduct(string productName)
        {
            return _productRepository.SearchProduct(productName).Select(p => ProductDtoToProduct(p)).ToList();
        }

        public List<IProduct> GetProductsByCategoryID(int categoryID)
        {
            return _productRepository.GetProductsByCategoryID(categoryID).Select(p => ProductDtoToProduct(p)).ToList();
        }

        private IProduct ProductDtoToProduct(IProductDto productDto)
        {
            return new Product()
            {
                ProductID = productDto.ProductID,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                ImagePath = productDto.ImagePath,
                CategoryId = productDto.CategoryID,
            };
        }

        private IProductDto ProductToProductDto(IProduct product)
        {
            IProductDto productDto = Factory.GetProductDto();

            productDto.ProductID = product.ProductID;
            productDto.Name = product.Name;
            productDto.Description = product.Description;
            productDto.Price = product.Price;
            productDto.ImagePath = product.ImagePath;
            productDto.CategoryID = product.CategoryId;

            return productDto;
        }
    }
}
