﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductsApi.Controllers;
using ProductsApi.Models;
using ProductsApi.Services;
using ProductTests.MockClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProductTests.ControllerTests
{
    public class ProductControllerTests
    {
        private readonly ProductsController controller = null;
        private readonly Mock<IProductService> mockService = null;

        public ProductControllerTests()
        {
            mockService = new Mock<IProductService>();
            controller = new ProductsController(mockService.Object);
        }

        [Fact]
        public void GetAll_Returns_Ok_When_All_Valid()
        {
            //Arrange

            var productList = new List<Product> {
                new Product{
                    ProductID = 1,
                    ProductName = "milk",
                    ProductDescription = "2%Milk",
                    UnitsInStock = 250,
                    SellPrice = 3.99m,
                    DiscountPercentage = 10,
                    UnitsMax = 1250
                },
                new Product{
                    ProductID = 2,
                    ProductName = "bread",
                    ProductDescription = "White",
                    UnitsInStock = 1050,
                    SellPrice = 4.99m,
                    DiscountPercentage = 5,
                    UnitsMax = 6250
                },
                new Product{
                    ProductID = 3,
                    ProductName = "butter",
                    ProductDescription = "unsalted",
                    UnitsInStock = 50,
                    SellPrice = 1.99m,
                    DiscountPercentage = 7,
                    UnitsMax = 500
                }
            };

            mockService.Setup(m => m.GetProductList())
                .Returns(productList);

            //Act

            ActionResult actionResult = controller.Get();

            //Asserts

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            List<Product> list = result.Value as List<Product>;
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void GetAll_Returns_500_When_Exception()
        {
            //Arrange

            mockService.Setup(m => m.GetProductList())
           .Throws(new Exception("error"));

            //Act

            ActionResult actionResult = controller.Get();

            //Asserts

            Assert.NotNull(actionResult);
            var result = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void Get_Returns_Ok_When_All_Valid()
        {
            //Arrange
            //-------------------------------------
            var product = new Product
            {
                ProductID = 4,
                ProductName = "milk",
                ProductDescription = "0%Milk",
                UnitsInStock = 20,
                SellPrice = 5.99m,
                DiscountPercentage = 5,
                UnitsMax = 125
            };

            mockService.Setup(m => m.GetProduct(
                It.IsAny<int>()
           )).Returns(product);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.Get(int.MaxValue);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            Product productResult = result.Value as Product;
            Assert.NotNull(productResult);
            Assert.Equal(4, product.ProductID);
        }

        [Fact]
        public void Get_Returns_NotFound_When_Product_NotFound()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------
            Product product = null;

            mockService.Setup(m => m.GetProduct(
                It.IsAny<int>()
           )).Returns(product);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.Get(int.MaxValue);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<NotFoundResult>(actionResult);
            Assert.Equal(404, result.StatusCode);

        }
        [Fact]
        public void Get_Returns_500_When_Exception()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------

            mockService.Setup(m => m.GetProduct(
                It.IsAny<int>()
           )).Throws(new Exception("Error"));

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.Get(int.MaxValue);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void Post_Returns_New_Id_When_Created()
        {
            // Arrange

            int expectedId = int.MaxValue;
            var product = new Product { };

            mockService.Setup(m => m.CreateProduct(
                It.IsAny<Product>()
            )).Returns(expectedId);

            // Act
            
            ActionResult actionResult = controller.Post(product);

            // Assert

            OkObjectResult result = Assert.IsType<OkObjectResult>(actionResult);

            //int id = Convert.ToInt32(result.Value);
            int actualResult = Assert.IsType<int>(result.Value);

            Assert.Equal(expectedId, actualResult);
        }

        [Fact]
        public void Post_Returns_500_When_ExceptionOccurs()
        {
            // Arrange

            var product = new Product { ProductName = "lalalala" };

            mockService.Setup(m => m.CreateProduct(
                It.IsAny<Product>()
            )).Throws(new Exception());

            // Act

            ActionResult actionResult = controller.Post(product);

            // Assert

            ObjectResult result = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(500, result.StatusCode);
        }
        [Fact]
        public void Post_Returns_500_When_Service_Returns_0()
        {
            // Arrange

            int expectedId = 0;

            var product = new Product { ProductName = "lalalala" };

            mockService.Setup(m => m.CreateProduct(
                It.IsAny<Product>()
            )).Returns(expectedId);

            // Act

            ActionResult actionResult = controller.Post(product);

            // Assert

            ObjectResult result = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void Put_Returns_OK_When_Updated()
        {
            //-------------------------------------
            // Arrange
            //-------------------------------------

            var product = new Product { ProductID = 10, ProductName = "Milk" };
            bool result = false;
            
            mockService.Setup(m => m.UpdateProduct(
                It.IsAny<Product>()
                )).Returns(result);
            //-------------------------------------
            // Act
            //-------------------------------------

            ActionResult actionResult = controller.Put(product);
            
            //-------------------------------------
            // Assert
            //-------------------------------------

            Assert.NotNull(actionResult);
        }

        [Fact]
        public void Put_Returns_NotFound_When_Product_NotUpdated()
        {
            // Arrange

            var product = new Product { };

            mockService.Setup(m => m.UpdateProduct(
                It.IsAny<Product>()
                ));

            //-------------------------------------
            // Act
            //-------------------------------------

            ActionResult actionResult = controller.Put(product);

            //-------------------------------------
            // Assert
            //-------------------------------------

            Assert.NotNull(actionResult);
        }

        [Fact]
        public void Put_Returns_500_When_Exception()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------

            var product = new Product { };

            mockService.Setup(m => m.UpdateProduct(
                It.IsAny<Product>()
           )).Throws(new Exception("Error"));

            //-------------------------------------
            // Act
            //-------------------------------------

            ActionResult actionResult = controller.Put(product);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(500, result.StatusCode);

        }


    }

}
