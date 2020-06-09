using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopLogicTests
{
    [TestClass]
    public class ProductTest
    {
        private Product _sut; //Subject Under Test

        [TestMethod]
        public void SetProductPrice_PriceIsOk_ReturnPrice()
        {
            //Arange
            _sut = new Product();

            //Act
            _sut.Price = 30;

            //Assert
            Assert.AreEqual(_sut.Price, 30);
        }

        [TestMethod]
        public void SetProductPrice_PriceIsNotOk_ReturnZero()
        {
            //Arange
            _sut = new Product();

            //Act
            _sut.Price = -30;

            //Assert
            Assert.AreEqual(_sut.Price, 0);
        }
    }
}
