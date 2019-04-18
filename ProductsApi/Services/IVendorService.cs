using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Services
{
    public interface IVendorService
    {
        List<Vendor> GetVendorList();
        Vendor GetVendor(int id);
        int CreateVendor(Vendor vendor);

        /// <summary>
        /// Updates the vendor if found
        /// </summary>
        /// <param name="vendor">new data for a given vendor, VendorId is used to find... </param>
        /// <returns>true if found and updated, false if not found</returns>
        bool UpdateVendor(Vendor vendor);

    }
}
