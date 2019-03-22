using Microsoft.Extensions.Configuration;
using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly string connectionString;

        public VendorRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetSection("Data").GetSection("ConnectionString").Value;
        }

        public int CreateVendor(Vendor vendor)
        {
            //[dbo].[sp_CreateVendor]
            throw new NotImplementedException();
        }

        public Vendor GetVendor(int id)
        {
            //[dbo].[sp_GetVendorByID]
            throw new NotImplementedException();
        }

        public List<Vendor> GetVendorList()
        {
            //[dbo].[sp_GetVendors]
            return null;
        }

        public void UpdateVendor(Vendor vendor)
        {
            //[dbo].[sp_UpdateVendor]
            throw new NotImplementedException();
        }
    }
}
