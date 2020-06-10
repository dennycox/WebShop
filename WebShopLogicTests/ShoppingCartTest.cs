using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopLogicTests
{
    [TestClass]
    public class ShoppingCartTest
    {
        private ShoppingCart _sut; //Subject Under Test

        [TestMethod]
        public void SetShoppingCartAmount_AmountIsOk_ReturnAmount()
        {
            //Arange
            _sut = new ShoppingCart();

            //Act
            _sut.Amount = 5;

            //Assert
            Assert.AreEqual(_sut.Amount, 5);
        }

        [TestMethod]
        public void SetShoppingCartAmount_AmountIsNotOk_ReturnZero()
        {
            //Arange
            _sut = new ShoppingCart();

            //Act
            _sut.Amount = -5;

            //Assert
            Assert.AreEqual(_sut.Amount, 1);
        }
    }
}
