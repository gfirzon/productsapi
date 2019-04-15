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
        
        public void UpdateProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }
    }
}
