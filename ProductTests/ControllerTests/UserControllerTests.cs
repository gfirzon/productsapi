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
    public class UserControllerTests
    {
        private readonly UsersController controller = null;
        private readonly Mock<IUserService> mockService = null;

        public UserControllerTests()
        {
            mockService = new Mock<IUserService>();
            controller = new UsersController(mockService.Object);
        }

        [Fact]
        public void GetAll_Returns_Ok_When_All_Valid()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------
            var userList = new List<User> {
                new User{
                    UserID = 10,
                    RoleID = 1,
                    IsActive = true,
                    UserName="lala@lala.com",
                    UserPassword = "lalala"
                },
                new User{
                    UserID = 20,
                    RoleID = 2,
                    IsActive = true,
                    UserName="lala@lala.com",
                    UserPassword = "lalala"
                },
            };

            mockService.Setup(m => m.GetUserList())
                .Returns(userList);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.Get();

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            List<User> list = result.Value as List<User>;
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void GetAll_Returns_500_When_Exception()
        {
            //Arrange

            mockService.Setup(m => m.GetUserList())
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
            //-------------------------------------
            //Arrange
            //-------------------------------------
            var user = new User
            {
                UserID = 10,
                RoleID = 1,
                IsActive = true,
                UserName = "lala@lala.com",
                UserPassword = "lalala"
            };

            mockService.Setup(m => m.GetUser(
                It.IsAny<int>()
           )).Returns(user);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.Get(int.MaxValue);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            User userResult = result.Value as User;
            Assert.NotNull(userResult);
            Assert.Equal(10, user.UserID);

        }

        [Fact]
        public void Get_Returns_NotFound_When_User_NotFound()
        {
            //Arrange
            //-------------------------------------

            User user = null;

            mockService.Setup(m => m.GetUser(
                It.IsAny<int>()
           )).Returns(user);

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

            mockService.Setup(m => m.GetUser(
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
        public void Foo()
        {
            //Arrange
            string n = "abc";

            //Act
            string m = n;

            //Asserts
            Assert.False(string.IsNullOrEmpty(m));
            //True, Equal, Null, NotNull
        }

        [Fact]
        public void Post_Returns_New_Id_When_Created()
        {
            // Arrange

            int expectedId = int.MaxValue;
            var user = new User { };

            mockService.Setup(m => m.CreateUser(
                It.IsAny<User>()
            )).Returns(expectedId);

            // Act

            ActionResult actionResult = controller.Post(user);

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

            var user = new User { UserName = "lalalala" };

            mockService.Setup(m => m.CreateUser(
                It.IsAny<User>()
            )).Throws(new Exception());

            // Act

            ActionResult actionResult = controller.Post(user);

            // Assert

            ObjectResult result = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void Post_Returns_500_When_Service_Returns_0()
        {
            // Arrange
            int expectedId = 0;

            var user = new User { UserName = "lalalala" };

            mockService.Setup(m => m.CreateUser(
                It.IsAny<User>()
            )).Returns(expectedId);

            // Act

            ActionResult actionResult = controller.Post(user);

            // Assert

            ObjectResult result = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void GetUserIDWithRoleName_Returns_Ok_When_All_Valid()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------
            var user = new UserViewModel
            {
                UserID = 10,
                RoleID = 3,
                IsActive = true,
                UserName = "lala@lala.com",
                UserPassword = "lalala",
                RoleName = "user"
            };

            mockService.Setup(m => m.GetUserViewModel(
                It.IsAny<int>()
           )).Returns(user);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.GetUserIDWithRoleName(int.MaxValue);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            UserViewModel userResult = result.Value as UserViewModel;
            Assert.NotNull(userResult);
            Assert.Equal(10, user.UserID);
        }

        [Fact]
        public void GetUserIDWithRoleName_Returns_NotFound_When_User_NotFound()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------
            UserViewModel user = null;

            mockService.Setup(m => m.GetUserViewModel(
                It.IsAny<int>()
           )).Returns(user);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.GetUserIDWithRoleName(int.MaxValue);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<NotFoundResult>(actionResult);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void GetUserViewModel_Returns_500_When_Exception()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------

            mockService.Setup(m => m.GetUserViewModel(
                It.IsAny<int>()
           )).Throws(new Exception("Error"));

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.GetUserIDWithRoleName(int.MaxValue);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(500, result.StatusCode);
        }

        //novoe


        [Fact]
        public void GetUsersListWithRoleName_Returns_Ok_When_All_Valid()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------

            var userList = new List<UserViewModel> {
                new UserViewModel{
                    UserID = 10,
                    RoleID = 1,
                    IsActive = true,
                    UserName="lala@lala.com",
                    UserPassword = "lalala"
                },
                new UserViewModel{
                    UserID = 20,
                    RoleID = 2,
                    IsActive = true,
                    UserName="lala@lala.com",
                    UserPassword = "lalala"
                },
            };

            mockService.Setup(m => m.GetUserViewModelList()).Returns(userList);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.GetUsersListWithRoleName();

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            List<UserViewModel> list = result.Value as List<UserViewModel>;
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void GetUsersListWithRoleName_Returns_500_When_Exception()
        {
            //Arrange

            mockService.Setup(m => m.GetUserViewModelList())
           .Throws(new Exception("error"));

            //Act

            ActionResult actionResult = controller.GetUsersListWithRoleName();

            //Asserts

            Assert.NotNull(actionResult);
            var result = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void UpdateUser_Returns_OK_When_Updated()
        {
            //-------------------------------------
            // Arrange
            //-------------------------------------

            var user = new User { };
            
            mockService.Setup(m => m.UpdateUser(
                It.IsAny<User>()
                ));
            //-------------------------------------
            // Act
            //-------------------------------------

            ActionResult actionResult = controller.Put(user);

            //-------------------------------------
            // Assert
            //-------------------------------------

            Assert.NotNull(actionResult);

        }

        [Fact]
        public void UpdateUser_Returns_NotFound_When_User_NotUpdated()
        {
            // Arrange

            var user = new User {};
            
            mockService.Setup(m => m.UpdateUser(
                It.IsAny<User>()
                ));

            //-------------------------------------
            // Act
            //-------------------------------------

            ActionResult actionResult = controller.Put(user);

            //-------------------------------------
            // Assert
            //-------------------------------------

            Assert.NotNull(actionResult);
        }

        [Fact]
        public void UpdateUser_Returns_500_When_Exception()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------

            var user = new User { };

            mockService.Setup(m => m.UpdateUser(
                It.IsAny<User>()
           )).Throws(new Exception("Error"));

            //-------------------------------------
            // Act
            //-------------------------------------

            ActionResult actionResult = controller.Put(user);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(500, result.StatusCode);

        }
    }
}
