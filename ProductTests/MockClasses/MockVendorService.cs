using ProductsApi.Models;
using ProductsApi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTests.MockClasses
{
    class MockVendorService : IVendorService
    {
        public int CreateVendor(Vendor vendor)
        {
            throw new NotImplementedException();
        }

        public Vendor GetVendor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vendor> GetVendorList()
        {
            return new List<Vendor> {
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
        }

        public bool UpdateVendor(Vendor vendor)
        {
            throw new NotImplementedException();
        }
    }
}
