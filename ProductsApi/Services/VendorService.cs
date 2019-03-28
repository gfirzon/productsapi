﻿using ProductsApi.Models;
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

        public Vendor GetVendor(int id)
        {
            return vendorRepository.GetVendor(id);
        }

        public List<Vendor> GetVendorList()
        {
            return vendorRepository.GetVendorList();
        }
    }
}