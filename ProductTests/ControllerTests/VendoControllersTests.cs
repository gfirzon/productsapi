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
    public class VendoControllersTests
    {
        [Fact]
        public void GetAll_Returns_Ok_When_All_Valid()
        {
            //Arrange

            IVendorService vendorService = null;

            vendorService = new MockVendorService();

            VendorsController controller = new VendorsController(vendorService);

            //Act

            ActionResult actionResult = controller.Get();

            //Asserts

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            List<Vendor> list = result.Value as List<Vendor>;
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void GetAll_Returns_Ok_When_All_Valid_Moq()
        {
            //Arrange

            var vendorList = new List<Vendor>{
                new Vendor {
                    VendorID = 1,
                    VendorName = "hahaha",
                    VendorPhone = "9998887766"
                },
                new Vendor {
                    VendorID = 2,
                    VendorName = "lalala",
                    VendorPhone = "1112223344"
                },
            };

            Mock<IVendorService> mockService = new Mock<IVendorService>();
            mockService.Setup(m => m.GetVendorList()).Returns(vendorList);

            IVendorService vendorService = mockService.Object;

            VendorsController controller = new VendorsController(vendorService);

            //Act

            ActionResult actionResult = controller.Get();

            //Asserts

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            List<Vendor> list = result.Value as List<Vendor>;
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void GetAll_Returns_500_When_Exception()
        {
            //Arrange

            Mock<IVendorService> mockService = new Mock<IVendorService>();

            mockService.Setup(m => m.GetVendorList())
           .Throws(new Exception("error"));

            VendorsController controller = new VendorsController(mockService.Object);

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
            var vendor = new Vendor
            {
                VendorID = 3,
                VendorName = "hehehe",
                VendorPhone = "2223334455"
            };

            Mock<IVendorService> mockService = new Mock<IVendorService>();
            mockService.Setup(m => m.GetVendor(
                It.IsAny<int>()
           )).Returns(vendor);

            IVendorService vendorService = mockService.Object;

            VendorsController controller = new VendorsController(vendorService);

            //-------------------------------------
            //Act
            //-------------------------------------

            ActionResult actionResult = controller.Get(int.MaxValue);

            //-------------------------------------
            //Asserts
            //-------------------------------------

            Assert.NotNull(actionResult);
            var result = Assert.IsType<OkObjectResult>(actionResult);

            Vendor vendorResult = result.Value as Vendor;
            Assert.NotNull(vendorResult);
            Assert.Equal(4, vendor.VendorID);
        }

        [Fact]
        public void Get_Returns_NotFound_When_Vendor_NotFound()
        {
            //-------------------------------------
            //Arrange
            //-------------------------------------
            Vendor vendor = null;

            Mock<IVendorService> mockService = new Mock<IVendorService>();
            mockService.Setup(m => m.GetVendor(
                It.IsAny<int>()
           )).Returns(vendor);

            IVendorService vendorService = mockService.Object;

            VendorsController controller = new VendorsController(vendorService);

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
            Mock<IVendorService> mockService = new Mock<IVendorService>();
            mockService.Setup(m => m.GetVendor(
                It.IsAny<int>()
           )).Throws(new Exception("error"));

            IVendorService vendorService = mockService.Object;

            VendorsController controller = new VendorsController(vendorService);

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










