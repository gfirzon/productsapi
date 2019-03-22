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

        public List<Vendor> GetVendorList()
        {
            return null;
        }
    }
}
