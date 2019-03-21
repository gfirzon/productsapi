using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Repositories
{
    public interface IVendorRepository
    {
        List<Vendor> GetVendorList();
    }
}
