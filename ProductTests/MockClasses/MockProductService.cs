using ProductsApi.Models;
using ProductsApi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTests.MockClasses
{
    public class MockProductService : IProductService
    {
        public int CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductList()
        {
            return new List<Product>{
                new Product{
                    ProductID = 1,
                    ProductName = "milk",
                    ProductDescription = "2%Milk",
                    UnitsInStock = 250,
                    SellPrice = 3.99m,
                    DiscountPercentage = 10,
                    UnitsMax = 1250
                },
                new Product{
                    ProductID = 2,
                    ProductName = "bread",
                    ProductDescription = "White",
                    UnitsInStock = 1050,
                    SellPrice = 4.99m,
                    DiscountPercentage = 5,
                    UnitsMax = 6250
                },
                new Product{
                    ProductID = 3,
                    ProductName = "butter",
                    ProductDescription = "unsalted",
                    UnitsInStock = 50,
                    SellPrice = 1.99m,
                    DiscountPercentage = 7,
                    UnitsMax = 500
                }
            };
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
