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
            int id = int.MaxValue;
            var user = new User
            {
                UserID = 10,
                RoleID = 1,
                IsActive = true,
                UserName = "lala@lala.com",
                UserPassword = "lalala"
            };

            mockRepository.Setup(m => m.CreateUser(user)).Returns(id);

            // Act
            id = service.CreateUser(user);

            // Asserts
            Assert.NotNull(user);
            Assert.Equal(10, user.UserID);
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
        public void UpdateUser_Returns_true_When_dbUser_Not_Null()
        {
            // Arrange
            bool result = false;
          
            var user = new User
            {
                UserID = 12,
                RoleID = 3,
                IsActive = true,
                UserName = "pa@gmail.com",
                UserPassword = "Polya"
            };

            User dbUser = new User();
            dbUser = service.GetUser(dbUser.UserID);
            mockRepository.Setup(m => m.UpdateUser(dbUser));

            // Act
            result = service.UpdateUser(user);

            // Asserts
            Assert.False(result);
        }
        [Fact]
        public void GetAll_Returns_ViewModelList_When_All_Valid()
        {
            // Arrange
            List<UserViewModel> list = new List<UserViewModel>();
            mockRepository.Setup(m => m.GetUserViewModelList()).Returns(list);

            // Act
            list = service.GetUserViewModelList();

            // Asserts
            Assert.NotNull(list);
        }
        [Fact]
        public void GetUserViewModelList_Returns_UserViewModel_When_Found()
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
            UserViewModel userView = service.GetUserViewModel(id);

            // Asserts
            Assert.NotNull(userView);
            Assert.NotNull(userView.UserName);
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
            UserViewModel userView = service.GetUserViewModel(id);

            // Asserts
            Assert.Null(userView);
        }
    }
}
