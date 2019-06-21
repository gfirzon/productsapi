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
    public class VendorServiceTests
    {
        private readonly VendorService service = null;
        private readonly Mock<IVendorRepository> mockRepository = null;

        public VendorServiceTests()
        {
            mockRepository = new Mock<IVendorRepository>();
            service = new VendorService(mockRepository.Object);
        }

        [Fact]
        public void GetVendor_Returns_Vendor_When_Found()
        {
            // Arrange
            int id = int.MaxValue;

            mockRepository.Setup(m => m.GetVendor(
                It.IsAny<int>()
                )).Returns(new Vendor
                {
                    VendorName = "GAGAGA"
                });

            // Act
            Vendor vendor = service.GetVendor(id);

            // Asserts
            Assert.NotNull(vendor);
            Assert.NotNull(vendor.VendorName);
        }

        [Fact]
        public void GetVendor_Returns_Null_When_NotFound()
        {
            // Arrange
            int id = int.MaxValue;

            Vendor repoVendor = null;

            mockRepository.Setup(m => m.GetVendor(
                It.IsAny<int>()
                )).Returns(repoVendor);

            // Act
            Vendor vendor = service.GetVendor(id);

            //Assert
            Assert.Null(vendor);
        }

        [Fact]
        public void CreateVendor_Returns_New_Id_When_Created()
        {
            // Arrange
            int id = int.MaxValue;
            var vendor = new Vendor
            {
                VendorID = 5,
                VendorName = "DADADA",
                VendorPhone = "7776665544",
                Email = "lala@lala.com"
            };

            mockRepository.Setup(m => m.CreateVendor(vendor)).Returns(id);

            // Act
            id = service.CreateVendor(vendor);

            // Asserts
            Assert.NotNull(vendor);
            Assert.Equal(5, vendor.VendorID);
        }

        [Fact]
        public void GetAll_Returns_VendorList_When_All_Valid()
        {
            // Arrange
            List<Vendor> list = new List<Vendor>();
            mockRepository.Setup(m => m.GetVendorList()).Returns(list);

            // Act
            list = service.GetVendorList();

            // Asserts
            Assert.NotNull(list);
        }


        [Fact]
        public void UpdateVendor_Returns_True_When_dbVendor_VendorFound()
        {
            // Arrange
            var vendor = new Vendor { };

            mockRepository.Setup(m => m.GetVendor(
                It.IsAny<int>()
                )).Returns(vendor);

            mockRepository.Setup(m => m.UpdateVendor(
                It.IsAny<Vendor>()
                ));

            // Act
           bool result = service.UpdateVendor(vendor);

            // Asserts
            Assert.True(result);
        }

        [Fact]
        public void UpdateVendor_Returns_true_When_dbVendor_NotFound()
        {
            // Arrange
            var vendor = new Vendor { };
            Vendor v = null;

            mockRepository.Setup(m => m.GetVendor(
                 It.IsAny<int>()
            )).Returns(v);

            mockRepository.Setup(m => m.UpdateVendor(
                It.IsAny<Vendor>()
            ));
                       
            // Act
            bool result = service.UpdateVendor(vendor);

            // Asserts
            Assert.False(result);
        }



    }
}

