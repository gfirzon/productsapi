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
    }
}
