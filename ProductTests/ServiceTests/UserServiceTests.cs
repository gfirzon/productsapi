using Moq;
using System.Linq;
using System.Threading.Tasks;
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

        [Fact]
        public void CreateUser_Returns_New_Id_When_Created()
        {
            // Arrange
            int expectedId = int.MaxValue;
            var user = new User { };

            mockRepository.Setup(m => m.CreateUser(user)).Returns(expectedId);

            // Act
            int actualId  = service.CreateUser(user);

            // Asserts
            Assert.Equal(expectedId, actualId);
        }
        [Fact]
        public void GetAll_Returns_UserList_When_All_Valid()
        {
            // Arrange
            List<User> list = new List<User>();
            mockRepository.Setup(m => m.GetUserList()).Returns(list);

            // Act
            list = service.GetUserList();

            // Asserts
            Assert.NotNull(list);
        }

        [Fact]
        public void UpdateUser_Returns_True_When_UserFound()
        {
            // Arrange
            var user = new User { };

            mockRepository.Setup(m => m.GetUser(
                It.IsAny<int>()
                )).Returns(user);

            mockRepository.Setup(m => m.UpdateUser(
                It.IsAny<User>()
                ));

            // Act
            bool result = service.UpdateUser(user);

            // Asserts
            Assert.True(result);
        }

        [Fact]
        public void UpdateUser_Returns_False_When_UserNotFound()
        {
            // Arrange
            var user = new User { };
            User u = null;

            mockRepository.Setup(m => m.GetUser(
                It.IsAny<int>()
                )).Returns(u);

            mockRepository.Setup(m => m.UpdateUser(
                It.IsAny<User>()
                ));

            // Act
            bool result = service.UpdateUser(user);

            // Asserts
            Assert.False(result);
        }

        [Fact]
        public void GetAll_Returns_ViewModelList_When_All_Valid()
        {
            // Arrange
            List<UserViewModel> list = new List<UserViewModel>();
            mockRepository.Setup(m => m.GetUserViewModelList(
                )).Returns(list);

            // Act
            List<UserViewModel> actualList = service.GetUserViewModelList();

            // Asserts
            Assert.NotNull(list);
        }
        [Fact]
        public void GetUserViewModel_Returns_UserViewModel_When_Found()
        {
            // Arrange
            int id = int.MaxValue;

            mockRepository.Setup(m => m.GetUserViewModel(
                It.IsAny<int>()
                )).Returns(new UserViewModel
                {
                    UserName = "AAA"
                });

            // Act
            UserViewModel model = service.GetUserViewModel(id);

            // Asserts
            Assert.NotNull(model);
            Assert.Equal("AAA", model.UserName);
        }

        [Fact]
        public void GetUserViewModel_Returns_Null_When_NotFound()
        {
            // Arrange
            int id = int.MaxValue;

            UserViewModel repoUser = null;

            mockRepository.Setup(m => m.GetUserViewModel(
                It.IsAny<int>()
                )).Returns(repoUser);

            // Act
            UserViewModel model = service.GetUserViewModel(id);

            // Asserts
            Assert.Null(model);
        }
    }
}
