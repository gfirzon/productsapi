using Moq;
using ProductsApi.Models;
using ProductsApi.Repositories;
using ProductsApi.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProductTests.ServiceTests
{
    public class ProductServiceTests
    {
        private readonly ProductService service = null;
        private readonly Mock<IProductRepository> mockRepository = null;

        public ProductServiceTests()
        {
            mockRepository = new Mock<IProductRepository>();
            service = new ProductService(mockRepository.Object);
        }

        [Fact]
        public void GetProduct_Returns_Product_When_Found()
        {
            // Arrange

            int id = int.MaxValue;

            mockRepository.Setup(m => m.GetProduct(
             It.IsAny<int>()
             )).Returns(new Product
             {
                 ProductName = "Apple"
             });

            // Act

            Product product = service.GetProduct(id);

            // Asserts
            Assert.NotNull(product);
            Assert.NotNull(product.ProductName);

        }

        [Fact]
        public void GetProduct_Returns_Null_When_NotFound()
        {
            // Arrange
            int id = int.MaxValue;

            Product repoProduct = null;

            mockRepository.Setup(m => m.GetProduct(
                It.IsAny<int>()
                )).Returns(repoProduct);

            // Act
            Product product = service.GetProduct(id);

            // Asserts
            Assert.Null(product);
        }

        [Fact]
        public void CreateProduct_Returns_New_Id_When_Created()
        {
            // Arrange
            int expectedId = int.MaxValue;
            var product = new Product { };

            mockRepository.Setup(m => m.CreateProduct(product)).Returns(expectedId);

            // Act
            int actualId = service.CreateProduct(product);

            // Asserts
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void GetAll_Returns_ProductList_When_All_Valid()
        {
            // Arrange
            List<Product> list = new List<Product>();
            mockRepository.Setup(m => m.GetProductList()).Returns(list);

            // Act
            list = service.GetProductList();

            // Asserts
            Assert.NotNull(list);
        }
        [Fact]
        public void UpdateProduct_Returns_True_When_ProductFound()
        {
            // Arrange
            var product = new Product { };

            mockRepository.Setup(m => m.GetProduct(
                It.IsAny<int>()
                )).Returns(product);

            mockRepository.Setup(m => m.UpdateProduct(
                It.IsAny<Product>()
                ));

            // Act
            bool result = service.UpdateProduct(product);

            // Asserts
            Assert.True(result);
        }

        [Fact]
        public void UpdateProduct_Returns_False_When_ProductNotFound()
        {
            // Arrange
            var product = new Product { };
            Product product1 = null;

            mockRepository.Setup(m => m.GetProduct(
                It.IsAny<int>()
                )).Returns(product1);

            mockRepository.Setup(m => m.UpdateProduct(
                It.IsAny<Product>()
                ));

            // Act
            bool result = service.UpdateProduct(product);

            // Asserts
            Assert.False(result);
        }
    }

}
