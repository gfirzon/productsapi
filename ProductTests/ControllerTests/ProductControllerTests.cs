using Microsoft.AspNetCore.Mvc;
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
        [Fact]
        public void GetAll_Returns_Ok_When_All_Valid()
        {
            //Arrange

            IProductService productService = null;

            productService = new MockProductService();

            ProductsController controller = new ProductsController(productService);

            //Act

            ActionResult actionResult = controller.Get();

            //Asserts

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            List<Product> list = result.Value as List<Product>;
            Assert.Equal(3, list.Count);
        }
        [Fact]
        public void GetAll_Returns_Ok_When_All_Valid_Moq()
        {
            //Arrange

            var productList = new List<Product>{
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

            Mock<IProductService> mockService = new Mock<IProductService>();
            mockService.Setup(m => m.GetProductList()).Returns(productList);

            IProductService productService = mockService.Object;

            ProductsController controller = new ProductsController(productService);

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

            Mock<IProductService> mockService = new Mock<IProductService>();

            mockService.Setup(m => m.GetProductList())
           .Throws(new Exception("error"));

            ProductsController controller = new ProductsController(mockService.Object);

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


            Mock<IProductService> mockService = new Mock<IProductService>();
            mockService.Setup(m => m.GetProduct(
                It.IsAny<int>()
           )).Returns(product);

            IProductService productService = mockService.Object;

            ProductsController controller = new ProductsController(productService);

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

            Mock<IProductService> mockService = new Mock<IProductService>();
            mockService.Setup(m => m.GetProduct(
                It.IsAny<int>()
           )).Returns(product);

            IProductService productService = mockService.Object;

            ProductsController controller = new ProductsController(productService);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.Get(int.MaxValue);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<NotFoundResult>(actionResult);
        }
        [Fact]
        public void Get_Returns_500_When_Exception()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------
            Mock<IProductService> mockService = new Mock<IProductService>();
            mockService.Setup(m => m.GetProduct(
                It.IsAny<int>()
           )).Throws(new Exception("error"));

            IProductService productService = mockService.Object;

            ProductsController controller = new ProductsController(productService);

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

    }
}
