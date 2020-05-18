﻿using Data.Models;
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

        private IProduct ProductDtoToProduct(IProductDto productDto)
        {
            return new Product()
            {
                ProductID = productDto.ProductID,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                ImagePath = productDto.ImagePath
            };
        }

        private IProductDto ProductToProductDto(IProduct product)
        {
            return new ProductDto()
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImagePath = product.ImagePath
            };
        }
    }
}