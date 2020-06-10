using Data.Models;
using DataInterfaces.Repositories;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace WebShopLogicTests
{
    [TestClass]
    public class ProductCollectionTest
    {
        private readonly ProductCollection _sut; //Subject Under Test
        private readonly Mock<IProductRepository> _productRepoMock = new Mock<IProductRepository>();

        public ProductCollectionTest()
        {
            _sut = new ProductCollection(_productRepoMock.Object);
        }

        [TestMethod]
        public void GetProductById_ProductExists_ReturnProduct()
        {
            //Arrange
            var productId = 20;
            var productName = "Actiefiguur Woody Toy Story";
            var productDescription = "Actiefiguur Woody van Toy Story";
            var productPrice = 17;
            var productImagePath = "Woody.jpeg";
            var productCategoryId = 2;

            var productDto = new ProductDto
            {
                ProductID = productId,
                Name = productName,
                Description = productDescription,
                Price = productPrice,
                ImagePath = productImagePath,
                CategoryID = productCategoryId,
            };

            _productRepoMock.Setup(x => x.GetProductById(productId)).Returns(productDto);

            //Act
            var product = _sut.GetProductById(productId);

            //Assert
            Assert.AreEqual(productId, product.ProductID);
            Assert.AreEqual(productName, product.Name);
            Assert.AreEqual(productDescription, product.Description);
            Assert.AreEqual(productPrice, product.Price);
            Assert.AreEqual(productImagePath, product.ImagePath);
            Assert.AreEqual(productCategoryId, product.CategoryId);
        }

        [TestMethod]
        public void GetProductById_ProductDoesNotExist_ReturnNull()
        {
            //Arrange
            _productRepoMock.Setup(x => x.GetProductById(0)).Returns(() => null);

            //Act
            var product = _sut.GetProductById(0);

            //Assert
            Assert.IsNull(product);
        }
    }
}
