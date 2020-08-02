using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models;
using System.Collections.Generic;
using HelloWorld.Controllers;
using System.Linq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestMethodWithFakeClass()
        {
            // Arrange
            var controller = new HomeController(new FakeProductRepository());

            // Act
            var result = controller.Products();
            var viewResult = (System.Web.Mvc.ViewResultBase)result;
            var model = viewResult.Model;

            // Assert
            var products = (Product[])model;
            Assert.AreEqual(44, products.Length, "Length is invalid");
        }
    }
}