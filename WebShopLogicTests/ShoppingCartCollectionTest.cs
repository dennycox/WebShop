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
    public class ShoppingCartCollectionTest
    {
        private readonly ShoppingCartCollection _sut; //Subject Under Test
        private readonly Mock<IShoppingCartRepository> _shoppingCartRepoMock = new Mock<IShoppingCartRepository>();

        public ShoppingCartCollectionTest()
        {
            _sut = new ShoppingCartCollection(_shoppingCartRepoMock.Object);
        }

        [TestMethod]
        public void GetShoppingCartById_ShoppingCartExists_ReturnShoppingCart()
        {
            //Arrange
            var shoppingCartProductId = 34;
            var shoppingCartProfileId = 21;
            var shoppingCartAmount = 2;

            var shoppingCartDto = new ShoppingCartDto
            {
                ProductID = shoppingCartProductId,
                ProfileID = shoppingCartProfileId,
                Amount = shoppingCartAmount,
            };

            _shoppingCartRepoMock.Setup(x => x.GetShoppingCartById(shoppingCartProductId)).Returns(shoppingCartDto);

            //Act
            var shoppingCart = _sut.GetShoppingCartById(shoppingCartProductId);

            //Assert
            Assert.AreEqual(shoppingCartProductId, shoppingCart.ProductID);
            Assert.AreEqual(shoppingCartProfileId, shoppingCart.ProfileID);
            Assert.AreEqual(shoppingCartAmount, shoppingCart.Amount);
        }

        [TestMethod]
        public void GetShoppingCartById_ShoppingCartDoesNotExist_ReturnNull()
        {
            //Arrange
            _shoppingCartRepoMock.Setup(x => x.GetShoppingCartById(0)).Returns(() => null);

            //Act
            var shoppingCart = _sut.GetShoppingCartById(0);

            //Assert
            Assert.IsNull(shoppingCart);
        }
    }
}
