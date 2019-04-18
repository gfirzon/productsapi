using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Services
{
    public interface IProductService
    {
        List<Product> GetProductList();
        Product GetProduct(int id);
        int CreateProduct(Product product);

        /// <summary>
        /// Updates the product if found
        /// </summary>
        /// <param name="product">new data for a given product, ProductId is used to find... </param>
        /// <returns>true if found and updated, false if not found</returns>
        bool UpdateProduct(Product product);
    }
}
