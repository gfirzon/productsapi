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
        [Fact]
        public void GetAll_Returns_Ok_When_All_Valid()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------

            IUserService userService = null;

            userService = new MockUserService();

            UsersController controller = new UsersController(userService);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.Get();

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            List<User>list = result.Value as List<User>;
            Assert.Equal(2, list.Count);
            
        }

        [Fact]
        public void GetAll_Returns_Ok_When_All_Valid_Moq()
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

            Mock<IUserService> mockService = new Mock<IUserService>();
            mockService.Setup(m => m.GetUserList()).Returns(userList);

            IUserService userService = mockService.Object;

            UsersController controller = new UsersController(userService);

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
               

            Mock<IUserService> mockService = new Mock<IUserService>();
            mockService.Setup(m => m.GetUser(
                It.IsAny<int>()
           )).Returns(user);

            IUserService userService = mockService.Object;

            UsersController controller = new UsersController(userService);

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
            //-------------------------------------
            //Arrange
            //-------------------------------------
            User user = null;

            Mock<IUserService> mockService = new Mock<IUserService>();
            mockService.Setup(m => m.GetUser(
                It.IsAny<int>()
           )).Returns(user);

            IUserService userService = mockService.Object;

            UsersController controller = new UsersController(userService);

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
            Mock<IUserService> mockService = new Mock<IUserService>();
            mockService.Setup(m => m.GetUser(
                It.IsAny<int>()
           )).Throws(new Exception("lalala"));

            IUserService userService = mockService.Object;

            UsersController controller = new UsersController(userService);

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
        public void foo()
        {
            //Arrange
            string n = "abc";

            //Act
            string m = n;

            //Asserts
            Assert.False(string.IsNullOrEmpty(m));
            //True, Equal, Null, NotNull
        }
    }
}
