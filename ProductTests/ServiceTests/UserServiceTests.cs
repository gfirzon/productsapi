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
    public class UserServiceTests
    {
        private readonly UserService service = null;
        private readonly Mock<IUserRepository> mockRepository = null;

        public UserServiceTests()
        {
            mockRepository = new Mock<IUserRepository>();
            service = new UserService(mockRepository.Object);
        }

        [Fact]
        public void GetUser_Returns_User_When_Found()
        {
            // Arrange
            int id = int.MaxValue;

            mockRepository.Setup(m => m.GetUser(
                It.IsAny<int>()
                )).Returns(new User
                {
                    UserName = "AAA"
                });

            // Act
            User user = service.GetUser(id);

            // Asserts
            Assert.NotNull(user);
            Assert.NotNull(user.UserName);
        }

        [Fact]
        public void GetUser_Returns_Null_When_NotFound()
        {
            // Arrange
            int id = int.MaxValue;

            User repoUser = null;

            mockRepository.Setup(m => m.GetUser(
                It.IsAny<int>()
                )).Returns(repoUser);

            // Act
            User user = service.GetUser(id);

            // Asserts
            Assert.Null(user);
        }
    }
}
