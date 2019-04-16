using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public int CreateProduct(Product product)
        {
            return productRepository.CreateProduct(product);
        }

        public Product GetProduct(int id)
        {
            return productRepository.GetProduct(id);
        }

        public List<Product> GetProductList()
        {
            return productRepository.GetProductList();
        }
        
        /// <summary>
        /// Updates the product if found
        /// </summary>
        /// <param name="product">new data for a given product, ProductId is used to find... </param>
        /// <returns>true if found and updated, false if not found</returns>
        public bool UpdateProduct(Product product)
        {
            bool result = false;

            Product dbProduct = GetProduct(product.ProductID);

            if (dbProduct != null)
            {
                productRepository.UpdateProduct(product);
                result = true;
            }

            return result;
        }
    }
}
