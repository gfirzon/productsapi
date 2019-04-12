using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProductList();
        Product GetProduct(int id);
        int CreateProduct(Product product);
        void UpdateProduct(Product product);
    }
}
