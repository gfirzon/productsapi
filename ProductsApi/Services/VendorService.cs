using ProductsApi.Models;
using ProductsApi.Repositories;
using System.Collections.Generic;

namespace ProductsApi.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository vendorRepository;

        public VendorService(IVendorRepository vendorRepository)
        {
            this.vendorRepository = vendorRepository;
        }

        public int CreateVendor(Vendor vendor)
        {
            return vendorRepository.CreateVendor(vendor);
        }

        public Vendor GetVendor(int id)
        {
            return vendorRepository.GetVendor(id);
        }


        public List<Vendor> GetVendorList()
        {
            return vendorRepository.GetVendorList();
        }
        //public void UpdateVendor(Vendor vendor)
        //{
        //    vendorRepository.UpdateVendor(vendor);
        //}

        /// <summary>
        /// Updates the vendors if found
        /// </summary>
        /// <param name="vendor">new data for a given vendor, VendorId is used to find... </param>
        /// <returns>true if found and updated, false if not found</returns>
        public bool UpdateVendor(Vendor vendor)
        {
            bool result = false;

            Vendor dblVendor = GetVendor(vendor.VendorID);

            if (dblVendor != null)
            {
                vendorRepository.UpdateVendor(vendor);
                result = true;
            }

            return result;
        }
    }
}
